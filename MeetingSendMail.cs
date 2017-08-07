using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace ThaHr30
{
    public partial class MeetingSendMail : Form
    {
        public MeetingSendMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lsBody = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01 Transitional//EN' 'http://www.w3.org/TR/html4/loose.dtd'> "
                            + "<html><head><title>Untitled Document</title> "
                            + "<meta http-equiv='Content-Type' content='text/html; charset=windows-874'>"
                            + "<style type='text/css'><!--.style1 {font-weight: bold}.style2 {font-size: 18px;font-weight: bold;font-family: BrowalliaUPC;}.style3 {color: #FF3399}-->"
                            +"</style></head><body>"
                            + "<span class='style1'><img src='http://www.bangna.co.th/bangnaschool/images/brain2.jpg' width='423' height='360'> "
                            + "กำหนดการรับสมัครนักศึกษาประจำปีการศึกษา  ๒๔๕๐ – ๕๑    <img src='http://www.bangna.co.th/bangnaschool/images/brain2.jpg' width='423' height='360'></span><br>"
                            +"<table><tr><td width='256'><ol> <li>  aaaaaaa      </li><li><span class='style3'>vzxcvzxc</span>v</li><li>rrr<span class='style2'>rrrrrrrrrrrrrrrr</span>rr</li>"
                            + " </ol></td>  </tr></table></body></html>";
            MailMessage lsEMail = new MailMessage();
            MailAddress lsFromAddress = new MailAddress("ekapop@bangna.co.th");
            //Attachment lsAttach = new Attachment(lsPath + "\\" + lsFileName);
            Application.DoEvents();
            lsEMail.From = lsFromAddress;
            lsEMail.To.Add("eploentham@gmail.com");
            lsEMail.To.Add("ekapop@bangna.co.th");
            lsEMail.To.Add("janenapa6647@gmail.com");
            //lsEMail.CC.Add("eploentham@gmail.com");
            lsEMail.Subject = "Test Mail";
            lsEMail.Body = lsBody;
            //lsEMail.Attachments.Add(lsAttach);
            SmtpClient lsSMTP = new SmtpClient("mail.bangna.co.th");
            lsEMail.IsBodyHtml = true; 
            lsSMTP.Credentials = CredentialCache.DefaultNetworkCredentials;
            lsSMTP.Send(lsEMail);
            Application.DoEvents();
        }

        private void MeetingSendMail_Load(object sender, EventArgs e)
        {
            axTXTextControl1.ButtonBarHandle = axTXButtonBar1.hWnd;
            axTXTextControl1.RulerHandle = axTXRuler1.hWnd;
            axTXTextControl1.VerticalRulerHandle = axTXRuler2.hWnd;
            axTXTextControl1.StatusBarHandle = axTXStatusBar1.hWnd;
            
        }

        private void MeetingSendMail_Resize(object sender, EventArgs e)
        {
            axTXTextControl1.Left = axTXRuler2.Width;
            axTXTextControl1.Top = axTXButtonBar1.Height + axTXRuler1.Height;
            axTXTextControl1.Height = this .Height - axTXButtonBar1.Height - axTXRuler1.Height - axTXStatusBar1.Height;
            axTXTextControl1.Width = this .Width - axTXRuler2.Width;
        }
    }
}