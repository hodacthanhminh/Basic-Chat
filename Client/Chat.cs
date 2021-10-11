using System;
using System.Collections.Generic;
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


namespace Client
{
    public partial class Chat : Form
    {
        private bool exit = false;
        Myclient obj;
        public int id;
        public string name;
        public Chat(Myclient myclient, int idroom, string name)
        {
            this.obj = myclient;
            this.id = idroom;
            this.Name = name;
            InitializeComponent();
            label4.Text = "Room:" + name + " Id:" + id;
            Thread list = new Thread(Star) { IsBackground = true };
            list.Start();
        }
        private void LoadTheme()
        {
            
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                }
                if (btns.GetType() == typeof(Label))
                {
                    btns.ForeColor = ThemeColor.PrimaryColor;
                }
            }
            titlepanel.BackColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, -0.05);
            Sendicon.ForeColor = ThemeColor.PrimaryColor;
            fileAttach.ForeColor = ThemeColor.PrimaryColor;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void paneltitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void LogWrite(string msg = null)
        {
            if (!exit)
            {
                try
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
                catch
                {

                }
               
            }
        }
        private void Star()
        {
            while (obj.Client.Connected)
            {
                string tmp = obj.Datareturn(id.ToString());
                if (tmp != "")
                {
                    string msg = DecryptDES(tmp, obj.Secretkey);
                    if (!msg.Contains(obj.Username)) LogWrite(msg);
                }
            }    
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        #region crypto
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (sendTextBox.Text.Length > 0)
            {
                string text = string.Format("<- {0} -> {1}", obj.Username, sendTextBox.Text);
                string msg = EncryptDES(text, obj.Secretkey);
                LogWrite("<- You -> " + sendTextBox.Text);
                sendTextBox.Clear();
                if (obj.Client.Connected)
                {
                    obj.TaskSend("Chat$"+EncryptDES(this.id.ToString(),obj.Secretkey)+  "$" + msg);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
