using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThaHr30
{
    public partial class ServiceIP : Form
    {
        IniFile lsIni = new IniFile("thahr30.ini");
        public ServiceIP()
        {
            InitializeComponent();
        }
        private void ServiceIP_Load(object sender, EventArgs e)
        {
            string lsURL;
            lsURL = lsIni.GetString("thahr30", "myipaddress", "http://www.myipaddress.com");
            //MessageBox.Show(lsURL, "lsURL");
            Web.Navigate(lsURL);
        }
        private void ServiceIP_KeyUp(object sender, KeyEventArgs e)
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