using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using Microsoft.VisualBasic;

namespace ThaHr30
{
    public partial class VoucherView : Form
    {
        public string lsStartDate = "", lsEndDate = "", lsFlag = "";
        IniFile lsIni = new IniFile("thahr30.ini");
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        public string lsServer, lsDatabase, lsCounter;
        private string lsSQLView = "",lsStaffPrivileges="", lsStaffID="";
        private int liColVouNo = 0, liColGuestName = 1, liColVouDate = 2, liColHotel = 3, liColCounter = 4, liColMac = 5, liColRoom = 6;
        private int liColConfirm = 10, liColRoomRate = 7, liColRoomRate1 = 8, liColStaffName=9, liColStatus=11;
        Boolean lbPageLoad = false;
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
        public string StaffID
        {
            get
            {
                return lsStaffID;
            }
            set
            {
                lsStaffID = value;
            }
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Reset();
            GrdView.Visible = false;
            GrdView.ActiveSheet.RowCount = 1;
            GrdView.ActiveSheet.ColumnCount = 12;
            GrdView.Height = this.Height - 150;
            GrdView.Width = this.Width - 30;
            GrdView.Top = 85;
            GrdView.Left = 12;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.ActiveSheet.SetColumnWidth(liColVouNo, 82);
            GrdView.ActiveSheet.SetColumnWidth(liColGuestName, 180);
            GrdView.ActiveSheet.SetColumnWidth(liColVouDate, 70);
            GrdView.ActiveSheet.SetColumnWidth(liColHotel, 285);
            GrdView.ActiveSheet.SetColumnWidth(liColCounter, 65);
            GrdView.ActiveSheet.SetColumnWidth(liColMac, 45);
            GrdView.ActiveSheet.SetColumnWidth(liColRoom, 45);
            GrdView.ActiveSheet.SetColumnWidth(liColConfirm, 48);
            GrdView.ActiveSheet.SetColumnWidth(liColRoomRate, 70);
            GrdView.ActiveSheet.SetColumnWidth(liColRoomRate1, 74);
            GrdView.ActiveSheet.SetColumnWidth(liColStaffName, 90);
            GrdView.ActiveSheet.SetColumnWidth(liColStatus, 60);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType() ;
            col = GrdView.ActiveSheet.Columns[liColVouNo, liColStatus];
            col.CellType = cell;
            col = GrdView.ActiveSheet.Columns[liColCounter, liColRoom];
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.NumberCellType cell8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            cell8.Separator = ",";
            col = GrdView.ActiveSheet.Columns[liColRoomRate, liColRoomRate1];
            col.CellType = cell8;
            FarPoint.Win.Spread.Column col7;
            FarPoint.Win.Spread.CellType.ButtonCellType cell7 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            col7 = GrdView.ActiveSheet.Columns[liColConfirm];
            //col.Locked = true;
            //col7.Label = "Confirm";
            col7.CellType = cell7;
            //GrdView .ActiveSheet
            FarPoint.Win.Spread.HideRowFilter hideRowFilter = new FarPoint.Win.Spread.HideRowFilter(GrdView.ActiveSheet);
            GrdView.ActiveSheet.Columns[liColVouNo, liColGuestName].AllowAutoFilter = true;
            GrdView.ActiveSheet.Columns[liColHotel, liColCounter].AllowAutoFilter = true;
            GrdView.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode ; 
            GrdView.ActiveSheet.Columns[0, 6].Locked = true;
            GrdView.ActiveSheet.SetColumnLabel(0, liColVouNo, "Vou NO");
            GrdView.ActiveSheet.SetColumnLabel(0, liColGuestName, "Guest Name");
            GrdView.ActiveSheet.SetColumnLabel(0, liColVouDate, "Vou Date");
            GrdView.ActiveSheet.SetColumnLabel(0, liColHotel, "Hotel");
            GrdView.ActiveSheet.SetColumnLabel(0, liColCounter, "Counter");
            GrdView.ActiveSheet.SetColumnLabel(0, liColMac, "MAC");
            GrdView.ActiveSheet.SetColumnLabel(0, liColRoom, "ROOM");
            GrdView.ActiveSheet.SetColumnLabel(0, liColConfirm, "Confirm");
            GrdView.ActiveSheet.SetColumnLabel(0, liColRoomRate, "RoomRate");
            GrdView.ActiveSheet.SetColumnLabel(0, liColRoomRate1, "RoomRate++");
            GrdView.ActiveSheet.SetColumnLabel(0, liColStaffName, "Staff Name");
            GrdView.ActiveSheet.SetColumnLabel(0, liColStatus, "Status");
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.AllowColumnMove = true;
            GrdView.Visible = true;
        }
        private void SelectVoucher(string aStartDate, string aEndDate, string aFlag)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            PaintGrdView();
            //if (lbPageLoad == false)
            //{
            string lsSQL = "", lsStartDate = "", lsEndDate = "", lsMemNameE="";
            string lsFlag = "", lsWhereCondition = "", lsStaffName="", lsStatusName="", lsPrefix="";
            string lsCounterID = lsIniT.SelectInitial(lsIniT.TblCounter, CboCounter.Text, Initial.WhereSelect.aNametoCode);
            Int32 i = 0;
            double ldoRoomRate = 0, ldoRoomRate1 = 0;
            lsFlag = aFlag;
            lsStartDate = aStartDate;
            lsEndDate = aEndDate;
            //MySqlConnection Conn = new MySqlConnection("Data Source="+lsServer +";Database="+lsDatabase+";User ID=root;Password=Ekartc2c5");
            //Conn.Open();
            if (TxtVouNo.Text != "")
            {
                lsWhereCondition = "Where vouno = '" + TxtVouNo .Text + "'";
            }
            else
            {
                lsWhereCondition = ConditionWhereVoucher(lsStartDate, lsEndDate, lsFlag, lsCounterID);
            }
            lsSQL = "Select count(*) as cnt From voucher " + lsWhereCondition ;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            while (lsRead.Read())
            {
                i = Convert.ToInt32(lsRead.GetValue(0).ToString());
            }
            lsRead.Close();
            GrdView.ActiveSheet.RowCount = 0;
            GrdView.ActiveSheet.RowCount = i + 1;
            //lsSQL = "Select vouno, guestfirstname, guestlastname, voudate, " 
            //    + "counter1, mac, memnamee1, roomno, "
            //    + "confirmremark, roomrate, roomrate1, checkindate, visitt, checkoutdate "
            //    + "From voucher v, member m "
            //    + "Where v.flag <> '3' and voudate >= '" + lsStartDate + "' and voudate <= '"
            //    + lsEndDate + "' " + lsWhereCounter + " and v.hotelcode = m.memid Order By vouno";

            lsSQL = "Select vouno, guestfirstname, guestlastname, voudate, "
                + "counter1, mac, roomno, hotelcode, "
                + "confirmremark, roomrate, roomrate1, checkindate, visitt, checkoutdate, roomrate, roomrate1, staffcode, statuscode, prefix "
                + "From voucher v "
                + lsWhereCondition + " Order By vouno";
            lsComm.CommandText = lsSQL;
            DateTime ldVouDate = new DateTime();
            DateTime ldCheckInDate = new DateTime();
            DateTime ldCheckOutDate = new DateTime();
            Int32 liVisitT = 0, li = 0;
            lsRead = lsComm.ExecuteReader();
            i = 0;
            Pb1.Minimum = 0;
            Pb1.Maximum = GrdView.ActiveSheet.RowCount;
            Pb1.Visible = true;
            SL1.Visible = true;
            while (lsRead.Read())
            {
                //i++;
                try
                {
                    lsSQL = lsRead["vouno"].ToString();
                    if (lsSQL == "50003119673")
                    {
                        lsSQL = lsRead["prefix"].ToString() + " " + lsRead["guestfirstname"].ToString();
                        //MessageBox.Show("aaaa", "aaaa", MessageBoxButtons.OK);
                    }
                    ldVouDate = Convert.ToDateTime(lsRead["voudate"]);
                    ldCheckInDate = Convert.ToDateTime(lsRead["checkindate"]);
                    ldCheckOutDate = Convert.ToDateTime(lsRead["checkoutdate"]);
                    liVisitT = Convert.ToInt32(lsRead["visitt"]);
                    li = DateTime.Compare(ldCheckOutDate, ldCheckInDate);
                    lsSQL = lsRead["guestfirstname"].ToString();
                    lsMemNameE = lsIniT.SelectInitial(lsIniT.TblMember, lsRead["hotelcode"].ToString(), Initial.WhereSelect.aCodetoName);
                    lsStaffName = lsIniT.SelectInitial(lsIniT.TblStaff, lsRead["staffcode"].ToString(), Initial.WhereSelect.aCodetoName);
                    lsStatusName = lsIniT.SelectInitial(lsIniT.TblStatus, lsRead["statuscode"].ToString(), Initial.WhereSelect.aCodetoName);
                    lsPrefix = lsIniT.SelectInitial(lsIniT.TblPrefix, lsRead["prefix"].ToString(), Initial.WhereSelect.aCodetoName);
                    ldoRoomRate = Convert.ToDouble(lsRead["roomrate"]);
                    ldoRoomRate1 = Convert.ToDouble(lsRead["roomrate1"]);
                    GrdView.ActiveSheet.SetText(i, liColVouNo, lsRead["vouno"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColGuestName, lsPrefix + " " + lsRead["guestlastname"].ToString() + " " + " " + lsRead["guestfirstname"].ToString());
                    //GrdView.Sheets[0].Cells[i, liColGuestName].Text = lsPrefix + " " + lsRead["guestlastname"].ToString() + " " + lsSQL;
                    GrdView.ActiveSheet.SetText(i, liColVouDate, ldVouDate.ToShortDateString());
                    lsSQL = lsIniT.SelectInitial(lsIniT.TblCounter, lsRead["counter1"].ToString(), Initial.WhereSelect.aCodetoName);
                    GrdView.ActiveSheet.SetText(i, liColCounter, lsSQL);
                    GrdView.ActiveSheet.SetText(i, liColHotel, lsMemNameE);
                    lsSQL = lsRead["mac"].ToString();
                    if (lsSQL.Length == 9)
                    {
                        lsSQL = lsRead["mac"].ToString().Substring(6, 3);
                    }
                    else
                    {
                        lsSQL = lsRead["mac"].ToString();
                    }
                    GrdView.ActiveSheet.SetText(i, liColMac, lsSQL);
                    lsSQL = lsRead["roomno"].ToString();
                    GrdView.ActiveSheet.SetText(i, liColRoom, lsSQL);
                    GrdView.ActiveSheet.SetText(i, liColRoomRate, ldoRoomRate.ToString());
                    GrdView.ActiveSheet.SetText(i, liColRoomRate1, ldoRoomRate1.ToString());
                    GrdView.ActiveSheet.SetText(i, liColStaffName, lsStaffName);
                    GrdView.ActiveSheet.SetText(i, liColStatus, lsStatusName);
                    lsSQL = lsRead.GetValue(0).ToString();

                    if (i == 12)
                    {
                        lsSQL = lsRead["roomno"].ToString();
                    }
                    if (lsRead["roomno"].ToString() == "-") // roomno
                    {
                        GrdView.ActiveSheet.Cells[i, liColVouNo].ForeColor = Color.Red;
                        GrdView.ActiveSheet.Cells[i, liColVouNo].Font = new Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Italic | FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.ActiveSheet.SetNote(i, liColVouNo, "RoomNO ไม่มีค่า");
                    }
                    if (lsRead.GetValue(8).ToString() == "-") // confirmremark
                    {
                        GrdView.ActiveSheet.Cells[i, liColRoom].ForeColor = Color.Red;
                        GrdView.ActiveSheet.Cells[i, liColRoom].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.ActiveSheet.SetNote(i, liColRoom, "Confirm ไม่มีค่า");
                    }
                    if (ldoRoomRate > ldoRoomRate1) // roomrate
                    {
                        GrdView.ActiveSheet.Cells[i, liColGuestName].ForeColor = Color.Magenta;
                        GrdView.ActiveSheet.Cells[i, liColGuestName].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.ActiveSheet.SetNote(i, liColGuestName, "Room Rate มากกว่า Room Rate++");
                    }
                    else if (ldoRoomRate < ldoRoomRate1)
                    {
                        GrdView.ActiveSheet.Cells[i, liColGuestName].ForeColor = Color.MediumSeaGreen;
                        GrdView.ActiveSheet.Cells[i, liColGuestName].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.ActiveSheet.SetNote(i, liColGuestName, "Room Rate น้อยกว่า Room Rate++");
                    }
                    if (ldVouDate != ldCheckInDate)
                    {
                        GrdView.ActiveSheet.Cells[i, liColGuestName].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.ActiveSheet.SetNote(i, liColGuestName, "วันที่ Voucher Date ไม่ต้องกับ Check in Date");
                    }
                    if (li != liVisitT)
                    {
                        GrdView.ActiveSheet.Cells[i, liColHotel].ForeColor = Color.Tomato;
                        GrdView.ActiveSheet.Cells[i, liColHotel].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        GrdView.CellNoteIndicatorVisible = true;
                        GrdView.ActiveSheet.SetNote(i, liColHotel, "จำนวนวันของ Check in Date กับ Check out Date ไม่เท่ากับ จำนวนวันที่เข้าพัก");
                    }
                    if ((i % 2) != 0)
                    {
                        GrdView.ActiveSheet.Rows[i].BackColor = Color.LightGoldenrodYellow;
                    }
                    //if ((i%100)==0)
                    //{
                    //    //Application.DoEvents();
                    //}
                    i++;
                    //GrdView.ActiveSheet.SetActiveCell(i, 1);
                    Pb1.Value = i;
                    SL1.Text = i.ToString() + " / " + (GrdView.ActiveSheet.RowCount - 1);
                }
                catch (Exception e)
                {
                    i++;
                    MessageBox.Show(lsRead["vouno"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                }
                //Application.DoEvents();
            }
            lsRead.Close();
            if (i > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            Pb1.Visible = false;
            SL1.Visible = false;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            //}
        }

        private string ConditionWhereVoucher(string aStartDate, string aEndDate, string aFlag, string aCounter)
        {
            string lsSQL = "", lsWhereCounter="";
            
            if (aCounter != "")
            {
                if (aCounter == "000")
                {
                    lsWhereCounter = " ";
                }
                else
                {
                    lsWhereCounter = " and counter1 = '" + aCounter + "'";
                }
            }
            switch (aFlag)
            {
                case "1":
                    {
                        lsSQL = " Where flagconfirm <> '2' and voudate >= '" + aStartDate + "' and voudate <= '"
                            + aEndDate + "'" + lsWhereCounter;
                        break;
                    }
                case "12":
                    {
                        lsSQL = " Where flagconfirm = '2' and voudate >= '" + aStartDate + "' and voudate <= '"
                            +aEndDate + "'" + lsWhereCounter;
                        break;
                    }
                case "9":
                    {
                        lsSQL = " Where flag = '3' and voudate >= '" + aStartDate + "' and voudate <= '"
                            + aEndDate + "'" + lsWhereCounter;
                        break;
                    }
                case "8":
                    {
                        lsSQL = " Where flag in('1','2') and voudate >= '" + aStartDate + "' and voudate <= '"
                            + aEndDate + "'" + lsWhereCounter;
                        break;
                    }
                case "15":
                    {
                        lsSQL = " Where flag = '4' and voudate >= '" + aStartDate + "' and voudate <= '"
                            + aEndDate + "'" + lsWhereCounter;
                        break;
                    }
                default:
                    {
                        lsSQL = " Where voudate >= '" + aStartDate + "' and voudate <= '"
                            + aEndDate + "'" + lsWhereCounter;
                        break;
                    }
            }
            return lsSQL;
        }
        public VoucherView()
        {
            InitializeComponent();
            lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            lsCounter = lsIni.GetString("thahr30", "counter", "001");
        }
        private void VoucherView_Load(object sender, EventArgs e)
        {
            lbPageLoad = true;
            //PaintGrdView();
            //GbCondition.Height = this.Height - 150;
            GbCondition.Width = this.Width - 30;
            Pb1.Visible = false;
            SL1.Visible = false;
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsGdb.SelectCbo(CboVoucherView.ComboBox, "cbovoucherview", Connection.TableIniT.CboVoucherView);
            lsGdb.SelectCbo(CboCounter.ComboBox, "report", Connection.TableIniT.Counter);
            CboVoucherView.Text = "ดูตาม Voucher สถานะปกติ(ทั้งหมด)";
            InsertCondition();
            lsIniT.CreateTblInitial(lsGdb.Gdb);
            CboCounter.Text = lsIniT.SelectInitial(lsIniT.TblCounter, lsCounter, Initial.WhereSelect.aCodetoName);
            SelectVoucher(lsStartDate , lsEndDate , lsFlag);
            CboCounter.Width = 480;
            CboVoucherView.ComboBox.Width = 275;
            Tb.Items ["cbocounter"].Width =480;
            //SetPrivileges(lsStaffID);
            lbPageLoad = false;
        }
        private void SetPrivileges(string aStaffID)
        {
            string lsView = "", lsAdd = "", lsEdit = "", lsDele = "";
            lsStaffPrivileges = lsGdb.SelectStaffPrivileges(aStaffID);
            lsView = lsStaffPrivileges.Substring(0, 1);
            lsAdd = lsStaffPrivileges.Substring(1, 1);
            lsEdit = lsStaffPrivileges.Substring(2, 1);
            lsDele = lsStaffPrivileges.Substring(3, 1);
            if (lsView == "1")
            {
                NewVoucher.Enabled = true;
            }
            else
            {
                NewVoucher.Enabled = false;
            }
        }
        public void SetStartDate(DateTime aDate)
        {
            TxtStartDate.Value = aDate;
        }
        public void SetEndDate(DateTime aDate)
        {
            TxtEndDate.Value = aDate;
        }
        public void SetFlag()
        {
            CboVoucherView.Text = "ดูตาม Voucher สถานะปกติ(ทั้งหมด)";
        }
        private void InsertCondition()
        {
            lsFlag = CboVoucherView.ComboBox.SelectedValue.ToString();
            //lsStartDate = lsGdb.SelectDateMySQL(TxtStartDate.Value);
            //lsEndDate = lsGdb.SelectDateMySQL(TxtEndDate.Value);
            //lsStartDate = TxtStartDate.Value.Year + "-" + TxtStartDate.Value.Month.ToString("00") + "-" + TxtStartDate.Value.Day.ToString("00");
            //lsEndDate = TxtEndDate.Value.Year + "-" + TxtEndDate.Value.Month.ToString("00") + "-" + TxtEndDate.Value.Day.ToString("00");
            lsStartDate = lsGdb.SelectDateMySQL(TxtStartDate.Value);
            lsEndDate = lsGdb.SelectDateMySQL(TxtEndDate.Value);
        }

        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            VoucherAdd frm = new VoucherAdd();
            frm.lsVouNO = GrdView.ActiveSheet.GetText(e.Row, 0);
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            InsertCondition();
            SelectVoucher(lsStartDate ,lsEndDate , lsFlag );
        }
        private void VoucherView_KeyUp(object sender, KeyEventArgs e)
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
        private void GrdView_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            VoucherConfirm frm = new VoucherConfirm();
            frm.lsVouNO = GrdView.ActiveSheet.GetText(e.Row, 0);
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            InsertCondition();
            SelectVoucher(lsStartDate , lsEndDate , lsFlag );
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            
        }
        private void CboVoucherView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                InsertCondition();
                SelectVoucher(lsStartDate, lsEndDate, lsFlag);
            }
            //lbPageLoad = false;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            GrdView.PrintSheet(0);
        }

        private void NewVoucher_Click(object sender, EventArgs e)
        {
            VoucherAdd lsFrm = new VoucherAdd();
            lsFrm.Connnection = lsGdb.Gdb;
            lsFrm.ShowDialog(this);
            InsertCondition();
            SelectVoucher(lsStartDate, lsEndDate, lsFlag);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void search_Click(object sender, EventArgs e)
        {
            InsertCondition();
            SelectVoucher(lsStartDate, lsEndDate, lsFlag);
        }

        private void TxtVouNo_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        InsertCondition();
                        SelectVoucher(lsStartDate, lsEndDate, lsFlag);
                        break;
                    }
            }            
        }

        private void GrdView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void CboCounter_Click(object sender, EventArgs e)
        {

        }
    }
}