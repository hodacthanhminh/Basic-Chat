using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Net.Security;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.InteropServices;
using System.Net.Configuration;
using System.CodeDom.Compiler;

namespace Client
{
    public class Myclient : IDisposable
    {
        private static Mutex mut = new Mutex();
        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer;
        private StringBuilder data;
        private EventWaitHandle handle;
        private byte[] secretkey;
        private string username;
        private Account account;
        private Task send = null;
        RSAParameters ServerPU;
        private ConcurrentDictionary<string, String> dataqueue = new ConcurrentDictionary<string, string>();

        private static Myclient instance;
        public TcpClient Client { get => client; set => client = value; }
        public NetworkStream Stream { get => stream; set => stream = value; }
        public byte[] Buffer { get => buffer; set => buffer = value; }
        public StringBuilder Data { get => data; set => data = value; }
        public EventWaitHandle Handle { get => handle; set => handle = value; }
        public byte[] Secretkey { get => secretkey; set => secretkey = value; }
        public string Username { get => username; set => username = value; }
        public static Myclient Instance {
            get { if (instance == null) instance = new Myclient(); return Myclient.instance; }
            private set { Myclient.instance = value; }
        }

        public Account Account { get => account; set => account = value; }

        public Myclient()
        {
            try
            {
                secretkey = CreateSecretkey();
                username = "Guest";
                client = new TcpClient();
                client.Connect("192.168.0.29", 9000);
                client.NoDelay = true;
                data = new StringBuilder();
                handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                stream = client.GetStream();
                Account = new Account();
                buffer = new byte[client.ReceiveBufferSize];
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
            TaskSend("Connect");
            Thread listen = new Thread(Listen)
            {
                IsBackground = true
            };
            listen.Start();
        }
        private void Listen()
        {
            while (client.Connected)
            {
                try
                {
                    mut.WaitOne();
                    stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(Read), null);
                    mut.ReleaseMutex();
                    handle.WaitOne();
                }
                catch
                {
                    client.Close();
                }
            }
            //MessageBox.Show("LostConnect!");
            client.Close();
            
        }
        private void Write(IAsyncResult result)
        {
            try
            {
                stream.EndWrite(result);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi hàm write");
            }
        }
        private void Send(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            try
            {
                stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), null);
            }
            catch (Exception ex)
            {
               //MessageBox.Show(ex.Message, "Lỗi hàm send");
            }
        }
        public void TaskSend(string msg)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => Send(msg));
            }
            else
            {
                send.ContinueWith(antecendent => Send(msg));
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        private void Read(IAsyncResult result)
        {
            int bytes = 0;
            if (client.Connected)
            {
                try
                {
                    bytes = stream.EndRead(result);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Lỗi read");
                    data.Clear();
                }
            }
            if (bytes > 0)
            {
                data.AppendFormat("{0}", Encoding.UTF8.GetString(buffer, 0, bytes));
                try
                {
                    if (stream.DataAvailable)
                    {
                        stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(Read), null);
                    }
                    else
                    {
                        int a = 0;
                        string msg = data?.ToString() ?? "";
                        string[] recieve = msg.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                        if (recieve[0].Contains("Publickey"))
                        {
                            GetKey(recieve[1]);
                            byte[] buff = Encryption(secretkey, ServerPU, false);
                            TaskSend("Secretkey$" + Convert.ToBase64String(buff));
                            data.Clear();
                        }
                        if (recieve[0].Contains("login"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("register"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("chat"))
                        {
                            recieve[1] = DecryptDES(recieve[1], secretkey);
                            dataqueue.TryAdd(recieve[1], recieve[2]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("room"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("Join"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("info"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("Pass"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("ChangeInfo"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }
                        if (recieve[0].Contains("OutRoom"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }    
                        if (recieve[0].Contains("Out"))
                        {
                            dataqueue.TryAdd(recieve[0], recieve[1]);
                            data.Clear();
                        }    
                        handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    data.Clear();
                    //MessageBox.Show(ex.Message, "Lỗi read 2");
                    handle.Set();
                }
            }
            else
            {
                client.Close();
                handle.Set();
            }
        }
        #region cryptol
        public string Datareturn(string key)
        {
    
            if (dataqueue.Count == 0) return "";
            string temp = "";
            foreach(KeyValuePair <string,string> data in dataqueue)
            {
                if (data.Key == key)
                {
                    dataqueue.TryRemove(data.Key, out temp);
                }
            }
            
            return temp;
        }
        public void GetKey(string msg)
        {
            var sr = new StringReader(msg);
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            ServerPU = (RSAParameters)xmlSerializer.Deserialize(sr);
        }
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
        private byte[] CreateSecretkey()
        {
            using (var radom = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[64];
                radom.GetBytes(bytes);
                return bytes;
            }
        }
        private string EncryptDES(string source, byte[] key)
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
        private string DecryptDES(string encodedText, byte[] key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
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
        #endregion
    }
}
