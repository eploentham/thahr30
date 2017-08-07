namespace ThaHr30
{
    partial class MemberView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberView));
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.GrdFilter = new FarPoint.Win.Spread.FpSpread();
            this.GrdFilter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Stb = new System.Windows.Forms.StatusStrip();
            this.SL1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.Tb = new System.Windows.Forms.ToolStrip();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NewMember = new System.Windows.Forms.ToolStripButton();
            this.contactoutlook = new System.Windows.Forms.ToolStripDropDownButton();
            this.updateContactOutlook = new System.Windows.Forms.ToolStripMenuItem();
            this.updateContactOutlookALL = new System.Windows.Forms.ToolStripMenuItem();
            this.updateContactOutlookModify = new System.Windows.Forms.ToolStripMenuItem();
            this.Print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.CboFilter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Img1 = new System.Windows.Forms.ImageList(this.components);
            this.Img2 = new System.Windows.Forms.ImageList(this.components);
            this.Img3 = new System.Windows.Forms.ImageList(this.components);
            this.Img4 = new System.Windows.Forms.ImageList(this.components);
            this.Img5 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFilter_Sheet1)).BeginInit();
            this.Stb.SuspendLayout();
            this.Tb.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdView
            // 
            this.GrdView.AccessibleDescription = "";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(12, 39);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(897, 400);
            this.GrdView.TabIndex = 16;
            this.GrdView.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.GrdView_CellClick);
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
            // GrdFilter
            // 
            this.GrdFilter.AccessibleDescription = "";
            this.GrdFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdFilter.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdFilter.Location = new System.Drawing.Point(14, 524);
            this.GrdFilter.Name = "GrdFilter";
            this.GrdFilter.ScrollBarMaxAlign = false;
            this.GrdFilter.ScrollBarShowMax = false;
            this.GrdFilter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdFilter_Sheet1});
            this.GrdFilter.Size = new System.Drawing.Size(900, 63);
            this.GrdFilter.TabIndex = 17;
            this.GrdFilter.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdFilter.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.GrdFilter_CellClick);
            // 
            // GrdFilter_Sheet1
            // 
            this.GrdFilter_Sheet1.Reset();
            this.GrdFilter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.GrdFilter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.GrdFilter_Sheet1.AllowNoteEdit = true;
            this.GrdFilter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // Stb
            // 
            this.Stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SL1,
            this.Pb1});
            this.Stb.Location = new System.Drawing.Point(0, 556);
            this.Stb.Name = "Stb";
            this.Stb.Size = new System.Drawing.Size(804, 22);
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
            // Tb
            // 
            this.Tb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit,
            this.toolStripSeparator2,
            this.NewMember,
            this.contactoutlook,
            this.Print,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.TxtSearch,
            this.toolStripLabel2,
            this.CboFilter,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.Tb.Location = new System.Drawing.Point(0, 0);
            this.Tb.Name = "Tb";
            this.Tb.Size = new System.Drawing.Size(804, 25);
            this.Tb.TabIndex = 34;
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
            // NewMember
            // 
            this.NewMember.Image = global::ThaHr30.Properties.Resources.wi0062_16;
            this.NewMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewMember.Name = "NewMember";
            this.NewMember.Size = new System.Drawing.Size(92, 22);
            this.NewMember.Text = " New Member";
            this.NewMember.Click += new System.EventHandler(this.NewMember_Click);
            // 
            // contactoutlook
            // 
            this.contactoutlook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateContactOutlook,
            this.updateContactOutlookALL,
            this.updateContactOutlookModify});
            this.contactoutlook.Image = ((System.Drawing.Image)(resources.GetObject("contactoutlook.Image")));
            this.contactoutlook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.contactoutlook.Name = "contactoutlook";
            this.contactoutlook.Size = new System.Drawing.Size(111, 22);
            this.contactoutlook.Text = "Update Outlook";
            // 
            // updateContactOutlook
            // 
            this.updateContactOutlook.Name = "updateContactOutlook";
            this.updateContactOutlook.Size = new System.Drawing.Size(225, 22);
            this.updateContactOutlook.Text = "Update Contact Outlook";
            this.updateContactOutlook.Click += new System.EventHandler(this.updateContactOutlook_Click);
            // 
            // updateContactOutlookALL
            // 
            this.updateContactOutlookALL.Name = "updateContactOutlookALL";
            this.updateContactOutlookALL.Size = new System.Drawing.Size(225, 22);
            this.updateContactOutlookALL.Text = "Update Contact Outlook ALL";
            this.updateContactOutlookALL.Click += new System.EventHandler(this.updateContactOutlookALL_Click);
            // 
            // updateContactOutlookModify
            // 
            this.updateContactOutlookModify.Name = "updateContactOutlookModify";
            this.updateContactOutlookModify.Size = new System.Drawing.Size(225, 22);
            this.updateContactOutlookModify.Text = "Update Contact Outlook Modify";
            this.updateContactOutlookModify.Click += new System.EventHandler(this.updateContactOutlookModify_Click);
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
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "   ค้นหา : ";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(171, 25);
            this.TxtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyUp);
            this.TxtSearch.Click += new System.EventHandler(this.TxtSearch_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel2.Text = "   ตามประเภท  :   ";
            // 
            // CboFilter
            // 
            this.CboFilter.Name = "CboFilter";
            this.CboFilter.Size = new System.Drawing.Size(175, 21);
            this.CboFilter.Click += new System.EventHandler(this.CboFilter_Click);
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
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 20);
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
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // Img1
            // 
            this.Img1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img1.ImageStream")));
            this.Img1.TransparentColor = System.Drawing.Color.Transparent;
            this.Img1.Images.SetKeyName(0, "1_star.gif");
            // 
            // Img2
            // 
            this.Img2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img2.ImageStream")));
            this.Img2.TransparentColor = System.Drawing.Color.Transparent;
            this.Img2.Images.SetKeyName(0, "2_star.gif");
            // 
            // Img3
            // 
            this.Img3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img3.ImageStream")));
            this.Img3.TransparentColor = System.Drawing.Color.Transparent;
            this.Img3.Images.SetKeyName(0, "3_star.gif");
            // 
            // Img4
            // 
            this.Img4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img4.ImageStream")));
            this.Img4.TransparentColor = System.Drawing.Color.Transparent;
            this.Img4.Images.SetKeyName(0, "4_star.gif");
            // 
            // Img5
            // 
            this.Img5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img5.ImageStream")));
            this.Img5.TransparentColor = System.Drawing.Color.Transparent;
            this.Img5.Images.SetKeyName(0, "5_star.gif");
            // 
            // MemberView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.Tb);
            this.Controls.Add(this.Stb);
            this.Controls.Add(this.GrdFilter);
            this.Controls.Add(this.GrdView);
            this.KeyPreview = true;
            this.Name = "MemberView";
            this.Text = "ViewMember";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MemberView_KeyUp);
            this.Load += new System.EventHandler(this.MemberView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFilter_Sheet1)).EndInit();
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
        private FarPoint.Win.Spread.FpSpread GrdFilter;
        private FarPoint.Win.Spread.SheetView GrdFilter_Sheet1;
        private System.Windows.Forms.StatusStrip Stb;
        private System.Windows.Forms.ToolStripStatusLabel SL1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private System.Windows.Forms.ToolStrip Tb;
        private System.Windows.Forms.ToolStripButton Exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton NewMember;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox CboFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripTextBox TxtSearch;
        private System.Windows.Forms.ToolStripButton Print;
        private System.Windows.Forms.ImageList Img1;
        private System.Windows.Forms.ImageList Img2;
        private System.Windows.Forms.ImageList Img3;
        private System.Windows.Forms.ImageList Img4;
        private System.Windows.Forms.ImageList Img5;
        private System.Windows.Forms.ToolStripDropDownButton contactoutlook;
        private System.Windows.Forms.ToolStripMenuItem updateContactOutlook;
        private System.Windows.Forms.ToolStripMenuItem updateContactOutlookALL;
        private System.Windows.Forms.ToolStripMenuItem updateContactOutlookModify;
    }
}