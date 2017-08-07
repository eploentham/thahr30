namespace ThaHr30
{
    partial class MemberSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberSearch));
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Tb = new System.Windows.Forms.ToolStrip();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CboLocation = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.CboProv = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.CboMember = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.Tb.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(0, 28);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(897, 400);
            this.GrdView.TabIndex = 15;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdView.TextTipAppearance = tipAppearance1;
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
            // Tb
            // 
            this.Tb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.toolStripTextBox1,
            this.toolStripLabel4,
            this.toolStripTextBox2,
            this.toolStripLabel1,
            this.CboLocation,
            this.toolStripLabel2,
            this.CboProv,
            this.toolStripLabel5,
            this.CboMember,
            this.toolStripSeparator1,
            this.search,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.Tb.Location = new System.Drawing.Point(0, 0);
            this.Tb.Name = "Tb";
            this.Tb.Size = new System.Drawing.Size(1047, 25);
            this.Tb.TabIndex = 28;
            this.Tb.Text = "toolStrip1";
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
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
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel3.Text = "ราคาเริ่มต้น :";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel4.Text = "ถึงราคา :";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel1.Text = "   Location : ";
            // 
            // CboLocation
            // 
            this.CboLocation.Name = "CboLocation";
            this.CboLocation.Size = new System.Drawing.Size(121, 25);
            this.CboLocation.SelectedIndexChanged += new System.EventHandler(this.CboLocation_SelectedIndexChanged);
            this.CboLocation.Click += new System.EventHandler(this.CboLocation_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel2.Text = "   จังหวัด  :   ";
            // 
            // CboProv
            // 
            this.CboProv.Name = "CboProv";
            this.CboProv.Size = new System.Drawing.Size(121, 25);
            this.CboProv.SelectedIndexChanged += new System.EventHandler(this.CboProv_SelectedIndexChanged);
            this.CboProv.Click += new System.EventHandler(this.CboProv_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel5.Text = "โรงแรม :";
            // 
            // CboMember
            // 
            this.CboMember.Name = "CboMember";
            this.CboMember.Size = new System.Drawing.Size(121, 25);
            this.CboMember.SelectedIndexChanged += new System.EventHandler(this.CboMember_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // search
            // 
            this.search.Image = ((System.Drawing.Image)(resources.GetObject("search.Image")));
            this.search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(69, 22);
            this.search.Text = " Search  ";
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
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // MemberSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 522);
            this.ControlBox = false;
            this.Controls.Add(this.Tb);
            this.Controls.Add(this.GrdView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.Tb.ResumeLayout(false);
            this.Tb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
        private System.Windows.Forms.ToolStrip Tb;
        private System.Windows.Forms.ToolStripButton Exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox CboLocation;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox CboProv;
        private System.Windows.Forms.ToolStripButton search;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripComboBox CboMember;
        //private FarPoint.Win.Spread.FpSpread GrdView;
    }
}

