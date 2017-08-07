namespace ThaHr30
{
    partial class AccInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccInvoice));
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.adjustdata = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSend = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CboMonth = new System.Windows.Forms.ToolStripComboBox();
            this.CboYear = new System.Windows.Forms.ToolStripComboBox();
            this.BtnOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Sl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtEmailSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtEmailFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkSendEmailAll = new System.Windows.Forms.CheckBox();
            this.ChkGenPDFAll = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit,
            this.toolStripSeparator2,
            this.adjustdata,
            this.save,
            this.toolStripButton1,
            this.printToolStripButton,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.CboMonth,
            this.CboYear,
            this.BtnOk,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip1.TabIndex = 27;
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // adjustdata
            // 
            this.adjustdata.Image = ((System.Drawing.Image)(resources.GetObject("adjustdata.Image")));
            this.adjustdata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adjustdata.Name = "adjustdata";
            this.adjustdata.Size = new System.Drawing.Size(91, 22);
            this.adjustdata.Text = "ปรับปรุงข้อมูล";
            this.adjustdata.Click += new System.EventHandler(this.adjustdata_Click);
            // 
            // save
            // 
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(96, 22);
            this.save.Text = "  เตรียมข้อมูล  ";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnSendEmail,
            this.BtnSend});
            this.toolStripButton1.Image = global::ThaHr30.Properties.Resources.blogicon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(108, 22);
            this.toolStripButton1.Text = "More Action ...";
            // 
            // BtnSendEmail
            // 
            this.BtnSendEmail.Image = global::ThaHr30.Properties.Resources.ei0021_16;
            this.BtnSendEmail.Name = "BtnSendEmail";
            this.BtnSendEmail.Size = new System.Drawing.Size(182, 22);
            this.BtnSendEmail.Text = "ส่งข้อมูลทาง E-Mail";
            this.BtnSendEmail.Click += new System.EventHandler(this.BtnSendEmail_Click);
            // 
            // BtnSend
            // 
            this.BtnSend.Image = global::ThaHr30.Properties.Resources.print_check_icon;
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(182, 22);
            this.BtnSend.Text = "พิมพ์เอกสารเพื่อส่ง FAX";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(55, 22);
            this.printToolStripButton.Text = "  &Print";
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
            this.CboMonth.DropDownClosed += new System.EventHandler(this.CboMonth_DropDownClosed);
            // 
            // CboYear
            // 
            this.CboYear.Name = "CboYear";
            this.CboYear.Size = new System.Drawing.Size(161, 25);
            // 
            // BtnOk
            // 
            this.BtnOk.Image = global::ThaHr30.Properties.Resources.binocular_icon;
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sl1,
            this.Pb1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Sl1
            // 
            this.Sl1.Name = "Sl1";
            this.Sl1.Size = new System.Drawing.Size(38, 17);
            this.Sl1.Text = "Status";
            // 
            // Pb1
            // 
            this.Pb1.Name = "Pb1";
            this.Pb1.Size = new System.Drawing.Size(800, 16);
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "GrdView";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(12, 91);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(732, 385);
            this.GrdView.TabIndex = 29;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdView.TextTipAppearance = tipAppearance2;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtEmailSubject);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtEmailFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChkSendEmailAll);
            this.groupBox1.Controls.Add(this.ChkGenPDFAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 51);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "การทำงาน";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TxtEmailSubject
            // 
            this.TxtEmailSubject.Location = new System.Drawing.Point(750, 17);
            this.TxtEmailSubject.Name = "TxtEmailSubject";
            this.TxtEmailSubject.Size = new System.Drawing.Size(210, 20);
            this.TxtEmailSubject.TabIndex = 5;
            this.TxtEmailSubject.Text = "Test send e-mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(664, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "E-mail Subject :";
            // 
            // TxtEmailFrom
            // 
            this.TxtEmailFrom.Location = new System.Drawing.Point(443, 17);
            this.TxtEmailFrom.Name = "TxtEmailFrom";
            this.TxtEmailFrom.Size = new System.Drawing.Size(210, 20);
            this.TxtEmailFrom.TabIndex = 3;
            this.TxtEmailFrom.Text = "eploentham@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-mail From :";
            // 
            // ChkSendEmailAll
            // 
            this.ChkSendEmailAll.AutoSize = true;
            this.ChkSendEmailAll.Location = new System.Drawing.Point(191, 19);
            this.ChkSendEmailAll.Name = "ChkSendEmailAll";
            this.ChkSendEmailAll.Size = new System.Drawing.Size(164, 17);
            this.ChkSendEmailAll.TabIndex = 1;
            this.ChkSendEmailAll.Text = "ให้โปรแกรมส่ง E-Mail ทั้งหมด";
            this.ChkSendEmailAll.UseVisualStyleBackColor = true;
            this.ChkSendEmailAll.CheckedChanged += new System.EventHandler(this.ChkSendEmailAll_CheckedChanged);
            // 
            // ChkGenPDFAll
            // 
            this.ChkGenPDFAll.AutoSize = true;
            this.ChkGenPDFAll.Location = new System.Drawing.Point(7, 20);
            this.ChkGenPDFAll.Name = "ChkGenPDFAll";
            this.ChkGenPDFAll.Size = new System.Drawing.Size(164, 17);
            this.ChkGenPDFAll.TabIndex = 0;
            this.ChkGenPDFAll.Text = "เตรียมข้อมูล gen PDF ทั้งหมด";
            this.ChkGenPDFAll.UseVisualStyleBackColor = true;
            this.ChkGenPDFAll.CheckedChanged += new System.EventHandler(this.ChkGenPDFAll_CheckedChanged);
            // 
            // AccInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrdView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AccInvoice";
            this.Text = "AccInvoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AccInvoice_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox CboMonth;
        private System.Windows.Forms.ToolStripComboBox CboYear;
        private System.Windows.Forms.ToolStripButton BtnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Sl1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkSendEmailAll;
        private System.Windows.Forms.CheckBox ChkGenPDFAll;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem BtnSendEmail;
        private System.Windows.Forms.ToolStripMenuItem BtnSend;
        private System.Windows.Forms.TextBox TxtEmailFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEmailSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton adjustdata;
    }
}