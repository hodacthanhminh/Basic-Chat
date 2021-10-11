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
    public partial class Info : Form
    {
        #region Declare
        Myclient obj;
        bool update = false;
        #endregion
        public Info(Myclient myclient)
        {
            this.obj = myclient;
            InitializeComponent();
        }
        #region Crypto
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
        #endregion
        #region Act func 
        private void UpdateData()
        {
            firstnameTb.Invoke((MethodInvoker)delegate
            {
                firstnameTb.Text = obj.Account.Firstname;
            });
            LastNameTb.Invoke((MethodInvoker)delegate
            {
                LastNameTb.Text = obj.Account.Lastname;
            });
            TelephoneTb.Invoke((MethodInvoker)delegate
            {
                TelephoneTb.Text = obj.Account.Telephone;
            });
            AddressTexbox.Invoke((MethodInvoker)delegate
            {
                AddressTexbox.Text = obj.Account.Address;
            });
            MailTb.Invoke((MethodInvoker)delegate
            {
                MailTb.Text = obj.Account.Email;
            });
        }
        private void Listen()
        {
            while(obj.Client.Connected)
            {
                string result = "";
                result = obj.Datareturn("info");
                if (result != "")
                {
                    string acc = DecryptDES(result, obj.Secretkey);
                    StringReader read = new StringReader(acc);
                    XmlSerializer ser = new XmlSerializer(typeof(Account));
                    obj.Account = (Account)ser.Deserialize(read);
                    UpdateData();
                }
            }    
        }
        #endregion
        #region Event
        private void updateBt_Click(object sender, EventArgs e)
        {
            notiinfo.Visible = false;
            if (update ==false)
            {
                firstnameTb.Enabled = true;
                LastNameTb.Enabled = true;
                TelephoneTb.Enabled = true;
                AddressTexbox.Enabled = true;
                MailTb.Enabled = true;
                update = true;
                updateBt.Text = "Update";
            }
            else
            {
                string fn = EncryptDES(firstnameTb.Text, obj.Secretkey);
                string ln = EncryptDES(LastNameTb.Text, obj.Secretkey);
                string tele = EncryptDES(TelephoneTb.Text, obj.Secretkey);
                string email = EncryptDES(MailTb.Text, obj.Secretkey);
                string home = EncryptDES(AddressTexbox.Text, obj.Secretkey);
                obj.TaskSend(string.Format("ChangeInfo$@{0}@{1}@{2}@{3}@{4}",fn,ln,tele,email,home));
                firstnameTb.Enabled = false;
                LastNameTb.Enabled = false;
                TelephoneTb.Enabled = false;
                AddressTexbox.Enabled = false;
                MailTb.Enabled = false;
                update = false;
                updateBt.Text = "ChangeInfo";
                string result = "";
                while (obj.Client.Connected)
                {
                    result = obj.Datareturn("ChangeInfo");
                    if (result != "")
                    {
                        notiinfo.Visible = true;
                        notiinfo.Text = result;
                        if (result.Contains("Successful"))
                        {
                            notiinfo.ForeColor = Color.ForestGreen;
                        }
                        else
                        {                     
                            notiinfo.ForeColor = Color.Coral;
                            UpdateData();
                        }
                        break;
                    }
                }
            }
        }
        private void Info_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Listen) { IsBackground = true };
            thread.Start();
        }
        #endregion
    }
}
