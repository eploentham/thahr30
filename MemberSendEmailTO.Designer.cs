namespace ThaHr30
{
    partial class MemberSendEmailTO
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
            this.CboProvince = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkProvinceAll = new System.Windows.Forms.CheckBox();
            this.btnProvinceOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRegionAll = new System.Windows.Forms.CheckBox();
            this.btnRegionOK = new System.Windows.Forms.Button();
            this.cboRegion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btntypeOK = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "GrdView";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(230, 12);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(482, 429);
            this.GrdView.TabIndex = 47;
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
            // CboProvince
            // 
            this.CboProvince.FormattingEnabled = true;
            this.CboProvince.Location = new System.Drawing.Point(63, 19);
            this.CboProvince.Name = "CboProvince";
            this.CboProvince.Size = new System.Drawing.Size(143, 21);
            this.CboProvince.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "จังหวัด :";
            // 
            // BtnOK
            // 
            this.BtnOK.Image = global::ThaHr30.Properties.Resources.signon;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOK.Location = new System.Drawing.Point(145, 373);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(79, 50);
            this.BtnOK.TabIndex = 54;
            this.BtnOK.Text = "OK";
            this.BtnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkProvinceAll);
            this.groupBox1.Controls.Add(this.btnProvinceOK);
            this.groupBox1.Controls.Add(this.CboProvince);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 114);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เลือกจังหวัด";
            // 
            // chkProvinceAll
            // 
            this.chkProvinceAll.AutoSize = true;
            this.chkProvinceAll.Location = new System.Drawing.Point(63, 57);
            this.chkProvinceAll.Name = "chkProvinceAll";
            this.chkProvinceAll.Size = new System.Drawing.Size(59, 17);
            this.chkProvinceAll.TabIndex = 56;
            this.chkProvinceAll.Text = "ทั้งหมด";
            this.chkProvinceAll.UseVisualStyleBackColor = true;
            // 
            // btnProvinceOK
            // 
            this.btnProvinceOK.Location = new System.Drawing.Point(63, 80);
            this.btnProvinceOK.Name = "btnProvinceOK";
            this.btnProvinceOK.Size = new System.Drawing.Size(75, 23);
            this.btnProvinceOK.TabIndex = 56;
            this.btnProvinceOK.Text = "เลือก";
            this.btnProvinceOK.UseVisualStyleBackColor = true;
            this.btnProvinceOK.Click += new System.EventHandler(this.btnProvinceOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRegionAll);
            this.groupBox2.Controls.Add(this.btnRegionOK);
            this.groupBox2.Controls.Add(this.cboRegion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 111);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "เลือกตาม Region";
            // 
            // chkRegionAll
            // 
            this.chkRegionAll.AutoSize = true;
            this.chkRegionAll.Location = new System.Drawing.Point(63, 57);
            this.chkRegionAll.Name = "chkRegionAll";
            this.chkRegionAll.Size = new System.Drawing.Size(59, 17);
            this.chkRegionAll.TabIndex = 56;
            this.chkRegionAll.Text = "ทั้งหมด";
            this.chkRegionAll.UseVisualStyleBackColor = true;
            // 
            // btnRegionOK
            // 
            this.btnRegionOK.Location = new System.Drawing.Point(63, 80);
            this.btnRegionOK.Name = "btnRegionOK";
            this.btnRegionOK.Size = new System.Drawing.Size(75, 23);
            this.btnRegionOK.TabIndex = 56;
            this.btnRegionOK.Text = "เลือก";
            this.btnRegionOK.UseVisualStyleBackColor = true;
            this.btnRegionOK.Click += new System.EventHandler(this.btnRegionOK_Click);
            // 
            // cboRegion
            // 
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Location = new System.Drawing.Point(63, 19);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(143, 21);
            this.cboRegion.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Region :";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(21, 373);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(78, 50);
            this.btnReset.TabIndex = 57;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.btntypeOK);
            this.groupBox3.Controls.Add(this.cboType);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 111);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "เลือกตาม ประะเภทสมาชิก";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(63, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 56;
            this.checkBox1.Text = "ทั้งหมด";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btntypeOK
            // 
            this.btntypeOK.Location = new System.Drawing.Point(63, 80);
            this.btntypeOK.Name = "btntypeOK";
            this.btntypeOK.Size = new System.Drawing.Size(75, 23);
            this.btntypeOK.TabIndex = 56;
            this.btntypeOK.Text = "เลือก";
            this.btntypeOK.UseVisualStyleBackColor = true;
            this.btntypeOK.Click += new System.EventHandler(this.btntypeOK_Click);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(63, 19);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(143, 21);
            this.cboType.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "ประเภท :";
            // 
            // MemberSendEmailTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 463);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.GrdView);
            this.Name = "MemberSendEmailTO";
            this.Text = "MemberSendemailTO";
            this.Load += new System.EventHandler(this.MemberSendEmailTO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.ComboBox CboProvince;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkProvinceAll;
        private System.Windows.Forms.Button btnProvinceOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkRegionAll;
        private System.Windows.Forms.Button btnRegionOK;
        private System.Windows.Forms.ComboBox cboRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btntypeOK;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label3;
    }
}