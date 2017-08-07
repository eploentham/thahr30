namespace ThaHr30
{
    partial class ShopSendData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtEndDate = new System.Windows.Forms.DateTimePicker();
            this.TxtStartDate = new System.Windows.Forms.DateTimePicker();
            this.CboTSend = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrdSend = new FarPoint.Win.Spread.FpSpread();
            this.GrdSend_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSend_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BtnSend);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtEndDate);
            this.groupBox1.Controls.Add(this.TxtStartDate);
            this.groupBox1.Controls.Add(this.CboTSend);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtProFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เงื่อนไขการส่ง";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(261, 55);
            this.maskedTextBox1.Mask = "___.___.___.___";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(109, 20);
            this.maskedTextBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "IP :";
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(256, 85);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(114, 49);
            this.BtnSend.TabIndex = 8;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ถึงวันที่ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ตั้งแต่วันที่ :";
            // 
            // TxtEndDate
            // 
            this.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtEndDate.Location = new System.Drawing.Point(91, 114);
            this.TxtEndDate.Name = "TxtEndDate";
            this.TxtEndDate.Size = new System.Drawing.Size(110, 20);
            this.TxtEndDate.TabIndex = 5;
            // 
            // TxtStartDate
            // 
            this.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtStartDate.Location = new System.Drawing.Point(91, 88);
            this.TxtStartDate.Name = "TxtStartDate";
            this.TxtStartDate.Size = new System.Drawing.Size(110, 20);
            this.TxtStartDate.TabIndex = 4;
            // 
            // CboTSend
            // 
            this.CboTSend.FormattingEnabled = true;
            this.CboTSend.Items.AddRange(new object[] {
            "ที่ยังไม่ได้ส่ง",
            "ตั้งแต่วันที่ - ถึงวันที่"});
            this.CboTSend.Location = new System.Drawing.Point(91, 50);
            this.CboTSend.Name = "CboTSend";
            this.CboTSend.Size = new System.Drawing.Size(110, 21);
            this.CboTSend.TabIndex = 3;
            this.CboTSend.SelectedValueChanged += new System.EventHandler(this.CboTSend_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ประเภทการส่ง :";
            // 
            // TxtProFile
            // 
            this.TxtProFile.Location = new System.Drawing.Point(91, 20);
            this.TxtProFile.Name = "TxtProFile";
            this.TxtProFile.Size = new System.Drawing.Size(110, 20);
            this.TxtProFile.TabIndex = 1;
            this.TxtProFile.Text = "thahr30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile :";
            // 
            // GrdSend
            // 
            this.GrdSend.About = "2.5.2005.2005";
            this.GrdSend.AccessibleDescription = "";
            this.GrdSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdSend.Location = new System.Drawing.Point(12, 168);
            this.GrdSend.Name = "GrdSend";
            this.GrdSend.ScrollBarShowMax = false;
            this.GrdSend.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdSend_Sheet1});
            this.GrdSend.Size = new System.Drawing.Size(396, 298);
            this.GrdSend.TabIndex = 17;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdSend.TextTipAppearance = tipAppearance1;
            // 
            // GrdSend_Sheet1
            // 
            this.GrdSend_Sheet1.Reset();
            this.GrdSend_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.GrdSend_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.GrdSend_Sheet1.AutoUpdateNotes = true;
            this.GrdSend_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // SendData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 478);
            this.Controls.Add(this.GrdSend);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "SendData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendData";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SendData_KeyUp);
            this.Load += new System.EventHandler(this.SendData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSend_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CboTSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtProFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TxtEndDate;
        private System.Windows.Forms.DateTimePicker TxtStartDate;
        private System.Windows.Forms.Button BtnSend;
        private FarPoint.Win.Spread.FpSpread GrdSend;
        private FarPoint.Win.Spread.SheetView GrdSend_Sheet1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label5;
        
    }
}