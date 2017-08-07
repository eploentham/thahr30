using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThaHr30
{
    public partial class MemberSendEmailFlash : Form
    {
        public MemberSendEmailFlash()
        {
            InitializeComponent();
        }
        public void setLabelEmailTotal(string txt)
        {
            label4.Text = txt;
        }
        public void setLabelEmailCurrent(string txt)
        {
            label5.Text = txt;
        }
        public void setLabelEmailName(string txt)
        {
            label6.Text = txt;
        }
        public void setLabelEmailSended(string txt)
        {
            label9.Text = txt;
        }
        public void setLabelEmailNotSend(string txt)
        {
            label10.Text = txt;
        }
        private void MemberSendEmailFlash_Load(object sender, EventArgs e)
        {

        }
    }
}