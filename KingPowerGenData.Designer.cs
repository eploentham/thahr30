namespace ThaHr30
{
    partial class KingPowerGenData
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnOpenMaster = new System.Windows.Forms.Button();
            this.GbMemSome = new System.Windows.Forms.GroupBox();
            this.GrdPriceList = new FarPoint.Win.Spread.FpSpread();
            this.GrdPriceList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label1 = new System.Windows.Forms.Label();
            this.CboMember = new System.Windows.Forms.ComboBox();
            this.BtnAll = new System.Windows.Forms.Button();
            this.ChkMemSome = new System.Windows.Forms.RadioButton();
            this.ChkMemAll = new System.Windows.Forms.RadioButton();
            this.BtnMember = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnOpenSale = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ChkIncludeVAT = new System.Windows.Forms.RadioButton();
            this.ChkExcludeVAT = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ChkRoomRate = new System.Windows.Forms.RadioButton();
            this.ChkRoomRate1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDate = new System.Windows.Forms.DateTimePicker();
            this.BtnVoucher = new System.Windows.Forms.Button();
            this.Stb = new System.Windows.Forms.StatusStrip();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GbMemSome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPriceList_Sheet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Stb.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 431);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เตรียมข้อมูลส่ง King Power";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnOpenMaster);
            this.groupBox3.Controls.Add(this.GbMemSome);
            this.groupBox3.Controls.Add(this.ChkMemSome);
            this.groupBox3.Controls.Add(this.ChkMemAll);
            this.groupBox3.Controls.Add(this.BtnMember);
            this.groupBox3.Location = new System.Drawing.Point(16, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(702, 202);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Member";
            // 
            // BtnOpenMaster
            // 
            this.BtnOpenMaster.Location = new System.Drawing.Point(11, 141);
            this.BtnOpenMaster.Name = "BtnOpenMaster";
            this.BtnOpenMaster.Size = new System.Drawing.Size(92, 49);
            this.BtnOpenMaster.TabIndex = 14;
            this.BtnOpenMaster.Text = "เปิด Text File";
            this.BtnOpenMaster.UseVisualStyleBackColor = true;
            this.BtnOpenMaster.Click += new System.EventHandler(this.BtnOpenMaster_Click);
            // 
            // GbMemSome
            // 
            this.GbMemSome.Controls.Add(this.GrdPriceList);
            this.GbMemSome.Controls.Add(this.label1);
            this.GbMemSome.Controls.Add(this.CboMember);
            this.GbMemSome.Controls.Add(this.BtnAll);
            this.GbMemSome.Location = new System.Drawing.Point(114, 10);
            this.GbMemSome.Name = "GbMemSome";
            this.GbMemSome.Size = new System.Drawing.Size(582, 186);
            this.GbMemSome.TabIndex = 13;
            this.GbMemSome.TabStop = false;
            this.GbMemSome.Text = "รายสมาชิก";
            // 
            // GrdPriceList
            // 
            this.GrdPriceList.AccessibleDescription = "GrdView";
            this.GrdPriceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdPriceList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdPriceList.Location = new System.Drawing.Point(9, 46);
            this.GrdPriceList.Name = "GrdPriceList";
            this.GrdPriceList.ScrollBarShowMax = false;
            this.GrdPriceList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdPriceList_Sheet1});
            this.GrdPriceList.Size = new System.Drawing.Size(567, 134);
            this.GrdPriceList.TabIndex = 76;
            this.GrdPriceList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.GrdPriceList_CellClick);
            // 
            // GrdPriceList_Sheet1
            // 
            this.GrdPriceList_Sheet1.Reset();
            this.GrdPriceList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.GrdPriceList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.GrdPriceList_Sheet1.AllowNoteEdit = true;
            this.GrdPriceList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "เลือกโรงแรม :";
            // 
            // CboMember
            // 
            this.CboMember.FormattingEnabled = true;
            this.CboMember.Location = new System.Drawing.Point(81, 19);
            this.CboMember.Name = "CboMember";
            this.CboMember.Size = new System.Drawing.Size(495, 21);
            this.CboMember.TabIndex = 33;
            this.CboMember.SelectedValueChanged += new System.EventHandler(this.CboMember_SelectedValueChanged);
            // 
            // BtnAll
            // 
            this.BtnAll.Location = new System.Drawing.Point(9, 107);
            this.BtnAll.Name = "BtnAll";
            this.BtnAll.Size = new System.Drawing.Size(47, 49);
            this.BtnAll.TabIndex = 10;
            this.BtnAll.Text = "ข้อมูล Member ทั้งหมด";
            this.BtnAll.UseVisualStyleBackColor = true;
            this.BtnAll.Visible = false;
            this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
            // 
            // ChkMemSome
            // 
            this.ChkMemSome.AutoSize = true;
            this.ChkMemSome.Location = new System.Drawing.Point(17, 56);
            this.ChkMemSome.Name = "ChkMemSome";
            this.ChkMemSome.Size = new System.Drawing.Size(75, 17);
            this.ChkMemSome.TabIndex = 12;
            this.ChkMemSome.TabStop = true;
            this.ChkMemSome.Text = "รายสมาชิก";
            this.ChkMemSome.UseVisualStyleBackColor = true;
            this.ChkMemSome.Click += new System.EventHandler(this.ChkMemSome_Click);
            this.ChkMemSome.CheckedChanged += new System.EventHandler(this.ChkMemSome_CheckedChanged);
            // 
            // ChkMemAll
            // 
            this.ChkMemAll.AutoSize = true;
            this.ChkMemAll.Location = new System.Drawing.Point(17, 23);
            this.ChkMemAll.Name = "ChkMemAll";
            this.ChkMemAll.Size = new System.Drawing.Size(58, 17);
            this.ChkMemAll.TabIndex = 11;
            this.ChkMemAll.TabStop = true;
            this.ChkMemAll.Text = "ทั้งหมด";
            this.ChkMemAll.UseVisualStyleBackColor = true;
            this.ChkMemAll.Click += new System.EventHandler(this.ChkMemAll_Click);
            // 
            // BtnMember
            // 
            this.BtnMember.Location = new System.Drawing.Point(11, 86);
            this.BtnMember.Name = "BtnMember";
            this.BtnMember.Size = new System.Drawing.Size(92, 49);
            this.BtnMember.TabIndex = 9;
            this.BtnMember.Text = "ข้อมูล Member";
            this.BtnMember.UseVisualStyleBackColor = true;
            this.BtnMember.Click += new System.EventHandler(this.BtnMember_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnOpenSale);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtDate);
            this.groupBox2.Controls.Add(this.BtnVoucher);
            this.groupBox2.Location = new System.Drawing.Point(16, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 183);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voucher";
            // 
            // BtnOpenSale
            // 
            this.BtnOpenSale.Location = new System.Drawing.Point(598, 60);
            this.BtnOpenSale.Name = "BtnOpenSale";
            this.BtnOpenSale.Size = new System.Drawing.Size(92, 73);
            this.BtnOpenSale.TabIndex = 25;
            this.BtnOpenSale.Text = "เปิด Text File";
            this.BtnOpenSale.UseVisualStyleBackColor = true;
            this.BtnOpenSale.Click += new System.EventHandler(this.BtnOpenSale_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ChkIncludeVAT);
            this.groupBox5.Controls.Add(this.ChkExcludeVAT);
            this.groupBox5.Location = new System.Drawing.Point(249, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 45);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Type VAT";
            // 
            // ChkIncludeVAT
            // 
            this.ChkIncludeVAT.AutoSize = true;
            this.ChkIncludeVAT.Location = new System.Drawing.Point(5, 15);
            this.ChkIncludeVAT.Name = "ChkIncludeVAT";
            this.ChkIncludeVAT.Size = new System.Drawing.Size(84, 17);
            this.ChkIncludeVAT.TabIndex = 21;
            this.ChkIncludeVAT.Text = "Include VAT";
            this.ChkIncludeVAT.UseVisualStyleBackColor = true;
            // 
            // ChkExcludeVAT
            // 
            this.ChkExcludeVAT.AutoSize = true;
            this.ChkExcludeVAT.Checked = true;
            this.ChkExcludeVAT.Location = new System.Drawing.Point(91, 15);
            this.ChkExcludeVAT.Name = "ChkExcludeVAT";
            this.ChkExcludeVAT.Size = new System.Drawing.Size(87, 17);
            this.ChkExcludeVAT.TabIndex = 22;
            this.ChkExcludeVAT.TabStop = true;
            this.ChkExcludeVAT.Text = "Exclude VAT";
            this.ChkExcludeVAT.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ChkRoomRate);
            this.groupBox4.Controls.Add(this.ChkRoomRate1);
            this.groupBox4.Location = new System.Drawing.Point(11, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 45);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Field Data";
            // 
            // ChkRoomRate
            // 
            this.ChkRoomRate.AutoSize = true;
            this.ChkRoomRate.Location = new System.Drawing.Point(6, 19);
            this.ChkRoomRate.Name = "ChkRoomRate";
            this.ChkRoomRate.Size = new System.Drawing.Size(79, 17);
            this.ChkRoomRate.TabIndex = 19;
            this.ChkRoomRate.Text = "Room Rate";
            this.ChkRoomRate.UseVisualStyleBackColor = true;
            // 
            // ChkRoomRate1
            // 
            this.ChkRoomRate1.AutoSize = true;
            this.ChkRoomRate1.Checked = true;
            this.ChkRoomRate1.Location = new System.Drawing.Point(91, 19);
            this.ChkRoomRate1.Name = "ChkRoomRate1";
            this.ChkRoomRate1.Size = new System.Drawing.Size(91, 17);
            this.ChkRoomRate1.TabIndex = 20;
            this.ChkRoomRate1.TabStop = true;
            this.ChkRoomRate1.Text = "Room Rate++";
            this.ChkRoomRate1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "ประจำวันที่ :";
            // 
            // TxtDate
            // 
            this.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtDate.Location = new System.Drawing.Point(97, 40);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(110, 20);
            this.TxtDate.TabIndex = 14;
            // 
            // BtnVoucher
            // 
            this.BtnVoucher.Location = new System.Drawing.Point(494, 60);
            this.BtnVoucher.Name = "BtnVoucher";
            this.BtnVoucher.Size = new System.Drawing.Size(92, 73);
            this.BtnVoucher.TabIndex = 13;
            this.BtnVoucher.Text = "ข้อมูล Voucher";
            this.BtnVoucher.UseVisualStyleBackColor = true;
            this.BtnVoucher.Click += new System.EventHandler(this.BtnVoucher_Click);
            // 
            // Stb
            // 
            this.Stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pb1});
            this.Stb.Location = new System.Drawing.Point(0, 451);
            this.Stb.Name = "Stb";
            this.Stb.Size = new System.Drawing.Size(748, 23);
            this.Stb.TabIndex = 29;
            this.Stb.Text = "statusStrip1";
            // 
            // Pb1
            // 
            this.Pb1.Name = "Pb1";
            this.Pb1.Size = new System.Drawing.Size(370, 17);
            // 
            // KingPowerGenData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 474);
            this.Controls.Add(this.Stb);
            this.Controls.Add(this.groupBox1);
            this.Name = "KingPowerGenData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrepareData";
            this.Load += new System.EventHandler(this.PrepareData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GbMemSome.ResumeLayout(false);
            this.GbMemSome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPriceList_Sheet1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Stb.ResumeLayout(false);
            this.Stb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnMember;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TxtDate;
        private System.Windows.Forms.Button BtnVoucher;
        private System.Windows.Forms.Button BtnAll;
        private System.Windows.Forms.StatusStrip Stb;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private System.Windows.Forms.RadioButton ChkRoomRate1;
        private System.Windows.Forms.RadioButton ChkRoomRate;
        private System.Windows.Forms.RadioButton ChkExcludeVAT;
        private System.Windows.Forms.RadioButton ChkIncludeVAT;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton ChkMemSome;
        private System.Windows.Forms.RadioButton ChkMemAll;
        private System.Windows.Forms.GroupBox GbMemSome;
        private System.Windows.Forms.ComboBox CboMember;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Spread.FpSpread GrdPriceList;
        private FarPoint.Win.Spread.SheetView GrdPriceList_Sheet1;
        private System.Windows.Forms.Button BtnOpenMaster;
        private System.Windows.Forms.Button BtnOpenSale;
    }
}