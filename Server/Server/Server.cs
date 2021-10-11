using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using Server.DTO;
using Server.DAO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Server
{
    public partial class Server : Form
    {
        private bool active = false;
        private Thread listener = null;
        private long id = 0;
        private struct MyClient
        {
            public long id;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
            public byte[] Secretkey;
            public List<Room> LRoom;
            public Account Acc;
        };
        private struct OnlineClient
        {
            public MyClient onl;
            public string username;
        }
        private OnlineClient Online;
        private ConcurrentDictionary<long, OnlineClient> accept = new ConcurrentDictionary<long, OnlineClient>();
        private ConcurrentDictionary<long, MyClient> list = new ConcurrentDictionary<long, MyClient>();
        private Task send = null;
        private Thread disconnect = null;
        private bool exit = false;
        #region crypto
        RSACryptoServiceProvider cryptoRSA;
        RSAParameters publicKey, privateKey;
        public void RSAlgorithm()
        {
            cryptoRSA = new RSACryptoServiceProvider(1024);
            publicKey = cryptoRSA.ExportParameters(false);
            privateKey = cryptoRSA.ExportParameters(true);
        }
        public static string GetKey(RSAParameters key)
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(sw, key);
            return sw.ToString();
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private string HashSHA256(string pass)
        {
            HashAlgorithm Sha2 = new SHA256CryptoServiceProvider();
            byte[] dataArray = Encoding.UTF8.GetBytes(pass);
            byte[] Shabyte2 = Sha2.ComputeHash(dataArray);
            return ByteArrayToString(Shabyte2);
        }
        public string EncryptDES(string source, byte[] key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(key);
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Encoding.UTF8.GetBytes(source);

            string encoded =
                Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return encoded;
        }
        public string DecryptDES(string encodedText, byte[] key)
        {
            using (TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider())
            {
                MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

                byte[] byteHash;
                byte[] byteBuff;

                byteHash = hashMD5Provider.ComputeHash(key);
                desCryptoProvider.Key = byteHash;
                desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Convert.FromBase64String(encodedText);

                string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                return plaintext;
            }
        }
        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
        #endregion
        public Server()
        {
            InitializeComponent();
        }
        #region Method
        #endregion
        private void LogWrite(string msg = null)
        {
            if (!exit)
            {
                logTextBox.Invoke((MethodInvoker)delegate
                {
                    if (msg == null)
                    {
                        logTextBox.Clear();
                    }
                    else
                    {
                        if (logTextBox.Text.Length > 0)
                        {
                            logTextBox.AppendText(Environment.NewLine);
                        }
                        logTextBox.AppendText(DateTime.Now.ToString("HH:mm") + " " + msg);
                    }
                });
            }
        }

        private void Active(bool status)
        {
            if (!exit)
            {
                startButton.Invoke((MethodInvoker)delegate
                {
                    active = status;
                    if (status)
                    {
                        startButton.Text = "Stop";
                        LogWrite("[/ Server started /]");
                    }   
                    else
                    {
                        startButton.Text = "Start";
                        LogWrite("[/ Server stopped /]");
                    }
                });
            }
        }

        private void Read(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    LogWrite(string.Format("[/ {0} /]", ex.Message));
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        
                       obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);

                    }
                    else
                    {
                        string msg = string.Format("<- Client {0} -> {1}", obj.id, obj.data);
                        LogWrite(msg);
                        obj.handle.Set();
                    }
                    
                }
                catch (Exception ex)
                {
                    
                    obj.data.Clear();
                    LogWrite(string.Format("[/ {0} /]", ex.Message));
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }
     
        private void Connection(ref MyClient obj)
        {
            list.TryAdd(obj.id, obj);
            string msg = string.Format("[/ Client {0} connected /]", obj.id);
            string temp;
            LogWrite(msg);
            //TaskSend(msg, obj.id);
            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);
                    temp = obj.data.ToString();
                    if (temp.Contains("Connect"))
                    {
                        ConnectSend(0, obj, GetKey(publicKey));
                    }    
                    if (temp.Contains("Secretkey"))
                    {
                        temp = temp.Remove(0, 10);
                        byte[] buff = Convert.FromBase64String(temp);
                        obj.Secretkey = Decryption(buff, privateKey, false);       
                        foreach (KeyValuePair<long,MyClient> key in list)
                        {
                            if (key.Key == obj.id) list.TryUpdate(key.Key, obj, key.Value);
                        }    
                    }
                    if (temp.Contains("login"))
                    {
                        temp = temp.Remove(0, 6);
                        string[] tmp1 = temp.Split(new[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                        temp = "Us:" + tmp1[0] + "Pw: " + tmp1[1];
                        string user = DecryptDES(tmp1[0], obj.Secretkey);
                        string pass = DecryptDES(tmp1[1], obj.Secretkey);
                        pass = HashSHA256(pass);
                        if (AccountDAO.Instance.Login(user, pass))
                        {
                            ConnectSend(2, obj);
                            List<Room> roomlist = RoomDAO.Instance.LoadRoomClientList(user);
                            obj.Acc = AccountDAO.Instance.GetAccountByUserName(user);
                            Online = new OnlineClient();
                            obj.LRoom = roomlist;
                            Online.onl = obj;
                            Online.username = user;
                            ConnectSend(5, obj, EncryptDES(SerializeListRoom(obj.LRoom), obj.Secretkey));
                            accept.TryAdd(Online.onl.id,Online);
                            ConnectSend(6, obj, EncryptDES(SerializeAccount(obj.Acc), obj.Secretkey));
                        }
                        else ConnectSend(1, obj);
                        
                    }
                    if (temp.Contains("ChangeInfo"))
                    {
                        temp = temp.Remove(0, 11);
                        string[] tmp1 = temp.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < tmp1.Length; i++)
                            tmp1[i] = DecryptDES(tmp1[i], obj.Secretkey);
                        try
                        {
                            AccountDAO.Instance.UpdateAccount(obj.Acc.Username, tmp1[0], tmp1[1], tmp1[2], tmp1[3], tmp1[4]);
                            obj.Acc = AccountDAO.Instance.GetAccountByUserName(obj.Acc.Username);
                            ConnectSend(13, obj);
                            ConnectSend(6, obj, EncryptDES(SerializeAccount(obj.Acc), obj.Secretkey));
                        }
                        catch
                        {
                            ConnectSend(14, obj);
                        }
                        
                    }
                    if (temp.Contains("ChangePass"))
                    {
                        temp = temp.Remove(0, 11);
                        string[] tmp1 = temp.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                        string user = DecryptDES(tmp1[0], obj.Secretkey);
                        string pass = DecryptDES(tmp1[1], obj.Secretkey);
                        string newpass = DecryptDES(tmp1[2], obj.Secretkey);
                        pass = HashSHA256(pass);
                        newpass = HashSHA256(newpass);
                        if (AccountDAO.Instance.Login(user, pass))
                        {
                            AccountDAO.Instance.PassChange(newpass, user);
                            ConnectSend(11, obj);
                        }
                        else
                        {
                            ConnectSend(12, obj);
                        }
                    }
                    if (temp.Contains("Register"))
                    {
                        temp = temp.Remove(0, 9);
                        string[] tmp1 = temp.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                        string user = DecryptDES(tmp1[0], obj.Secretkey);
                        string pass = DecryptDES(tmp1[1], obj.Secretkey);
                        pass = HashSHA256(pass);
                        string email = DecryptDES(tmp1[2], obj.Secretkey);
                        
                        if (AccountDAO.Instance.CheckAccount(user))
                        {
                            if (AccountDAO.Instance.Register(user,pass,email))
                            ConnectSend(4, obj);
                            else
                            {
                                ConnectSend(3, obj);
                            }
                        }
                        else
                        {
                            ConnectSend(3, obj);
                        }                            
                    }    
                    if (temp.Contains("Chat"))
                    {
                        temp = temp.Remove(0, 5);                   
                        string[] tmp1 = temp.Split(new[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                        string idRoom = DecryptDES(tmp1[0], obj.Secretkey);
                        string chat = DecryptDES(tmp1[1], obj.Secretkey);
                        if (!RoomDAO.Instance.CheckExistUser(obj.Acc.Username, Int32.Parse(idRoom)))
                        {
                            List<Account> AccountList = AccountDAO.Instance.LoadUserRoom(Int32.Parse(idRoom));
                            foreach (Account item in AccountList)
                            {

                                TaskSend(idRoom + "$" + chat, item.Username);
                            }
                        }    
                    }
                    if (temp.Contains("Join"))
                    {
                        temp = temp.Remove(0,5);
                        temp = DecryptDES(temp, obj.Secretkey);
                        if (RoomDAO.Instance.CheckRoom(Int32.Parse(temp)))
                        {
                            if (RoomDAO.Instance.CheckExistUser(obj.Acc.Username, Int32.Parse(temp)))
                            {
                                RoomDAO.Instance.UpdateJoin(Int32.Parse(temp), obj.Acc.Username);
                                List<Room> LR = RoomDAO.Instance.GetRoom(Int32.Parse(temp));
                                ConnectSend(7, obj);
                                Thread.Sleep(500);
                                ConnectSend(9, obj, EncryptDES(SerializeListRoom(LR), obj.Secretkey));
                            }
                            else
                            {
                                ConnectSend(10, obj);
                            }
                        }
                        else
                        {
                            ConnectSend(8, obj);
                        }      
                    }
                    if (temp.Contains("Create"))
                    {
                        temp = temp.Remove(0,7);
                        temp = DecryptDES(temp, obj.Secretkey);
                        RoomDAO.Instance.CreateRoom("4Dm1n");
                        int IdRoom = RoomDAO.Instance.GetIdRoom("4Dm1n");
                        RoomDAO.Instance.UpdateName(temp);
                        List<Room> LR = RoomDAO.Instance.GetRoom(IdRoom);
                        RoomDAO.Instance.UpdateJoin(IdRoom, obj.Acc.Username);
                        ConnectSend(9, obj, EncryptDES(SerializeListRoom(LR), obj.Secretkey));
                    }
                    if (temp.Contains("OutRoom"))
                    {
                        temp = temp.Remove(0, 8);
                        temp = DecryptDES(temp, obj.Secretkey);
                        if (RoomDAO.Instance.CheckRoom(Int32.Parse(temp)))
                        {
                            if (!RoomDAO.Instance.CheckExistUser(obj.Acc.Username, Int32.Parse(temp)))
                            {
                                RoomDAO.Instance.OutRoom(obj.Acc.Username, Int32.Parse(temp));
                                ConnectSend(15, obj);
                                Thread.Sleep(500);
                                ConnectSend(17, obj,EncryptDES(temp,obj.Secretkey));
                            }
                            else
                            {
                                ConnectSend(16, obj);
                            }
                        }    
                        else
                        {
                            ConnectSend(16, obj);
                        }                            
                    }    
                    obj.data.Clear();
                    obj.handle.WaitOne();
                }
                catch (Exception ex)
                {
                    LogWrite(string.Format("[/ {0} /]", ex.Message));
                    obj.data.Clear();
                }
            }
            obj.client.Close();
            msg = string.Format("[/ Client {0} disconnected /]", obj.id);
            LogWrite(msg);
            list.TryRemove(obj.id, out MyClient tmp);
            accept.TryRemove(obj.id, out OnlineClient Otmp);
        }

        private void Listener(IPAddress localaddr, int port)
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(localaddr, port);
                listener.Start();
                Active(true);
                while (active)
                {
                    if (listener.Pending())
                    {
                        try
                        {
                            MyClient obj = new MyClient();
                            obj.id = id;
                            obj.client = listener.AcceptTcpClient();
                            obj.stream = obj.client.GetStream();
                            obj.buffer = new byte[obj.client.ReceiveBufferSize];
                            obj.data = new StringBuilder();
                            obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                            obj.Acc = new Account();
                            Thread th = new Thread(() => Connection(ref obj))
                            {
                                IsBackground = true
                            };
                            th.Start();
                            id++;
                        }
                        catch (Exception ex)
                        {
                            LogWrite(string.Format("[/ {0} /]", ex.Message));
                        }
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                Active(false);
            }
            catch (Exception ex)
            {
                LogWrite(string.Format("[/ {0} /]", ex.Message));
            }
            finally
            {
                if (listener != null)
                {
                    listener.Server.Close();
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (active)
            {
                active = false;
            }
            else if (listener == null || !listener.IsAlive)
            {
                string address = "0.0.0.0";
                IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress iPAddress in localIP)
                {
                    if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        address = iPAddress.ToString();
                    }
                }
                localaddrMaskedTextBox.Text = address;
                bool localaddrResult = IPAddress.TryParse(address, out IPAddress localaddr);
                if (!localaddrResult)
                {
                    LogWrite("[/ Address is not valid /]");
                }
                bool portResult = int.TryParse(portTextBox.Text, out int port);
                if (!portResult)
                {
                    LogWrite("[/ Port number is not valid /]");
                }
                else if (port < 0 || port > 65535)
                {
                    portResult = false;
                    LogWrite("[/ Port number is out of range /]");
                }
                if (localaddrResult && portResult)
                {
                    listener = new Thread(() => Listener(localaddr, port))
                    {
                        IsBackground = true
                    };
                    listener.Start();
                    RSAlgorithm();
                }
            }
        }

        private void ConnectSend(int C, MyClient obj,string abcc = null)
        { 
            string tmp = "1" ;
            switch (C)
            {
                case 0:
                    tmp = "$Publickey$" + abcc;
                    LogWrite("Send Public Key");
                    break;
                case 1:
                    tmp = "login$Denied$";
                    break;
                case 2:
                    tmp = "login$Accepted$";
                    break;
                case 3:
                    tmp = "register$Failed$";
                    break;
                case 4:
                    tmp = "register$Success$";
                    break;
                case 5:
                    tmp = "room$" + abcc;
                    break;
                case 6:
                    tmp = "$info$" + abcc;
                    break;
                case 7:
                    tmp = "Join$Successfull";
                    break;
                case 8:
                    tmp = "Join$Denied1";
                    break;
                case 9:
                    tmp = "room$" + abcc;
                    break;
                case 10:
                    tmp = "Join$Denied2";
                    break;
                case 11:
                    tmp = "Pass$Success";
                    break;
                case 12:
                    tmp = "Pass$Failed";
                    break;
                case 13:
                    tmp = "ChangeInfo$Successful";
                    break;
                case 14:
                    tmp = "ChangeInfo$Failed";
                    break;
                case 15:
                    tmp = "OutRoom$Successfull";
                    break;
                case 16:
                    tmp = "OutRoom$Failed";
                    break;
                case 17:
                    tmp = "Out$" + abcc;
                    break;

            };
            LogWrite(tmp);
            TaskSend2(tmp, obj.id);
        }
        private string SerializeAccount(Account T)
        {
            
            var writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(Account));
            serializer.Serialize(writer, T);
            return writer.ToString();
        }
        private string SerializeListRoom(List<Room> T)
        {
            
            var writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
            serializer.Serialize(writer, T);
            return writer.ToString();
        }
        private void Write2(IAsyncResult result)
        {
            OnlineClient obj = (OnlineClient)result.AsyncState;
            if (obj.onl.client.Connected)
            {
                try
                {
                    obj.onl.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    LogWrite(string.Format("[/ {0} /]", ex.Message));
                }
            }
        }
        private void Send(string msg,string username)
        {
            foreach (KeyValuePair<long, OnlineClient> obj in accept)
            {
                if (username == obj.Value.username && obj.Value.onl.client.Connected )
                {
                    try
                    {
                        string[] tmp1 = msg.Split(new[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                        string text =EncryptDES(tmp1[1], obj.Value.onl.Secretkey);
                        byte[] buffer = Encoding.UTF8.GetBytes("chat$" + EncryptDES(tmp1[0],obj.Value.onl.Secretkey) +"$" + text);
                        obj.Value.onl.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write2), obj.Value);
                    }
                    catch (Exception ex)
                    {
                        LogWrite(string.Format("[/ {0} /]", ex.Message));
                    }
                }
            }
        }
        #region send
        private void Write(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    LogWrite(string.Format("[/ {0} /]", ex.Message));
                }
            }
        }
        private void Send2(string msg, long id = -1)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            foreach (KeyValuePair<long, MyClient> obj in list)
            {
                if (id == obj.Value.id && obj.Value.client.Connected)
                {
                    try
                    {
                        obj.Value.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), obj.Value);
                    }
                    catch (Exception ex)
                    {
                        LogWrite(string.Format("[/ {0} /]", ex.Message));
                    }
                }
            }
        }
        private void TaskSend2(string msg, long id)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => Send2(msg, id));
            }
            else
            {
                send.ContinueWith(antecendent => Send2(msg, id));
            }
        }
        #endregion
        private void TaskSend(string msg, string username)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => Send(msg, username));
            }
            else
            {
                send.ContinueWith(antecendent => Send(msg, username));
            }
        }
       
        private void SendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (sendTextBox.Text.Length > 0)
                {
                    string msg = sendTextBox.Text;
                    sendTextBox.Clear();
                    LogWrite("<- Server (You) -> " + msg);
                    TaskSend("<- Server -> " + msg,"guess");
                }
            }
        }

        private void Disconnect()
        {
            foreach (KeyValuePair<long, MyClient> obj in list)
            {
                obj.Value.client.Close();
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (disconnect == null || !disconnect.IsAlive)
            {
                disconnect = new Thread(() => Disconnect())
                {
                    IsBackground = true
                };
                disconnect.Start();
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            active = false;
            if (disconnect == null || !disconnect.IsAlive)
            {
                disconnect = new Thread(() => Disconnect())
                {
                    IsBackground = true
                };
                disconnect.Start();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LogWrite();
        }
    }
}
