namespace ThaHr30
{
    partial class ShopSendEmail
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
            this.TxtDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSMTP = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFrom = new System.Windows.Forms.TextBox();
            this.TxtBody = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtSMTP);
            this.groupBox1.Controls.Add(this.BtnOK);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtSubject);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TxtDate
            // 
            this.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtDate.Location = new System.Drawing.Point(422, 19);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(95, 20);
            this.TxtDate.TabIndex = 9;
            this.TxtDate.ValueChanged += new System.EventHandler(this.TxtDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Outgoing SMTP : ";
            // 
            // TxtSMTP
            // 
            this.TxtSMTP.Location = new System.Drawing.Point(104, 19);
            this.TxtSMTP.Name = "TxtSMTP";
            this.TxtSMTP.Size = new System.Drawing.Size(302, 20);
            this.TxtSMTP.TabIndex = 7;
            this.TxtSMTP.Text = "mail.asianet.co.th";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(422, 69);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(96, 50);
            this.BtnOK.TabIndex = 6;
            this.BtnOK.Text = "Send E-Mail";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subject : ";
            // 
            // TxtSubject
            // 
            this.TxtSubject.Location = new System.Drawing.Point(104, 135);
            this.TxtSubject.Name = "TxtSubject";
            this.TxtSubject.Size = new System.Drawing.Size(302, 20);
            this.TxtSubject.TabIndex = 4;
            this.TxtSubject.Text = "Daily payin record ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To : ";
            // 
            // TxtTo
            // 
            this.TxtTo.Location = new System.Drawing.Point(104, 73);
            this.TxtTo.Multiline = true;
            this.TxtTo.Name = "TxtTo";
            this.TxtTo.Size = new System.Drawing.Size(302, 56);
            this.TxtTo.TabIndex = 2;
            this.TxtTo.Text = "manager@thaihotels.org,account@thaihotels.org,info@thaihotels.org,tawanss@yahoo.c" +
                "om,eploentham@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From : ";
            // 
            // TxtFrom
            // 
            this.TxtFrom.Location = new System.Drawing.Point(104, 47);
            this.TxtFrom.Name = "TxtFrom";
            this.TxtFrom.Size = new System.Drawing.Size(302, 20);
            this.TxtFrom.TabIndex = 0;
            // 
            // TxtBody
            // 
            this.TxtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBody.Location = new System.Drawing.Point(12, 179);
            this.TxtBody.Name = "TxtBody";
            this.TxtBody.Size = new System.Drawing.Size(525, 311);
            this.TxtBody.TabIndex = 1;
            this.TxtBody.Text = "";
            // 
            // ShopSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 502);
            this.Controls.Add(this.TxtBody);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShopSendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopSendEmail";
            this.Load += new System.EventHandler(this.ShopSendEmail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFrom;
        private System.Windows.Forms.RichTextBox TxtBody;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSMTP;
        private System.Windows.Forms.DateTimePicker TxtDate;
    }
}