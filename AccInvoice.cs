using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Net;
namespace ThaHr30
{
    public partial class AccInvoice : Form
    {
        private Int16 liColMainHotelCode = 0, liColMainMemNamee1 = 1, liColMainVoucher = 2, liColMainDays = 3, liColMainPax = 4, liColMainDepositAMT = 5;
        private Int16 liColMainGenPDF = 7, liColMainSendEMail = 8, colSendcomp=9, liColMainTypeGen = 10, liColMainEMail = 11, liColMainFileName = 12, liColMainDepositPay = 6;
        private string lsStartDate = "", lsEndDate = "";
        private int liColVouNo = 0, liColGuestName = 1, liColVouDate = 2, liColCounter = 3, liColMac = 4, liColRoomRate = 5, liColRoomRate1 = 6, liColStaffName = 7;
        private int liColStatus = 8, liColCheckInDate = 9, liColCheckOutDate = 10, liColDays = 11, liColPax = 12, liColDeposit = 13, liColRoomNO = 14, liColDetailCounterID = 0, liColDetailDepositAMT = 5;
        private Int32 emailsendwait = 0;
        enum TypeGen
        {
            PDF, Excel, HTML,RTF, Word
        }
        //TypeGen lsTypeGen = new TypeGen();
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile();
        double ldoAccountMemberRate = 0;
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
        public AccInvoice()
        {
            InitializeComponent();
        }
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            //mailSent = true;
        }

        private void SendEMail(string aServer)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Pb1.Visible = true;
            Int16 liRow = 0, liCnt=0;
            string lsTO = "", lsSubject = "", lsFileName="", lsBody="", lsErr="", emailError="";
            Boolean lbSendEmail = false, sendedComp = true;
            //GrdView.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            for (int i = 0; i <= GrdView.Sheets[0].RowCount-1; i++)
            {
                lbSendEmail = Convert.ToBoolean(GrdView.Sheets[0].GetValue(i, liColMainSendEMail));
                if (lbSendEmail)
                {
                    liRow++;
                }
            }
            Pb1.Maximum = liRow + 1;
            liRow = 0;            

            for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
            {
                lbSendEmail = Convert.ToBoolean(GrdView.Sheets[0].GetValue(i, liColMainSendEMail));
                sendedComp = Convert.ToBoolean(GrdView.Sheets[0].GetValue(i, colSendcomp));
                if (lbSendEmail && !sendedComp)
                {
                    try
                    {
                        lsTO = "";
                        lsSubject = "";
                        lsTO = GrdView.Sheets[0].GetText(i, liColMainEMail);
                        lsSubject = TxtEmailSubject.Text + " " + GrdView.Sheets[0].GetText(i, liColMainMemNamee1) + " " + CboMonth.Text + " " + CboYear.Text;
                        lsFileName = GrdView.Sheets[0].GetText(i, liColMainFileName);
                        MailMessage lsEMail = new MailMessage();
                        MailAddress lsFromAddress = new MailAddress(TxtEmailFrom.Text);
                        Application.DoEvents();
                        lsEMail.From = lsFromAddress;
                        if (lsFileName != "")
                        {
                            Attachment lsAttach = new Attachment(lsFileName);
                            lsErr = lsAttach + " ";
                            lsEMail.Attachments.Add(lsAttach);

                            lsEMail.To.Add(lsTO);
                            //lsEMail.To.Add("eploentham1@gmail.com");

                            lsErr = lsErr + " " + lsTO + " ";
                            //lsEMail.To.Add("eploentham@gmail.com");
                            lsEMail.Subject = lsSubject;
                            lsEMail.Body = lsBody;
                            SmtpClient lsSMTP = new SmtpClient(aServer);
                            //SmtpClient lsSMTP = new SmtpClient("mail.asianet.co.th");
                            //lsSMTP.Credentials = CredentialCache.DefaultNetworkCredentials;
                            lsSMTP.Credentials = new NetworkCredential("account@thaihotels.org", "account");
                            lsErr = lsErr + " " + lsTO + " send ";

                            lsSMTP.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                            lsSMTP.Send(lsEMail);

                            lsErr = lsErr + " " + lsTO + " send success ";
                            //lsSMTP.SendAsync
                            Application.DoEvents();
                            lsAttach.Dispose();
                            liCnt++;
                            //GrdView.ActiveSheet.Rows[i].BackColor = Color.LightGoldenrodYellow;
                        }
                        //liRow++;
                        GrdView.ActiveSheet.Rows[i].BackColor = Color.RosyBrown;
                        GrdView.Sheets[0].SetText(i, colSendcomp, "1");
                        Pb1.Value = i;
                        return;
                    }
                    catch (Exception e)
                    {
                        lsGdb.WriteLogError("", e, "", "SendEMail ");
                        MessageBox.Show(e.Message.ToString() + "\n" + lsErr, e.Source.ToString());
                        emailError = " มี error " + emailError;
                    }
                }
            }
            //timer.Stop;
            Pb1.Visible = false;
            Sl1.Text = "Send Email จำนวน " + liCnt.ToString() + " ตรวจสอบความผิดพลาด " + emailError;
            //GrdView.Cursor = System.Windows.Forms.Cursors.Default;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void Timer_Tick(object sender, EventArgs eArgs)
        {
            string lsSMTP = lsIni.GetString("thahr30", "smtp", "mail.asianet.co.th");
            Boolean aa = false;
            TxtEmailSubject.Text = GetSubjectSendEMail();
            //if (aa)
            //{
                SendEMail(lsSMTP);
            //}
        }
        private void PaintGrdMain()
        {
            GrdView.Left = 12;
            GrdView.Height = this.Height - 150;
            GrdView.Width = this.Width - 80;
            GrdView.Top = 88;
            GrdView.Left = 12;
            GrdView.Sheets[0].ColumnCount = 13;
            GrdView.Sheets[0].RowCount = 1;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[0].SetColumnWidth(liColMainHotelCode, 82);
            GrdView.Sheets[0].SetColumnWidth(liColMainMemNamee1, 250);
            GrdView.Sheets[0].SetColumnWidth(liColMainVoucher, 60);
            GrdView.Sheets[0].SetColumnWidth(liColMainDays, 60);
            GrdView.Sheets[0].SetColumnWidth(liColMainPax, 60);
            GrdView.Sheets[0].SetColumnWidth(liColMainDepositAMT, 80);
            GrdView.Sheets[0].SetColumnWidth(liColMainDepositPay, 80);
            GrdView.Sheets[0].SetColumnWidth(liColMainGenPDF, 80);
            GrdView.Sheets[0].SetColumnWidth(liColMainSendEMail, 80);
            GrdView.Sheets[0].SetColumnWidth(colSendcomp, 80);
            GrdView.Sheets[0].SetColumnWidth(liColMainTypeGen, 70);
            GrdView.Sheets[0].SetColumnWidth(liColMainEMail, 220);
            GrdView.Sheets[0].SetColumnWidth(liColMainFileName, 250);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.Sheets[0].Columns[liColMainHotelCode, liColMainPax];
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.NumberCellType celldeposit = new FarPoint.Win.Spread.CellType.NumberCellType();
            GrdView.Sheets[0].Columns[liColMainDepositAMT].CellType = celldeposit;
            GrdView.Sheets[0].Columns[liColMainMemNamee1, liColMainDepositAMT].Locked = true;
            FarPoint.Win.Spread.CellType.NumberCellType celldepositpay = new FarPoint.Win.Spread.CellType.NumberCellType();
            GrdView.Sheets[0].Columns[liColMainDepositPay].CellType = celldepositpay;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellgenpdf = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellgenpdf.TextTrue = "gen DOC";
            cellgenpdf.TextFalse = "gen DOC";
            GrdView.Sheets[0].Columns[liColMainGenPDF].CellType = cellgenpdf;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellsendemail = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellsendemail.TextTrue = "send E-Mail";
            cellsendemail.TextFalse = "send E-Mail";
            GrdView.Sheets[0].Columns[liColMainSendEMail].CellType = cellsendemail;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellsendemailcomp = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellsendemailcomp.TextTrue = "Sended";
            cellsendemailcomp.TextFalse = "Sended";
            GrdView.Sheets[0].Columns[colSendcomp].CellType = cellsendemailcomp;
            FarPoint.Win.Spread.CellType.ComboBoxCellType cellTypeGen = new FarPoint.Win.Spread.CellType.ComboBoxCellType();            
            cellTypeGen.Items = new string[] {Convert.ToString(TypeGen.PDF), Convert.ToString(TypeGen.Excel), Convert.ToString(TypeGen.HTML), Convert.ToString(TypeGen.RTF), Convert.ToString(TypeGen.Word)};
            GrdView.Sheets[0].Columns[liColMainTypeGen].CellType = cellTypeGen;
            FarPoint.Win.Spread.CellType.TextCellType cellEMail = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[liColMainEMail].CellType = cellEMail;
            FarPoint.Win.Spread.CellType.TextCellType cellFilename = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[liColMainFileName].CellType = cellFilename;
            GrdView.Sheets[0].SetColumnLabel(0, liColMainHotelCode, "hotelcode");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainMemNamee1, "Member Name E");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainVoucher, "Vou NO");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainDays, "Days");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainPax, "PAX");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainDepositAMT, "Deposit");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainDepositPay, "Pay/Rec" + ldoAccountMemberRate.ToString() + "%");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainGenPDF, " PDF ");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainSendEMail, " ");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainTypeGen, " ");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainEMail, "E-Mail Name");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainFileName, "Attachment FileName");
            GrdView.AllowColumnMove = true;
            GrdView.Sheets[0].Columns[0].Visible = false;
        }
        private void SelectVoucher(string aMonth, string aYear)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Pb1.Visible = true;
            Int32 i = 0, j = 0, liCountVoucherMain = 0, liCountDaysMain = 0, liCountPaxMain = 0;
            double ldoDepositAMT = 0, ldoDeposit = 0;
            string lsSQL = "";
            //PaintGrdMain();
            DateTime ld = new DateTime();
            //Connection lsConn = new Connection();
            //lsConn.ConnectDatabase();
            Int32 li = Convert.ToInt32(aMonth);
            lsStartDate = aYear + "-" + li.ToString("00") + "-01";
            ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
            lsStartDate = (Convert.ToInt16(aYear) - 543) + "-" + li.ToString("00") + "-01";
            lsEndDate = lsGdb.SelectDateMySQL(ld);
            lsSQL = "Select count(*) as cnt From accrecvoucher v "
                + "Where v.checkindate >= '" + lsStartDate + "' and v.checkindate <= '"
                + lsEndDate + "' and v.flag in ('1','2') Group By hotelcode ";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsReadMain;
            lsReadMain = lsComm.ExecuteReader();
            if (lsReadMain.HasRows)
            {
                while (lsReadMain.Read())
                {
                    j++;
                }
            }
            lsReadMain.Close();
            GrdView.Sheets[0].RowCount = j+1;
            Pb1.Minimum = 0;
            Pb1.Maximum = j;
            lsSQL = "Select v.hotelcode as hotelcode, count(v.hotelcode) voucher, sum(v.visitt)as Days, "
                + "sum(personintrip) as PAX, sum(depositamt) as Deposit, counter1 as counter, sum(v.depositamt - (v.roomrate1*v.visitt*" 
                + ldoAccountMemberRate + "/100)) as depositpay From accrecvoucher v "
                + "Where v.checkindate >= '" + lsStartDate + "' and v.checkindate <= '"
                + lsEndDate + "' and v.flag in ('1','2') Group By hotelcode ";
            lsComm.CommandText = lsSQL;
            lsReadMain = lsComm.ExecuteReader();
            if (lsReadMain.HasRows)
            {
                while (lsReadMain.Read())
                {
                    ldoDeposit = Convert.ToDouble(lsReadMain["Deposit"]);
                    lsSQL = lsIniT.SelectInitial(lsIniT.TblMember, lsReadMain["hotelcode"].ToString(), Initial.WhereSelect.aCodetoName);
                    GrdView.Sheets[0].SetText(i, liColMainHotelCode, lsReadMain["hotelcode"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMainMemNamee1, lsSQL);
                    GrdView.Sheets[0].SetText(i, liColMainVoucher, lsReadMain["voucher"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMainDays, lsReadMain["Days"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMainPax, lsReadMain["PAX"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMainDepositAMT, ldoDeposit.ToString());
                    GrdView.Sheets[0].SetText(i, liColMainDepositPay, lsReadMain["depositpay"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMainTypeGen, Convert.ToString(TypeGen.PDF));
                    GrdView.Sheets[0].SetText(i, liColMainEMail, lsIniT.SelectInitial(lsIniT.TblMemberEmailAccount ,lsReadMain["hotelcode"].ToString(), Initial.WhereSelect.aCodetoName));
                    liCountVoucherMain = liCountVoucherMain + Convert.ToInt32(lsReadMain["voucher"]);
                    liCountDaysMain = liCountDaysMain + Convert.ToInt32(lsReadMain["days"]);
                    liCountPaxMain = liCountPaxMain + Convert.ToInt32(lsReadMain["pax"]);
                    if (ldoDeposit < Convert.ToDouble(lsReadMain["depositpay"]))
                    {
                        GrdView.Sheets[0].Cells[i, liColMainDepositPay].ForeColor = Color.Green;
                        GrdView.Sheets[0].Cells[i, liColMainDepositPay].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.Sheets[0].SetNote(i, liColMainDepositPay, "รับเงินเพิ่ม");
                    }
                    else
                    {
                        GrdView.Sheets[0].Cells[i, liColMainDepositPay].ForeColor = Color.Red;
                        GrdView.Sheets[0].Cells[i, liColMainDepositPay].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.Sheets[0].SetNote(i, liColMainDepositPay, "จ่ายเงิน");
                    }
                    ldoDepositAMT = ldoDepositAMT + ldoDeposit;
                    if ((i % 2) != 0)
                    {
                        GrdView.Sheets[0].Rows[i].BackColor = Color.LightGoldenrodYellow;
                    }
                    i++;
                    Pb1.Value = i;
                }
            }
            lsReadMain.Close();
            if (GrdView.Sheets[0].RowCount > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            //lsConn.Gdb.Close();
            Pb1.Visible = false;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void DefaultGenPDF(Boolean aFlag)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
            {
                if (aFlag)
                {
                    GrdView.Sheets[0].SetText(i, liColMainGenPDF, "1");
                    GrdView.Sheets[0].SetText(i, liColMainTypeGen, Convert.ToString(TypeGen.PDF));
                }
                else
                {
                    GrdView.Sheets[0].SetText(i, liColMainGenPDF, "0");
                    GrdView.Sheets[0].SetText(i, liColMainTypeGen, "");
                }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void DefaultSendEmail(Boolean aFlag)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
            {
                if (aFlag)
                {
                    GrdView.Sheets[0].SetText(i, liColMainSendEMail, "1");
                }
                else
                {
                    GrdView.Sheets[0].SetText(i, liColMainSendEMail, "0");
                }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void GenReport()
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Int16 liRow = 0;
            Pb1.Visible = true;
            Int32 li = Convert.ToInt32(CboMonth.ComboBox.SelectedValue.ToString());
            DateTime ld = new DateTime();
            Report lsRpt = new Report();
            Pb1.Minimum = 0;
            Pb1.Maximum = GrdView.Sheets[0].RowCount;
            lsStartDate = CboYear.Text + "-" + li.ToString("00") + "-01";
            ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
            lsStartDate = (Convert.ToInt16(CboYear.Text) - 543) + "-" + li.ToString("00") + "-01";
            lsEndDate = ld.Year.ToString("0000") + "-" + ld.Month.ToString("00") + "-" + ld.Day.ToString("00");
            string lsYearMonth = CboYear.Text + "\\" + CboMonth.Text;
            string lsPath = Application.StartupPath + "\\Account\\" + lsYearMonth, lsFileName = "";
            string reportPath = Application.StartupPath + "\\rptmonthlysalereport.rpt";
            string lsHotelCode = "", lsHotelName="", lsLine3="";
            Boolean lbGenPDG = true, lbFirst=true;
            for (int i = 0; i <= GrdView.Sheets[0].RowCount-1; i++)
            {
                string aa = GrdView.Sheets[0].GetText(i, liColMainMemNamee1);
                lbGenPDG = Convert.ToBoolean(GrdView.Sheets[0].GetValue(i, liColMainGenPDF));
                if (lbGenPDG)
                {
                    liRow++;
                }
            }
            Pb1.Maximum = liRow + 1;
            lsLine3 = "For the month of : " + CboMonth.ComboBox.Text + " " + (Convert.ToInt16(CboYear.ComboBox.Text) - 543);
            liRow = 0;
            for (int i=0; i <= GrdView.Sheets[0].RowCount - 1; i++)
            {
                lsHotelCode = "";
                lsHotelName = "";
                lsHotelCode = GrdView.Sheets[0].GetText(i, liColMainHotelCode);
                lsHotelName = GrdView.Sheets[0].GetText(i, liColMainMemNamee1);
                lbGenPDG = Convert.ToBoolean(GrdView.Sheets[0].GetValue(i, liColMainGenPDF));
                if (lbGenPDG)
                {
                    if (lbFirst)
                    {
                        lsRpt.CreateVoucherAcc("rptmonthlysalereport", lsStartDate, lsEndDate, lsHotelName, lsHotelName, "", "", true);
                    }
                    else
                    {
                        lsRpt.CreateVoucherAcc("rptmonthlysalereport", lsStartDate, lsEndDate, lsHotelName, lsHotelName, "", "", false);
                    }
                    lbFirst = false;
                    Application.DoEvents();
                    lsFileName = "";
                    lsFileName = GrdView.Sheets[0].GetText(i, liColMainMemNamee1) + ".pdf";
                    if (lsFileName != "")
                    {
                        lsFileName = GrdView.Sheets[0].GetText(i, liColMainMemNamee1) + ".pdf";
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
                        RptExport.DataDefinition.FormulaFields["line3"].Text = "\"" + lsLine3 + "\"";
                        Application.DoEvents();
                        RptExport.ExportToDisk(ExportFormatType.PortableDocFormat, lsPath + "\\" + lsFileName);
                        
                        RptExport.Dispose();
                        Application.DoEvents();
                        liRow++;
                        Pb1.Value = liRow;
                        GrdView.Sheets[0].Rows[i].BackColor = Color.BurlyWood;
                    }
                    GrdView.Sheets[0].SetText(i, liColMainFileName, lsPath + "\\" + lsFileName);
                    GrdView.Sheets[0].SetActiveCell(i, 1);
                }
            }
            Pb1.Visible = false;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void PaintGrdView(Int32 aGrd)
        {
            GrdView.Sheets[aGrd].ColumnCount = 15;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[aGrd].SetColumnWidth(liColVouNo, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColGuestName, 220);
            GrdView.Sheets[aGrd].SetColumnWidth(liColVouDate, 70);
            GrdView.Sheets[aGrd].SetColumnWidth(liColCounter, 75);
            GrdView.Sheets[aGrd].SetColumnWidth(liColMac, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColRoomRate, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColRoomRate1, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColStaffName, 85);
            GrdView.Sheets[aGrd].SetColumnWidth(liColStatus, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColCheckInDate, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColCheckOutDate, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColDays, 45);
            GrdView.Sheets[aGrd].SetColumnWidth(liColPax, 45);
            GrdView.Sheets[aGrd].SetColumnWidth(liColDeposit, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColRoomNO, 60);

            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.Sheets[aGrd].Columns[liColVouNo, liColRoomNO];
            col.CellType = cell;

            GrdView.Sheets[aGrd].Columns[liColDetailCounterID, liColDetailDepositAMT].Locked = true;
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColVouNo, "Vou No");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColGuestName, "Guest Name");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColVouDate, "Vou Date");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColCounter, "Counter");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColMac, "MAC");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColRoomRate, "Room Rate");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColRoomRate1, "Room Rate++");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColStaffName, "Staff");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColStatus, "Status");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColCheckInDate, "in Date");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColCheckOutDate, "out Date");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColPax, "PAX");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColDays, "Days");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColDeposit, "Deposit");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColRoomNO, "Room NO");
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            //GrdView.Sheets[aGrd].Columns[liColVouNo].Visible = false;
            FarPoint.Win.Spread.HideRowFilter hideRowFilter = new FarPoint.Win.Spread.HideRowFilter(GrdView.ActiveSheet);
            GrdView.Sheets[aGrd].Columns[liColGuestName].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColVouDate].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColCounter].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColStaffName].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColCheckInDate].AllowAutoFilter = true;
            //GrdView.Visible = true;
        }
        private void SelectVoucherDetail(string aMemId, int aGrdIndex)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Int32 i = 0, j = 0;
            string lsSQL = "", ls = "", lsCounterName = "", lsStatus = "", lsStaffName = "";
            DateTime ld = new DateTime();
            PaintGrdView(aGrdIndex);
            lsSQL = "Select count(*) cnt From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                + lsEndDate + "' and hotelcode = '" + aMemId + "' and flag in ('1','2') ";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = lsComm1.ExecuteReader();
            if (lsRead1.HasRows)
            {
                while (lsRead1.Read())
                {
                    i = Convert.ToInt32(lsRead1["cnt"]);
                }
            }
            lsRead1.Close();
            GrdView.Sheets[aGrdIndex].RowCount = i;
            lsSQL = "Select vouno, guestfirstname, guestlastname, voudate, counter1, mac, "
                + "roomno, roomrate, roomrate1, staffcode, statuscode, checkindate, checkoutdate, "
                + "visitt, pax, depositamt, roomno From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                + lsEndDate + "' and hotelcode = '" + aMemId + "' and flag in ('1','2') Order By counter1, voudate, vouno";
            MySqlCommand lsComm2 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead2;
            lsRead2 = lsComm2.ExecuteReader();
            if (lsRead2.HasRows)
            {
                j = 0;
                while (lsRead2.Read())
                {
                    lsCounterName = lsIniT.SelectInitial(lsIniT.TblCounter, lsRead2["counter1"].ToString(), Initial.WhereSelect.aCodetoName);
                    lsStaffName = lsIniT.SelectInitial(lsIniT.TblStaff, lsRead2["staffcode"].ToString(), Initial.WhereSelect.aCodetoName);
                    lsStatus = lsIniT.SelectInitial(lsIniT.TblStatus, lsRead2["statuscode"].ToString(), Initial.WhereSelect.aCodetoName);

                    GrdView.Sheets[aGrdIndex].Cells[j, liColVouNo].Text = lsRead2["vouno"].ToString();
                    GrdView.Sheets[aGrdIndex].SetText(j, liColGuestName, lsRead2["guestfirstname"].ToString() + " " + lsRead2["guestlastname"].ToString());
                    ld = Convert.ToDateTime(lsRead2["voudate"]);
                    ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + ld.Year.ToString("0000");
                    GrdView.Sheets[aGrdIndex].Cells[j, liColVouDate].Text = ls;
                    GrdView.Sheets[aGrdIndex].Cells[j, liColCounter].Text = lsCounterName;
                    GrdView.Sheets[aGrdIndex].Cells[j, liColMac].Text = lsRead2["mac"].ToString().Substring(6, 3);
                    GrdView.Sheets[aGrdIndex].Cells[j, liColRoomRate].Text = lsRead2["roomrate"].ToString();
                    GrdView.Sheets[aGrdIndex].Cells[j, liColRoomRate1].Text = lsRead2["roomrate1"].ToString();
                    GrdView.Sheets[aGrdIndex].Cells[j, liColStaffName].Text = lsStaffName;
                    GrdView.Sheets[aGrdIndex].Cells[j, liColStatus].Text = lsStatus;
                    ld = Convert.ToDateTime(lsRead2["checkindate"]);
                    ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + ld.Year.ToString("0000");
                    GrdView.Sheets[aGrdIndex].Cells[j, liColCheckInDate].Text = ls;
                    ld = Convert.ToDateTime(lsRead2["checkoutdate"]);
                    ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + ld.Year.ToString("0000");
                    GrdView.Sheets[aGrdIndex].Cells[j, liColCheckOutDate].Text = ls;
                    GrdView.Sheets[aGrdIndex].Cells[j, liColDays].Text = lsRead2["visitt"].ToString();
                    GrdView.Sheets[aGrdIndex].Cells[j, liColPax].Text = lsRead2["pax"].ToString();
                    GrdView.Sheets[aGrdIndex].Cells[j, liColDeposit].Text = lsRead2["depositamt"].ToString();
                    GrdView.Sheets[aGrdIndex].Cells[j, liColRoomNO].Text = lsRead2["roomno"].ToString();
                    if ((j % 2) != 0)
                    {
                        GrdView.Sheets[aGrdIndex].Rows[j].BackColor = Color.LightGoldenrodYellow;
                    }
                    j++;
                }
            }
            lsRead2.Close();
            if (GrdView.Sheets[aGrdIndex].RowCount > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void AccInvoice_Load(object sender, EventArgs e)
        {
            Pb1.Visible = false;
            ldoAccountMemberRate = Convert.ToDouble(lsIni.GetString("thahr30", "accountmemberrate", "0"));
            TxtEmailFrom.Text = lsIni.GetString("thahr30", "emailaccountfrom", "account@thaihotel.org");
            PaintGrdMain();
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsIniT.CreateTblInitial(lsGdb.Gdb);
            lsGdb.SelectCbo(CboYear.ComboBox, "", Connection.TableIniT.YearName);
            lsGdb.SelectCbo(CboMonth.ComboBox, "", Connection.TableIniT.MonthName);
            CboMonth.ComboBox.SelectedValue = DateTime.Today.Month.ToString();
            CboYear.ComboBox.SelectedValue = Convert.ToString(DateTime.Today.Year + 543);
            TxtEmailSubject.Text = lsIni.GetString("thahr30", "emailaccountsubject", "account@thaihotel.org") + CboMonth.Text + " " + CboYear.Text;
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SelectVoucher(CboMonth.ComboBox.SelectedValue.ToString(), CboYear.Text);
            //ChkDiffVoucher(CboMonth.ComboBox.SelectedValue.ToString(), CboYear.Text);
            TxtEmailSubject.Text = GetSubjectSendEMail();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void ChkGenPDFAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkGenPDFAll.Checked)
            {
                DefaultGenPDF(true);
            }
            else
            {
                DefaultGenPDF(false);
            }
        }

        private void ChkSendEmailAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSendEmailAll.Checked)
            {
                DefaultSendEmail(true);
            }
            else
            {
                DefaultSendEmail(false);
            }
        }
        private string GetSubjectSendEMail()
        {
            string lsReturn = "";
            lsReturn = lsIni.GetString("thahr30", "emailaccountsubject", "account@thaihotel.org") + " " + CboMonth.Text + " " + CboYear.Text;
            return lsReturn;
        }
        private void save_Click(object sender, EventArgs e)
        {
            GenReport();
        }
        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            emailsendwait = Convert.ToInt32(lsIni.GetString("thahr30", "emailsendwait", "1"));
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = emailsendwait*1000;
            timer.Start();
            timer.Tick += new EventHandler(Timer_Tick);
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GrdView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
        }

        private void adjustdata_Click(object sender, EventArgs e)
        {
            
        }

        private void CboMonth_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Boolean lbTrue = true;
            string lsSheetName = GrdView.Sheets[0].Cells[e.Row, 1].Text;
            for (int j = 0; j <= GrdView.Sheets.Count - 1; j++)
            {
                if (lsSheetName == GrdView.Sheets[j].SheetName)
                {
                    lbTrue = false;
                }
            }
            if (lbTrue)
            {
                int i = GrdView.Sheets.Count + 1;
                GrdView.Sheets.Count = i;
                GrdView.Sheets[i - 1].SheetName = GrdView.Sheets[0].Cells[e.Row, 1].Text;
                SelectVoucherDetail(GrdView.Sheets[0].Cells[e.Row, 0].Text, i - 1);
            }
            else
            {
                MessageBox.Show("โรงแรมนี้ถูกเพิ่มไปแล้ว", "", MessageBoxButtons.OK);
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
    }
}