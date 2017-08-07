using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThaHr30
{
    public partial class KingPowerOpenText : Form
    {
        public string lsFileName="";
        public KingPowerOpenText()
        {
            InitializeComponent();
        }

        private void KingPowerOpenText_Load(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Txt.Visible = false;
            Txt.Top = this.Top + 35;
            Txt.Left = this.Left + 7;
            Txt.Height = this.Height - 94;
            Txt.Width = this.Width -20;
            if (lsFileName != "")
            {
                Txt.LoadFile(lsFileName, RichTextBoxStreamType.PlainText);
            }
            Txt.Font = new Font("Tahoma", 12, FontStyle.Regular);
            //Txt.SelectionFont = new Font("Tahoma", 12, FontStyle.Bold);
            Txt.SelectionColor = System.Drawing.Color.Red;

            Txt.Visible = true;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void saveclose_Click(object sender, EventArgs e)
        {
            Txt.SaveFile(lsFileName, RichTextBoxStreamType.PlainText);
            this.Close();
        }
        private void Font_Click(object sender, EventArgs e)
        {
            Font1.ShowDialog();
            Txt.Font = new Font(Font1.Font , FontStyle.Regular );
            Txt.Refresh();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}