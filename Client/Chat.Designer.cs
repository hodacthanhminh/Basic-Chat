namespace Client
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.titlepanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Sendicon = new FontAwesome.Sharp.IconPictureBox();
            this.fileAttach = new FontAwesome.Sharp.IconPictureBox();
            this.titlepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sendicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileAttach)).BeginInit();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.AllowDrop = true;
            this.logTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.Location = new System.Drawing.Point(0, 31);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(312, 313);
            this.logTextBox.TabIndex = 30;
            this.logTextBox.TabStop = false;
            // 
            // sendTextBox
            // 
            this.sendTextBox.BackColor = System.Drawing.Color.White;
            this.sendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sendTextBox.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendTextBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.sendTextBox.Location = new System.Drawing.Point(2, 348);
            this.sendTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendTextBox.Size = new System.Drawing.Size(237, 19);
            this.sendTextBox.TabIndex = 32;
            this.sendTextBox.TabStop = false;
            // 
            // titlepanel
            // 
            this.titlepanel.Controls.Add(this.label4);
            this.titlepanel.Controls.Add(this.label3);
            this.titlepanel.Controls.Add(this.label1);
            this.titlepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlepanel.Location = new System.Drawing.Point(0, 0);
            this.titlepanel.Name = "titlepanel";
            this.titlepanel.Size = new System.Drawing.Size(312, 30);
            this.titlepanel.TabIndex = 34;
            this.titlepanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltitleBar_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(266, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "O";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(289, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "O";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Sendicon
            // 
            this.Sendicon.BackColor = System.Drawing.SystemColors.Control;
            this.Sendicon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Sendicon.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.Sendicon.IconColor = System.Drawing.SystemColors.ControlText;
            this.Sendicon.IconSize = 26;
            this.Sendicon.Location = new System.Drawing.Point(282, 347);
            this.Sendicon.Name = "Sendicon";
            this.Sendicon.Size = new System.Drawing.Size(26, 26);
            this.Sendicon.TabIndex = 35;
            this.Sendicon.TabStop = false;
            this.Sendicon.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // fileAttach
            // 
            this.fileAttach.BackColor = System.Drawing.SystemColors.Control;
            this.fileAttach.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileAttach.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.fileAttach.IconColor = System.Drawing.SystemColors.ControlText;
            this.fileAttach.IconSize = 26;
            this.fileAttach.Location = new System.Drawing.Point(250, 347);
            this.fileAttach.Name = "fileAttach";
            this.fileAttach.Size = new System.Drawing.Size(26, 26);
            this.fileAttach.TabIndex = 36;
            this.fileAttach.TabStop = false;
            // 
            // Chat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(312, 373);
            this.Controls.Add(this.fileAttach);
            this.Controls.Add(this.Sendicon);
            this.Controls.Add(this.titlepanel);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.logTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.titlepanel.ResumeLayout(false);
            this.titlepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sendicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileAttach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Panel titlepanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox Sendicon;
        private FontAwesome.Sharp.IconPictureBox fileAttach;
        private System.Windows.Forms.Label label4;
    }
}