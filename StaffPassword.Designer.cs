namespace ThaHr30
{
    partial class StaffPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffPassword));
            this.GbInformation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPasswordNew = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.TxtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.TxtStaffName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.GbInformation.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbInformation
            // 
            this.GbInformation.Controls.Add(this.label3);
            this.GbInformation.Controls.Add(this.TxtPasswordNew);
            this.GbInformation.Controls.Add(this.label77);
            this.GbInformation.Controls.Add(this.TxtPasswordConfirm);
            this.GbInformation.Controls.Add(this.label35);
            this.GbInformation.Controls.Add(this.TxtStaffName);
            this.GbInformation.Location = new System.Drawing.Point(12, 42);
            this.GbInformation.Name = "GbInformation";
            this.GbInformation.Size = new System.Drawing.Size(444, 251);
            this.GbInformation.TabIndex = 30;
            this.GbInformation.TabStop = false;
            this.GbInformation.Text = "รายละเอียด Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "New Password :";
            // 
            // TxtPasswordNew
            // 
            this.TxtPasswordNew.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPasswordNew.Location = new System.Drawing.Point(150, 73);
            this.TxtPasswordNew.Name = "TxtPasswordNew";
            this.TxtPasswordNew.PasswordChar = '*';
            this.TxtPasswordNew.Size = new System.Drawing.Size(278, 20);
            this.TxtPasswordNew.TabIndex = 43;
            this.TxtPasswordNew.Enter += new System.EventHandler(this.TxtPasswordNew_Enter);
            this.TxtPasswordNew.Leave += new System.EventHandler(this.TxtPasswordNew_Leave);
            this.TxtPasswordNew.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPasswordNew_KeyUp);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(11, 102);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(97, 13);
            this.label77.TabIndex = 44;
            this.label77.Text = "Confirm Password :";
            // 
            // TxtPasswordConfirm
            // 
            this.TxtPasswordConfirm.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPasswordConfirm.Location = new System.Drawing.Point(150, 99);
            this.TxtPasswordConfirm.Name = "TxtPasswordConfirm";
            this.TxtPasswordConfirm.PasswordChar = '*';
            this.TxtPasswordConfirm.Size = new System.Drawing.Size(278, 20);
            this.TxtPasswordConfirm.TabIndex = 43;
            this.TxtPasswordConfirm.Enter += new System.EventHandler(this.TxtPasswordConfirm_Enter);
            this.TxtPasswordConfirm.Leave += new System.EventHandler(this.TxtPasswordConfirm_Leave);
            this.TxtPasswordConfirm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPasswordConfirm_KeyUp);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 27);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(67, 13);
            this.label35.TabIndex = 29;
            this.label35.Text = "ชื่อพนักงาน :";
            // 
            // TxtStaffName
            // 
            this.TxtStaffName.Location = new System.Drawing.Point(150, 20);
            this.TxtStaffName.Name = "TxtStaffName";
            this.TxtStaffName.ReadOnly = true;
            this.TxtStaffName.Size = new System.Drawing.Size(278, 20);
            this.TxtStaffName.TabIndex = 28;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit,
            this.toolStripSeparator2,
            this.save,
            this.toolStripSeparator3,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(469, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // exit
            // 
            this.exit.Image = global::ThaHr30.Properties.Resources.exit;
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(51, 22);
            this.exit.Text = "  Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click_1);
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
            this.save.Size = new System.Drawing.Size(90, 22);
            this.save.Text = "&Save && Close";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 306);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(469, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // StaffPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 328);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GbInformation);
            this.Name = "StaffPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffPassword";
            this.Load += new System.EventHandler(this.StaffPassword_Load);
            this.GbInformation.ResumeLayout(false);
            this.GbInformation.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GbInformation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPasswordNew;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox TxtPasswordConfirm;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox TxtStaffName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}