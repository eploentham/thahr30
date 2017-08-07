namespace ThaHr30
{
    partial class MeetingSearchContact
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Stb = new System.Windows.Forms.StatusStrip();
            this.SL1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.ChkAll = new System.Windows.Forms.RadioButton();
            this.ChkMember = new System.Windows.Forms.RadioButton();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.CboFilter = new System.Windows.Forms.ComboBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.ChkRegion = new System.Windows.Forms.RadioButton();
            this.ChkType = new System.Windows.Forms.RadioButton();
            this.ChkUseAll = new System.Windows.Forms.CheckBox();
            this.chkAllwithoutresign = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.Stb.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "GrdView";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(136, 12);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(644, 475);
            this.GrdView.TabIndex = 46;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdView.TextTipAppearance = tipAppearance2;
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
            // Stb
            // 
            this.Stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SL1,
            this.Pb1});
            this.Stb.Location = new System.Drawing.Point(0, 490);
            this.Stb.Name = "Stb";
            this.Stb.Size = new System.Drawing.Size(792, 22);
            this.Stb.TabIndex = 47;
            this.Stb.Text = "statusStrip1";
            // 
            // SL1
            // 
            this.SL1.Name = "SL1";
            this.SL1.Size = new System.Drawing.Size(115, 17);
            this.SL1.Text = "toolStripStatusLabel1";
            // 
            // Pb1
            // 
            this.Pb1.Name = "Pb1";
            this.Pb1.Size = new System.Drawing.Size(370, 16);
            // 
            // ChkAll
            // 
            this.ChkAll.AutoSize = true;
            this.ChkAll.Location = new System.Drawing.Point(13, 65);
            this.ChkAll.Name = "ChkAll";
            this.ChkAll.Size = new System.Drawing.Size(94, 17);
            this.ChkAll.TabIndex = 48;
            this.ChkAll.TabStop = true;
            this.ChkAll.Text = "ดึงข้อมูลทั้งหมด";
            this.ChkAll.UseVisualStyleBackColor = true;
            // 
            // ChkMember
            // 
            this.ChkMember.AutoSize = true;
            this.ChkMember.Location = new System.Drawing.Point(13, 176);
            this.ChkMember.Name = "ChkMember";
            this.ChkMember.Size = new System.Drawing.Size(80, 17);
            this.ChkMember.TabIndex = 49;
            this.ChkMember.TabStop = true;
            this.ChkMember.Text = "ตามโรงแรม";
            this.ChkMember.UseVisualStyleBackColor = true;
            this.ChkMember.CheckedChanged += new System.EventHandler(this.ChkMember_CheckedChanged);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Image = global::ThaHr30.Properties.Resources.binocular_icon;
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearch.Location = new System.Drawing.Point(12, 238);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(107, 50);
            this.BtnSearch.TabIndex = 50;
            this.BtnSearch.Text = "ดึงข้อมูล";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // CboFilter
            // 
            this.CboFilter.FormattingEnabled = true;
            this.CboFilter.Location = new System.Drawing.Point(9, 199);
            this.CboFilter.Name = "CboFilter";
            this.CboFilter.Size = new System.Drawing.Size(121, 21);
            this.CboFilter.TabIndex = 51;
            // 
            // BtnOK
            // 
            this.BtnOK.Image = global::ThaHr30.Properties.Resources.signon;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOK.Location = new System.Drawing.Point(9, 305);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(107, 50);
            this.BtnOK.TabIndex = 52;
            this.BtnOK.Text = "OK";
            this.BtnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // ChkRegion
            // 
            this.ChkRegion.AutoSize = true;
            this.ChkRegion.Location = new System.Drawing.Point(13, 153);
            this.ChkRegion.Name = "ChkRegion";
            this.ChkRegion.Size = new System.Drawing.Size(80, 17);
            this.ChkRegion.TabIndex = 53;
            this.ChkRegion.TabStop = true;
            this.ChkRegion.Text = "ตาม Region";
            this.ChkRegion.UseVisualStyleBackColor = true;
            this.ChkRegion.CheckedChanged += new System.EventHandler(this.ChkRegion_CheckedChanged);
            // 
            // ChkType
            // 
            this.ChkType.AutoSize = true;
            this.ChkType.Location = new System.Drawing.Point(12, 130);
            this.ChkType.Name = "ChkType";
            this.ChkType.Size = new System.Drawing.Size(115, 17);
            this.ChkType.TabIndex = 54;
            this.ChkType.TabStop = true;
            this.ChkType.Text = "ตาม ประเภทสมาชิก";
            this.ChkType.UseVisualStyleBackColor = true;
            this.ChkType.CheckedChanged += new System.EventHandler(this.ChkType_CheckedChanged);
            // 
            // ChkUseAll
            // 
            this.ChkUseAll.AutoSize = true;
            this.ChkUseAll.Location = new System.Drawing.Point(14, 387);
            this.ChkUseAll.Name = "ChkUseAll";
            this.ChkUseAll.Size = new System.Drawing.Size(83, 17);
            this.ChkUseAll.TabIndex = 55;
            this.ChkUseAll.Text = "เลือกทั้งหมด";
            this.ChkUseAll.UseVisualStyleBackColor = true;
            this.ChkUseAll.CheckedChanged += new System.EventHandler(this.ChkUseAll_CheckedChanged);
            // 
            // chkAllwithoutresign
            // 
            this.chkAllwithoutresign.AutoSize = true;
            this.chkAllwithoutresign.Location = new System.Drawing.Point(14, 88);
            this.chkAllwithoutresign.Name = "chkAllwithoutresign";
            this.chkAllwithoutresign.Size = new System.Drawing.Size(120, 17);
            this.chkAllwithoutresign.TabIndex = 56;
            this.chkAllwithoutresign.TabStop = true;
            this.chkAllwithoutresign.Text = "ดึงข้อมูลที่เป็นสมาชิก";
            this.chkAllwithoutresign.UseVisualStyleBackColor = true;
            // 
            // MeetingSearchContact
            // 
            this.ClientSize = new System.Drawing.Size(792, 512);
            this.Controls.Add(this.chkAllwithoutresign);
            this.Controls.Add(this.ChkUseAll);
            this.Controls.Add(this.ChkType);
            this.Controls.Add(this.ChkRegion);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.CboFilter);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.ChkMember);
            this.Controls.Add(this.ChkAll);
            this.Controls.Add(this.Stb);
            this.Controls.Add(this.GrdView);
            this.Name = "MeetingSearchContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MeetingSearchContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.Stb.ResumeLayout(false);
            this.Stb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.StatusStrip Stb;
        private System.Windows.Forms.ToolStripStatusLabel SL1;
        private System.Windows.Forms.ToolStripProgressBar Pb1;
        private System.Windows.Forms.RadioButton ChkAll;
        private System.Windows.Forms.RadioButton ChkMember;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.ComboBox CboFilter;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.RadioButton ChkRegion;
        private System.Windows.Forms.RadioButton ChkType;
        private System.Windows.Forms.CheckBox ChkUseAll;
        private System.Windows.Forms.RadioButton chkAllwithoutresign;
    }
}