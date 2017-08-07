namespace ThaHr30
{
    partial class MeetingAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeetingAdd));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.saveclose = new System.Windows.Forms.ToolStripButton();
            this.print = new System.Windows.Forms.ToolStripDropDownButton();
            this.prnlistname = new System.Windows.Forms.ToolStripMenuItem();
            this.printLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toWordAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ex_all_sort_Thai = new System.Windows.Forms.ToolStripMenuItem();
            this.ex_all_sort_Eng = new System.Windows.Forms.ToolStripMenuItem();
            this.toWordSome = new System.Windows.Forms.ToolStripMenuItem();
            this.ex_sort_Thai = new System.Windows.Forms.ToolStripMenuItem();
            this.ex_sort_Eng = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.ToolStripDropDownButton();
            this.cancelvoid = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMeetingID = new System.Windows.Forms.TextBox();
            this.TxtMeetingNameT = new System.Windows.Forms.TextBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.TxtPlace = new System.Windows.Forms.TextBox();
            this.TxtStartDate = new System.Windows.Forms.MaskedTextBox();
            this.TxtStartTime = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.TxtEndTime = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtRemark = new System.Windows.Forms.TextBox();
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Stb = new System.Windows.Forms.StatusStrip();
            this.SL1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.btnClearPrintLabel = new System.Windows.Forms.Button();
            this.btnSetPrintLabel = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.Stb.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit,
            this.toolStripSeparator5,
            this.saveclose,
            this.print,
            this.id,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip1.TabIndex = 24;
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // saveclose
            // 
            this.saveclose.Image = ((System.Drawing.Image)(resources.GetObject("saveclose.Image")));
            this.saveclose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveclose.Name = "saveclose";
            this.saveclose.Size = new System.Drawing.Size(90, 22);
            this.saveclose.Text = "&Save && Close";
            this.saveclose.Click += new System.EventHandler(this.saveclose_Click);
            // 
            // print
            // 
            this.print.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prnlistname,
            this.printLabel,
            this.toolStripMenuItem1});
            this.print.Image = ((System.Drawing.Image)(resources.GetObject("print.Image")));
            this.print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(61, 22);
            this.print.Text = "&Print ";
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // prnlistname
            // 
            this.prnlistname.Name = "prnlistname";
            this.prnlistname.Size = new System.Drawing.Size(211, 22);
            this.prnlistname.Text = "Print รายชื่อผู้เข้าประชุม";
            this.prnlistname.Click += new System.EventHandler(this.prnlistname_Click);
            // 
            // printLabel
            // 
            this.printLabel.Name = "printLabel";
            this.printLabel.Size = new System.Drawing.Size(211, 22);
            this.printLabel.Text = "Print Label รายชื่อผู้เข้าประชุม";
            this.printLabel.Click += new System.EventHandler(this.printLabel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toWordAll,
            this.toWordSome});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem1.Text = "Export รายงานการประชุม";
            // 
            // toWordAll
            // 
            this.toWordAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ex_all_sort_Thai,
            this.ex_all_sort_Eng});
            this.toWordAll.Name = "toWordAll";
            this.toWordAll.Size = new System.Drawing.Size(152, 22);
            this.toWordAll.Text = "ทั้งหมด";
            this.toWordAll.Click += new System.EventHandler(this.toWordAll_Click);
            // 
            // ex_all_sort_Thai
            // 
            this.ex_all_sort_Thai.Name = "ex_all_sort_Thai";
            this.ex_all_sort_Thai.Size = new System.Drawing.Size(221, 22);
            this.ex_all_sort_Thai.Text = "เรียงตาม ชื่อสมาชิกภาษาไทย";
            this.ex_all_sort_Thai.Click += new System.EventHandler(this.ex_all_sort_Thai_Click);
            // 
            // ex_all_sort_Eng
            // 
            this.ex_all_sort_Eng.Name = "ex_all_sort_Eng";
            this.ex_all_sort_Eng.Size = new System.Drawing.Size(221, 22);
            this.ex_all_sort_Eng.Text = "เรียงตาม ชื่อสมาชิกภาษาอังกฤษ";
            this.ex_all_sort_Eng.Click += new System.EventHandler(this.ex_all_sort_Eng_Click);
            // 
            // toWordSome
            // 
            this.toWordSome.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ex_sort_Thai,
            this.ex_sort_Eng});
            this.toWordSome.Name = "toWordSome";
            this.toWordSome.Size = new System.Drawing.Size(152, 22);
            this.toWordSome.Text = "เฉพาะผู้มาประชุม";
            this.toWordSome.Click += new System.EventHandler(this.toWordSome_Click);
            // 
            // ex_sort_Thai
            // 
            this.ex_sort_Thai.Name = "ex_sort_Thai";
            this.ex_sort_Thai.Size = new System.Drawing.Size(221, 22);
            this.ex_sort_Thai.Text = "เรียงตาม ชื่อสมาชิกภาษาไทย";
            this.ex_sort_Thai.Click += new System.EventHandler(this.ex_sort_Thai_Click);
            // 
            // ex_sort_Eng
            // 
            this.ex_sort_Eng.Name = "ex_sort_Eng";
            this.ex_sort_Eng.Size = new System.Drawing.Size(221, 22);
            this.ex_sort_Eng.Text = "เรียงตาม ชื่อสมาชิกภาษาอังกฤษ";
            this.ex_sort_Eng.Click += new System.EventHandler(this.ex_sort_Eng_Click);
            // 
            // id
            // 
            this.id.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelvoid,
            this.deleteVoucher,
            this.toolStripSeparator6});
            this.id.Image = global::ThaHr30.Properties.Resources.blogicon;
            this.id.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(105, 22);
            this.id.Text = "More Action...";
            // 
            // cancelvoid
            // 
            this.cancelvoid.Name = "cancelvoid";
            this.cancelvoid.Size = new System.Drawing.Size(147, 22);
            this.cancelvoid.Text = "Cancel Void";
            // 
            // deleteVoucher
            // 
            this.deleteVoucher.Name = "deleteVoucher";
            this.deleteVoucher.Size = new System.Drawing.Size(147, 22);
            this.deleteVoucher.Text = "Delete Voucher";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(144, 6);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Meeting ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "ชื่อการประชุม :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "รายละเอียดการประชุม :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "สถานที่จัดการประชุม :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "วันที่จัดการประชุม :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "หมายเหตุ :";
            // 
            // TxtMeetingID
            // 
            this.TxtMeetingID.Location = new System.Drawing.Point(130, 45);
            this.TxtMeetingID.Name = "TxtMeetingID";
            this.TxtMeetingID.ReadOnly = true;
            this.TxtMeetingID.Size = new System.Drawing.Size(126, 20);
            this.TxtMeetingID.TabIndex = 32;
            // 
            // TxtMeetingNameT
            // 
            this.TxtMeetingNameT.Location = new System.Drawing.Point(130, 71);
            this.TxtMeetingNameT.Multiline = true;
            this.TxtMeetingNameT.Name = "TxtMeetingNameT";
            this.TxtMeetingNameT.Size = new System.Drawing.Size(263, 49);
            this.TxtMeetingNameT.TabIndex = 34;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(130, 126);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(263, 81);
            this.TxtDescription.TabIndex = 35;
            // 
            // TxtPlace
            // 
            this.TxtPlace.Location = new System.Drawing.Point(130, 213);
            this.TxtPlace.Name = "TxtPlace";
            this.TxtPlace.Size = new System.Drawing.Size(263, 20);
            this.TxtPlace.TabIndex = 36;
            // 
            // TxtStartDate
            // 
            this.TxtStartDate.Location = new System.Drawing.Point(130, 239);
            this.TxtStartDate.Mask = "99/99/9999";
            this.TxtStartDate.Name = "TxtStartDate";
            this.TxtStartDate.Size = new System.Drawing.Size(76, 20);
            this.TxtStartDate.TabIndex = 37;
            // 
            // TxtStartTime
            // 
            this.TxtStartTime.Location = new System.Drawing.Point(130, 283);
            this.TxtStartTime.Mask = "00:00";
            this.TxtStartTime.Name = "TxtStartTime";
            this.TxtStartTime.Size = new System.Drawing.Size(62, 20);
            this.TxtStartTime.TabIndex = 39;
            this.TxtStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "เวลาประชุม :";
            // 
            // TxtEndDate
            // 
            this.TxtEndDate.Location = new System.Drawing.Point(275, 239);
            this.TxtEndDate.Mask = "99/99/9999";
            this.TxtEndDate.Name = "TxtEndDate";
            this.TxtEndDate.Size = new System.Drawing.Size(76, 20);
            this.TxtEndDate.TabIndex = 40;
            // 
            // TxtEndTime
            // 
            this.TxtEndTime.Location = new System.Drawing.Point(275, 283);
            this.TxtEndTime.Mask = "00:00";
            this.TxtEndTime.Name = "TxtEndTime";
            this.TxtEndTime.Size = new System.Drawing.Size(76, 20);
            this.TxtEndTime.TabIndex = 41;
            this.TxtEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "ถึง :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "ถึง :";
            // 
            // TxtRemark
            // 
            this.TxtRemark.Location = new System.Drawing.Point(130, 309);
            this.TxtRemark.Multiline = true;
            this.TxtRemark.Name = "TxtRemark";
            this.TxtRemark.Size = new System.Drawing.Size(263, 81);
            this.TxtRemark.TabIndex = 44;
            // 
            // GrdView
            // 
            this.GrdView.AccessibleDescription = "GrdView";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(399, 28);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(629, 698);
            this.GrdView.TabIndex = 45;
            this.GrdView.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.GrdView_Change);
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
            this.Stb.Location = new System.Drawing.Point(0, 724);
            this.Stb.Name = "Stb";
            this.Stb.Size = new System.Drawing.Size(1028, 22);
            this.Stb.TabIndex = 50;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "dd/mm/yyyy ปีพ.ศ.";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Image = global::ThaHr30.Properties.Resources.binocular_icon;
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearch.Location = new System.Drawing.Point(293, 408);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(100, 50);
            this.BtnSearch.TabIndex = 56;
            this.BtnSearch.Text = "ดึงข้อมูล";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Image = global::ThaHr30.Properties.Resources.deletecontent;
            this.BtnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDel.Location = new System.Drawing.Point(296, 541);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(97, 23);
            this.BtnDel.TabIndex = 49;
            this.BtnDel.Text = "ลบข้อมูล";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Image = global::ThaHr30.Properties.Resources.blogicon;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdd.Location = new System.Drawing.Point(296, 510);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(97, 23);
            this.BtnAdd.TabIndex = 48;
            this.BtnAdd.Text = "เพิ่มข้อมูล";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Image = global::ThaHr30.Properties.Resources.stop;
            this.BtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClear.Location = new System.Drawing.Point(296, 475);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(97, 23);
            this.BtnClear.TabIndex = 47;
            this.BtnClear.Text = "ล้างข้อมูล";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnClearPrintLabel
            // 
            this.btnClearPrintLabel.Location = new System.Drawing.Point(131, 396);
            this.btnClearPrintLabel.Name = "btnClearPrintLabel";
            this.btnClearPrintLabel.Size = new System.Drawing.Size(125, 23);
            this.btnClearPrintLabel.TabIndex = 58;
            this.btnClearPrintLabel.Text = "Clear print Label";
            this.btnClearPrintLabel.UseVisualStyleBackColor = true;
            this.btnClearPrintLabel.Click += new System.EventHandler(this.btnClearPrintLabel_Click);
            // 
            // btnSetPrintLabel
            // 
            this.btnSetPrintLabel.Location = new System.Drawing.Point(131, 435);
            this.btnSetPrintLabel.Name = "btnSetPrintLabel";
            this.btnSetPrintLabel.Size = new System.Drawing.Size(125, 23);
            this.btnSetPrintLabel.TabIndex = 59;
            this.btnSetPrintLabel.Text = "Set print Label";
            this.btnSetPrintLabel.UseVisualStyleBackColor = true;
            this.btnSetPrintLabel.Click += new System.EventHandler(this.btnSetPrintLabel_Click);
            // 
            // MeetingAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.btnSetPrintLabel);
            this.Controls.Add(this.btnClearPrintLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.Stb);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.GrdView);
            this.Controls.Add(this.TxtRemark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtEndTime);
            this.Controls.Add(this.TxtEndDate);
            this.Controls.Add(this.TxtStartTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtStartDate);
            this.Controls.Add(this.TxtPlace);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.TxtMeetingNameT);
            this.Controls.Add(this.TxtMeetingID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MeetingAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemberMeetingAdd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MemberMeetingAdd_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.Stb.ResumeLayout(false);
            this.Stb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton saveclose;
        private System.Windows.Forms.ToolStripDropDownButton id;
        private System.Windows.Forms.ToolStripMenuItem cancelvoid;
        private System.Windows.Forms.ToolStripMenuItem deleteVoucher;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtMeetingID;
        private System.Windows.Forms.TextBox TxtMeetingNameT;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.TextBox TxtPlace;
        private System.Windows.Forms.MaskedTextBox TxtStartDate;
        private System.Windows.Forms.MaskedTextBox TxtStartTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox TxtEndDate;
        private System.Windows.Forms.MaskedTextBox TxtEndTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtRemark;
        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.StatusStrip Stb;
        private System.Windows.Forms.ToolStripStatusLabel SL1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripDropDownButton print;
        private System.Windows.Forms.ToolStripMenuItem prnlistname;
        private System.Windows.Forms.ToolStripMenuItem printLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toWordAll;
        private System.Windows.Forms.ToolStripMenuItem toWordSome;
        private System.Windows.Forms.ToolStripMenuItem ex_sort_Thai;
        private System.Windows.Forms.ToolStripMenuItem ex_sort_Eng;
        private System.Windows.Forms.ToolStripMenuItem ex_all_sort_Thai;
        private System.Windows.Forms.ToolStripMenuItem ex_all_sort_Eng;
        private System.Windows.Forms.Button btnClearPrintLabel;
        private System.Windows.Forms.Button btnSetPrintLabel;
    }
}