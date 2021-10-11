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
    public partial class Register : Form
    {
        private Random random;
        private int tempIndex;
        private Myclient obj;
        public Register(ref Myclient myclient)
        {
            random = new Random();
            this.obj = myclient;
            InitializeComponent();
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
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                }
            }
            label1.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            titlepanel.BackColor = ThemeColor.ChangeColorBrightness(color,-0.05);
        }
        private void Register_Load(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text!= null)
            {
                bool check = false;
                string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                foreach (var item in specialChar)
                {
                    if (textBox1.Text.Contains(item))
                    {
                        check = true;
                        break;
                    }    
                }
                if (check)
                {
                    label5.Visible = true;
                    label5.Text = "Username just include (a-z, A-Z, 0-9)!";
                }
                else label5.Visible = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 5 || textBox1.Text.Length > 15)
            {
                label5.Visible = true;
                label5.Text = "Username must include 6 - 15 character!";
            }
            else
            {
                label5.Visible = false;
            }                
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (textBox2.Text != textBox3.Text || textBox3.Text == "")
            {
                label6.Visible = true;
                label6.Text = "Password not correct!";
            }
            else
            {
                label6.Visible = false;
            }                
             
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                label8.Visible = true;
                label8.Text = "Password can not be null";
            }    
            else
            {
                label8.Visible = false;
            }                
        }

        private void RegisterBt_Click(object sender, EventArgs e)
        {
            if (!label5.Visible && !label6.Visible && !label8.Visible)
            {
                string username = EncryptDES(textBox1.Text, obj.Secretkey);
                string password = EncryptDES(textBox2.Text, obj.Secretkey);
                string email = EncryptDES(textBox4.Text, obj.Secretkey);
                label7.Visible = false;
                obj.TaskSend("Register@" + username + "@" + password + "@" + email);
                string result = "";
                while (obj.Client.Connected)
                {
                    result = obj.Datareturn("register");
                    if (result != "")
                    {
                        if (result.Contains("Success"))
                        {
                            label7.Visible = true;
                            label7.Text = "Success";
                            label7.ForeColor = Color.ForestGreen;

                        }
                        else
                        {
                            if (result.Contains("Failed"))
                            {
                                label7.Visible = true;
                                label7.Text = "Fail";
                                label7.ForeColor = Color.Coral;
                            }
                        }
                        break;
                    }
                    
                }    
                 
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text =="")
            {
                label9.Visible = true;
                label9.Text = "Email can not be null";
            }    
            else
            {
                label9.Visible = false;
            }                
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResizeBt_Click(object sender, EventArgs e)
        {

        }

        private void MinimizeBt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Register_Resize(object sender, EventArgs e)
        {

        }
    }
}