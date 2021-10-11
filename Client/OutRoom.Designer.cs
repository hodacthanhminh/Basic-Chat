namespace Client
{
    partial class OutRoom
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
            this.toppanel = new System.Windows.Forms.Panel();
            this.MinimizeBt = new System.Windows.Forms.Label();
            this.outBt = new System.Windows.Forms.Label();
            this.noti = new System.Windows.Forms.Label();
            this.SendBt = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idRoom = new System.Windows.Forms.TextBox();
            this.toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendBt)).BeginInit();
            this.SuspendLayout();
            // 
            // toppanel
            // 
            this.toppanel.Controls.Add(this.MinimizeBt);
            this.toppanel.Controls.Add(this.outBt);
            this.toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toppanel.Location = new System.Drawing.Point(0, 0);
            this.toppanel.Name = "toppanel";
            this.toppanel.Size = new System.Drawing.Size(150, 28);
            this.toppanel.TabIndex = 9;
            this.toppanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltitleBar_MouseDown);
            // 
            // MinimizeBt
            // 
            this.MinimizeBt.AutoSize = true;
            this.MinimizeBt.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBt.ForeColor = System.Drawing.Color.White;
            this.MinimizeBt.Location = new System.Drawing.Point(104, 0);
            this.MinimizeBt.Name = "MinimizeBt";
            this.MinimizeBt.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBt.TabIndex = 5;
            this.MinimizeBt.Text = "O";
            // 
            // outBt
            // 
            this.outBt.AutoSize = true;
            this.outBt.BackColor = System.Drawing.Color.Transparent;
            this.outBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.outBt.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outBt.ForeColor = System.Drawing.Color.White;
            this.outBt.Location = new System.Drawing.Point(127, 0);
            this.outBt.Name = "outBt";
            this.outBt.Size = new System.Drawing.Size(23, 23);
            this.outBt.TabIndex = 4;
            this.outBt.Text = "O";
            this.outBt.Click += new System.EventHandler(this.outBt_Click);
            // 
            // noti
            // 
            this.noti.AutoSize = true;
            this.noti.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noti.ForeColor = System.Drawing.Color.Coral;
            this.noti.Location = new System.Drawing.Point(15, 86);
            this.noti.Name = "noti";
            this.noti.Size = new System.Drawing.Size(79, 15);
            this.noti.TabIndex = 8;
            this.noti.Text = "No exits room";
            this.noti.Visible = false;
            // 
            // SendBt
            // 
            this.SendBt.BackColor = System.Drawing.SystemColors.Control;
            this.SendBt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SendBt.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.SendBt.IconColor = System.Drawing.SystemColors.ControlText;
            this.SendBt.Location = new System.Drawing.Point(106, 83);
            this.SendBt.Name = "SendBt";
            this.SendBt.Size = new System.Drawing.Size(32, 32);
            this.SendBt.TabIndex = 7;
            this.SendBt.TabStop = false;
            this.SendBt.Click += new System.EventHandler(this.SendBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "IdRoom";
            // 
            // idRoom
            // 
            this.idRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idRoom.Location = new System.Drawing.Point(12, 57);
            this.idRoom.Name = "idRoom";
            this.idRoom.Size = new System.Drawing.Size(126, 22);
            this.idRoom.TabIndex = 5;
            // 
            // OutRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 130);
            this.Controls.Add(this.toppanel);
            this.Controls.Add(this.noti);
            this.Controls.Add(this.SendBt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idRoom);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutRoom";
            this.Text = "OutRoom";
            this.Load += new System.EventHandler(this.OutRoom_Load);
            this.toppanel.ResumeLayout(false);
            this.toppanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendBt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel toppanel;
        private System.Windows.Forms.Label MinimizeBt;
        private System.Windows.Forms.Label outBt;
        private System.Windows.Forms.Label noti;
        private FontAwesome.Sharp.IconPictureBox SendBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idRoom;
    }
}