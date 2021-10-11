namespace Client
{
    partial class FormRoom
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Plus = new FontAwesome.Sharp.IconPictureBox();
            this.Join = new FontAwesome.Sharp.IconPictureBox();
            this.OutRoomBt = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Plus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Join)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutRoomBt)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 338);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Plus
            // 
            this.Plus.BackColor = System.Drawing.Color.White;
            this.Plus.Dock = System.Windows.Forms.DockStyle.Right;
            this.Plus.ForeColor = System.Drawing.Color.Black;
            this.Plus.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.Plus.IconColor = System.Drawing.Color.Black;
            this.Plus.IconSize = 29;
            this.Plus.Location = new System.Drawing.Point(298, 0);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(32, 29);
            this.Plus.TabIndex = 1;
            this.Plus.TabStop = false;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // Join
            // 
            this.Join.BackColor = System.Drawing.Color.White;
            this.Join.ForeColor = System.Drawing.Color.Black;
            this.Join.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.Join.IconColor = System.Drawing.Color.Black;
            this.Join.IconSize = 29;
            this.Join.Location = new System.Drawing.Point(234, 0);
            this.Join.Name = "Join";
            this.Join.Size = new System.Drawing.Size(32, 29);
            this.Join.TabIndex = 2;
            this.Join.TabStop = false;
            this.Join.Click += new System.EventHandler(this.Join_Click);
            // 
            // OutRoomBt
            // 
            this.OutRoomBt.BackColor = System.Drawing.Color.White;
            this.OutRoomBt.Dock = System.Windows.Forms.DockStyle.Right;
            this.OutRoomBt.ForeColor = System.Drawing.Color.Black;
            this.OutRoomBt.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.OutRoomBt.IconColor = System.Drawing.Color.Black;
            this.OutRoomBt.IconSize = 29;
            this.OutRoomBt.Location = new System.Drawing.Point(266, 0);
            this.OutRoomBt.Name = "OutRoomBt";
            this.OutRoomBt.Size = new System.Drawing.Size(32, 29);
            this.OutRoomBt.TabIndex = 3;
            this.OutRoomBt.TabStop = false;
            this.OutRoomBt.Click += new System.EventHandler(this.OutRoomBt_Click);
            // 
            // FormRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 367);
            this.Controls.Add(this.OutRoomBt);
            this.Controls.Add(this.Join);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRoom";
            this.Text = "FormRoom";
            ((System.ComponentModel.ISupportInitialize)(this.Plus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Join)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutRoomBt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconPictureBox Plus;
        private FontAwesome.Sharp.IconPictureBox Join;
        private FontAwesome.Sharp.IconPictureBox OutRoomBt;
    }
}