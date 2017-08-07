using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using MySql.Data.MySqlClient;
namespace ThaHr30
{
    public partial class MemberSendEmail : Form
    {
        Connection conn = new Connection();
        IniFile iniFile = new IniFile();
        Timer timer = new Timer();
        Int32 indexsendemail = 0;
        private Int32 colFlag = 0, colEmail = 1, colEmailFlag = 2, colEmailSend=3, rowgrdView = 1, rowemailsend=0,rowemailtotal=100;
        string filebody = "";
        Int32 sendemailsuccess=0, sendemailerror=0;
        MemberSendEmailFlash flash = new MemberSendEmailFlash();
        ArrayList sendemail1 = new ArrayList();
        Boolean flagsendemailed = false;
        public MemberSendEmail()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            GrdView.Reset();
            rowgrdView = 1;
            GrdView.ActiveSheet.RowCount = rowgrdView;
            GrdView.ActiveSheet.ColumnCount = 4;
            //GrdView.Height = this.Height - 60;
            //GrdView.Width = this.Width - 30;
            //GrdView.Top = 30;
            //GrdView.Left = 500;
            FarPoint.Win.Spread.CellType.TextCellType cellTxt = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[colEmail, colEmailFlag].CellType = cellTxt;
            //GrdView.Sheets[0].Columns[colMemID, colMemID].CellType = cellTxt;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellGrdCheck = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellGrdCheck.TextTrue = "use";
            cellGrdCheck.TextFalse = "use";
            GrdView.ActiveSheet.Columns[colFlag].CellType = cellGrdCheck;
            cellGrdCheck.TextTrue = "send";
            cellGrdCheck.TextFalse = "send";
            GrdView.ActiveSheet.Columns[colEmailSend].CellType = cellGrdCheck;
            GrdView.ActiveSheet.SetColumnLabel(0, colFlag, "USE");
            GrdView.ActiveSheet.SetColumnLabel(0, colEmail, "EMail");
            GrdView.ActiveSheet.SetColumnLabel(0, colEmailFlag, "Flag");
            GrdView.ActiveSheet.SetColumnLabel(0, colEmailSend, "Send");
            GrdView.ActiveSheet.SetColumnWidth(colFlag, 60);
            GrdView.ActiveSheet.SetColumnWidth(colEmail, 200);
            GrdView.ActiveSheet.SetColumnWidth(colEmailFlag, 70);
            GrdView.ActiveSheet.SetColumnWidth(colEmailSend, 60);
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.Visible = true;
        }
        private void sendEmail(string smtpaddress, string to,
            string from, string subject, string filenamebody, string body,
            string attachfile1, string attachfile2, string attachfile3, string attachfile4)
        {
            try
            {
                MailMessage EMail = new MailMessage();
                MailAddress fromAddress = new MailAddress(from);
                String Body = "", path = filenamebody;
                EMail.IsBodyHtml = true;
                if (to != null &&
                    !to.Equals(""))
                {
                    EMail.To.Add(to.Trim());
                    EMail.From = fromAddress;
                    //lsEMail.CC.Add("eploentham@gmail.com");
                    EMail.Subject = subject;
                    EMail.Body = body;
                    //LinkedResource logo = new LinkedResource(@"C:\DSC00028.JPG");
                    //AlternateView av1 = AlternateView.CreateAlternateViewFromString(
                    //    "<html><body><img src=cid:companylogo/><br></body></html>" + body, null, MediaTypeNames.Text.Html);
                    //av1.LinkedResources.Add(logo);
                    if (!path.Equals(""))
                    {
                        LinkedResource logo = new LinkedResource(path);
                        logo.ContentId = "companylogo";
                        // done HTML formatting in the next line to display my logo
                        AlternateView av1 = AlternateView.CreateAlternateViewFromString("<html><body><img src=cid:companylogo><br></body></html>" + Body, null, MediaTypeNames.Text.Html);
                        av1.LinkedResources.Add(logo);
                        EMail.AlternateViews.Add(av1);
                    }
                    //Body = "<html><body><br>" + body + "<img src='c:\\DSC00028.JPG'><br></body></html>";
                    //EMail.Body = av1.ToString();
                    //EMail.AlternateViews.Add(av1);
                    //EMail.Body = Txt.SelectedRtf.ToString();

                    if (attachfile1 != "")
                    {
                        Attachment attachFile = new Attachment(attachfile1);
                        EMail.Attachments.Add(attachFile);
                    }
                    if (attachfile2 != "")
                    {
                        Attachment attachFile = new Attachment(attachfile2);
                        EMail.Attachments.Add(attachFile);
                    }
                    if (attachfile3 != "")
                    {
                        Attachment attachFile = new Attachment(attachfile3);
                        EMail.Attachments.Add(attachFile);
                    }
                    if (attachfile4 != "")
                    {
                        Attachment attachFile = new Attachment(attachfile4);
                        EMail.Attachments.Add(attachFile);
                    }
                    SmtpClient SMTP = new SmtpClient(smtpaddress);
                    SMTP.Credentials = new NetworkCredential("membership@thaihotels.org", "membership");
                    SMTP.Send(EMail);
                    sendemailsuccess++;
                    flash.setLabelEmailSended(sendemailsuccess.ToString());
                }
            }
            catch (Exception ex)
            {
                sendemailerror++;
                flash.setLabelEmailNotSend(sendemailerror.ToString());
            }
            //attachFile.Dispose();
            //Application.DoEvents();
        }
        private void Timer_Tick(object sender, EventArgs eArgs)
        {
            //string lsSMTP = iniFile.GetString("thahr30", "smtp", "mail.asianet.co.th");
            //Boolean aa = false;
            //TxtEmailSubject.Text = GetSubjectSendEMail();
            if (rowemailsend >= rowemailtotal)
            {
                flash.Close();
                timer.Stop();
                btnSendEmail.Enabled = true;
            }
            else
            {
                btnSendEmail.Enabled = false;
                sendEmail(TxtSMTP.Text, sendemail1[indexsendemail].ToString(), TxtFrom.Text, 
                    TxtSubject.Text, filebody, txtAttachFile1.Text, 
                    txtAttachFile1.Text, txtAttachFile2.Text, txtAttachFile3.Text, txtAttachFile4.Text);
                flash.setLabelEmailCurrent(rowemailsend.ToString());
                flash.setLabelEmailName(sendemail1[indexsendemail].ToString());
                indexsendemail++;
                rowemailsend++;
            }
            //if (aa)
            //{
            //SendEMail(lsSMTP);
            //}
        }
        private void exit_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
        private void MemberSendEmail_Load(object sender, EventArgs e)
        {
            TxtFrom.Text = iniFile.GetString("thahr30", "emailmemberfrom", "membership@thaihotel.org");
            string SMTP = iniFile.GetString("thahr30", "smtp", "mail.asianet.co.th");
            TxtSMTP.Text = SMTP;
            //emailsendwait =
            txtEmailSendWait.Value = Convert.ToInt32(iniFile.GetString("thahr30", "emailsendwait", "4"));
            PaintGrdView();
        }
        private void btnAttachFile1_Click(object sender, EventArgs e)
        {
            //openFileDialog.OpenFile();
            openFileDialog.ShowDialog();
            string filename1 = openFileDialog.FileName;
            txtAttachFile1.Text = filename1;
        }
        private void btnTO_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            MemberSendEmailTO membersendemailto = new MemberSendEmailTO();
            FarPoint.Win.Spread.FpSpread grdview = new FarPoint.Win.Spread.FpSpread();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            membersendemailto.ShowDialog(this);
            grdview = membersendemailto.getGrd();
            GrdView.Sheets[0].RowCount = grdview.Sheets[0].RowCount;
            for (int i = 0; i <= grdview.Sheets[0].RowCount - 1; i++)
            {
                GrdView.Sheets[0].Cells[i, colFlag].Value = grdview.Sheets[0].Cells[i, colFlag].Value;
                GrdView.Sheets[0].Cells[i, colEmailFlag].Value = grdview.Sheets[0].Cells[i, colEmailFlag].Value;
                GrdView.Sheets[0].Cells[i, colEmail].Value = grdview.Sheets[0].Cells[i, colEmail].Value;
            }
        }
        private void btnBody_Click(object sender, EventArgs e)
        {
            InsertImage();
        }
        public void InsertImage()
        {
            openFileDialog.ShowDialog();
            string lstrFile = openFileDialog.FileName;
            filebody = lstrFile;
            Bitmap myBitmap = new Bitmap(lstrFile);
            // Copy the bitmap to the clipboard.

            Clipboard.SetDataObject(myBitmap);
            // Get the format for the object type.

            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            // After verifying that the data can be pasted, paste

            if (Txt.CanPaste(myFormat))
            {
                Txt.Paste(myFormat);
            }
            else
            {
                MessageBox.Show("The data format that you attempted site" +
                  " is not supportedby this control.");
            }
        }
        private void btnAttachFile2_Click(object sender, EventArgs e)
        {
            //openFileDialog.OpenFile();
            openFileDialog.ShowDialog();
            string filename2 = openFileDialog.FileName;
            txtAttachFile2.Text = filename2;
        }
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            sendemail1 = new ArrayList();
            Int32 emailsendwait = 0;
            ArrayList c= new ArrayList();
            string to = "", from = "", subject = "", body = "", type="", subtype="";
            //timer.Interval = txtEmailSendWait.Value * 1000;
            for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
            {
                if (GrdView.Sheets[0].Cells[i, colFlag].Value != null &&
                    (Boolean) GrdView.Sheets[0].Cells[i, colFlag].Value)
                {
                    subtype = GrdView.Sheets[0].Cells[i, colEmail].Value.ToString();
                    type = GrdView.Sheets[0].Cells[i, colEmailFlag].Value.ToString();
                    if (type.Equals("จังหวัด"))
                    {
                        type = "province";
                    }
                    else if (type.Equals("region"))
                    {
                        type = "region";
                    }
                    else
                    {
                        type = "";
                    }
                    if (subtype.Equals("ทั้งหมด"))
                    {
                        subtype = "";
                    }
                    c = conn.MemberSendEmailSelect(type, subtype);
                    sendemail1.AddRange(c);
                }
            }
            rowemailtotal = sendemail1.Count;
            rowemailsend = 0;
            flash = new MemberSendEmailFlash();
            flash.setLabelEmailTotal(rowemailtotal.ToString());
            flash.Show(this);
            timer.Enabled = true;
            timer.Interval = Convert.ToInt32(txtEmailSendWait.Value) * 1000;
            timer.Start();
            indexsendemail = 0;
            flagsendemailed = false;
            //conn.getConnectThaiHotels();
        }

        private void txtEmailSendWait_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = Convert.ToInt32(txtEmailSendWait.Value) * 1000;
        }

        private void btnAttachFile3_Click(object sender, EventArgs e)
        {
            //openFileDialog.OpenFile();
            openFileDialog.ShowDialog();
            string filename3 = openFileDialog.FileName;
            txtAttachFile3.Text = filename3;
        }

        private void btnAttachFile4_Click(object sender, EventArgs e)
        {
            //openFileDialog.OpenFile();
            openFileDialog.ShowDialog();
            string filename4 = openFileDialog.FileName;
            txtAttachFile4.Text = filename4;
        }
    }
}