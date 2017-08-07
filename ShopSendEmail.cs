using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Net;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace ThaHr30
{
    public partial class ShopSendEmail : Form
    {
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile();
        DateTime ldDate;
        string lsSubject = "";
        public MySqlConnection Connnection
        {
            get
            {
                return lsGdb.Gdb;
            }
            set
            {
                lsGdb.Gdb = value;
            }
        }
        public DateTime  SendDate
        {
            get
            {
                return TxtDate.Value;
            }
            set
            {
                TxtDate.Value = value;
            }
        }
        public ShopSendEmail()
        {
            InitializeComponent();
            SendLoad();
        }
        public void SendEMail(string aServer, Boolean aFlag, string aTO, string aReportName)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            string lsTO = "", lsSubject = "", lsStartDate = "", lsEndDate = "", lsLine2="", lsLine1="", lsLine3="";
            string lsPath = Application.StartupPath + "\\Counter\\" , lsFileName = "";
            string reportPath = "", lsDay="";
            if (aReportName == "rptdailypayinrecordsuemail")
            {
                reportPath = Application.StartupPath + "\\rptdailypayinrecordsuemail.rpt";
            }
            else
            {
                reportPath = Application.StartupPath + "\\RptDailyPayinRecordPayment.rpt";
            }
            lsStartDate = TxtDate.Value.Year.ToString() + "-" + TxtDate.Value.Month.ToString("00") + "-" + TxtDate.Value.Day.ToString("00");
            lsDay = TxtDate.Value.Day.ToString("00") + "-" + TxtDate.Value.Month.ToString("00") + "-" + Convert.ToString(TxtDate.Value.Year + 543);
            lsEndDate = lsStartDate;
            Report lsRpt = new Report();
            try
            {
                TxtTo.Text = aTO;
                //TxtTo.Text = "eploentham@gmail.com";
                lsLine1 = lsIni.GetString("thahr30", "companyname", "Thai Hotels ");
                lsLine2 = lsIni.GetString("report", aReportName, "DAILY SUMMARY DEPOSIT REPORT ");
                lsLine3 = "For date : " + lsDay;// + " to " + TxtDate.Value.Day.ToString("00") + "-" + TxtDate.Value.Month.ToString("00") + "-" + TxtDate.Value.Year.ToString();
                if (aReportName == "rptdailypayinrecordsuemail")
                {
                    lsFileName = "dailypayinrecord" + lsDay + ".pdf";
                }
                else
                {
                    lsFileName = "dailycash-credit" + lsDay + ".pdf";//DAILY PAY IN RECORD REPORT GROUP BY PAYMENT
                }
                lsRpt.CreateVoucherAcc(aReportName, lsStartDate, lsEndDate, "", "", "", "", true);
                if (Directory.Exists(lsPath) == false)
                {
                    Directory.CreateDirectory(lsPath);
                }
                if (File.Exists(lsPath + "\\" + lsFileName))
                {
                    File.Delete(lsPath + "\\" + lsFileName);
                }
                ReportDocument RptExport = new ReportDocument();
                
                RptExport.Load(reportPath);
                RptExport.DataDefinition.FormulaFields["line1"].Text = "\"" + lsLine1 + "\"";
                RptExport.DataDefinition.FormulaFields["line2"].Text = "\"" + lsLine2 + "\"";
                RptExport.DataDefinition.FormulaFields["line3"].Text = "\"" + lsLine3 + "\"";
                Application.DoEvents();
                RptExport.ExportToDisk(ExportFormatType.PortableDocFormat, lsPath + "\\" + lsFileName);

                RptExport.Dispose();
                Application.DoEvents();

                lsTO = "";
                lsSubject = "";
                lsTO = TxtTo.Text;
                if (aReportName == "rptdailypayinrecordsuemail")
                {
                    lsSubject = TxtSubject.Text.Replace("/", "-");
                }
                else
                {
                    lsSubject = "Daily Cash/Credit " + lsDay;
                }
                MailMessage lsEMail = new MailMessage();
                MailAddress lsFromAddress = new MailAddress(TxtFrom.Text);
                Attachment lsAttach = new Attachment(lsPath + "\\" + lsFileName);
                Application.DoEvents();
                lsEMail.From = lsFromAddress;
                lsEMail.To.Add(lsTO);
                //lsEMail.CC.Add("eploentham@gmail.com");
                lsEMail.Subject = lsSubject;
                lsEMail.Body = TxtBody.Text;
                lsEMail.Attachments.Add(lsAttach);
                SmtpClient lsSMTP = new SmtpClient(aServer);
                lsSMTP.Credentials = CredentialCache.DefaultNetworkCredentials;
                lsSMTP.Send(lsEMail);
                Application.DoEvents();
            }
            catch (Exception e)
            {
                lsGdb.WriteLogError("", e, "", "SendEMail ");
                MessageBox.Show(e.Message.ToString(), e.Source.ToString());
            }
            if (aFlag)
            {
                MessageBox.Show("send e-amil success", "E-Mail", MessageBoxButtons.OK);
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void ShopSendEmail_Load(object sender, EventArgs e)
        {
            TxtTo.Text = "manager@thaihotels.org,account@thaihotels.org,info@thaihotels.org,tawanss@yahoo.com,eploentham@gmail.com";
            TxtTo.Text = "eploentham@gmail.com";
        }

        private void SendLoad()
        {
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            string lsSMTP = lsIni.GetString("thahr30", "smtp", "mail.asianet.co.th");
            string lsFrom = lsIni.GetString("thahr30", "emailfrom", "counterb@thaihotels.org");
            string lsTo = lsIni.GetString("thahr30", "emailto", "mail.asianet.co.th");
            lsSubject = lsIni.GetString("thahr30", "emailsubjectdailyreport", "mail.asianet.co.th");
            TxtSMTP.Text = lsSMTP;
            TxtFrom.Text = lsFrom;
            TxtTo.Text = lsTo;
            SetSubject();
            SelectEMail(TxtDate.Value);
        }

        private void SetSubject()
        {
            TxtSubject.Text = "Daily Pay in Record " + TxtDate.Value.ToShortDateString();
        }
        private void SelectEMail(DateTime aDate)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SetSubject();
            string lsSQL = "", lsDate = "";
            Int32 liCnt = 0, liDays = 0, liResRooms = 0, liCntCounter=0, liDaysCounter=0, liResRoomsCounter=0;
            double ldoDepositAmt = 0, ldoDepositAmtCounter=0;
            lsDate = lsGdb.SelectDateMySQL(aDate);
            Connection lsConn = new Connection();
            lsConn.ConnectDatabase();
            MySqlConnection lsConn1 = new MySqlConnection();
            lsConn1 = lsConn.Gdb;
            lsSubject = lsSubject + " " + lsGdb.SelectDateBudda(aDate);
            lsSQL = "Select ifnull(count(*),0) as cnt, ifnull(sum(depositamt),0) as depositamt, ifnull(sum(visitt),0) as visitt, ifnull(sum(resrooms),0) as resrooms From voucher Where voudate = '" + lsDate + "' and flag in('1','2')";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            //TxtBody.SelectionBullet = true;
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    liCnt = Convert.ToInt32(lsRead["cnt"]);
                    liDays = Convert.ToInt32(lsRead["visitt"]);
                    liResRooms = Convert.ToInt32(lsRead["resrooms"]);
                    ldoDepositAmt = Convert.ToDouble(lsRead["depositamt"]);
                }
            }
            lsRead.Close();
            TxtBody.Text = "Dear committee\n";
            TxtBody.Text = TxtBody.Text + "Date : "  + lsGdb.SelectDate(TxtDate.Value, Connection.FlagDate.DateShow, lsIni) + "\n";
            TxtBody.Text = TxtBody.Text + "\n";
            TxtBody.Text = TxtBody.Text + "Voucher total   = " + liCnt + "\n";
            TxtBody.Text = TxtBody.Text + "        Days     = " + liDays + "\n";
            TxtBody.Text = TxtBody.Text + "        Rooms   = " + liResRooms + "\n";
            TxtBody.Text = TxtBody.Text + "        Deposit  = " + ldoDepositAmt.ToString ("0,000.00") + "\n";
            TxtBody.Text = TxtBody.Text + "\n";
            lsSQL = "Select * From counter Where flag = '1'";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = lsComm1 .ExecuteReader();
            if (lsRead1.HasRows)
            {
                while(lsRead1.Read())
                {
                    lsSQL = "Select ifnull(count(*),0) as cnt, ifnull(sum(depositamt),0) as depositamt, ifnull(sum(visitt),0) as visitt, ifnull(sum(resrooms),0) as resrooms From voucher Where voudate = '" + lsDate + "' and counter1 = '" + lsRead1["counterid"].ToString() + "' and flag in('1','2')";
                    MySqlCommand lsComm2 = new MySqlCommand (lsSQL, lsConn.Gdb);
                    MySqlDataReader lsRead2;
                    lsRead2 = lsComm2.ExecuteReader();
                    if (lsRead2.HasRows)
                    {
                        while (lsRead2.Read())
                        {
                            liCntCounter = Convert.ToInt32(lsRead2["cnt"]);
                            liDaysCounter = Convert.ToInt32(lsRead2["visitt"]);
                            liResRoomsCounter = Convert.ToInt32(lsRead2["resrooms"]);
                            ldoDepositAmtCounter = Convert.ToDouble(lsRead2["depositamt"]);
                            TxtBody.Text = TxtBody.Text + "Counter : " + lsRead1["countername"].ToString() + "\n";
                            TxtBody.Text = TxtBody.Text + "Voucher total   = " + liCntCounter + "\n";
                            TxtBody.Text = TxtBody.Text + "        Days    = " + liDaysCounter + "\n";
                            TxtBody.Text = TxtBody.Text + "        Rooms   = " + liResRoomsCounter + "\n";
                            TxtBody.Text = TxtBody.Text + "        Deposit = " + ldoDepositAmtCounter.ToString("0,000.00") + "\n";
                            TxtBody.Text = TxtBody.Text + "\n";
                            lsSQL = "";
                        }
                    }
                    lsRead2.Close();
                }
            }
            lsRead1.Close();
            lsConn.Gdb.Close();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            SendEMail(TxtSMTP.Text, true, TxtTo.Text, "rptdailypayinrecordsuemail");
        }

        private void TxtDate_ValueChanged(object sender, EventArgs e)
        {
            SelectEMail(TxtDate.Value);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}