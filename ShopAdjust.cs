using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;
namespace ThaHr30
{
    public partial class ShopAdjust : Form
    {
        Boolean lbPageLoad = false, lbFlagHD= true;
        IniFile lsIni = new IniFile("thahr30.ini");
        Initial lsIniT = new Initial();
        Connection lsGdb = new Connection();
        MySqlConnection lsConnSelect1 = new MySqlConnection();
        MySqlConnection lsConnSelect2 = new MySqlConnection();
        MySqlConnection lsConnUpdate1 = new MySqlConnection();
        string lsCountMain = "0", lsCounterIP = "";
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
        public Boolean FlagHD
        {
            get
            {
                return lbFlagHD;
            }
            set
            {
                lbFlagHD = value;
            }
        }
        public ShopAdjust()
        {
            InitializeComponent();
        }
        private void PaintGrdRec()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdRec.Visible = false;
            GrdRec.Reset();
            GrdRec.ActiveSheet.RowCount = 0;
            GrdRec.ActiveSheet.ColumnCount = 4;
            GrdRec.Height = 682;
            GrdRec.Width = 1017;
            GrdRec.ActiveSheet.SetColumnWidth(0, 85);
            GrdRec.ActiveSheet.SetColumnWidth(1, 200);
            GrdRec.ActiveSheet.SetColumnWidth(2, 85);
            GrdRec.ActiveSheet.SetColumnWidth(3, 85);
            GrdRec.ActiveSheet.SetColumnLabel(0, 0, "Vou NO");
            GrdRec.ActiveSheet.SetColumnLabel(0, 1, "Guest Name");
            GrdRec.ActiveSheet.SetColumnLabel(0, 2, "Vou Date");
            GrdRec.ActiveSheet.SetColumnLabel(0, 3, "MAC");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdRec.ActiveSheet.Columns[0,3];
            col.CellType = cell;
            GrdRec.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdRec.BorderStyle = BorderStyle.None;
            GrdRec.Visible = true;
        }
        private void SendEMail(string aServer)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();


            string lsSQL = "", lsDate = "", lsBody="", lsSubject="";
            Int32 liCnt = 0, liDays = 0, liResRooms = 0, liCntCounter = 0, liDaysCounter = 0, liResRoomsCounter = 0;
            double ldoDepositAmt = 0, ldoDepositAmtCounter = 0;
            lsDate = lsGdb.SelectDateMySQL(TxtStartDate.Value);
            Connection lsConn = new Connection();
            lsConn.ConnectDatabase();
            MySqlConnection lsConn1 = new MySqlConnection();
            lsConn1 = lsConn.Gdb;
            lsSubject = lsSubject + " " + lsGdb.SelectDateBudda(TxtStartDate.Value);
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
            lsBody = "Dear committee\n";
            lsBody = lsBody + "Date : " + lsGdb.SelectDate(TxtStartDate.Value, Connection.FlagDate.DateShow, lsIni) + "\n";
            lsBody = lsBody + "\n";
            lsBody = lsBody + "Voucher total   = " + liCnt + "\n";
            lsBody = lsBody + "        Days     = " + liDays + "\n";
            lsBody = lsBody + "        Rooms   = " + liResRooms + "\n";
            lsBody = lsBody + "        Deposit  = " + ldoDepositAmt.ToString("0,000.00") + "\n";
            lsBody = lsBody + "\n";
            lsSQL = "Select * From counter Where flag = '1'";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = lsComm1.ExecuteReader();
            if (lsRead1.HasRows)
            {
                while (lsRead1.Read())
                {
                    lsSQL = "Select ifnull(count(*),0) as cnt, ifnull(sum(depositamt),0) as depositamt, ifnull(sum(visitt),0) as visitt, ifnull(sum(resrooms),0) as resrooms From voucher Where voudate = '" + lsDate + "' and counter1 = '" + lsRead1["counterid"].ToString() + "' and flag in('1','2')";
                    MySqlCommand lsComm2 = new MySqlCommand(lsSQL, lsConn.Gdb);
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
                            lsBody = lsBody + "Counter : " + lsRead1["countername"].ToString() + "\n";
                            lsBody = lsBody + "Voucher total   = " + liCntCounter + "\n";
                            lsBody = lsBody + "        Days    = " + liDaysCounter + "\n";
                            lsBody = lsBody + "        Rooms   = " + liResRoomsCounter + "\n";
                            lsBody = lsBody + "        Deposit = " + ldoDepositAmtCounter.ToString("0,000.00") + "\n";
                            lsBody = lsBody + "\n";
                            lsSQL = "";
                        }
                    }
                    lsRead2.Close();
                }
            }
            lsRead1.Close();
            lsConn.Gdb.Close();



            string lsTO = "";
            string lsSMTP = lsIni.GetString("thahr30", "smtp", "mail.asianet.co.th");
            string lsFrom = lsIni.GetString("thahr30", "emailfrom", "mail.asianet.co.th");
            string lsTo = lsIni.GetString("thahr30", "emailto", "mail.asianet.co.th");
            lsSubject = lsIni.GetString("thahr30", "emailsubjectdailyreport", "mail.asianet.co.th");
            try
            {
                //lsTO = "";
                //lsSubject = "";
                //lsSubject = lsSubject;
                MailMessage lsEMail = new MailMessage();
                MailAddress lsFromAddress = new MailAddress(lsFrom);
                Application.DoEvents();
                lsEMail.From = lsFromAddress;
                lsEMail.To.Add(lsTO);
                //lsEMail.CC.Add("eploentham@gmail.com");
                lsEMail.Subject = lsSubject;
                lsEMail.Body = lsBody;
                SmtpClient lsSMTP1 = new SmtpClient(aServer);
                lsSMTP1.Credentials = CredentialCache.DefaultNetworkCredentials;
                lsSMTP1.Send(lsEMail);
                Application.DoEvents();
            }
            catch (Exception e)
            {
                lsGdb.WriteLogError("", e, "", "SendEMail ");
                MessageBox.Show(e.Message.ToString(), e.Source.ToString());
            }
            MessageBox.Show("send e-amil success", "E-Mail", MessageBoxButtons.OK);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void PaintGrdRecMember()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdRec.Visible = false;
            GrdRec.Reset();
            GrdRec.ActiveSheet.RowCount = 0;
            GrdRec.ActiveSheet.ColumnCount = 3;
            GrdRec.Height = 682;
            GrdRec.Width = 1017;
            GrdRec.ActiveSheet.SetColumnWidth(0, 85);
            GrdRec.ActiveSheet.SetColumnWidth(1, 300);
            GrdRec.ActiveSheet.SetColumnWidth(2, 85);
            GrdRec.ActiveSheet.SetColumnLabel(0, 0, "Mem Id");
            GrdRec.ActiveSheet.SetColumnLabel(0, 1, "Hotel Name");
            GrdRec.ActiveSheet.SetColumnLabel(0, 2, "Price List");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdRec.ActiveSheet.Columns[0, 2];
            col.CellType = cell;
            GrdRec.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdRec.BorderStyle = BorderStyle.None;
            GrdRec.Visible = true;
        }
        
        public void SeparateInitial(string aTable, string aColumnCode, string aColumnName)
        {
            Int32 i = 0;
            Initial lsIniT = new Initial();
            string lsSQL = "";
            try
            {
                lsSQL = "Select count(*) as cnt From " + aTable + " ";
                MySqlCommand lsCommConter1 = new MySqlCommand(lsSQL, lsConnSelect1);
                MySqlDataReader lsReadCounter1;
                lsReadCounter1 = lsCommConter1.ExecuteReader();
                if (lsReadCounter1.HasRows)
                {
                    while (lsReadCounter1.Read())
                    {
                        Pb1.Maximum = Convert.ToInt32(lsReadCounter1["cnt"].ToString());
                    }
                }
                lsReadCounter1.Close();
                lsSQL = "Select * From " + aTable + " ";
                MySqlCommand lsCommConter = new MySqlCommand(lsSQL, lsConnSelect1);
                MySqlDataReader lsReadCounter;
                lsReadCounter = lsCommConter.ExecuteReader();
                if (lsReadCounter.HasRows)
                {
                    lsIniT.TableName = aTable;
                    lsIniT.ColumnCode = aColumnCode;
                    lsIniT.ColumnNameE = aColumnName;
                    while (lsReadCounter.Read())
                    {
                        lsIniT.DataCode = lsReadCounter.GetValue(0).ToString();
                        lsIniT.DataNameE = lsReadCounter.GetValue(1).ToString();
                        lsIniT.DataFlag = lsReadCounter["flag"].ToString();
                        lsIniT.CreateInitial(lsConnUpdate1);
                        i++;
                        GrdRec.ActiveSheet.AddRows(0, 1);
                        GrdRec.ActiveSheet.Cells[0, 0].Text = lsIniT.DataCode;
                        GrdRec.ActiveSheet.Cells[0, 1].Text = lsIniT.DataNameE;
                    }
                }
                lsReadCounter.Close();
            }
            catch (Exception e)
            {
                string ls = "ไม่สามารถ save ได้ " +aTable;
                lsGdb.WriteLogError(ls, e, aTable, "SeparateInitial ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
        }
        public Int32 SeparateMember(Boolean FlagHD)
        {
            Int32 i = 0;
            DateTime ldVoidDate;
            string lsSQL = "", lsPl = "", lsCounterid = "", lsStrSelect = "", lsStrUpdate = "";
            Member lstblMember = new Member();
            PaintGrdRecMember();
            lsCounterid = lsIniT.SelectInitial(lsIniT.TblCounter, CboCounter.Text, Initial.WhereSelect.aNametoCode);
            if (FlagHD)
            {
                lsSQL = "Select count(*) as cnt From member Where flagsend <> '2'";
            }
            else
            {
                lsSQL = "Select count(*) as cnt From member Where flagsend" + lsCounterid + " <> '2'";
            }
            MySqlCommand lsCommConter1 = new MySqlCommand(lsSQL, lsConnSelect1);
            MySqlDataReader lsReadCounter1;
            lsReadCounter1 = lsCommConter1.ExecuteReader();
            if (lsReadCounter1.HasRows)
            {
                while (lsReadCounter1.Read())
                {
                    Lb1.Items.Add("มีข้อมูล Member "+lsReadCounter1["cnt"].ToString() + lsConnSelect1.ConnectionString);
                    Application.DoEvents();
                    Pb1.Maximum = Convert.ToInt32(lsReadCounter1["cnt"].ToString());
                }
            }
            lsReadCounter1.Close();
            if (FlagHD)
            {
                lsSQL = "Select * From member Where flagsend <> '2'";
            }
            else
            {
                lsSQL = "Select * From member Where flagsend" + lsCounterid + " <> '2'";
            }
            MySqlCommand lsCommConter = new MySqlCommand(lsSQL, lsConnSelect1);
            MySqlDataReader lsReadCounter;
            lsReadCounter = lsCommConter.ExecuteReader();
            //MessageBox.Show("bbbbbbbbb", "aaaa");
            if (lsReadCounter.HasRows)
            {
                while (lsReadCounter.Read())
                {
                    try
                    {
                        lstblMember.MemID = lsReadCounter["memid"].ToString();
                        lstblMember.MemNameE1 = lsReadCounter["memnamee1"].ToString();
                        lstblMember.MemNameE2 = lsReadCounter["memnamee2"].ToString();
                        lstblMember.MemNameT = lsReadCounter["memnamet"].ToString();
                        lstblMember.Remark = lsReadCounter["remark"].ToString();
                        lstblMember.NumRoom = Convert.ToInt32(lsReadCounter["numroom"].ToString());
                        lstblMember.PriceEnd = Convert.ToDecimal(lsReadCounter["priceend"].ToString());
                        lstblMember.PriceStart = Convert.ToDecimal(lsReadCounter["pricestart"].ToString());
                        lstblMember.HotelRating = Convert.ToInt32(lsReadCounter["hotelrating"].ToString());
                        lstblMember.Deposit = Convert.ToDecimal(lsReadCounter["deposit"]);
                        lstblMember.HotelChain = lsReadCounter["hotelchaincode"].ToString();
                        lstblMember.RegionCode = lsReadCounter["regioncode"].ToString();
                        lstblMember.TMemCode = lsReadCounter["tmemcode"].ToString();
                        lstblMember.TBisCode = lsReadCounter["tbiscode"].ToString();
                        lstblMember.FlagGreenLeft = lsReadCounter["flaggreenleft"].ToString();
                        lstblMember.ProvCode = lsReadCounter["provcode"].ToString();
                        lstblMember.TypePriceBaht = lsReadCounter["typepricebaht"].ToString();
                        lstblMember.Location = lsReadCounter["locationcode"].ToString();
                        lstblMember.FlagSend = "1";
                        lstblMember.EMailAccount = lsReadCounter["emailaccount"].ToString();
                        lstblMember.FlagSale = lsReadCounter["flagsale"].ToString();
                        lstblMember.NationCode = lsReadCounter["nationcode"].ToString();
                        try
                        {
                            ldVoidDate = DateTime.Parse(lsReadCounter["startdate"].ToString());
                            lstblMember.StartDate = lsGdb.SelectDateMySQL(ldVoidDate);
                        }
                        catch
                        {
                            lstblMember.StartDate = "2007-01-01";
                        }
                        try
                        {
                            ldVoidDate = DateTime.Parse(lsReadCounter["enddate"].ToString());
                            lstblMember.EndDate = lsGdb.SelectDateMySQL(ldVoidDate);
                        }
                        catch
                        {
                            lstblMember.EndDate = "2007-01-01";
                        }
                        try
                        {
                            ldVoidDate = DateTime.Parse(lsReadCounter["regisdate"].ToString());
                            lstblMember.RegisDate = lsGdb.SelectDateMySQL(ldVoidDate);
                        }
                        catch
                        {
                            lstblMember.RegisDate = "2007-01-01";
                        }
                        lstblMember.SKK9ID = lsReadCounter["skk9id"].ToString();
                        lstblMember.EMailAccount = lsReadCounter["emailaccount"].ToString();
                        lstblMember.CreateMember(lsConnUpdate1);
                        //MessageBox.Show("222 lsCounterid " + lsCounterid, "ee", MessageBoxButtons.OK);
                        //lsPl = lstblMember.SendPriceList(lstblMember.MemID, lsStrSelect, lsStrUpdate, lsDatabase);
                        //MessageBox.Show("lsCounterid " + lsCounterid, "ee", MessageBoxButtons.OK);
                        lstblMember.UpdateFlagSend(lstblMember.MemID, lsCounterid, lsConnSelect2);
                        i++;
                        GrdRec.ActiveSheet.AddRows(0, 1);
                        GrdRec.ActiveSheet.Cells[0, 0].Text = lstblMember.MemID;
                        GrdRec.ActiveSheet.Cells[0, 1].Text = lstblMember.MemNameE1;
                        GrdRec.ActiveSheet.Cells[0, 2].Text = lsPl;
                        //GrdRec.ActiveSheet.Cells[0, 3].Text = lstblMember.MAC;
                        //lsGdb.SeparateTable(Connection.TableIniT.MemberPriceList, "memcode", "refid = '" + lstblMember .MemID + "'", lsConnSelect1, lsConnUpdate1);
                        Pb1.Value = i;
                        Application.DoEvents();
                    }
                    catch (Exception e)
                    {
                        i++;
                        string ls = "ไม่สามารถบันทึกข้อมูล SeparateMember ได้ " + lsSQL;
                        lsGdb.WriteLogError(ls, e, lsSQL, "SeparateMember");
                        MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsReadCounter.Close();
            return i;
        }
        public Boolean SeparateVoucher(Boolean FlagHD, Int32 aFlagSend)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Pb1.Minimum = 0;
            Boolean lbReturn = true;
            Int32 i = 0;
            DateTime ldDate = new DateTime();
            Voucher lstblVou = new Voucher();
            string lsServer = "", lsDatabase = "", lsSQL = "";
            string lsStartDate = "", lsEndDate="", lsCounter = "", lsStrSelect="", lsStrUpdate="";
            lsStartDate = lsGdb.SelectDateMySQL(TxtStartDate.Value);
            lsEndDate = lsGdb.SelectDateMySQL(TxtEndDate.Value);
            lsCounter = lsGdb.SelectCounter("counteridfromcountername", "countername", CboCounter.Text, lsGdb.Gdb);
            lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsDatabaseServerName = lsIni.GetString("thahr30", "databaseservername", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            if (FlagHD)
            {
                lsStrSelect = lsServer;
                lsStrUpdate = TxtIP.Text;
                //lsDatabase = lsDatabaseServerName;
            }
            else
            {
                lsStrSelect = TxtIP.Text;
                lsStrUpdate = "localhost";
            }
            MySqlConnection lsConnSelect = new MySqlConnection("Data Source=" + lsStrSelect + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + "");
            MySqlConnection lsConnUpdate = new MySqlConnection("Data Source=" + lsStrUpdate + ";Database=" + lsDatabaseServerName + ";User ID=" + lsUserName + ";Password=" + lsPassword + "");
            try
            {
                lsConnSelect.Open();
            }
            catch(Exception e)
            {
                lbReturn = false;
                string ls = "ไม่สามารถติดต่อ Counter SeparateMember ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "SeparateMember");
                MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูล " + lsStrSelect + " " + e.Message.ToString(), e.Source.ToString());
            }
            try
            {
                lsConnUpdate.Open();
            }
            catch (Exception e)
            {
                lbReturn = false;
                string ls = "ไม่สามารถติดต่อ Counter SeparateMember ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "SeparateMember");
                MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูล " + lsStrUpdate + " " + e.Message.ToString(), e.Source.ToString());
            }
            if (aFlagSend == 1)
            {

            }
            else
            {
                if (FlagHD)
                {
                    lsSQL = "Select count(*) as cnt From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                        + lsEndDate + "' Order By counter1, vouno";
                }
                else
                {
                    lsSQL = "Select count(*) as cnt From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                        + lsEndDate + "' and counter1 = '" + lsCounter + "' Order By counter1, vouno";
                }
            }
            MySqlCommand lsCommConter1 = new MySqlCommand(lsSQL, lsConnSelect);
            MySqlDataReader lsReadCounter1;
            lsReadCounter1 = lsCommConter1.ExecuteReader();
            if (lsReadCounter1.HasRows)
            {
                while (lsReadCounter1.Read())
                {
                    Pb1.Maximum = Convert.ToInt32(lsReadCounter1["cnt"].ToString());
                }
            }
            lsReadCounter1.Close();
            if (aFlagSend == 1)
            {

            }
            else
            {
                if (FlagHD)
                {
                    lsSQL = "Select * From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                        + lsEndDate + "' Order By counter1, vouno";
                }
                else
                {
                    lsSQL = "Select * From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                        + lsEndDate + "' and counter1 = '" + lsCounter + "' Order By counter1, vouno";
                }
            }
            MySqlCommand lsCommConter = new MySqlCommand(lsSQL, lsConnSelect);
            MySqlDataReader lsReadCounter;
            lsReadCounter = lsCommConter.ExecuteReader();
            if (lsReadCounter.HasRows)
            {
                while (lsReadCounter.Read())
                {
                    try
                    {
                        lstblVou.TableName = "voucher";
                        //lstblVou.HostName = "office";
                        //lsSendVoucher.ConnectDatabase();
                        lstblVou.VouNO = lsReadCounter["vouno"].ToString();
                        lstblVou.VouDate = Convert.ToDateTime(lsReadCounter["voudate"].ToString());
                        lstblVou.VisitT = Convert.ToInt32(lsReadCounter["visitt"].ToString());
                        lstblVou.GuestFirstName = lsReadCounter["guestfirstname"].ToString();
                        lstblVou.GuestLastName = lsReadCounter["guestlastname"].ToString();
                        lstblVou.ShiftCode = lsReadCounter["shiftcode"].ToString();
                        lstblVou.ResRooms = Convert.ToInt32(lsReadCounter["resrooms"].ToString());
                        lstblVou.ProvCode = lsReadCounter["provcode"].ToString();
                        lstblVou.HotelCode = lsReadCounter["hotelcode"].ToString();
                        lstblVou.RoomCode = lsReadCounter["roomcode"].ToString();
                        lstblVou.ResTime = lsReadCounter["restime"].ToString();
                        if (lsReadCounter.GetValue(17).ToString() != "")
                        {
                            lstblVou.CheckInTime = Convert.ToDateTime(lsReadCounter["checkindate"].ToString());
                        }
                        else
                        {
                            lstblVou.CheckInTime = ldDate;
                        }
                        if (lsReadCounter.GetValue(18).ToString() != "")
                        {
                            lstblVou.CheckOutTime = Convert.ToDateTime(lsReadCounter["checkoutdate"].ToString());
                        }
                        else
                        {
                            lstblVou.CheckOutTime = ldDate;
                        }
                        lstblVou.PersoninTrip = Convert.ToInt32(lsReadCounter["personintrip"].ToString());
                        lstblVou.DepositAMT = Convert.ToDecimal(lsReadCounter["depositamt"].ToString());
                        lstblVou.RoomRate = Convert.ToDecimal(lsReadCounter["roomrate"].ToString());
                        lstblVou.RoomRate1 = Convert.ToDecimal(lsReadCounter["roomrate1"].ToString());
                        lstblVou.StaffCode = lsReadCounter["staffcode"].ToString();
                        lstblVou.StatusCode = lsReadCounter["statuscode"].ToString();
                        lstblVou.ConfirmPerson = lsReadCounter["confirmperson"].ToString();
                        lstblVou.Counter1 = lsReadCounter["counter1"].ToString();
                        lstblVou.CouNO = lsReadCounter["couno"].ToString();
                        lstblVou.NationCode = lsReadCounter["nationcode"].ToString();
                        lstblVou.Remark = lsReadCounter["remark"].ToString();
                        lstblVou.Flag = lsReadCounter["flag"].ToString();
                        lstblVou.RoomNO = lsReadCounter["roomno"].ToString();
                        lstblVou.MAC = lsReadCounter["mac"].ToString();
                        lstblVou.MemPlCode = lsReadCounter["memplcode"].ToString();
                        lstblVou.PriceEnd = Convert.ToDecimal(lsReadCounter["priceend"]);
                        lstblVou.Taxi = lsReadCounter["taxi"].ToString();
                        lstblVou.Pay_Type = lsReadCounter["pay_type"].ToString();
                        lstblVou.CreaditCardID = lsReadCounter["cardid"].ToString();
                        if (lstblVou.Taxi == "")
                        {
                            lstblVou.Taxi = "false";
                        }
                        lstblVou.Breakfast = lsReadCounter["breakfast"].ToString();
                        if (lstblVou.Breakfast == "")
                        {
                            lstblVou.Breakfast = "false";
                        }
                        lstblVou.CreateVoucher(lsConnUpdate);
                        lstblVou.UpdateFlagSend(lsConnUpdate);
                        i++;
                        GrdRec.ActiveSheet.AddRows(0, 1);
                        GrdRec.ActiveSheet.Cells[0, 0].Text = lstblVou.VouNO;
                        GrdRec.ActiveSheet.Cells[0, 1].Text = lstblVou.GuestFirstName + " " + lstblVou.GuestLastName;
                        GrdRec.ActiveSheet.Cells[0, 2].Text = lstblVou.VouDate.ToShortDateString();
                        GrdRec.ActiveSheet.Cells[0, 3].Text = lstblVou.MAC;
                        Pb1.Value = i;
                        if (i > 15)
                        {
                            GrdRec.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
                        }
                    }
                    catch (Exception e)
                    {
                        lbReturn = false;
                        i++;
                        string ls = "ไม่สามารถบันทึกข้อมูล SeparateVoucher ได้ " + lsSQL;
                        lsGdb.WriteLogError(ls, e, lsSQL, "SeparateVoucher");
                        MessageBox.Show("" + e.Message.ToString(), "" + e.Source.ToString(), MessageBoxButtons.OK);
                    }
                    Application.DoEvents();
                }
            }
            lsReadCounter.Close();
            lsConnSelect.Close();
            lsConnUpdate.Close();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            return lbReturn;
        }
        private void BtnRec_Click(object sender, EventArgs e)
        {
            Pb1.Visible = true;
            BtnRec.Enabled = false;
            string lsVou = "", lsMem="", lsSendDate="", lsFlagSendEmailSu="1";
            string lsTO = lsIni.GetString("thahr30", "emailto", "info@thaihotels.org");
            string lsSendrptdailypayinrecordpaymentEmailTO = lsIni.GetString("thahr30", "sendrptdailypayinrecordpaymentemailto", "info@thaihotels.org");
            Lb1.Items.Clear();
            if (ChkSendReportSu.Checked)
            {
                Lb1.Items.Add("เริ่มส่ง E-mail แจ้งยอด Voucher วันที่" + TxtStartDate.Value.ToString());
                Application.DoEvents();
                string lsSMTP = lsIni.GetString("thahr30", "smtp", "mail.asianet.co.th");
                ShopSendEmail frmSendEmail = new ShopSendEmail();
                frmSendEmail.SendDate = TxtStartDate.Value;
                frmSendEmail.SendEMail(lsSMTP, false, lsTO, "rptdailypayinrecordsuemail");
                frmSendEmail.SendEMail(lsSMTP, false, lsSendrptdailypayinrecordpaymentEmailTO, "rptdailypayinrecordpayment");
                Lb1.Items.Add("ส่ง E-mail เรียบร้อย");
                lsFlagSendEmailSu = "2";
                Application.DoEvents();
            }
            lsSendDate = lsGdb .SelectDateMySQL(TxtStartDate.Value);
            Lb1.Items.Add("เริ่มส่งข้อมูล Voucher");
            Application.DoEvents();
            if (SeparateVoucher(ChkHD.Checked, Convert.ToInt32(CboTSend .SelectedValue.ToString()) ) == true )
            {
                lsVou = "ส่งข้อมูล Voucher เรียบร้อย";
                //MessageBox.Show("ส่งข้อมูลเรียบร้อย", "ส่งข้อมูล", MessageBoxButtons.OK);
            }
            Lb1.Items.Add("ส่งข้อมูล Voucher เรียบร้อย ");
            Application.DoEvents();
            Int32 liMember = 0;
            string lsServer = "", lsDatabase = "", lsStrSelect = "", lsStrUpdate = "";
            lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsDatabaseServerName = lsIni.GetString("thahr30", "databaseservername", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            if (ChkHD.Checked)
            {
                lsStrSelect = TxtIP.Text;
                lsStrUpdate = lsServer;
            }
            else
            {
                lsStrSelect = lsServer;
                lsStrUpdate = TxtIP.Text;
            }
            lsConnSelect1.ConnectionString = "Data Source=" + lsStrSelect + ";Database=" + lsDatabaseServerName + ";User ID=" + lsUserName + ";Password=" + lsPassword + "";
            lsConnSelect2.ConnectionString = "Data Source=" + lsStrSelect + ";Database=" + lsDatabaseServerName + ";User ID=" + lsUserName + ";Password=" + lsPassword + "";
            lsConnUpdate1.ConnectionString = "Data Source=" + lsStrUpdate + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + "";
            try
            {
                lsConnSelect1.Open();
                Lb1.Items.Add("เปิด Connection " + lsConnSelect1.Database);
                Application.DoEvents();
                lsConnSelect2.Open();
                Lb1.Items.Add("เปิด Connection " + lsConnSelect2.Database);
                Application.DoEvents();
            }
            catch (Exception e1)
            {
                string ls = "ไม่สามารถติดต่อ Counter SeparateMember ได้ ";
                lsGdb.WriteLogError(ls, e1, "", "SeparateMember");
                MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูล " + lsStrSelect + " " + e1.Message.ToString(), e1.Source.ToString());
                 
            }
            try
            {
                lsConnUpdate1.Open();
                Lb1.Items.Add("เปิด Connection " + lsConnUpdate1.Database);
                Application.DoEvents();
            }
            catch (Exception e2)
            {
                string ls = "ไม่สามารถติดต่อ Counter SeparateMember ได้ ";
                lsGdb.WriteLogError(ls, e2, "", "SeparateMember");
                MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูล " + lsStrUpdate + " " + e2.Message.ToString(), e2.Source.ToString());
            }
            Lb1.Items.Add("เริ่มรับข้อมูล Member ");
            Application.DoEvents();
            liMember = SeparateMember(ChkHD.Checked);
            lsMem = "รับข้อมูล Member " + liMember.ToString() + "เรียบร้อย";
            Lb1.Items.Add("รับข้อมูล Member เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.Nationality, "nationcode", "",Pb1 , lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("nationality", "nationcode", "nationname");
            Lb1.Items.Add("ปรับปรุงข้อมูล Nationality เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.TypeRoom, "plcode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("typeroom", "plcode", "plnamee");
            Lb1.Items.Add("ปรับปรุงข้อมูล ราคาห้องพัก เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.TypeMem, "tmemcode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("typemem", "tmemcode", "tmemname");
            Lb1.Items.Add("ปรับปรุงข้อมูล ประเภทสมาชิก เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.TypeBis, "tbiscode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("typebis", "tbiscode", "tbisname");
            Lb1.Items.Add("ปรับปรุงข้อมูล ประเภทวิสาหกิจ เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.Status, "statuscode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("status", "statuscode", "statusname");
            Lb1.Items.Add("ปรับปรุงข้อมูล สถานะ เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.Staff, "staffcode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("staff", "staffcode", "staffname");
            Lb1.Items.Add("ปรับปรุงข้อมูล พนักงาน เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.Shift, "shiftcode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("shift", "shiftcode", "shiftname");
            Lb1.Items.Add("ปรับปรุงข้อมูล Shift เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.Salutation, "salcode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("salutation", "salcode", "salnamee");
            Lb1.Items.Add("ปรับปรุงข้อมูล Sale เรียบร้อย");
            Application.DoEvents();
            lsGdb.SeparateTable(Connection.TableIniT.Region, "regioncode", "", Pb1, lsConnSelect1, lsConnUpdate1);
            //SeparateInitial("region", "regioncode", "regionname");
            Lb1.Items.Add("ปรับปรุงข้อมูล Region เรียบร้อย");
            if (ChkPriceList.Checked == true)
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                Cursor.Show();
                Lb1.Items.Add("กำลังส่งข้อมูล PriceList ");
                Application.DoEvents();
                lsGdb.SeparateTable(Connection.TableIniT.MemberPriceList, "plid", "", Pb1, lsConnUpdate1, lsConnSelect1);
                Lb1.Items.Add("ส่งข้อมูล PriceList เรียบร้อย");
                Cursor.Current = System.Windows.Forms.Cursors.Default;
                Cursor.Show();
            }
            Application.DoEvents();
            lsConnSelect1.Close();
            Lb1.Items.Add("ปิด Connection " + lsConnSelect1.Database);
            lsConnSelect2.Close();
            Lb1.Items.Add("ปิด Connection " + lsConnSelect2.Database);
            lsConnUpdate1.Close();
            Lb1.Items.Add("ปิด Connection " + lsConnUpdate1.Database);
            lsGdb.UpdateSendVoucher(lsCounterIP, lsSendDate, lsFlagSendEmailSu);
            Lb1.Items.Add("ส่งข้อมูล เรียบร้อย");
            Pb1.Visible = false;
            BtnRec.Enabled = true;
            MessageBox.Show("ส่งข้อมูล เรียบร้อย", "ส่งข้อมูล");
            this.Close();
        }
        private void SelectCondition(string aFlag)
        {
            switch (aFlag)
            {
                case "13":
                    {
                        label5.Visible = false;
                        label1.Visible = false;
                        TxtStartDate.Visible = false;
                        TxtEndDate.Visible = false;
                        break;
                    }
                case "14":
                    {
                        label5.Visible = true ;
                        label1.Visible = true;
                        TxtStartDate.Visible = true ;
                        TxtEndDate.Visible = true;
                        break;
                    }
            }
        }
        private void ShopAdjust_Load(object sender, EventArgs e)
        {
            string lsSendDate = "", lsFlagSendEmailSu="";
            lbPageLoad = true;
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsGdb.SelectCbo(CboTSend, "cbotsend", Connection.TableIniT.CboTSend);
            lsGdb.SelectCbo(CboCounter, "ip", Connection.TableIniT.Counter); //ตั้งแต่วันที่ - ถึงวันที่
            CboTSend.Text = "ตั้งแต่วันที่ - ถึงวันที่";
            lsCountMain = lsIni.GetString("thahr30", "countermain", "0");
            lsCounterIP = lsIni.GetString("thahr30", "counter", "000");
            lsCounterIP = lsGdb.SelectCounter("ipfromcounterid", "counterid", lsCounterIP, lsGdb.Gdb);
            PaintGrdRec();
            lsIniT.CreateTblInitial(lsGdb.Gdb);
            //lsIniT.CreateTblMember();
            //lsIniT.CreateTblNationality();
            //lsIniT.CreateTblCounter();
            //lsIniT.CreateTblShift();
            //lsIniT.CreateTblTypeMem();
            if (FlagHD)
            {
                ChkHD.Checked = true;
                TxtIP.Text = lsIni.GetString("thahr30", "ipheadoffice", "127.0.0.1");
                BtnRec.Enabled = true;
                BtnRec.Text = "ส่งข้อมูล";
            }
            else
            {
                ChkHD.Checked = false;
                BtnRec.Enabled = false;
            }
            CheckSendEmailSu(TxtStartDate.Value);
            ChkHD.Visible = false;
            ChkCounter.Visible = false;
            lbPageLoad = false;
            Pb1.Visible = false;
        }

        private void CheckSendEmailSu(DateTime aSendDate)
        {
            string lsFlagSendEmailSu = "";
            string lsSendDate = lsGdb.SelectDateMySQL(aSendDate);
            MySqlCommand lsComm = new MySqlCommand("Select flagsendemailsu From countersend Where senddate = '" + lsSendDate + "'", lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsFlagSendEmailSu = lsRead["flagsendemailsu"].ToString();
                }
            }
            lsRead.Close();
            if (lsFlagSendEmailSu == "2")
            {
                ChkSendReportSu.Checked = false;
            }
            else
            {
                ChkSendReportSu.Checked = true;
            }
        }
        private void CboCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                TxtIP.Text = lsGdb.SelectCounter("ipfromcountername", "countername", CboCounter.Text, lsGdb.Gdb);
                if (TxtIP.Text == lsCounterIP)
                {
                    MessageBox.Show("ไม่สามารถรับส่งได้เพราะเป็น Counter เดียวกัน", "", MessageBoxButtons.OK);
                    BtnRec.Enabled = false;
                }
                else
                {
                    BtnRec.Enabled = true;
                }
            }
        }
        private void CboTSend_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCondition(CboTSend.SelectedValue.ToString());
        }

        private void TxtStartDate_ValueChanged(object sender, EventArgs e)
        {
            TxtEndDate.Value = TxtStartDate.Value;
            CheckSendEmailSu(TxtStartDate.Value);
        }

        private void ChkHD_CheckedChanged(object sender, EventArgs e)
        {
            VisibleCounter();
        }

        private void VisibleCounter()
        {
            if (ChkHD.Checked)
            {
                CboCounter.Visible = false;
                label6.Visible = false;
            }
            else
            {
                CboCounter.Visible = true;
                label6.Visible = true;
            }
        }

        private void ChkCounter_CheckedChanged(object sender, EventArgs e)
        {
            VisibleCounter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}