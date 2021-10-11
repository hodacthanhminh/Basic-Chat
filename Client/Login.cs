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
    public partial class Login : Form
    {
        #region Declare
        Myclient obj;
        private Random random;
        private int tempIndex;
        #endregion
        public Login()
        {
            random = new Random();
            InitializeComponent();
        }
        #region theme
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void paneltitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void LoadTheme()
        {
            Color color = SelectThemeColor();
            ThemeColor.PrimaryColor = color;
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = color;
                    btn.ForeColor = Color.White;
                }
                if (btns.GetType() == typeof(Label))
                {
                    btns.ForeColor = color;
                }
            }
            titlepanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.05);
        }
        #endregion
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
        #region Event
        private void LoginBt_Click(object sender, EventArgs e)
        {
            notilogin.Visible = false;
            string user = EncryptDES(usernameTb.Text, obj.Secretkey);
            string pass = EncryptDES(passwordTb.Text, obj.Secretkey);
            obj.TaskSend("login" + "$" + user + "$" + pass);
            string result = "";
            while (obj.Client.Connected)
            {
                result = obj.Datareturn("login");
                if (result !="")
                {
                    if (result.Contains("Accept"))
                    {
                        notilogin.Visible = true;
                        notilogin.Text = "Successful";
                        notilogin.ForeColor = Color.ForestGreen;
                        obj.Username = usernameTb.Text;
                        timer1.Enabled = true;
                        notilogin.Visible = false;
                        timer1.Start();
                    }
                    else
                    {
                        if (result.Contains("Denied"))
                        {
                            notilogin.Visible = true;
                            notilogin.Text = "Password or Username is not correct!";
                            notilogin.ForeColor = Color.Coral;
                        }
                    }
                    break;
                }
                
            }    
            
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            obj = new Myclient();
            LoadTheme();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            this.Hide();
            MainForm mf = new MainForm(obj);
            mf.ShowDialog();
            this.Show();
            obj = new Myclient();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            obj.Client.Dispose();
            Environment.Exit(0);
            this.Close();
        }
        private void Register_Click(object sender, EventArgs e)
        {
            Register register = new Register(ref obj);
            register.Show();
        }
        private void MinimizeBt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}
