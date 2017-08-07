namespace ThaHr30
{
    partial class AccMemberYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccMemberYear));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CboYear = new System.Windows.Forms.ToolStripComboBox();
            this.BtnOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.GbSum = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtVatRate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtVATSum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtMemberFeeSum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtSaleSum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtMemberFee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtRoom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMeeting = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtMeetingSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSubTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRoomSum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMemberSum = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.GbSum.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit,
            this.toolStripSeparator2,
            this.save,
            this.printToolStripButton,
            this.toolStripSeparator3,
            this.toolStripLabel1,
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
            this.toolStrip1.Size = new System.Drawing.Size(973, 25);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // exit
            // 
            this.exit.Image = ((System.Drawing.Image)(resources.GetObject("exit.Image")));
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
            // save
            // 
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(97, 22);
            this.save.Text = "  บันทึกข้อมูลทั้งหมด  ";
            this.save.Click += new System.EventHandler(this.save_Click);
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
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "  Year : ";
            // 
            // CboYear
            // 
            this.CboYear.Name = "CboYear";
            this.CboYear.Size = new System.Drawing.Size(161, 25);
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
            this.toolStripStatusLabel1,
            this.Pb1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(973, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // Pb1
            // 
            this.Pb1.Name = "Pb1";
            this.Pb1.Size = new System.Drawing.Size(800, 16);
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(8, 33);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(955, 442);
            this.GrdView.TabIndex = 31;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdView.TextTipAppearance = tipAppearance1;
            this.GrdView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.GrdView_CellDoubleClick);
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
            // GbSum
            // 
            this.GbSum.Controls.Add(this.label12);
            this.GbSum.Controls.Add(this.TxtVatRate);
            this.GbSum.Controls.Add(this.label11);
            this.GbSum.Controls.Add(this.TxtTotal);
            this.GbSum.Controls.Add(this.label10);
            this.GbSum.Controls.Add(this.TxtVATSum);
            this.GbSum.Controls.Add(this.label9);
            this.GbSum.Controls.Add(this.TxtMemberFeeSum);
            this.GbSum.Controls.Add(this.label8);
            this.GbSum.Controls.Add(this.TxtSaleSum);
            this.GbSum.Controls.Add(this.label7);
            this.GbSum.Controls.Add(this.TxtMemberFee);
            this.GbSum.Controls.Add(this.label6);
            this.GbSum.Controls.Add(this.TxtRoom);
            this.GbSum.Controls.Add(this.label5);
            this.GbSum.Controls.Add(this.TxtMeeting);
            this.GbSum.Controls.Add(this.label4);
            this.GbSum.Controls.Add(this.TxtMeetingSum);
            this.GbSum.Controls.Add(this.label3);
            this.GbSum.Controls.Add(this.TxtSubTotal);
            this.GbSum.Controls.Add(this.label2);
            this.GbSum.Controls.Add(this.TxtRoomSum);
            this.GbSum.Controls.Add(this.label1);
            this.GbSum.Controls.Add(this.TxtMemberSum);
            this.GbSum.Location = new System.Drawing.Point(629, 49);
            this.GbSum.Name = "GbSum";
            this.GbSum.Size = new System.Drawing.Size(291, 406);
            this.GbSum.TabIndex = 32;
            this.GbSum.TabStop = false;
            this.GbSum.Text = "สรุปรายละเอียดต่างๆ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 361);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "VAT Rate :";
            // 
            // TxtVatRate
            // 
            this.TxtVatRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtVatRate.Location = new System.Drawing.Point(155, 358);
            this.TxtVatRate.Name = "TxtVatRate";
            this.TxtVatRate.Size = new System.Drawing.Size(94, 20);
            this.TxtVatRate.TabIndex = 30;
            this.TxtVatRate.Text = "7.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "TOTAL :";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtTotal.Location = new System.Drawing.Point(155, 216);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(94, 20);
            this.TxtTotal.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "VAT :";
            // 
            // TxtVATSum
            // 
            this.TxtVATSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtVATSum.Location = new System.Drawing.Point(155, 191);
            this.TxtVATSum.Name = "TxtVATSum";
            this.TxtVATSum.Size = new System.Drawing.Size(94, 20);
            this.TxtVATSum.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "ค่า Member Fee ทั้งหมด :";
            // 
            // TxtMemberFeeSum
            // 
            this.TxtMemberFeeSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtMemberFeeSum.Location = new System.Drawing.Point(155, 75);
            this.TxtMemberFeeSum.Name = "TxtMemberFeeSum";
            this.TxtMemberFeeSum.Size = new System.Drawing.Size(94, 20);
            this.TxtMemberFeeSum.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "ค่า Sale room ทั้งหมด :";
            // 
            // TxtSaleSum
            // 
            this.TxtSaleSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtSaleSum.Location = new System.Drawing.Point(155, 127);
            this.TxtSaleSum.Name = "TxtSaleSum";
            this.TxtSaleSum.Size = new System.Drawing.Size(94, 20);
            this.TxtSaleSum.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "ค่า Member Fee :";
            // 
            // TxtMemberFee
            // 
            this.TxtMemberFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtMemberFee.Location = new System.Drawing.Point(155, 280);
            this.TxtMemberFee.Name = "TxtMemberFee";
            this.TxtMemberFee.Size = new System.Drawing.Size(94, 20);
            this.TxtMemberFee.TabIndex = 20;
            this.TxtMemberFee.Text = "3000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "ค่า Room ที่เรียกเก็บต่อห้อง :";
            // 
            // TxtRoom
            // 
            this.TxtRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtRoom.Location = new System.Drawing.Point(155, 306);
            this.TxtRoom.Name = "TxtRoom";
            this.TxtRoom.Size = new System.Drawing.Size(94, 20);
            this.TxtRoom.TabIndex = 18;
            this.TxtRoom.Text = "381";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "ค่า Meeting ที่เรียกเก็บ :";
            // 
            // TxtMeeting
            // 
            this.TxtMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtMeeting.Location = new System.Drawing.Point(155, 332);
            this.TxtMeeting.Name = "TxtMeeting";
            this.TxtMeeting.Size = new System.Drawing.Size(94, 20);
            this.TxtMeeting.TabIndex = 16;
            this.TxtMeeting.Text = "1401.87";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "ค่า Meeting ทั้งหมด :";
            // 
            // TxtMeetingSum
            // 
            this.TxtMeetingSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtMeetingSum.Location = new System.Drawing.Point(155, 101);
            this.TxtMeetingSum.Name = "TxtMeetingSum";
            this.TxtMeetingSum.Size = new System.Drawing.Size(94, 20);
            this.TxtMeetingSum.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sub Total :";
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtSubTotal.Location = new System.Drawing.Point(155, 165);
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.Size = new System.Drawing.Size(94, 20);
            this.TxtSubTotal.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "จำนวน Room ที่ใช้งาน :";
            // 
            // TxtRoomSum
            // 
            this.TxtRoomSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtRoomSum.Location = new System.Drawing.Point(155, 49);
            this.TxtRoomSum.Name = "TxtRoomSum";
            this.TxtRoomSum.Size = new System.Drawing.Size(94, 20);
            this.TxtRoomSum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "จำนวน Member ทั้งหมด :";
            // 
            // TxtMemberSum
            // 
            this.TxtMemberSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtMemberSum.Location = new System.Drawing.Point(155, 23);
            this.TxtMemberSum.Name = "TxtMemberSum";
            this.TxtMemberSum.Size = new System.Drawing.Size(94, 20);
            this.TxtMemberSum.TabIndex = 0;
            // 
            // AccMemberYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 502);
            this.Controls.Add(this.GbSum);
            this.Controls.Add(this.GrdView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AccMemberYear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccMemberYear";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AccMemberYear_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.GbSum.ResumeLayout(false);
            this.GbSum.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox CboYear;
        private System.Windows.Forms.ToolStripButton BtnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.GroupBox GbSum;
        private System.Windows.Forms.TextBox TxtSubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRoomSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMemberSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtMeetingSum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMeeting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtRoom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtMemberFee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtSaleSum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtMemberFeeSum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtVATSum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtVatRate;
    }
}