namespace ThaHr30
{
    partial class RecData
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
            this.GrdRec = new FarPoint.Win.Spread.FpSpread();
            this.GrdRec_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PB1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdRec
            // 
            this.GrdRec.About = "2.5.2005.2005";
            this.GrdRec.AccessibleDescription = "";
            this.GrdRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdRec.Location = new System.Drawing.Point(17, 121);
            this.GrdRec.Name = "GrdRec";
            this.GrdRec.ScrollBarShowMax = false;
            this.GrdRec.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.GrdRec_Sheet1});
            this.GrdRec.Size = new System.Drawing.Size(396, 387);
            this.GrdRec.TabIndex = 19;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GrdRec.TextTipAppearance = tipAppearance1;
            // 
            // GrdRec_Sheet1
            // 
            this.GrdRec_Sheet1.Reset();
            this.GrdRec_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.GrdRec_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.GrdRec_Sheet1.AutoUpdateNotes = true;
            this.GrdRec_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PB1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnRec);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 103);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รับข้อมูล";
            // 
            // PB1
            // 
            this.PB1.Location = new System.Drawing.Point(6, 74);
            this.PB1.Name = "PB1";
            this.PB1.Size = new System.Drawing.Size(384, 23);
            this.PB1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "จำนวนข้อมูล";
            // 
            // BtnRec
            // 
            this.BtnRec.Location = new System.Drawing.Point(276, 19);
            this.BtnRec.Name = "BtnRec";
            this.BtnRec.Size = new System.Drawing.Size(114, 49);
            this.BtnRec.TabIndex = 8;
            this.BtnRec.Text = "Receive Data";
            this.BtnRec.UseVisualStyleBackColor = true;
            this.BtnRec.Click += new System.EventHandler(this.BtnRec_Click);
            // 
            // RecData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 520);
            this.Controls.Add(this.GrdRec);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecData";
            this.Text = "RecData";
            this.Load += new System.EventHandler(this.RecData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRec_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread GrdRec;
        private FarPoint.Win.Spread.SheetView GrdRec_Sheet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnRec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar PB1;
        
    }
}