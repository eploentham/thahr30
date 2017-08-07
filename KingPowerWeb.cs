using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThaHr30
{
    public partial class KingPowerWeb : Form
    {
        IniFile lsIni = new IniFile("thahr30.ini");
        public KingPowerWeb()
        {
            InitializeComponent();
        }

        private void KingPowerWeb_Load(object sender, EventArgs e)
        {
            string lsURL;
            lsURL = lsIni.GetString("thahr30", "kingpowerintranet", "http://10.0.0.1/kps/");
            //MessageBox.Show(lsURL, "lsURL");
            Web.Navigate(lsURL);
        }

        private void KingPowerWeb_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }
    }
}