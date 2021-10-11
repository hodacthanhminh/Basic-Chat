namespace Client
{
    partial class MainForm
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
            this.panelLogo = new System.Windows.Forms.Panel();
            this.nameUser = new System.Windows.Forms.Label();
            this.MinimizeBt = new System.Windows.Forms.Label();
            this.outBt = new System.Windows.Forms.Label();
            this.panelTool = new System.Windows.Forms.Panel();
            this.GameBt = new FontAwesome.Sharp.IconButton();
            this.SettingBt = new FontAwesome.Sharp.IconButton();
            this.HomeBt = new FontAwesome.Sharp.IconButton();
            this.ChatBt = new FontAwesome.Sharp.IconButton();
            this.infoBt = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ExitBt = new FontAwesome.Sharp.IconButton();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo.SuspendLayout();
            this.panelTool.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Black;
            this.panelLogo.Controls.Add(this.nameUser);
            this.panelLogo.Controls.Add(this.MinimizeBt);
            this.panelLogo.Controls.Add(this.outBt);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(330, 30);
            this.panelLogo.TabIndex = 3;
            this.panelLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltitleBar_MouseDown);
            // 
            // nameUser
            // 
            this.nameUser.AutoSize = true;
            this.nameUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameUser.ForeColor = System.Drawing.Color.White;
            this.nameUser.Location = new System.Drawing.Point(13, 4);
            this.nameUser.Name = "nameUser";
            this.nameUser.Size = new System.Drawing.Size(45, 16);
            this.nameUser.TabIndex = 4;
            this.nameUser.Text = "label1";
            // 
            // MinimizeBt
            // 
            this.MinimizeBt.AutoSize = true;
            this.MinimizeBt.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBt.ForeColor = System.Drawing.Color.White;
            this.MinimizeBt.Location = new System.Drawing.Point(284, 0);
            this.MinimizeBt.Name = "MinimizeBt";
            this.MinimizeBt.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBt.TabIndex = 3;
            this.MinimizeBt.Text = "O";
            this.MinimizeBt.Click += new System.EventHandler(this.MinimizeBt_Click);
            // 
            // outBt
            // 
            this.outBt.AutoSize = true;
            this.outBt.BackColor = System.Drawing.Color.Transparent;
            this.outBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.outBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outBt.ForeColor = System.Drawing.Color.White;
            this.outBt.Location = new System.Drawing.Point(307, 0);
            this.outBt.Name = "outBt";
            this.outBt.Size = new System.Drawing.Size(23, 23);
            this.outBt.TabIndex = 2;
            this.outBt.Text = "O";
            this.outBt.Click += new System.EventHandler(this.outBt_Click);
            // 
            // panelTool
            // 
            this.panelTool.BackColor = System.Drawing.Color.Transparent;
            this.panelTool.Controls.Add(this.GameBt);
            this.panelTool.Controls.Add(this.SettingBt);
            this.panelTool.Controls.Add(this.HomeBt);
            this.panelTool.Controls.Add(this.ChatBt);
            this.panelTool.Controls.Add(this.infoBt);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Location = new System.Drawing.Point(0, 30);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(330, 50);
            this.panelTool.TabIndex = 7;
            // 
            // GameBt
            // 
            this.GameBt.BackColor = System.Drawing.Color.DimGray;
            this.GameBt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameBt.FlatAppearance.BorderSize = 0;
            this.GameBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GameBt.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.GameBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameBt.ForeColor = System.Drawing.Color.Transparent;
            this.GameBt.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.GameBt.IconColor = System.Drawing.Color.White;
            this.GameBt.IconSize = 25;
            this.GameBt.Location = new System.Drawing.Point(132, 0);
            this.GameBt.Name = "GameBt";
            this.GameBt.Rotation = 0D;
            this.GameBt.Size = new System.Drawing.Size(66, 50);
            this.GameBt.TabIndex = 2;
            this.GameBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GameBt.UseVisualStyleBackColor = false;
            this.GameBt.Click += new System.EventHandler(this.GameBt_Click);
            // 
            // SettingBt
            // 
            this.SettingBt.BackColor = System.Drawing.Color.DimGray;
            this.SettingBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingBt.FlatAppearance.BorderSize = 0;
            this.SettingBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingBt.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SettingBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingBt.ForeColor = System.Drawing.Color.Transparent;
            this.SettingBt.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.SettingBt.IconColor = System.Drawing.Color.White;
            this.SettingBt.IconSize = 25;
            this.SettingBt.Location = new System.Drawing.Point(198, 0);
            this.SettingBt.Name = "SettingBt";
            this.SettingBt.Rotation = 0D;
            this.SettingBt.Size = new System.Drawing.Size(66, 50);
            this.SettingBt.TabIndex = 1;
            this.SettingBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SettingBt.UseVisualStyleBackColor = false;
            this.SettingBt.Click += new System.EventHandler(this.SettingBt_Click);
            // 
            // HomeBt
            // 
            this.HomeBt.BackColor = System.Drawing.Color.DimGray;
            this.HomeBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.HomeBt.FlatAppearance.BorderSize = 0;
            this.HomeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBt.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.HomeBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBt.ForeColor = System.Drawing.Color.Transparent;
            this.HomeBt.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.HomeBt.IconColor = System.Drawing.Color.White;
            this.HomeBt.IconSize = 25;
            this.HomeBt.Location = new System.Drawing.Point(264, 0);
            this.HomeBt.Name = "HomeBt";
            this.HomeBt.Rotation = 0D;
            this.HomeBt.Size = new System.Drawing.Size(66, 50);
            this.HomeBt.TabIndex = 0;
            this.HomeBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HomeBt.UseVisualStyleBackColor = false;
            this.HomeBt.Click += new System.EventHandler(this.HomeBt_Click);
            // 
            // ChatBt
            // 
            this.ChatBt.BackColor = System.Drawing.Color.DimGray;
            this.ChatBt.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChatBt.FlatAppearance.BorderSize = 0;
            this.ChatBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChatBt.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.ChatBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatBt.ForeColor = System.Drawing.Color.Transparent;
            this.ChatBt.IconChar = FontAwesome.Sharp.IconChar.Comment;
            this.ChatBt.IconColor = System.Drawing.Color.White;
            this.ChatBt.IconSize = 25;
            this.ChatBt.Location = new System.Drawing.Point(66, 0);
            this.ChatBt.Name = "ChatBt";
            this.ChatBt.Rotation = 0D;
            this.ChatBt.Size = new System.Drawing.Size(66, 50);
            this.ChatBt.TabIndex = 1;
            this.ChatBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChatBt.UseVisualStyleBackColor = false;
            this.ChatBt.Click += new System.EventHandler(this.ChatBt_Click);
            // 
            // infoBt
            // 
            this.infoBt.BackColor = System.Drawing.Color.DimGray;
            this.infoBt.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoBt.FlatAppearance.BorderSize = 0;
            this.infoBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoBt.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.infoBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBt.ForeColor = System.Drawing.Color.Transparent;
            this.infoBt.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            this.infoBt.IconColor = System.Drawing.Color.White;
            this.infoBt.IconSize = 25;
            this.infoBt.Location = new System.Drawing.Point(0, 0);
            this.infoBt.Name = "infoBt";
            this.infoBt.Rotation = 0D;
            this.infoBt.Size = new System.Drawing.Size(66, 50);
            this.infoBt.TabIndex = 1;
            this.infoBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.infoBt.UseVisualStyleBackColor = false;
            this.infoBt.Click += new System.EventHandler(this.infoBt_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ExitBt);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 447);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 53);
            this.panel3.TabIndex = 9;
            // 
            // ExitBt
            // 
            this.ExitBt.BackColor = System.Drawing.Color.Gray;
            this.ExitBt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExitBt.FlatAppearance.BorderSize = 0;
            this.ExitBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBt.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.ExitBt.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBt.ForeColor = System.Drawing.Color.White;
            this.ExitBt.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.ExitBt.IconColor = System.Drawing.Color.White;
            this.ExitBt.IconSize = 32;
            this.ExitBt.Location = new System.Drawing.Point(0, 0);
            this.ExitBt.Name = "ExitBt";
            this.ExitBt.Rotation = 0D;
            this.ExitBt.Size = new System.Drawing.Size(330, 53);
            this.ExitBt.TabIndex = 0;
            this.ExitBt.Text = "Exit";
            this.ExitBt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitBt.UseVisualStyleBackColor = false;
            this.ExitBt.Click += new System.EventHandler(this.ExitBt_Click);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.panelMenu);
            this.panelForm.Controls.Add(this.panel3);
            this.panelForm.Controls.Add(this.panelTool);
            this.panelForm.Controls.Add(this.panelLogo);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(330, 500);
            this.panelForm.TabIndex = 2;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 80);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(330, 367);
            this.panelMenu.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 500);
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTool.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label MinimizeBt;
        private System.Windows.Forms.Label outBt;
        private System.Windows.Forms.Panel panelTool;
        private FontAwesome.Sharp.IconButton ChatBt;
        private FontAwesome.Sharp.IconButton SettingBt;
        private FontAwesome.Sharp.IconButton infoBt;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton ExitBt;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton HomeBt;
        private FontAwesome.Sharp.IconButton GameBt;
        private System.Windows.Forms.Label nameUser;
    }
}

