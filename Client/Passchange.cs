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
    public partial class Passchange : Form
    {
        Myclient obj;
        public Passchange(Myclient myclient)
        {
            this.obj = myclient;
            InitializeComponent();
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
            if (textBox2.Text == "")
            {
                label8.Visible = true;
                label8.Text = "Password can not be null";
            }
            else
            {
                label8.Visible = false;
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
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (!label5.Visible && !label6.Visible && !label8.Visible)
            {
                string username = EncryptDES(obj.Username, obj.Secretkey);
                string password = EncryptDES(textBox1.Text, obj.Secretkey);
                string newpassword = EncryptDES(textBox2.Text, obj.Secretkey);
                label7.Visible = false;
                obj.TaskSend("ChangePass$" + username + "@" + password + "@" + newpassword);
                string result = "";
                while (obj.Client.Connected)
                {
                    result = obj.Datareturn("Pass");
                    if (result !="")
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
    }
}
