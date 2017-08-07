using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace ThaHr30
{
    public partial class MemberSKK9 : Form
    {
        private Int32 liColMemID = 1, liColMemNameE1 = 2, liColNationality = 3, liColMemOwner = 4, liColTBis = 5, liColAddress = 6;
        private Int32 liColStartDate = 7, liColEndDate = 8, liColTMem = 9, liCelNote = 10, liColAddressDoc = 11, liColCheck = 0, liColSKK9 = 12;
        private Int32 liColLine1 = 14, liColSubDistrictName = 15, liColDistrictName = 16, liColProvName = 17, liColPostCode = 18;
        private Int32 liColContactSkk9=13, liColEmail=19, liColWebSite=20, liColTele=21, liColFax=22, liColFlagResign=23;
        private Int32 liColFlagRestaurant = 24, liColFlagMeeting = 25, liColFlagSpa = 26, liColFlagFitness = 27, liColBusiness = 28;
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile();
        Member lstblMember = new Member();
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
        public MemberSKK9()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void PaintGrdMain()
        {
            //GrdView.Visible = false;
            //GrdView.Reset();
            GrdView.ActiveSheet.RowCount = 0;
            GrdView.Left = 9;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 30;
            GrdView.Sheets[0].SheetName = "Member";
            GrdView.Top = 35;
            GrdView.Left = 12;
            GrdView.Sheets[0].ColumnCount = 29;
            GrdView.Sheets[0].RowCount = 500;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[0].ColumnHeader.RowCount = 2;
            GrdView.Sheets[0].SetColumnWidth(liColMemID, 50);
            GrdView.Sheets[0].SetColumnWidth(liColMemNameE1, 260);
            GrdView.Sheets[0].SetColumnWidth(liColNationality, 60);
            GrdView.Sheets[0].SetColumnWidth(liColEndDate, 70);
            GrdView.Sheets[0].SetColumnWidth(liColTMem, 70);
            GrdView.Sheets[0].SetColumnWidth(liColMemOwner, 60);
            GrdView.Sheets[0].SetColumnWidth(liColTBis, 80);
            GrdView.Sheets[0].SetColumnWidth(liColAddress, 65);
            GrdView.Sheets[0].SetColumnWidth(liColStartDate, 90);
            GrdView.Sheets[0].SetColumnWidth(liColEndDate, 90);
            GrdView.Sheets[0].SetColumnWidth(liColTMem, 90);
            GrdView.Sheets[0].SetColumnWidth(liCelNote, 90);
            GrdView.Sheets[0].SetColumnWidth(liColSKK9, 50);
            GrdView.Sheets[0].SetColumnWidth(liColLine1, 50);
            GrdView.Sheets[0].SetColumnWidth(liColSubDistrictName, 50);
            GrdView.Sheets[0].SetColumnWidth(liColDistrictName, 50);
            GrdView.Sheets[0].SetColumnWidth(liColProvName, 50);
            GrdView.Sheets[0].SetColumnWidth(liColPostCode, 50);
            GrdView.Sheets[0].SetColumnWidth(liColContactSkk9, 100);
            GrdView.Sheets[0].SetColumnWidth(liColPostCode, 50);
            GrdView.Sheets[0].SetColumnWidth(liColEmail, 50);
            GrdView.Sheets[0].SetColumnWidth(liColWebSite, 50);
            GrdView.Sheets[0].SetColumnWidth(liColTele, 50);
            GrdView.Sheets[0].SetColumnWidth(liColFax, 50);
            GrdView.Sheets[0].SetColumnWidth(liColFlagResign, 50);
            GrdView.Sheets[0].SetColumnWidth(liColFlagRestaurant, 50);
            GrdView.Sheets[0].SetColumnWidth(liColFlagMeeting, 50);
            GrdView.Sheets[0].SetColumnWidth(liColFlagSpa, 50);
            GrdView.Sheets[0].SetColumnWidth(liColFlagFitness, 50);
            GrdView.Sheets[0].SetColumnWidth(liColBusiness, 50);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.Sheets[0].Columns[liColMemID, liColBusiness];
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellGrdCheck = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellGrdCheck.TextTrue = "use";
            cellGrdCheck.TextFalse = "use";
            GrdView.Sheets[0].Columns[liColCheck].CellType = cellGrdCheck;
            //FarPoint.Win.Spread.CellType.NumberCellType celldeposit = new FarPoint.Win.Spread.CellType.NumberCellType();
            //GrdView.Sheets[0].Columns[liColAddress].CellType = celldeposit;
            GrdView.Sheets[0].Columns[liColMemNameE1, liColPostCode].Locked = true;
            GrdView.Sheets[0].SetColumnLabel(0, liColCheck, " ");
            //GrdView.Sheets[0].SetColumnLabel(0, liColMemID, "Mem ID");
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColCheck].Text = "Use";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColCheck].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColMemID].Text = "Mem ID";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColMemID].Text = " ";
            GrdView.Sheets[0].Models.RowHeaderSpan.Add(0, liColMemID, 1, liColMemID);
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColMemOwner].Text = "ชื่อสมาชิก";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColMemOwner].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColNationality].Text = "Nationality";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColNationality].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColMemNameE1].Text = "ชื่อประกอบวิสาหกิจ";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColMemNameE1].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColTBis].Text = "ประเภทวิสาหกิจ";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColTBis].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColAddress].Text = "ที่ตั้งสำนักงาน";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColAddress].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColStartDate].Text = "วันที่เริ่มสมาชิก";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColStartDate].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColEndDate].Text = "วันพ้นสมาชิกภาพ";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColEndDate].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColTMem].Text = "ประเภทสมาชิก";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColTMem].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liCelNote].Text = "หมายเหตุ";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liCelNote].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColAddressDoc].Text = "ที่อยู่จัดส่งเอกสาร";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColAddressDoc].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColSKK9].Text = "สคค9";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColSKK9].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells [1,liColSubDistrictName].Text ="ตำบล";
            GrdView.Sheets[0].ColumnHeader.Cells [1,liColDistrictName].Text ="อำเภอ";
            GrdView.Sheets[0].ColumnHeader.Cells [1,liColProvName].Text = "จังหวัด";
            GrdView.Sheets[0].ColumnHeader.Cells [1,liColPostCode].Text ="รหัสไปรษณีย์";
            GrdView.Sheets[0].ColumnHeader.Cells [1,liColLine1].Text = "ที่อยู่ 1.";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColEmail].Text = "E-Mail";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColWebSite].Text = "Web Site";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColTele].Text = "โทรศัพท์";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColFax].Text = "FAX";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColFlagResign].Text = "Resign";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColFlagRestaurant].Text = "Restaurant";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColFlagMeeting].Text = "Meeting";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColFlagSpa].Text = "Spa";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColFlagFitness].Text = "Fitness";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColBusiness].Text = "Business";
            GrdView.Sheets[0].Models.RowHeaderSpan.Add(0, 0, 1, 2);
            GrdView.Sheets[0].Models.ColumnHeaderSpan.Add(0, liColLine1, 1, liColFax);
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColLine1, 0, liColPostCode].Text = "ที่ตั้งสำนักงาน";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColContactSkk9].Text = "ชื่อแสดงใน สคค 9";
            GrdView.Sheets[0].ColumnHeader.Cells[1, liColContactSkk9].Text = " ";
            //GrdView.Sheets[0].ColumnHeader.Cells[0, liColLine1, 0, liColPostCode].Text = " ";
            GrdView.AllowColumnMove = true;
            GrdView.Sheets[0].RowCount = 1;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            GrdView.ActiveSheet.Columns[liColMemID, liColContactSkk9].AllowAutoSort = true;
            GrdView.ActiveSheet.Columns[liColCheck, liColContactSkk9].AllowAutoFilter = true;
            //GrdView.Visible = true;
            //GrdView.Sheets[0].Columns[0].Visible = false;
        }
        private void SelectMember()
        {
            lsGdb.Gdb.Close();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            PaintGrdMain();
            Pb1.Visible = true;
            Int32 i = 0, j = 0,liAddressCode=0;
            string lsSQL = "", lsAddress="", lsDate="", lsTypeAddress="", lsMemID="",lsContactSkk9="";
            lsSQL = "Select count(*) cnt "
                    + "From member m "
                    + "left join typemem t on m.tmemcode = t.tmemcode "
                    + "left join typebis b on m.tbiscode = b.tbiscode "
                    + "left join membernote n on m.noteid = n.noteid "
                    + "left join nationality nt on m.nationcode = nt.nationcode "
                    + "left join address a on m.memid = a.refid "
                    + "left join province p on a.provcode = p.provcode "
                    + "left join district d on a.districtcode = d.districtcode "
                    + "left join subdistrict s on a.subdistrictcode = s.subdistrictcode "
                    + "left join contact c on m.memid = c.refid, memberowner o "
                    + "Where m.ownerid = o.ownerid and a.addresscode = '"
                    + CboTMem.ComboBox.SelectedValue.ToString() +"' and "
                    + "c.contactid = (select c.contactid From contact c where c.refid = m.memid and c.flagskk9 ='1' having max(contactid)) "
                    + "Order By m.memnamee1";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsReadMain;
            lsReadMain = lsComm.ExecuteReader();
            if (lsReadMain.HasRows)
            {
                while (lsReadMain.Read())
                {
                    j = Convert.ToInt32(lsReadMain["cnt"]);
                }
            }
            lsReadMain.Close();
            GrdView.Sheets[0].RowCount = j + 1;
            Pb1.Minimum = 0;
            Pb1.Maximum = j;
            lsSQL = "Select m.*, o.ownernamet, t.tmemnamet, b.tbisname, n.note, m.skk9id, nt.nationname, "
                    + " m.startdate, m.enddate, nt.nationnamet, a.email aemail, a.line1, a.website, a.telephone, "
                    + "a.fax, p.provnamet, d.districtnamet, s.subdistrictnamet, a.flaglang as flaglangaddress, a.postcode as postcodeaddress, "
                    + "p.provnamee, d.districtnamee, s.subdistrictnamee, c.* "
                    + "From member m "
                    + "left join typemem t on m.tmemcode = t.tmemcode "
                    + "left join typebis b on m.tbiscode = b.tbiscode "
                    + "left join membernote n on m.noteid = n.noteid "
                    + "left join nationality nt on m.nationcode = nt.nationcode "
                    + "left join address a on m.memid = a.refid "
                    + "left join province p on a.provcode = p.provcode "
                    + "left join district d on a.districtcode = d.districtcode "
                    + "left join subdistrict s on a.subdistrictcode = s.subdistrictcode "
                    + "left join contact c on m.memid = c.refid, memberowner o "
                    + "Where m.ownerid = o.ownerid and a.addresscode = '"
                    + CboTMem.ComboBox.SelectedValue.ToString() + "' and "
                    //+ "c.contactid = (select c.contactid From contact c where c.refid = m.memid having max(contactid)) "
                    + "c.contactid = (select c.contactid From contact c where c.refid = m.memid and c.flagskk9 ='1' having max(contactid)) "
                    + "Order By m.memnamee1";
            lsComm.CommandText = lsSQL;
            lsReadMain = lsComm.ExecuteReader();
            if (lsReadMain.HasRows)
            {
                while (lsReadMain.Read())
                {
                    lsSQL = lsReadMain["note"].ToString();
                    lsDate = lsGdb.SelectDate(Convert .ToDateTime ( lsReadMain["startdate"].ToString()), Connection.FlagDate.DateBuddhism, lsIni);
                    GrdView.Sheets[0].SetText(i, liColMemID, lsReadMain["memid"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMemOwner, lsReadMain["ownernamet"].ToString());
                    GrdView.Sheets[0].SetText(i, liColNationality, lsReadMain["nationnamet"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMemNameE1, lsReadMain["memnamet"].ToString());
                    GrdView.Sheets[0].SetText(i, liColTBis, lsReadMain["tbisname"].ToString());
                    GrdView.Sheets[0].SetText(i, liColStartDate, lsDate);
                    lsDate = lsGdb.SelectDate(Convert.ToDateTime(lsReadMain["enddate"].ToString()), Connection.FlagDate.DateBuddhism, lsIni);
                    GrdView.Sheets[0].SetText(i, liColEndDate, lsDate);
                    GrdView.Sheets[0].SetText(i, liColTMem, lsReadMain["tmemnamet"].ToString());
                    GrdView.Sheets[0].SetText(i, liCelNote, lsReadMain["note"].ToString());
                    GrdView.Sheets[0].SetText(i, liColSKK9, lsReadMain["skk9id"].ToString());
                    lsAddress = "";
                    lsAddress = lsReadMain["line1"].ToString() + " " + lsReadMain["subdistrictnamet"].ToString() + " "
                        + lsReadMain["districtnamet"].ToString() + lsReadMain["provnamet"].ToString() + lsReadMain["postcode"].ToString();
                    GrdView.Sheets[0].SetText(i, liColAddress, lsAddress);
                    GrdView.Sheets[0].SetText(i, liColLine1, lsReadMain["line1"].ToString());
                    lsSQL = lsReadMain["aemail"].ToString();
                    GrdView.Sheets[0].SetText(i, liColEmail, lsReadMain["aemail"].ToString());
                    GrdView.Sheets[0].SetText(i, liColWebSite, lsReadMain["website"].ToString());
                    GrdView.Sheets[0].SetText(i, liColTele, lsReadMain["telephone"].ToString());
                    GrdView.Sheets[0].SetText(i, liColFax, lsReadMain["fax"].ToString());
                    GrdView.Sheets[0].SetText(i, liColFlagResign, lsReadMain["flagresign"].ToString());
                    GrdView.Sheets[0].SetText(i, liColFlagRestaurant, lsReadMain["flagrestaurant"].ToString());
                    GrdView.Sheets[0].SetText(i, liColFlagMeeting, lsReadMain["flagmeeting"].ToString());
                    GrdView.Sheets[0].SetText(i, liColFlagSpa, lsReadMain["flagspa"].ToString());
                    GrdView.Sheets[0].SetText(i, liColFlagFitness, lsReadMain["flagfitness"].ToString());
                    GrdView.Sheets[0].SetText(i, liColBusiness, lsReadMain["flagbusiness"].ToString());
                    lsSQL = lsReadMain["flaglang"].ToString();
                    if (lsReadMain["flaglangaddress"].ToString() == "1")
                    {
                        GrdView.Sheets[0].SetText(i, liColSubDistrictName, lsReadMain["subdistrictnamet"].ToString());
                        GrdView.Sheets[0].SetText(i, liColDistrictName, lsReadMain["districtnamet"].ToString());
                        GrdView.Sheets[0].SetText(i, liColProvName, lsReadMain["provnamet"].ToString());
                    }
                    else
                    {
                        GrdView.Sheets[0].SetText(i, liColSubDistrictName, lsReadMain["subdistrictnamee"].ToString());
                        GrdView.Sheets[0].SetText(i, liColDistrictName, lsReadMain["districtnamee"].ToString());
                        GrdView.Sheets[0].SetText(i, liColProvName, lsReadMain["provnamee"].ToString());
                    }
                    if (lsReadMain["flagprintskk9"].ToString() == "1")
                    {
                        GrdView.Sheets[0].SetText(i, 0, "1");
                    }
                    GrdView.Sheets[0].SetText(i, liColPostCode, lsReadMain["postcodeaddress"].ToString());
                    lsContactSkk9 = lsReadMain["contactnamet"].ToString() + " " + lsReadMain["contactsurnamet"].ToString();
                    GrdView.Sheets[0].SetText(i, liColContactSkk9, lsContactSkk9);
                    i++;
                    Pb1.Value = i;
                }
            }
            lsReadMain.Close();
            liAddressCode = Convert.ToInt32(CboTMem.ComboBox.SelectedValue.ToString());
            lsTypeAddress = CboTMem.Text;
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColAddress].Text = lsTypeAddress;
            //GrdView.Sheets[0].ColumnHeader.Cells[1, liColAddress].Text = " ";
            GrdView.Sheets[0].ColumnHeader.Cells[0, liColLine1, 0, liColPostCode].Text = lsTypeAddress;
            //GrdView.Sheets[0].ColumnHeader.Cells[0, liColLine1, 0, liColPostCode].Text = " ";
            if (GrdView.Sheets[0].RowCount > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            //lsConn.Gdb.Close();
            Pb1.Visible = false;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void MemberSKK9_Load(object sender, EventArgs e)
        {
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            else
            {
                lsGdb.Gdb.Close();
                lsGdb.Gdb.Open();
                //lsGdb.ConnectDatabase();
            }
            Pb1.Visible = false;
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            GrdView.Top = this.Top + 35;
            GrdView.Left = this.Left + 15;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 25;
            lsIniT.CreateTblInitial(lsGdb.Gdb);
            PaintGrdMain();
            lsGdb.SelectCbo(CboTMem.ComboBox, "", Connection.TableIniT.CboAddress);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void exportToExcel_Click(object sender, EventArgs e)
        {
            string lsExcelFileName = lsIni.GetString("thahr30", "exporttoexcelfilename", "member.xls");
            string lsExcelFileNameWithHeader = lsIni.GetString("thahr30", "exporttoexcelfilewithheader", "0");
            switch (lsExcelFileNameWithHeader)
            {
                case "0":
                    {
                        GrdView.SaveExcel(Application.StartupPath + "\\" + lsExcelFileName, FarPoint.Win.Spread.Model.IncludeHeaders.None);
                        break ;
                    }
                case "1":
                    {
                        GrdView.SaveExcel(Application.StartupPath + "\\" + lsExcelFileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly );
                        break ;
                    }
            }
            Process myProcess = new Process();
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            myProcess.StartInfo.FileName = Application.StartupPath + "\\" + lsExcelFileName;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            SelectMember();
        }
        private void printlabel_Click(object sender, EventArgs e)
        {
            Report Rpt = new Report();
            Rpt.PrintGrd(GrdView);
            ReportView frm = new ReportView();
            frm.lsReportName = "rptlabel";
            frm.Show(this);
        }

        private void printskk9_Click(object sender, EventArgs e)
        {
            Report Rpt = new Report();
            Rpt.PrintGrd(GrdView);
            ReportView frm = new ReportView();
            frm.lsReportName = "rptskk9";
            frm.Show(this);
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SelectMember();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            else
            {
                lsGdb.Gdb.Close();
                lsGdb.Gdb.Open();
                //lsGdb.ConnectDatabase();
            }
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            string lsFlag = "", lsMemID="";
            for (Int32 i = 0; i <= GrdView.ActiveSheet.RowCount - 1; i++)
            {
                lsFlag = GrdView.ActiveSheet.GetText(i, 0);
                lsMemID = GrdView.ActiveSheet.GetText(i, liColMemID);
                if (lsFlag == "True")
                {
                    lstblMember.UpdateFlagPrintSKK9(lsMemID, lsGdb.Gdb);
                }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void clearBookmark_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            lstblMember.UpdateFlagPrintSKK9ClearAll(lsGdb.Gdb);
            for(Int32 i=0;i<=GrdView .ActiveSheet .RowCount -1;i++)
            {
                GrdView.ActiveSheet.SetText(i, 0, "0");
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
    }
}