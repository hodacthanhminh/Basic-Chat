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
using FontAwesome.Sharp;


namespace Client
{
    public partial class OutRoom : Form
    {
        Myclient obj;
        public OutRoom(Myclient myclient)
        {
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
        private void LoadTheme()
        {

            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(IconPictureBox))
                {
                    IconPictureBox btn = (IconPictureBox)btns;
                    btn.IconColor = ThemeColor.PrimaryColor;
                }
                if (btns.GetType() == typeof(Label))
                {
                    btns.ForeColor = ThemeColor.PrimaryColor;
                }
                toppanel.BackColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, -0.05);
            }
        }

        private void outBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendBt_Click(object sender, EventArgs e)
        {
            if (idRoom.Text != "")
            {
                noti.Visible = false;
                obj.TaskSend("OutRoom$" + EncryptDES(idRoom.Text, obj.Secretkey));
                string tmp = "";
                while (obj.Client.Connected)
                {
                    tmp = obj.Datareturn("OutRoom");
                    if (tmp != "")
                    {
                        if (tmp.Contains("Successfull"))
                        {
                            noti.Visible = true;
                            noti.Text = tmp;
                            noti.ForeColor = Color.ForestGreen;
                        }
                        if (tmp.Contains("Failed"))
                        {
                            noti.Visible = true;
                            noti.ForeColor = Color.Coral;
                            noti.Text = "Not in room";
                        }
                        break;
                    }
                }
            }    
            else
            {
                noti.Visible = true;
                noti.Text = "Enter IdRoom";
                noti.ForeColor = Color.Yellow;
            }
            
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

        private void OutRoom_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
