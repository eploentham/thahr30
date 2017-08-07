namespace ThaHr30
{
    partial class SearchAddress
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
            this.TxtPostCode = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.CboProvName = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.CboDistrict = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.CboSubDistrict = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtPostCode
            // 
            this.TxtPostCode.Location = new System.Drawing.Point(105, 108);
            this.TxtPostCode.Name = "TxtPostCode";
            this.TxtPostCode.Size = new System.Drawing.Size(105, 20);
            this.TxtPostCode.TabIndex = 90;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(22, 111);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(75, 13);
            this.label54.TabIndex = 89;
            this.label54.Text = "√À— ‰ª√…≥¬Ï :";
            // 
            // CboProvName
            // 
            this.CboProvName.FormattingEnabled = true;
            this.CboProvName.Location = new System.Drawing.Point(105, 81);
            this.CboProvName.Name = "CboProvName";
            this.CboProvName.Size = new System.Drawing.Size(218, 21);
            this.CboProvName.TabIndex = 88;
            this.CboProvName.DropDownClosed += new System.EventHandler(this.CboProvName_DropDownClosed);
            this.CboProvName.Click += new System.EventHandler(this.CboProvName_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(22, 84);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(44, 13);
            this.label55.TabIndex = 87;
            this.label55.Text = "®—ßÀ«—¥ :";
            // 
            // CboDistrict
            // 
            this.CboDistrict.FormattingEnabled = true;
            this.CboDistrict.Location = new System.Drawing.Point(105, 54);
            this.CboDistrict.Name = "CboDistrict";
            this.CboDistrict.Size = new System.Drawing.Size(219, 21);
            this.CboDistrict.TabIndex = 86;
            this.CboDistrict.DropDownClosed += new System.EventHandler(this.CboDistrict_DropDownClosed);
            this.CboDistrict.Click += new System.EventHandler(this.CboDistrict_Click);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(22, 57);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(42, 13);
            this.label56.TabIndex = 85;
            this.label56.Text = "Õ”‡¿Õ :";
            // 
            // CboSubDistrict
            // 
            this.CboSubDistrict.FormattingEnabled = true;
            this.CboSubDistrict.Location = new System.Drawing.Point(105, 27);
            this.CboSubDistrict.Name = "CboSubDistrict";
            this.CboSubDistrict.Size = new System.Drawing.Size(218, 21);
            this.CboSubDistrict.TabIndex = 84;
            this.CboSubDistrict.SelectedIndexChanged += new System.EventHandler(this.CboSubDistrict_SelectedIndexChanged);
            this.CboSubDistrict.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboSubDistrict_KeyPress);
            this.CboSubDistrict.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CboSubDistrict_KeyUp);
            this.CboSubDistrict.DropDownClosed += new System.EventHandler(this.CboSubDistrict_DropDownClosed);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(22, 30);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(38, 13);
            this.label57.TabIndex = 83;
            this.label57.Text = "µ”∫≈ :";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(105, 134);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(105, 31);
            this.BtnOK.TabIndex = 91;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // SearchAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 192);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TxtPostCode);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.CboProvName);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.CboDistrict);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.CboSubDistrict);
            this.Controls.Add(this.label57);
            this.KeyPreview = true;
            this.Name = "SearchAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchAddress";
            this.Load += new System.EventHandler(this.SearchAddress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPostCode;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ComboBox CboProvName;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox CboDistrict;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox CboSubDistrict;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button BtnOK;
    }
}