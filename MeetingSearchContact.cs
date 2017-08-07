using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using MySql.Data.MySqlClient;
namespace ThaHr30
{
    public partial class MeetingSearchContact : Form
    {
        private Int32 liColFlag = 0, liColMeetingContactID = 1, liColMeetingContactName = 2, liColCompanyName = 3;
        private Int32 liColPositionName = 4, liColTypeMeetingContact = 5, liColPrintLabel=6, colContactID=9;
        private Int32 colTmemNameT = 7, colMemNameT = 8, colMemID=10;
        string lsMeetingID = "";
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile();
        Meeting lsTblMeeting = new Meeting();
        Int32 liCnt = 0, liFlagContact=0;
        object[,] ldDataArr;
        FlagContact lfFlagContact;
        //private Int32 colFlag = 0, colEmail = 1, colEmailFlag = 2, rowgrdView = 1;
        public enum FlagContact
        {
            Contact = 1, Committee = 2, Reporter = 3
        }
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
        public string MeetingID
        {
            get
            {
                return lsMeetingID;
            }
            set
            {
                lsMeetingID = value;
            }
        }
        public object[,] DataArr
        {
            get
            {
                return ldDataArr;
            }
            set
            {
                ldDataArr = value;
            }
        }
        public Int32 DataCount
        {
            get
            {
                return liCnt;
            }
            set
            {
                liCnt = value;
            }
        }
        public FlagContact FlagMeetingContact
        {
            get
            {
                return lfFlagContact; 
            }
            set
            {
                lfFlagContact = value;
                //FlagContact = value;
            }
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            GrdView.Reset();
            GrdView.ActiveSheet.RowCount = 1;
            GrdView.ActiveSheet.ColumnCount = 11;
            //GrdView.Height = this.Height - 60;
            //GrdView.Width = this.Width - 30;
            //GrdView.Top = 30;
            //GrdView.Left = 500;

            FarPoint.Win.Spread.CellType.TextCellType cellTxt = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[liColMeetingContactID, colMemNameT].CellType = cellTxt;
            GrdView.Sheets[0].Columns[colMemID, colMemID].CellType = cellTxt;
            GrdView.Sheets[0].Columns[liColMeetingContactID].Visible = false;
            //GrdView.Sheets[0].Columns[liColPrintLabel].Visible = false;

            FarPoint.Win.Spread.CellType.CheckBoxCellType cellGrdCheck = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellGrdCheck.TextTrue = "use";
            cellGrdCheck.TextFalse = "use";
            GrdView.ActiveSheet.Columns[liColFlag].CellType = cellGrdCheck;

            GrdView.ActiveSheet.SetColumnWidth(liColMeetingContactID, 72);
            GrdView.ActiveSheet.SetColumnWidth(liColMeetingContactName, 170);
            GrdView.ActiveSheet.SetColumnWidth(liColCompanyName, 170);
            GrdView.ActiveSheet.SetColumnWidth(liColPositionName, 80);
            GrdView.ActiveSheet.SetColumnWidth(liColTypeMeetingContact, 80);

            GrdView.ActiveSheet.SetColumnLabel(0, liColFlag, "USE");
            GrdView.ActiveSheet.SetColumnLabel(0, liColMeetingContactID, "meetingcontactid");
            GrdView.ActiveSheet.SetColumnLabel(0, liColMeetingContactName, "ชื่อผู้เข้าประชุม");
            GrdView.ActiveSheet.SetColumnLabel(0, liColCompanyName, "บริษัท");
            GrdView.ActiveSheet.SetColumnLabel(0, liColPositionName, "ตำแหน่ง");
            GrdView.ActiveSheet.SetColumnLabel(0, liColTypeMeetingContact, "ประเภท");
            GrdView.ActiveSheet.SetColumnLabel(0, liColPrintLabel, "printlabel");
            GrdView.ActiveSheet.SetColumnLabel(0, colTmemNameT, "ประเภทสมาชิก");
            GrdView.ActiveSheet.SetColumnLabel(0, colMemNameT, "ชื่อสมาชิกภาษาไทย");
            GrdView.ActiveSheet.SetColumnLabel(0, colContactID, "contactid");
            GrdView.ActiveSheet.SetColumnLabel(0, colMemID, "memid");

            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.Visible = true;

            GrdView.ActiveSheet.Columns[liColMeetingContactID, liColTypeMeetingContact].AllowAutoSort = true;
            GrdView.ActiveSheet.Columns[liColMeetingContactID, liColTypeMeetingContact].AllowAutoFilter = true;

            GrdView.Sheets[0].Columns[colContactID].Visible = false;

            GrdView.AllowColumnMove = true;
        }
        private void SelectMeetingContactAll( string aWhere)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Int32 i = 0, liCnt = 0;
            string sql = "";
            if (ChkAll.Checked)
            {
                //lsSQL = "Select count(*) as cnt From contact c, member m Where c.refid = m.memid and c.flagmeeting = '1'";
                sql = "Select count(*) as cnt "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode "
                    + "Where c.flagold <> '2' ";
            }
            else if (chkAllwithoutresign.Checked)
            {
                //lsSQL = "Select count(*) as cnt From contact c, member m Where c.refid = m.memid and c.flagmeeting = '1'";
                sql = "Select count(*) as cnt "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode "
                    + "Where c.refid = m.memid and c.flagold <> '2'  and m.flagresign <> '1' ";
            }
            else if (ChkRegion.Checked)
            {
                sql = "Select count(*) as cnt "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode "
                    + "Where c.refid = m.memid and m.regioncode = '" + aWhere + "' and c.flagmeeting = '1'";
            }
            else if (ChkType.Checked)
            {
                sql = "Select count(*) as cnt "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = m.tmemcode "
                    + "Where c.refid = m.memid and m.tmemcode = '" + aWhere + "' and c.flagmeeting = '1'";
            }
            else
            {
                sql = "Select count(*) as cnt "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode "
                    + "Where c.refid = m.memid and m.memid = '" + aWhere + "' and c.flagmeeting = '1'";
            }
            MySqlCommand Comm = new MySqlCommand(sql, lsGdb.Gdb);
            MySqlDataReader rs;
            rs = Comm.ExecuteReader();
            if (rs.HasRows)
            {
                while (rs.Read())
                {
                    liCnt = Convert.ToInt32(rs["cnt"]);
                }
            }
            GrdView.ActiveSheet.RowCount = liCnt + 1;
            rs.Close();
            if (ChkAll.Checked)
            {
                //lsSQL = "Select c.contactnamet, c.contactsurnamet, m.memid, m.memnamee1, c.positiont From contact c, member m Where c.refid = m.memid and c.flagmeeting = '1'";
                sql = "Select c.contactnamet, c.contactsurnamet, m.memid, m.memnamee1, m.memnamet, "
                    + "c.positiont, c.flagprintlabel, t.tmemnamet, c.contactid "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode " 
                    + "Where c.flagold <> '2' ";
            }
            else if (chkAllwithoutresign.Checked)
            {
                //lsSQL = "Select c.contactnamet, c.contactsurnamet, m.memid, m.memnamee1, c.positiont From contact c, member m Where c.refid = m.memid and c.flagmeeting = '1'";
                sql = "Select c.contactnamet, c.contactsurnamet, m.memid, m.memnamee1, m.memnamet, "
                    + "c.positiont, c.flagprintlabel, t.tmemnamet, c.contactid "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode " 
                    + "Where c.refid = m.memid and c.flagold <> '2'  and m.flagresign <> '1' ";
            }
            else if (ChkRegion.Checked)
            {
                sql = "Select c.contactnamet, c.contactsurnamet, m.memid, m.memnamee1, m.memnamet, "
                    + "c.positiont, c.flagprintlabel, t.tmemnamet, c.contactid "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode " 
                    + "Where c.refid = m.memid and m.regioncode = '" + aWhere + "' and c.flagmeeting = '1'";
            }
            else if (ChkType.Checked)
            {
                sql = "Select c.contactnamet, c.contactsurnamet, m.memid, m.memnamee1, m.memnamet, "
                    + "c.positiont, c.flagprintlabel, t.tmemnamet, c.contactid "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = m.tmemcode " 
                    + "Where c.refid = m.memid and m.tmemcode = '" + aWhere + "' and c.flagmeeting = '1'";
            }
            else
            {
                sql = "Select c.contactnamet, c.contactsurnamet, m.memid, m.memnamee1, m.memnamet, "
                    + "c.positiont, c.flagprintlabel, t.tmemnamet, c.contactid "
                    + "From contact c left join member m on c.refid = m.memid "
                    + "left join typemem t on m.tmemcode = t.tmemcode " 
                    + "Where c.refid = m.memid and m.memid = '" + aWhere + "' and c.flagmeeting = '1'";
            }
            Comm.CommandText = sql;
            rs = Comm.ExecuteReader();
            if (rs.HasRows)
            {
                while (rs.Read())
                {
                    GrdView.ActiveSheet.SetText(i, liColMeetingContactID, "0");
                    GrdView.ActiveSheet.SetText(i, liColMeetingContactName, rs["contactnamet"].ToString() + " " + rs["contactsurnamet"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColTypeMeetingContact, "");
                    //GrdView.ActiveSheet.SetText(i, liColCompanyName, lsRead["memnamee1"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColCompanyName, rs["memnamee1"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColPositionName, rs["positiont"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColPrintLabel, rs["flagprintlabel"].ToString());
                    GrdView.ActiveSheet.Cells[i, colMemNameT].Text = rs["memnamet"].ToString();
                    GrdView.ActiveSheet.Cells[i, colTmemNameT].Text = rs["tmemnamet"].ToString();
                    GrdView.ActiveSheet.Cells[i, colContactID].Text = rs["contactid"].ToString();
                    GrdView.ActiveSheet.Cells[i, colMemID].Text = rs["memid"].ToString();
                    i++;
                }
            }
            rs.Close();
            //if (i > 22)
            //{
            //    GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            //    GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            //    GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            //}
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void CloseForm()
        {
            this.Close();
        }
        public MeetingSearchContact()
        {
            InitializeComponent();
        }
        private void MeetingSearchContact_Load(object sender, EventArgs e)
        {
            PaintGrdView();
            Pb1.Visible = false;
            SL1.Visible = false;
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                if (lsGdb.ConnectDatabase() == false)
                {
                    CloseForm();
                }
            }
            SelectFilter();
        }

        private void SelectFilter()
        {
            if (ChkMember.Checked)
            {
                lsGdb.SelectCbo(CboFilter, "", Connection.TableIniT.Member);
            }
            else if (ChkRegion.Checked)
            {
                lsGdb.SelectCbo(CboFilter, "", Connection.TableIniT.Region);
            }
            else if (ChkType.Checked)
            {
                lsGdb.SelectCbo(CboFilter, "", Connection.TableIniT.TypeMem);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
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

            if (ChkAll.Checked)
            {
                SelectMeetingContactAll("");
            }
            else if (chkAllwithoutresign.Checked)
            {
                SelectMeetingContactAll("");
            }
            else
            {
                SelectMeetingContactAll(CboFilter.SelectedValue.ToString());
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string ls = "";
            Int32 i = 0,j=0;
            //GrdView .ActiveSheet.RowFilter 
            string[,] lsArr = new string[GrdView.ActiveSheet.RowCount + 1, 10];
            Boolean lbFlag = false;
            //ldDataArr = GrdView.ActiveSheet.GetArray(0, liColMeetingContactID, GrdView.ActiveSheet.RowCount - 1, liColTypeMeetingContact);
            //liCnt = GrdView.ActiveSheet.RowCount;            
            //CreateColumn(ldData);
            for (i = 0; i <= GrdView.ActiveSheet.RowCount - 1; i++)
            {
                lbFlag = Convert.ToBoolean(GrdView.ActiveSheet.GetValue(i, 0));
                if (lbFlag)
                {
                    //Arr .                    
                    ls = GrdView.ActiveSheet.GetText(i, liColPositionName);
                    lsArr[j, 0] = GrdView.ActiveSheet.GetText(i, liColMeetingContactID);
                    lsArr[j, 1] = GrdView.ActiveSheet.GetText(i, liColMeetingContactName);
                    lsArr[j, 2] = GrdView.ActiveSheet.GetText(i, liColCompanyName);
                    lsArr[j, 3] = GrdView.ActiveSheet.GetText(i, liColPositionName);
                    lsArr[j, 4] = GrdView.ActiveSheet.GetText(i, liColTypeMeetingContact);
                    lsArr[j, 5] = GrdView.ActiveSheet.GetText(i, liColPrintLabel);
                    lsArr[j, 6] = GrdView.ActiveSheet.Cells[i, colTmemNameT].Text;
                    lsArr[j, 7] = GrdView.ActiveSheet.Cells[i, colMemNameT].Text;
                    lsArr[j, 8] = GrdView.ActiveSheet.Cells[i, colContactID].Text;
                    lsArr[j, 9] = GrdView.ActiveSheet.Cells[i, colMemID].Text;
                    j++;
                }
            }
            ldDataArr = lsArr;
            liCnt = j;
            CloseForm();
        }

        private void ChkType_CheckedChanged(object sender, EventArgs e)
        {
            SelectFilter();
        }

        private void ChkRegion_CheckedChanged(object sender, EventArgs e)
        {
            SelectFilter();
        }

        private void ChkMember_CheckedChanged(object sender, EventArgs e)
        {
            SelectFilter();
        }

        private void ChkUseAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUseAll.Checked)
            {
                ChkUseAll.Text = "เลือกทั้งหมด";                
            }
            else
            {
                ChkUseAll.Text = "ไม่เลือกทั้งหมด";
            }
            for (Int32 i = 0; i <= GrdView.ActiveSheet.RowCount - 1; i++)
            {
                GrdView.ActiveSheet.SetValue(i, liColFlag, ChkUseAll.Checked);
            }
        }

        //private static void CreateColumn(DataTable ldData)
        //{
        //    DataColumn column;
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "meetingcontactid";
        //    column.AutoIncrement = false;
        //    column.Caption = "meetingcontactid";
        //    column.ReadOnly = false;
        //    column.Unique = false;
        //    ldData.Columns.Add(column);
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "meetingcontactname";
        //    column.AutoIncrement = false;
        //    column.Caption = "ชื่อผู้เข้าประชุม";
        //    column.ReadOnly = false;
        //    column.Unique = false;
        //    ldData.Columns.Add(column);
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "companyname";
        //    column.AutoIncrement = false;
        //    column.Caption = "บริษัท";
        //    column.ReadOnly = false;
        //    column.Unique = false;
        //    ldData.Columns.Add(column);
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "positionname";
        //    column.AutoIncrement = false;
        //    column.Caption = "ตำแหน่ง";
        //    column.ReadOnly = false;
        //    column.Unique = false;
        //    ldData.Columns.Add(column);
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "typemeetingcontact";
        //    column.AutoIncrement = false;
        //    column.Caption = "ประเภท";
        //    column.ReadOnly = false;
        //    column.Unique = false;
        //    ldData.Columns.Add(column);
        //}
    }
}