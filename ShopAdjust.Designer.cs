namespace ThaHr30
{
    partial class ShopAdjust
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
            this.Gb2 = new System.Windows.Forms.GroupBox();
            this.ChkPriceList = new System.Windows.Forms.CheckBox();
            this.ChkCounter = new System.Windows.Forms.RadioButton();
            this.ChkHD = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRec = new System.Windows.Forms.Button();
            this.TxtEndDate = new System.Windows.Forms.DateTimePicker();
            this.CboTSend = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CboCounter = new System.Windows.Forms.ComboBox();
            this.TxtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.GrdRec = new FarPoint.Win.Spread.FpSpread();
            this.GrdRec_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Stb = new System.Windows.Forms.StatusStrip();
            this.SL1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.Lb1 = new System.Windows.Forms.ListBox();
            this.ChkSendReportSu = new System.Windows.Forms.CheckBox();
            this.Gb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec_Sheet1)).BeginInit();
            this.Stb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gb2
            // 
            this.Gb2.Controls.Add(this.ChkSendReportSu);
            this.Gb2.Controls.Add(this.ChkPriceList);
            this.Gb2.Controls.Add(this.ChkCounter);
            this.Gb2.Controls.Add(this.ChkHD);
            this.Gb2.Controls.Add(this.label1);
            this.Gb2.Controls.Add(this.BtnRec);
            this.Gb2.Controls.Add(this.TxtEndDate);
            this.Gb2.Controls.Add(this.CboTSend);
            this.Gb2.Controls.Add(this.label2);
            this.Gb2.Controls.Add(this.TxtIP);
            this.Gb2.Controls.Add(this.label7);
            this.Gb2.Controls.Add(this.label6);
            this.Gb2.Controls.Add(this.CboCounter);
            this.Gb2.Controls.Add(this.TxtStartDate);
            this.Gb2.Controls.Add(this.label5);
            this.Gb2.Location = new System.Drawing.Point(12, 12);
            this.Gb2.Name = "Gb2";
            this.Gb2.Size = new System.Drawing.Size(506, 148);
            this.Gb2.TabIndex = 30;
            this.Gb2.TabStop = false;
            this.Gb2.Text = " ปรับปรุงข้อมูล";
            // 
            // ChkPriceList
            // 
            this.ChkPriceList.AutoSize = true;
            this.ChkPriceList.Location = new System.Drawing.Point(263, 16);
            this.ChkPriceList.Name = "ChkPriceList";
            this.ChkPriceList.Size = new System.Drawing.Size(192, 17);
            this.ChkPriceList.TabIndex = 48;
            this.ChkPriceList.Text = "ส่งราคา PriceList กลับสำนักงานใหญ่";
            this.ChkPriceList.UseVisualStyleBackColor = true;
            // 
            // ChkCounter
            // 
            this.ChkCounter.AutoSize = true;
            this.ChkCounter.Checked = true;
            this.ChkCounter.Location = new System.Drawing.Point(377, 66);
            this.ChkCounter.Name = "ChkCounter";
            this.ChkCounter.Size = new System.Drawing.Size(123, 17);
            this.ChkCounter.TabIndex = 47;
            this.ChkCounter.TabStop = true;
            this.ChkCounter.Text = "receive from Counter";
            this.ChkCounter.UseVisualStyleBackColor = true;
            this.ChkCounter.CheckedChanged += new System.EventHandler(this.ChkCounter_CheckedChanged);
            // 
            // ChkHD
            // 
            this.ChkHD.AutoSize = true;
            this.ChkHD.Location = new System.Drawing.Point(263, 66);
            this.ChkHD.Name = "ChkHD";
            this.ChkHD.Size = new System.Drawing.Size(108, 17);
            this.ChkHD.TabIndex = 46;
            this.ChkHD.TabStop = true;
            this.ChkHD.Text = "send Head Office";
            this.ChkHD.UseVisualStyleBackColor = true;
            this.ChkHD.CheckedChanged += new System.EventHandler(this.ChkHD_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "ถึงวันที่ :";
            // 
            // BtnRec
            // 
            this.BtnRec.Location = new System.Drawing.Point(20, 93);
            this.BtnRec.Name = "BtnRec";
            this.BtnRec.Size = new System.Drawing.Size(223, 46);
            this.BtnRec.TabIndex = 36;
            this.BtnRec.Text = "รับข้อมูล";
            this.BtnRec.UseVisualStyleBackColor = true;
            this.BtnRec.Click += new System.EventHandler(this.BtnRec_Click);
            // 
            // TxtEndDate
            // 
            this.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtEndDate.Location = new System.Drawing.Point(102, 67);
            this.TxtEndDate.Name = "TxtEndDate";
            this.TxtEndDate.Size = new System.Drawing.Size(141, 20);
            this.TxtEndDate.TabIndex = 44;
            // 
            // CboTSend
            // 
            this.CboTSend.FormattingEnabled = true;
            this.CboTSend.Items.AddRange(new object[] {
            "ที่ยังไม่ได้ส่ง",
            "ตั้งแต่วันที่ - ถึงวันที่"});
            this.CboTSend.Location = new System.Drawing.Point(102, 14);
            this.CboTSend.Name = "CboTSend";
            this.CboTSend.Size = new System.Drawing.Size(141, 21);
            this.CboTSend.TabIndex = 42;
            this.CboTSend.SelectedIndexChanged += new System.EventHandler(this.CboTSend_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "ประเภทการส่ง :";
            // 
            // TxtIP
            // 
            this.TxtIP.Location = new System.Drawing.Point(332, 119);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(141, 20);
            this.TxtIP.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "IP :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Counter :";
            // 
            // CboCounter
            // 
            this.CboCounter.FormattingEnabled = true;
            this.CboCounter.Location = new System.Drawing.Point(332, 93);
            this.CboCounter.Name = "CboCounter";
            this.CboCounter.Size = new System.Drawing.Size(141, 21);
            this.CboCounter.TabIndex = 34;
            this.CboCounter.SelectedIndexChanged += new System.EventHandler(this.CboCounter_SelectedIndexChanged);
            // 
            // TxtStartDate
            // 
            this.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtStartDate.Location = new System.Drawing.Point(102, 41);
            this.TxtStartDate.Name = "TxtStartDate";
            this.TxtStartDate.Size = new System.Drawing.Size(141, 20);
            this.TxtStartDate.TabIndex = 1;
            this.TxtStartDate.ValueChanged += new System.EventHandler(this.TxtStartDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "วันที่ :";
            // 
            // GrdRec
            // 
            this.GrdRec.About = "2.5.2005.2005";
            this.GrdRec.AccessibleDescription = "";
            this.GrdRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdRec.Location = new System.Drawing.Point(12, 166);
            this.GrdRec.Name = "GrdRec";
            this.GrdRec.ScrollBarShowMax = false;
            this.GrdRec.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdRec_Sheet1});
            this.GrdRec.Size = new System.Drawing.Size(506, 318);
            this.GrdRec.TabIndex = 31;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdRec.TextTipAppearance = tipAppearance1;
            // 
            // GrdRec_Sheet1
            // 
            this.GrdRec_Sheet1.Reset();
            this.GrdRec_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.GrdRec_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.GrdRec_Sheet1.AutoUpdateNotes = true;
            this.GrdRec_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // Stb
            // 
            this.Stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SL1,
            this.Pb1});
            this.Stb.Location = new System.Drawing.Point(0, 487);
            this.Stb.Name = "Stb";
            this.Stb.Size = new System.Drawing.Size(817, 22);
            this.Stb.TabIndex = 32;
            this.Stb.Text = "statusStrip1";
            // 
            // SL1
            // 
            this.SL1.Name = "SL1";
            this.SL1.Size = new System.Drawing.Size(0, 17);
            // 
            // Pb1
            // 
            this.Pb1.Name = "Pb1";
            this.Pb1.Size = new System.Drawing.Size(370, 16);
            // 
            // Lb1
            // 
            this.Lb1.FormattingEnabled = true;
            this.Lb1.Location = new System.Drawing.Point(524, 23);
            this.Lb1.Name = "Lb1";
            this.Lb1.Size = new System.Drawing.Size(281, 446);
            this.Lb1.TabIndex = 33;
            // 
            // ChkSendReportSu
            // 
            this.ChkSendReportSu.AutoSize = true;
            this.ChkSendReportSu.Checked = true;
            this.ChkSendReportSu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkSendReportSu.Location = new System.Drawing.Point(263, 39);
            this.ChkSendReportSu.Name = "ChkSendReportSu";
            this.ChkSendReportSu.Size = new System.Drawing.Size(146, 17);
            this.ChkSendReportSu.TabIndex = 49;
            this.ChkSendReportSu.Text = "ส่ง รายงานให้ คุณสุวรรณา";
            this.ChkSendReportSu.UseVisualStyleBackColor = true;
            // 
            // ShopAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 509);
            this.Controls.Add(this.Lb1);
            this.Controls.Add(this.Stb);
            this.Controls.Add(this.GrdRec);
            this.Controls.Add(this.Gb2);
            this.Name = "ShopAdjust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopAdjust";
            this.Load += new System.EventHandler(this.ShopAdjust_Load);
            this.Gb2.ResumeLayout(false);
            this.Gb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec_Sheet1)).EndInit();
            this.Stb.ResumeLayout(false);
            this.Stb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Gb2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnRec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CboCounter;
        private System.Windows.Forms.DateTimePicker TxtStartDate;
        private System.Windows.Forms.Label label5;
        private FarPoint.Win.Spread.FpSpread GrdRec;
        private FarPoint.Win.Spread.SheetView GrdRec_Sheet1;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.ComboBox CboTSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip Stb;
        private System.Windows.Forms.ToolStripStatusLabel SL1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TxtEndDate;
        private System.Windows.Forms.RadioButton ChkCounter;
        private System.Windows.Forms.RadioButton ChkHD;
        private System.Windows.Forms.ListBox Lb1;
        private System.Windows.Forms.CheckBox ChkPriceList;
        private System.Windows.Forms.CheckBox ChkSendReportSu;
        
    }
}