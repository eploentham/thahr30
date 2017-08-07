namespace ThaHr30
{
    partial class MemberSendEmail
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberSendEmail));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnBody = new System.Windows.Forms.Button();
            this.txtEmailSendWait = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAttachFile2 = new System.Windows.Forms.Button();
            this.btnAttachFile1 = new System.Windows.Forms.Button();
            this.txtAttachFile2 = new System.Windows.Forms.TextBox();
            this.txtAttachFile1 = new System.Windows.Forms.TextBox();
            this.btnTO = new System.Windows.Forms.Button();
            this.TxtDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSMTP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFrom = new System.Windows.Forms.TextBox();
            this.Txt = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAttachFile3 = new System.Windows.Forms.Button();
            this.txtAttachFile3 = new System.Windows.Forms.TextBox();
            this.btnAttachFile4 = new System.Windows.Forms.Button();
            this.txtAttachFile4 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailSendWait)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAttachFile4);
            this.groupBox1.Controls.Add(this.txtAttachFile4);
            this.groupBox1.Controls.Add(this.btnAttachFile3);
            this.groupBox1.Controls.Add(this.txtAttachFile3);
            this.groupBox1.Controls.Add(this.GrdView);
            this.groupBox1.Controls.Add(this.btnBody);
            this.groupBox1.Controls.Add(this.txtEmailSendWait);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAttachFile2);
            this.groupBox1.Controls.Add(this.btnAttachFile1);
            this.groupBox1.Controls.Add(this.txtAttachFile2);
            this.groupBox1.Controls.Add(this.txtAttachFile1);
            this.groupBox1.Controls.Add(this.btnTO);
            this.groupBox1.Controls.Add(this.TxtDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtSMTP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtSubject);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 224);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "GrdView";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(506, 10);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(436, 208);
            this.GrdView.TabIndex = 48;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdView.TextTipAppearance = tipAppearance1;
            // 
            // GrdView_Sheet1
            // 
            this.GrdView_Sheet1.Reset();
            this.GrdView_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.GrdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.GrdView_Sheet1.AutoUpdateNotes = true;
            this.GrdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnBody
            // 
            this.btnBody.Location = new System.Drawing.Point(6, 96);
            this.btnBody.Name = "btnBody";
            this.btnBody.Size = new System.Drawing.Size(75, 23);
            this.btnBody.TabIndex = 19;
            this.btnBody.Text = "„∫ª–ÀπÈ“";
            this.btnBody.UseVisualStyleBackColor = true;
            this.btnBody.Click += new System.EventHandler(this.btnBody_Click);
            // 
            // txtEmailSendWait
            // 
            this.txtEmailSendWait.Location = new System.Drawing.Point(357, 99);
            this.txtEmailSendWait.Name = "txtEmailSendWait";
            this.txtEmailSendWait.Size = new System.Drawing.Size(49, 20);
            this.txtEmailSendWait.TabIndex = 18;
            this.txtEmailSendWait.ValueChanged += new System.EventHandler(this.txtEmailSendWait_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "wait time : ";
            // 
            // btnAttachFile2
            // 
            this.btnAttachFile2.Location = new System.Drawing.Point(9, 151);
            this.btnAttachFile2.Name = "btnAttachFile2";
            this.btnAttachFile2.Size = new System.Drawing.Size(72, 23);
            this.btnAttachFile2.TabIndex = 16;
            this.btnAttachFile2.Text = "Attach File2 : ";
            this.btnAttachFile2.UseVisualStyleBackColor = true;
            this.btnAttachFile2.Click += new System.EventHandler(this.btnAttachFile2_Click);
            // 
            // btnAttachFile1
            // 
            this.btnAttachFile1.Location = new System.Drawing.Point(9, 122);
            this.btnAttachFile1.Name = "btnAttachFile1";
            this.btnAttachFile1.Size = new System.Drawing.Size(72, 23);
            this.btnAttachFile1.TabIndex = 15;
            this.btnAttachFile1.Text = "Attach File1 : ";
            this.btnAttachFile1.UseVisualStyleBackColor = true;
            this.btnAttachFile1.Click += new System.EventHandler(this.btnAttachFile1_Click);
            // 
            // txtAttachFile2
            // 
            this.txtAttachFile2.Location = new System.Drawing.Point(104, 148);
            this.txtAttachFile2.Name = "txtAttachFile2";
            this.txtAttachFile2.Size = new System.Drawing.Size(302, 20);
            this.txtAttachFile2.TabIndex = 13;
            // 
            // txtAttachFile1
            // 
            this.txtAttachFile1.Location = new System.Drawing.Point(104, 125);
            this.txtAttachFile1.Name = "txtAttachFile1";
            this.txtAttachFile1.Size = new System.Drawing.Size(302, 20);
            this.txtAttachFile1.TabIndex = 11;
            // 
            // btnTO
            // 
            this.btnTO.Location = new System.Drawing.Point(457, 14);
            this.btnTO.Name = "btnTO";
            this.btnTO.Size = new System.Drawing.Size(43, 23);
            this.btnTO.TabIndex = 10;
            this.btnTO.Text = "...";
            this.btnTO.UseVisualStyleBackColor = true;
            this.btnTO.Click += new System.EventHandler(this.btnTO_Click);
            // 
            // TxtDate
            // 
            this.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtDate.Location = new System.Drawing.Point(104, 99);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(95, 20);
            this.TxtDate.TabIndex = 9;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subject : ";
            // 
            // TxtSubject
            // 
            this.TxtSubject.Location = new System.Drawing.Point(104, 73);
            this.TxtSubject.Name = "TxtSubject";
            this.TxtSubject.Size = new System.Drawing.Size(302, 20);
            this.TxtSubject.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To : ";
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
            // Txt
            // 
            this.Txt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Txt.Location = new System.Drawing.Point(12, 258);
            this.Txt.Name = "Txt";
            this.Txt.Size = new System.Drawing.Size(942, 469);
            this.Txt.TabIndex = 2;
            this.Txt.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit,
            this.toolStripSeparator5,
            this.btnSendEmail,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(972, 25);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // exit
            // 
            this.exit.Image = global::ThaHr30.Properties.Resources.cancelicon;
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(51, 22);
            this.exit.Text = "  Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendEmail.Image")));
            this.btnSendEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(82, 22);
            this.btnSendEmail.Text = "Send E-Mail";
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btnAttachFile3
            // 
            this.btnAttachFile3.Location = new System.Drawing.Point(9, 177);
            this.btnAttachFile3.Name = "btnAttachFile3";
            this.btnAttachFile3.Size = new System.Drawing.Size(72, 23);
            this.btnAttachFile3.TabIndex = 50;
            this.btnAttachFile3.Text = "Attach File3 : ";
            this.btnAttachFile3.UseVisualStyleBackColor = true;
            this.btnAttachFile3.Click += new System.EventHandler(this.btnAttachFile3_Click);
            // 
            // txtAttachFile3
            // 
            this.txtAttachFile3.Location = new System.Drawing.Point(104, 174);
            this.txtAttachFile3.Name = "txtAttachFile3";
            this.txtAttachFile3.Size = new System.Drawing.Size(302, 20);
            this.txtAttachFile3.TabIndex = 49;
            // 
            // btnAttachFile4
            // 
            this.btnAttachFile4.Location = new System.Drawing.Point(9, 201);
            this.btnAttachFile4.Name = "btnAttachFile4";
            this.btnAttachFile4.Size = new System.Drawing.Size(72, 23);
            this.btnAttachFile4.TabIndex = 52;
            this.btnAttachFile4.Text = "Attach File4 : ";
            this.btnAttachFile4.UseVisualStyleBackColor = true;
            this.btnAttachFile4.Click += new System.EventHandler(this.btnAttachFile4_Click);
            // 
            // txtAttachFile4
            // 
            this.txtAttachFile4.Location = new System.Drawing.Point(104, 198);
            this.txtAttachFile4.Name = "txtAttachFile4";
            this.txtAttachFile4.Size = new System.Drawing.Size(302, 20);
            this.txtAttachFile4.TabIndex = 51;
            // 
            // MemberSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 739);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Txt);
            this.Controls.Add(this.groupBox1);
            this.Name = "MemberSendEmail";
            this.Text = "MemberSendEmail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MemberSendEmail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailSendWait)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker TxtDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSMTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFrom;
        private System.Windows.Forms.RichTextBox Txt;
        private System.Windows.Forms.Button btnTO;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.TextBox txtAttachFile2;
        private System.Windows.Forms.TextBox txtAttachFile1;
        private System.Windows.Forms.Button btnAttachFile2;
        private System.Windows.Forms.Button btnAttachFile1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NumericUpDown txtEmailSendWait;
        private System.Windows.Forms.Label label5;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        public FarPoint.Win.Spread.FpSpread GrdView;
        private System.Windows.Forms.Button btnBody;
        private System.Windows.Forms.ToolStripButton btnSendEmail;
        private System.Windows.Forms.Button btnAttachFile4;
        private System.Windows.Forms.TextBox txtAttachFile4;
        private System.Windows.Forms.Button btnAttachFile3;
        private System.Windows.Forms.TextBox txtAttachFile3;
    }
}