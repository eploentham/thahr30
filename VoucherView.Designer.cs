namespace ThaHr30
{
    partial class VoucherView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoucherView));
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.GbCondition = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEndDate = new System.Windows.Forms.DateTimePicker();
            this.TxtStartDate = new System.Windows.Forms.DateTimePicker();
            this.Stb = new System.Windows.Forms.StatusStrip();
            this.SL1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.Tb = new System.Windows.Forms.ToolStrip();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NewVoucher = new System.Windows.Forms.ToolStripButton();
            this.Print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CboCounter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.CboVoucherView = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.TxtVouNo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.GbCondition.SuspendLayout();
            this.Stb.SuspendLayout();
            this.Tb.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(12, 90);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(955, 368);
            this.GrdView.TabIndex = 24;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdView.TextTipAppearance = tipAppearance1;
            this.GrdView.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.GrdView_ButtonClicked);
            this.GrdView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.GrdView_CellDoubleClick);
            this.GrdView.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.GrdView_CellClick);
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
            // GbCondition
            // 
            this.GbCondition.Controls.Add(this.label2);
            this.GbCondition.Controls.Add(this.label1);
            this.GbCondition.Controls.Add(this.TxtEndDate);
            this.GbCondition.Controls.Add(this.TxtStartDate);
            this.GbCondition.Location = new System.Drawing.Point(12, 28);
            this.GbCondition.Name = "GbCondition";
            this.GbCondition.Size = new System.Drawing.Size(1065, 52);
            this.GbCondition.TabIndex = 25;
            this.GbCondition.TabStop = false;
            this.GbCondition.Text = "เงื่อนไข";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ถึงวันที่ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ตั้งแต่วันที่ :";
            // 
            // TxtEndDate
            // 
            this.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtEndDate.Location = new System.Drawing.Point(247, 21);
            this.TxtEndDate.Name = "TxtEndDate";
            this.TxtEndDate.Size = new System.Drawing.Size(95, 20);
            this.TxtEndDate.TabIndex = 1;
            // 
            // TxtStartDate
            // 
            this.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtStartDate.Location = new System.Drawing.Point(85, 21);
            this.TxtStartDate.Name = "TxtStartDate";
            this.TxtStartDate.Size = new System.Drawing.Size(94, 20);
            this.TxtStartDate.TabIndex = 0;
            // 
            // Stb
            // 
            this.Stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SL1,
            this.Pb1});
            this.Stb.Location = new System.Drawing.Point(0, 493);
            this.Stb.Name = "Stb";
            this.Stb.Size = new System.Drawing.Size(1089, 22);
            this.Stb.TabIndex = 26;
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
            // Tb
            // 
            this.Tb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit,
            this.toolStripSeparator2,
            this.NewVoucher,
            this.Print,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.CboCounter,
            this.toolStripLabel2,
            this.CboVoucherView,
            this.toolStripSeparator4,
            this.search,
            this.toolStripSeparator,
            this.toolStripLabel3,
            this.TxtVouNo,
            this.toolStripSeparator5,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.Tb.Location = new System.Drawing.Point(0, 0);
            this.Tb.Name = "Tb";
            this.Tb.Size = new System.Drawing.Size(1089, 25);
            this.Tb.TabIndex = 27;
            this.Tb.Text = "toolStrip1";
            // 
            // Exit
            // 
            this.Exit.Image = global::ThaHr30.Properties.Resources.exit;
            this.Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(51, 22);
            this.Exit.Text = "  Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NewVoucher
            // 
            this.NewVoucher.Image = global::ThaHr30.Properties.Resources.wi0062_16;
            this.NewVoucher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewVoucher.Name = "NewVoucher";
            this.NewVoucher.Size = new System.Drawing.Size(93, 22);
            this.NewVoucher.Text = " New Voucher";
            this.NewVoucher.Click += new System.EventHandler(this.NewVoucher_Click);
            // 
            // Print
            // 
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(67, 22);
            this.Print.Text = "   &Print   ";
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel1.Text = "   Counter : ";
            // 
            // CboCounter
            // 
            this.CboCounter.Name = "CboCounter";
            this.CboCounter.Size = new System.Drawing.Size(121, 25);
            this.CboCounter.Click += new System.EventHandler(this.CboCounter_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel2.Text = "   ตามประเภท  :   ";
            // 
            // CboVoucherView
            // 
            this.CboVoucherView.Name = "CboVoucherView";
            this.CboVoucherView.Size = new System.Drawing.Size(121, 25);
            this.CboVoucherView.SelectedIndexChanged += new System.EventHandler(this.CboVoucherView_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // search
            // 
            this.search.Image = global::ThaHr30.Properties.Resources.wi0009_16;
            this.search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(69, 22);
            this.search.Text = " Search  ";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel3.Text = "Voucher No :";
            // 
            // TxtVouNo
            // 
            this.TxtVouNo.Name = "TxtVouNo";
            this.TxtVouNo.Size = new System.Drawing.Size(100, 25);
            this.TxtVouNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtVouNo_KeyUp);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
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
            // VoucherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 515);
            this.Controls.Add(this.Tb);
            this.Controls.Add(this.Stb);
            this.Controls.Add(this.GbCondition);
            this.Controls.Add(this.GrdView);
            this.KeyPreview = true;
            this.Name = "VoucherView";
            this.Text = "VoucherView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VoucherView_KeyUp);
            this.Load += new System.EventHandler(this.VoucherView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.GbCondition.ResumeLayout(false);
            this.GbCondition.PerformLayout();
            this.Stb.ResumeLayout(false);
            this.Stb.PerformLayout();
            this.Tb.ResumeLayout(false);
            this.Tb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.GroupBox GbCondition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TxtEndDate;
        private System.Windows.Forms.DateTimePicker TxtStartDate;
        private System.Windows.Forms.StatusStrip Stb;
        private System.Windows.Forms.ToolStripStatusLabel SL1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private System.Windows.Forms.ToolStrip Tb;
        private System.Windows.Forms.ToolStripButton Exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton NewVoucher;
        private System.Windows.Forms.ToolStripButton Print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox CboCounter;
        private System.Windows.Forms.ToolStripComboBox CboVoucherView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton search;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox TxtVouNo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}