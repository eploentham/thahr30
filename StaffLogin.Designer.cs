namespace ThaHr30
{
    partial class StaffLogin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicPosition = new System.Windows.Forms.PictureBox();
            this.PicTrue = new System.Windows.Forms.PictureBox();
            this.PicFalse = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.PicConnecting = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFalse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicConnecting)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicConnecting);
            this.groupBox1.Controls.Add(this.PicPosition);
            this.groupBox1.Controls.Add(this.PicTrue);
            this.groupBox1.Controls.Add(this.PicFalse);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.BtnOK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.TxtUserName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log in";
            // 
            // PicPosition
            // 
            this.PicPosition.Image = global::ThaHr30.Properties.Resources.arrow_back1;
            this.PicPosition.Location = new System.Drawing.Point(282, 76);
            this.PicPosition.Name = "PicPosition";
            this.PicPosition.Size = new System.Drawing.Size(28, 27);
            this.PicPosition.TabIndex = 9;
            this.PicPosition.TabStop = false;
            // 
            // PicTrue
            // 
            this.PicTrue.Image = global::ThaHr30.Properties.Resources.agree;
            this.PicTrue.Location = new System.Drawing.Point(62, 117);
            this.PicTrue.Name = "PicTrue";
            this.PicTrue.Size = new System.Drawing.Size(36, 31);
            this.PicTrue.TabIndex = 8;
            this.PicTrue.TabStop = false;
            // 
            // PicFalse
            // 
            this.PicFalse.Image = global::ThaHr30.Properties.Resources.disagree;
            this.PicFalse.Location = new System.Drawing.Point(201, 117);
            this.PicFalse.Name = "PicFalse";
            this.PicFalse.Size = new System.Drawing.Size(36, 31);
            this.PicFalse.TabIndex = 7;
            this.PicFalse.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ThaHr30.Properties.Resources.log_keys;
            this.pictureBox1.Location = new System.Drawing.Point(10, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 57);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(201, 156);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 31);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(41, 156);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 31);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User  Name :";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(135, 83);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(141, 20);
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter);
            this.TxtPassword.Leave += new System.EventHandler(this.TxtPassword_Leave);
            this.TxtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyUp);
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(135, 57);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(141, 20);
            this.TxtUserName.TabIndex = 0;
            this.TxtUserName.Enter += new System.EventHandler(this.TxtUserName_Enter);
            this.TxtUserName.Leave += new System.EventHandler(this.TxtUserName_Leave);
            this.TxtUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtUserName_KeyUp);
            // 
            // PicConnecting
            // 
            this.PicConnecting.Image = global::ThaHr30.Properties.Resources.signon;
            this.PicConnecting.Location = new System.Drawing.Point(104, 117);
            this.PicConnecting.Name = "PicConnecting";
            this.PicConnecting.Size = new System.Drawing.Size(36, 31);
            this.PicConnecting.TabIndex = 10;
            this.PicConnecting.TabStop = false;
            // 
            // StaffLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 254);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "StaffLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffLogin";
            this.Load += new System.EventHandler(this.StaffLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFalse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicConnecting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PicFalse;
        private System.Windows.Forms.PictureBox PicTrue;
        private System.Windows.Forms.PictureBox PicPosition;
        private System.Windows.Forms.PictureBox PicConnecting;
    }
}