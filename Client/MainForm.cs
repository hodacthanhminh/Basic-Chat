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
    public partial class MainForm : Form
    {
        #region Declare
        Myclient obj;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm = null;
        GameForm Gf;
        Info inf;
        FormRoom chat;
        Passchange set;
        #endregion
        #region theme
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
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelTool.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    previousBtn.BackColor = ExitBt.BackColor;
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
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
        #endregion
        #region Event
        private void infoBt_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (activeForm != null) activeForm.Hide();
            activeForm = inf;
            inf.TopLevel = false;
            inf.FormBorderStyle = FormBorderStyle.None;
            inf.Dock = DockStyle.Fill;
            inf.BringToFront();
            inf.Show();
            panelMenu.Controls.Add(inf);
        }

        private void ChatBt_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (activeForm != null) activeForm.Hide();
            activeForm = chat;
            chat.TopLevel = false;
            chat.FormBorderStyle = FormBorderStyle.None;
            chat.Dock = DockStyle.Fill;
            chat.BringToFront();
            chat.Show();
            panelMenu.Controls.Add(chat);
        }
        private void SettingBt_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (activeForm != null) activeForm.Hide();
            activeForm = set;
            set.TopLevel = false;
            set.FormBorderStyle = FormBorderStyle.None;
            set.Dock = DockStyle.Fill;
            set.BringToFront();
            set.Show();
            panelMenu.Controls.Add(set);
        }
        private void ExitBt_Click(object sender, EventArgs e)
        {
            obj.Client.Dispose();
            this.Close();
        }
        private void outBt_Click(object sender, EventArgs e)
        {
            obj.Client.Dispose();
            this.Close();
        }
        private void MinimizeBt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void GameBt_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (activeForm != null) activeForm.Hide();
            activeForm = Gf;
            Gf.TopLevel = false;
            Gf.FormBorderStyle = FormBorderStyle.None;
            Gf.Dock = DockStyle.Fill;
            Gf.BringToFront();
            Gf.Show();
            panelMenu.Controls.Add(Gf);
        }
        private void HomeBt_Click(object sender, EventArgs e)
        {
            DisableButton();
            if (activeForm != null) activeForm.Hide();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Color color = SelectThemeColor();
            panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.05);
            ExitBt.BackColor = color;
            infoBt.BackColor = color;
            ChatBt.BackColor = color;
            SettingBt.BackColor = color;
            GameBt.BackColor = color;
            HomeBt.BackColor = color;
            ThemeColor.FormColor = color;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RemoveOwnedForm(Gf);
            this.RemoveOwnedForm(chat);
            this.RemoveOwnedForm(inf);
            this.RemoveOwnedForm(set);
        }
        #endregion
        public MainForm(Myclient myclient)
        {
            this.obj = myclient;
            random = new Random();
            Gf = new GameForm();
            chat = new FormRoom(obj);
            inf = new Info(obj);
            set = new Passchange(obj);
            InitializeComponent();
            nameUser.Text = obj.Username;
        }
    }
}
