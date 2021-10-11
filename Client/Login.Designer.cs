namespace Client
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.notilogin = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoginBt = new System.Windows.Forms.Button();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.usernameTb = new System.Windows.Forms.TextBox();
            this.passwordLb = new System.Windows.Forms.Label();
            this.usernameLb = new System.Windows.Forms.Label();
            this.titlepanel = new System.Windows.Forms.Panel();
            this.MinimizeBt = new System.Windows.Forms.Label();
            this.exitBt = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Register = new System.Windows.Forms.Button();
            this.titlepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notilogin
            // 
            this.notilogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notilogin.AutoSize = true;
            this.notilogin.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notilogin.ForeColor = System.Drawing.Color.Coral;
            this.notilogin.Location = new System.Drawing.Point(31, 187);
            this.notilogin.Name = "notilogin";
            this.notilogin.Size = new System.Drawing.Size(0, 18);
            this.notilogin.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(34, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 1);
            this.panel2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(30, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 1);
            this.panel1.TabIndex = 22;
            // 
            // LoginBt
            // 
            this.LoginBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBt.FlatAppearance.BorderSize = 0;
            this.LoginBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBt.Location = new System.Drawing.Point(34, 213);
            this.LoginBt.Name = "LoginBt";
            this.LoginBt.Size = new System.Drawing.Size(251, 36);
            this.LoginBt.TabIndex = 21;
            this.LoginBt.Text = "Login";
            this.LoginBt.UseVisualStyleBackColor = true;
            this.LoginBt.Click += new System.EventHandler(this.LoginBt_Click);
            // 
            // passwordTb
            // 
            this.passwordTb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTb.BackColor = System.Drawing.SystemColors.Menu;
            this.passwordTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTb.ForeColor = System.Drawing.Color.DimGray;
            this.passwordTb.Location = new System.Drawing.Point(30, 154);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '•';
            this.passwordTb.Size = new System.Drawing.Size(251, 19);
            this.passwordTb.TabIndex = 20;
            // 
            // usernameTb
            // 
            this.usernameTb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameTb.BackColor = System.Drawing.SystemColors.Menu;
            this.usernameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTb.ForeColor = System.Drawing.Color.DimGray;
            this.usernameTb.Location = new System.Drawing.Point(30, 75);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(251, 19);
            this.usernameTb.TabIndex = 19;
            // 
            // passwordLb
            // 
            this.passwordLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLb.AutoSize = true;
            this.passwordLb.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLb.Location = new System.Drawing.Point(26, 128);
            this.passwordLb.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.passwordLb.Name = "passwordLb";
            this.passwordLb.Size = new System.Drawing.Size(76, 23);
            this.passwordLb.TabIndex = 18;
            this.passwordLb.Text = "Password";
            // 
            // usernameLb
            // 
            this.usernameLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameLb.AutoSize = true;
            this.usernameLb.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLb.Location = new System.Drawing.Point(26, 49);
            this.usernameLb.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.usernameLb.Name = "usernameLb";
            this.usernameLb.Size = new System.Drawing.Size(80, 23);
            this.usernameLb.TabIndex = 17;
            this.usernameLb.Text = "Username";
            // 
            // titlepanel
            // 
            this.titlepanel.Controls.Add(this.MinimizeBt);
            this.titlepanel.Controls.Add(this.exitBt);
            this.titlepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlepanel.Location = new System.Drawing.Point(0, 0);
            this.titlepanel.Name = "titlepanel";
            this.titlepanel.Size = new System.Drawing.Size(310, 30);
            this.titlepanel.TabIndex = 25;
            this.titlepanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltitleBar_MouseDown);
            // 
            // MinimizeBt
            // 
            this.MinimizeBt.AutoSize = true;
            this.MinimizeBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBt.ForeColor = System.Drawing.Color.White;
            this.MinimizeBt.Location = new System.Drawing.Point(264, 0);
            this.MinimizeBt.Name = "MinimizeBt";
            this.MinimizeBt.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBt.TabIndex = 28;
            this.MinimizeBt.Text = "O";
            this.MinimizeBt.Click += new System.EventHandler(this.MinimizeBt_Click);
            // 
            // exitBt
            // 
            this.exitBt.AutoSize = true;
            this.exitBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBt.ForeColor = System.Drawing.Color.White;
            this.exitBt.Location = new System.Drawing.Point(287, 0);
            this.exitBt.Name = "exitBt";
            this.exitBt.Size = new System.Drawing.Size(23, 23);
            this.exitBt.TabIndex = 26;
            this.exitBt.Text = "O";
            this.exitBt.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Register
            // 
            this.Register.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Register.FlatAppearance.BorderSize = 0;
            this.Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Register.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register.Location = new System.Drawing.Point(34, 255);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(251, 36);
            this.Register.TabIndex = 26;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 318);
            this.ControlBox = false;
            this.Controls.Add(this.Register);
            this.Controls.Add(this.titlepanel);
            this.Controls.Add(this.notilogin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LoginBt);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.usernameTb);
            this.Controls.Add(this.passwordLb);
            this.Controls.Add(this.usernameLb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.titlepanel.ResumeLayout(false);
            this.titlepanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label notilogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LoginBt;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.TextBox usernameTb;
        private System.Windows.Forms.Label passwordLb;
        private System.Windows.Forms.Label usernameLb;
        private System.Windows.Forms.Panel titlepanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label MinimizeBt;
        private System.Windows.Forms.Label exitBt;
        private System.Windows.Forms.Button Register;
    }
}