namespace ThaHr30
{
    partial class AccViewVoucher
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
            this.TB1 = new System.Windows.Forms.TrackBar();
            this.GrdView = new FarPoint.Win.Spread.FpSpread();
            this.GrdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.TB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // TB1
            // 
            this.TB1.Location = new System.Drawing.Point(12, 12);
            this.TB1.Name = "TB1";
            this.TB1.Size = new System.Drawing.Size(471, 45);
            this.TB1.TabIndex = 0;
            this.TB1.Scroll += new System.EventHandler(this.TB1_Scroll);
            // 
            // GrdView
            // 
            this.GrdView.About = "2.5.2005.2005";
            this.GrdView.AccessibleDescription = "";
            this.GrdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.GrdView.Location = new System.Drawing.Point(12, 51);
            this.GrdView.Name = "GrdView";
            this.GrdView.ScrollBarShowMax = false;
            this.GrdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdView_Sheet1});
            this.GrdView.Size = new System.Drawing.Size(471, 277);
            this.GrdView.TabIndex = 30;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdView.TextTipAppearance = tipAppearance1;
            this.GrdView.Click += new System.EventHandler(this.GrdView_Click);
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
            // AccViewVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 340);
            this.Controls.Add(this.GrdView);
            this.Controls.Add(this.TB1);
            this.KeyPreview = true;
            this.Name = "AccViewVoucher";
            this.Text = "AccViewVoucher";
            this.Click += new System.EventHandler(this.AccViewVoucher_Click);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AccViewVoucher_KeyUp);
            this.Load += new System.EventHandler(this.AccViewVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdView_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TB1;
        private FarPoint.Win.Spread.FpSpread GrdView;
        private FarPoint.Win.Spread.SheetView GrdView_Sheet1;
    }
}