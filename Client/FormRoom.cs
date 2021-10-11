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
using System.Collections.Concurrent;

namespace Client
{
    public partial class FormRoom : Form
    {
        Myclient obj;
        List<Room> LR;
        private ConcurrentDictionary<long, Chat > chatqueue = new ConcurrentDictionary<long, Chat>();
        public FormRoom(Myclient myclient)
        {
            InitializeComponent();
            Plus.IconColor = ThemeColor.PrimaryColor;
            Join.IconColor = ThemeColor.PrimaryColor;
            OutRoomBt.IconColor = ThemeColor.PrimaryColor;
            this.obj = myclient;
            LR = new List<Room>();
            Thread thread = new Thread(Listen) { IsBackground = true };
            thread.Start();
        }
        private void Listen()
        {
            while (obj.Client.Connected)
            {
                string tmp = obj.Datareturn("room");
                if (tmp != "")
                {
                    string room = DecryptDES(tmp, obj.Secretkey);
                    StringReader read = new StringReader(room);
                    XmlSerializer ser = new XmlSerializer(typeof(List<Room>));
                    List<Room> temp = (List<Room>)ser.Deserialize(read);
                    foreach (Room item in temp)
                    {
                        IconButton btn = new IconButton();
                        #region create button
                        btn.FlatAppearance.BorderSize = 0;
                        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
                        btn.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
                        btn.IconChar = FontAwesome.Sharp.IconChar.FacebookMessenger;
                        btn.IconColor = System.Drawing.Color.Blue;
                        btn.IconSize = 50;
                        //btn.Location = new System.Drawing.Point(3, 3);
                        btn.Name = "iconButton1";
                        btn.Rotation = 0D;
                        btn.Size = new System.Drawing.Size(74, 80);
                        btn.TabIndex = 0;
                        btn.Text =item.Name;
                        btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                        btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                        btn.UseVisualStyleBackColor = true;
                        btn.Click += Btn_Click;
                        btn.Tag = item;
                        #endregion
                        if (flowLayoutPanel1.InvokeRequired)
                        {
                            flowLayoutPanel1.Invoke((MethodInvoker)delegate
                            {
                                flowLayoutPanel1.Controls.Add(btn);
                            });
                        }    
                        else
                        {
                            flowLayoutPanel1.Controls.Add(btn);
                        }    
                        Chat chat = new Chat(obj, item.ID,item.Name);
                        chatqueue.TryAdd(item.ID, chat);
                    }
                }
                string tmp2 = obj.Datareturn("Out");
                if (tmp2 != "")
                {
                    string room = DecryptDES(tmp2, obj.Secretkey);
                    long idRoom = long.Parse(room);
                    foreach ( KeyValuePair<long , Chat> item in chatqueue)
                        if (item.Key == idRoom )
                        {
                            chatqueue.TryRemove(item.Key, out Chat Chat1);
                            this.RemoveOwnedForm(Chat1);
                        }
                    foreach (IconButton btn in flowLayoutPanel1.Controls)
                    {
                        int roomid = (btn.Tag as Room).ID;
                        if (roomid == idRoom)
                        {
                            if (flowLayoutPanel1.InvokeRequired)
                            {
                                flowLayoutPanel1.Invoke((MethodInvoker)delegate
                                {
                                    flowLayoutPanel1.Controls.Remove(btn);
                                });
                            }
                            else
                            {
                                flowLayoutPanel1.Controls.Remove(btn);
                            }
                        }                            
                    }    
                }    
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int roomid = ((sender as IconButton).Tag as Room).ID;
            foreach (KeyValuePair<long,Chat> item in chatqueue)
            {
                if (item.Key == roomid) item.Value.Show();
            }    
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

        private void Plus_Click(object sender, EventArgs e)
        {
            CreateRoom create = new CreateRoom(obj);
            create.Show();
        }

        private void Join_Click(object sender, EventArgs e)
        {
            Join join = new Join(obj);
            join.Show();
        }

        private void OutRoomBt_Click(object sender, EventArgs e)
        {
            OutRoom outRoom = new OutRoom(obj);
            outRoom.Show();
        }
    }

}
