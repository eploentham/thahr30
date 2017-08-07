namespace ThaHr30
{
    partial class ShopView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopView));
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Stb = new System.Windows.Forms.StatusStrip();
            this.SL1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.GbSum = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtGuest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtDeposit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPAX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDays = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCustnotCheckIn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtNoShow = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtVoid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtVoucherUse = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtVoucherSum = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnRec = new System.Windows.Forms.ToolStripButton();
            this.BtnOffice = new System.Windows.Forms.ToolStripButton();
            this.BtnKPS = new System.Windows.Forms.ToolStripButton();
            this.Btnwebkps = new System.Windows.Forms.ToolStripButton();
            this.Btnsendemail = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CboMonth = new System.Windows.Forms.ToolStripComboBox();
            this.CboYear = new System.Windows.Forms.ToolStripComboBox();
            this.BtnOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.Stb.SuspendLayout();
            this.GbSum.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdView
            // 
            this.GrdView.AccessibleDescription = "GrdView";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(12, 70);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(654, 387);
            this.GrdView.TabIndex = 25;
            this.GrdView.ActiveSheetChanged += new System.EventHandler(this.GrdView_ActiveSheetChanged);
            this.GrdView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.GrdView_CellDoubleClick);
            // 
            // GrdView_Sheet1
            // 
            this.GrdView_Sheet1.Reset();
            this.GrdView_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.GrdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.GrdView_Sheet1.AllowNoteEdit = true;
            this.GrdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // Stb
            // 
            this.Stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SL1,
            this.Pb1});
            this.Stb.Location = new System.Drawing.Point(0, 515);
            this.Stb.Name = "Stb";
            this.Stb.Size = new System.Drawing.Size(1028, 22);
            this.Stb.TabIndex = 27;
            this.Stb.Text = "statusStrip1";
            // 
            // SL1
            // 
            this.SL1.Name = "SL1";
            this.SL1.Size = new System.Drawing.Size(109, 17);
            this.SL1.Text = "toolStripStatusLabel1";
            // 
            // Pb1
            // 
            this.Pb1.Name = "Pb1";
            this.Pb1.Size = new System.Drawing.Size(370, 16);
            // 
            // GbSum
            // 
            this.GbSum.Controls.Add(this.label9);
            this.GbSum.Controls.Add(this.TxtGuest);
            this.GbSum.Controls.Add(this.label8);
            this.GbSum.Controls.Add(this.TxtDeposit);
            this.GbSum.Controls.Add(this.label7);
            this.GbSum.Controls.Add(this.TxtPAX);
            this.GbSum.Controls.Add(this.label6);
            this.GbSum.Controls.Add(this.TxtDays);
            this.GbSum.Controls.Add(this.label5);
            this.GbSum.Controls.Add(this.TxtCustnotCheckIn);
            this.GbSum.Controls.Add(this.label10);
            this.GbSum.Controls.Add(this.TxtNoShow);
            this.GbSum.Controls.Add(this.label11);
            this.GbSum.Controls.Add(this.TxtVoid);
            this.GbSum.Controls.Add(this.label12);
            this.GbSum.Controls.Add(this.TxtVoucherUse);
            this.GbSum.Controls.Add(this.label13);
            this.GbSum.Controls.Add(this.TxtVoucherSum);
            this.GbSum.Location = new System.Drawing.Point(524, 84);
            this.GbSum.Name = "GbSum";
            this.GbSum.Size = new System.Drawing.Size(404, 323);
            this.GbSum.TabIndex = 30;
            this.GbSum.TabStop = false;
            this.GbSum.Text = "สรุปรายละเอียดต่างๆ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "จำนวน Guest :";
            // 
            // TxtGuest
            // 
            this.TxtGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtGuest.Location = new System.Drawing.Point(147, 127);
            this.TxtGuest.Name = "TxtGuest";
            this.TxtGuest.Size = new System.Drawing.Size(105, 20);
            this.TxtGuest.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Deposit :";
            // 
            // TxtDeposit
            // 
            this.TxtDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtDeposit.Location = new System.Drawing.Point(147, 153);
            this.TxtDeposit.Name = "TxtDeposit";
            this.TxtDeposit.Size = new System.Drawing.Size(105, 20);
            this.TxtDeposit.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "จำนวนห้อง (PAX) :";
            // 
            // TxtPAX
            // 
            this.TxtPAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtPAX.Location = new System.Drawing.Point(147, 101);
            this.TxtPAX.Name = "TxtPAX";
            this.TxtPAX.Size = new System.Drawing.Size(105, 20);
            this.TxtPAX.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "จำนวนวัน (Days) :";
            // 
            // TxtDays
            // 
            this.TxtDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtDays.Location = new System.Drawing.Point(147, 75);
            this.TxtDays.Name = "TxtDays";
            this.TxtDays.Size = new System.Drawing.Size(105, 20);
            this.TxtDays.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Customer not check in :";
            // 
            // TxtCustnotCheckIn
            // 
            this.TxtCustnotCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtCustnotCheckIn.Location = new System.Drawing.Point(147, 249);
            this.TxtCustnotCheckIn.Name = "TxtCustnotCheckIn";
            this.TxtCustnotCheckIn.Size = new System.Drawing.Size(94, 20);
            this.TxtCustnotCheckIn.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "No Show :";
            // 
            // TxtNoShow
            // 
            this.TxtNoShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtNoShow.Location = new System.Drawing.Point(147, 223);
            this.TxtNoShow.Name = "TxtNoShow";
            this.TxtNoShow.Size = new System.Drawing.Size(94, 20);
            this.TxtNoShow.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Void :";
            // 
            // TxtVoid
            // 
            this.TxtVoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtVoid.Location = new System.Drawing.Point(147, 197);
            this.TxtVoid.Name = "TxtVoid";
            this.TxtVoid.Size = new System.Drawing.Size(94, 20);
            this.TxtVoid.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "จำนวน Voucher ที่ใช้งาน :";
            // 
            // TxtVoucherUse
            // 
            this.TxtVoucherUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtVoucherUse.Location = new System.Drawing.Point(147, 49);
            this.TxtVoucherUse.Name = "TxtVoucherUse";
            this.TxtVoucherUse.Size = new System.Drawing.Size(105, 20);
            this.TxtVoucherUse.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "จำนวน Voucher ทั้งหมด :";
            // 
            // TxtVoucherSum
            // 
            this.TxtVoucherSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtVoucherSum.Location = new System.Drawing.Point(147, 23);
            this.TxtVoucherSum.Name = "TxtVoucherSum";
            this.TxtVoucherSum.Size = new System.Drawing.Size(105, 20);
            this.TxtVoucherSum.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit,
            this.toolStripSeparator2,
            this.BtnRec,
            this.BtnOffice,
            this.BtnKPS,
            this.Btnwebkps,
            this.Btnsendemail,
            this.printToolStripButton,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.CboMonth,
            this.CboYear,
            this.BtnOk,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // exit
            // 
            this.exit.Image = global::ThaHr30.Properties.Resources.exit;
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(51, 22);
            this.exit.Text = "  Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnRec
            // 
            this.BtnRec.Image = ((System.Drawing.Image)(resources.GetObject("BtnRec.Image")));
            this.BtnRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRec.Name = "BtnRec";
            this.BtnRec.Size = new System.Drawing.Size(98, 22);
            this.BtnRec.Text = "  รับข้อมูลใหม่  ";
            this.BtnRec.Visible = false;
            this.BtnRec.Click += new System.EventHandler(this.BtnRec_Click);
            // 
            // BtnOffice
            // 
            this.BtnOffice.Image = global::ThaHr30.Properties.Resources.wi0096_16;
            this.BtnOffice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOffice.Name = "BtnOffice";
            this.BtnOffice.Size = new System.Drawing.Size(146, 22);
            this.BtnOffice.Text = "  ส่งข้อมูลเข้า head office";
            this.BtnOffice.Click += new System.EventHandler(this.BtnOffice_Click);
            // 
            // BtnKPS
            // 
            this.BtnKPS.Image = global::ThaHr30.Properties.Resources.wi0054_16;
            this.BtnKPS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnKPS.Name = "BtnKPS";
            this.BtnKPS.Size = new System.Drawing.Size(117, 22);
            this.BtnKPS.Text = "เตรียมข้อมูลส่ง KPS";
            this.BtnKPS.Click += new System.EventHandler(this.BtnKPS_Click);
            // 
            // Btnwebkps
            // 
            this.Btnwebkps.Image = global::ThaHr30.Properties.Resources.wi0064_161;
            this.Btnwebkps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btnwebkps.Name = "Btnwebkps";
            this.Btnwebkps.Size = new System.Drawing.Size(74, 22);
            this.Btnwebkps.Text = " web KPS ";
            this.Btnwebkps.Click += new System.EventHandler(this.Btnwebkps_Click);
            // 
            // Btnsendemail
            // 
            this.Btnsendemail.Image = global::ThaHr30.Properties.Resources.ei0021_161;
            this.Btnsendemail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btnsendemail.Name = "Btnsendemail";
            this.Btnsendemail.Size = new System.Drawing.Size(138, 22);
            this.Btnsendemail.Text = "  แจ้งยอดขายทาง E-Mail";
            this.Btnsendemail.Click += new System.EventHandler(this.Btnsendemail_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(55, 22);
            this.printToolStripButton.Text = "  &Print";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "  เดือน : ";
            // 
            // CboMonth
            // 
            this.CboMonth.Name = "CboMonth";
            this.CboMonth.Size = new System.Drawing.Size(121, 25);
            // 
            // CboYear
            // 
            this.CboYear.Name = "CboYear";
            this.CboYear.Size = new System.Drawing.Size(161, 25);
            this.CboYear.Click += new System.EventHandler(this.CboYear_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Image = ((System.Drawing.Image)(resources.GetObject("BtnOk.Image")));
            this.BtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(66, 22);
            this.BtnOk.Text = "  Search";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // ShopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 537);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GbSum);
            this.Controls.Add(this.Stb);
            this.Controls.Add(this.GrdView);
            this.KeyPreview = true;
            this.Name = "ShopView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShopView_KeyUp);
            this.Load += new System.EventHandler(this.ShopView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.Stb.ResumeLayout(false);
            this.Stb.PerformLayout();
            this.GbSum.ResumeLayout(false);
            this.GbSum.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.StatusStrip Stb;
        private System.Windows.Forms.ToolStripStatusLabel SL1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private System.Windows.Forms.GroupBox GbSum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtGuest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtDeposit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtPAX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDays;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCustnotCheckIn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtNoShow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtVoid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtVoucherUse;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtVoucherSum;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnRec;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox CboMonth;
        private System.Windows.Forms.ToolStripComboBox CboYear;
        private System.Windows.Forms.ToolStripButton BtnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton BtnOffice;
        private System.Windows.Forms.ToolStripButton Btnsendemail;
        private System.Windows.Forms.ToolStripButton BtnKPS;
        private System.Windows.Forms.ToolStripButton Btnwebkps;
    }
}