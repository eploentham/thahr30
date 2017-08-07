using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Microsoft.Office;
using Word = Microsoft.Office.Interop.Word;

using System.Reflection;
namespace ThaHr30
{
    public partial class MeetingAdd : Form
    {
        private Int32 liColMeetingContactID = 0, liColMeetingContactName = 1, liColCompanyName = 2, liColPositionName=3, liColTypeMeetingContact = 4;
        private Int32 liColFlag = 5, liColFlagVisit=6, liColMemID=7, liColPrintLabel=8;
        private Int32 colTmemNameT = 9, colMemNameT = 10, colContactID = 11;
        
        string lsMeetingID = "";
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile();
        Meeting lsTblMeeting = new Meeting();
        object[,] ldData;
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
        public object[,] arr
        {
            get
            {
                return ldData;
            }
            set
            {
                ldData = value;
                GrdView.Sheets[0].SetArray(0, 0, arr);
            }
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            GrdView.Reset();
            GrdView.Sheets.Count = 3;
            GrdView.Sheets[0].SheetName = "ผู้มาประชุม";
            GrdView.Sheets[1].SheetName = "กรรมการ";
            GrdView.Sheets[2].SheetName = "ผู้สื่อข่าว";
            GrdView.Sheets[0].RowCount = 1;
            GrdView.Sheets[0].ColumnCount = 12;
            //GrdView.Height = this.Height - 60;
            //GrdView.Width = this.Width - 30;
            GrdView.Top = 30;
            GrdView.Left = 400;
            //this.Width
            GrdView.Width = this.Width - 420;

            FarPoint.Win.Spread.CellType.TextCellType cellTxt = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[liColMeetingContactID, colMemNameT].CellType = cellTxt;
            GrdView.Sheets[0].Columns[liColMeetingContactID].Visible = false;
            GrdView.Sheets[0].Columns[liColFlag].Visible = false;
            GrdView.Sheets[0].Columns[liColMemID].Visible = true;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellGrdCheck = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellGrdCheckP = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellGrdCheck.TextTrue = "Visit";
            cellGrdCheck.TextFalse = "Visit";
            GrdView.Sheets[0].Columns[liColFlagVisit].CellType = cellGrdCheck;
            cellGrdCheckP.TextTrue = "Print";
            cellGrdCheckP.TextFalse = "Print";
            GrdView.Sheets[0].Columns[liColPrintLabel].CellType = cellGrdCheckP;

            GrdView.Sheets[0].SetColumnWidth(liColMeetingContactID, 72);
            GrdView.Sheets[0].SetColumnWidth(liColMeetingContactName, 170);
            GrdView.Sheets[0].SetColumnWidth(liColCompanyName, 170);
            GrdView.Sheets[0].SetColumnWidth(liColPositionName, 80);
            GrdView.Sheets[0].SetColumnWidth(liColTypeMeetingContact, 80);
            GrdView.Sheets[0].SetColumnWidth(liColFlagVisit, 80);
            GrdView.Sheets[0].SetColumnWidth(liColPrintLabel, 85);

            GrdView.Sheets[0].SetColumnLabel(0, liColMeetingContactID, "meetingcontactid");
            GrdView.Sheets[0].SetColumnLabel(0, liColMeetingContactName, "ชื่อผู้เข้าประชุม");
            GrdView.Sheets[0].SetColumnLabel(0, liColCompanyName, "บริษัท");
            GrdView.Sheets[0].SetColumnLabel(0, liColPositionName, "ตำแหน่ง");
            GrdView.Sheets[0].SetColumnLabel(0, liColTypeMeetingContact, "ประเภท");
            GrdView.Sheets[0].SetColumnLabel(0, liColFlag, "flag");
            GrdView.Sheets[0].SetColumnLabel(0, liColFlagVisit, "มาประชุม");
            GrdView.Sheets[0].SetColumnLabel(0, liColMemID, "สคค9");
            GrdView.Sheets[0].SetColumnLabel(0, liColPrintLabel, "printlabel");
            GrdView.Sheets[0].SetColumnLabel(0, colTmemNameT, "ประเภทสมาชิก");
            GrdView.Sheets[0].SetColumnLabel(0, colMemNameT, "ชื่อสมาชิกภาษาไทย");
            GrdView.Sheets[0].SetColumnLabel(0, colContactID, "contactid");

            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            //GrdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.Visible = true;

            //GrdView.Sheets[0].Columns[colContactID].Visible = false;
            GrdView.Sheets[0].Columns[liColMeetingContactID, colMemNameT].AllowAutoSort = true;
            GrdView.Sheets[0].Columns[liColMeetingContactID, colMemNameT].AllowAutoFilter = true;

            GrdView.AllowColumnMove = true;
        }
        private void PaintGrdCommittee()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            GrdView.Sheets[1].RowCount = 1;
            GrdView.Sheets[1].ColumnCount = 8;

            FarPoint.Win.Spread.CellType.TextCellType cellTxt = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[1].Columns[liColMeetingContactID, liColMemID].CellType = cellTxt;
            GrdView.Sheets[1].Columns[liColMeetingContactID].Visible = false;
            GrdView.Sheets[1].Columns[liColFlag].Visible = false;
            GrdView.Sheets[1].Columns[liColMemID].Visible = false;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellGrdCheck = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellGrdCheck.TextTrue = "Visit";
            cellGrdCheck.TextFalse = "Visit";
            GrdView.Sheets[1].Columns[liColFlagVisit].CellType = cellGrdCheck;

            GrdView.Sheets[1].SetColumnWidth(liColMeetingContactID, 72);
            GrdView.Sheets[1].SetColumnWidth(liColMeetingContactName, 170);
            GrdView.Sheets[1].SetColumnWidth(liColCompanyName, 170);
            GrdView.Sheets[1].SetColumnWidth(liColPositionName, 80);
            GrdView.Sheets[1].SetColumnWidth(liColTypeMeetingContact, 80);

            GrdView.Sheets[1].SetColumnLabel(0, liColMeetingContactID, "meetingcontactid");
            GrdView.Sheets[1].SetColumnLabel(0, liColMeetingContactName, "ชื่อกรรมการ");
            GrdView.Sheets[1].SetColumnLabel(0, liColCompanyName, "บริษัท");
            GrdView.Sheets[1].SetColumnLabel(0, liColPositionName, "ตำแหน่ง");
            GrdView.Sheets[1].SetColumnLabel(0, liColFlag, "flag");
            GrdView.Sheets[1].SetColumnLabel(0, liColFlagVisit, "มาประชุม");
            GrdView.Sheets[1].SetColumnLabel(0, liColMemID, "memid");

            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            //GrdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.Visible = true;

            GrdView.Sheets[1].Columns[liColMeetingContactID, liColFlagVisit].AllowAutoSort = true;
            GrdView.Sheets[1].Columns[liColMeetingContactID, liColFlagVisit].AllowAutoFilter = true;

            GrdView.AllowColumnMove = true;
        }
        private void SelectMeetingContact()
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
            Int32 i = 0, liCnt=0;
            string lsSQL = "Select * From meeting Where meetingid = '" + lsMeetingID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TxtMeetingID.Text = lsRead["meetingid"].ToString();
                    TxtMeetingNameT.Text = lsRead["meetingnamet"].ToString();
                    TxtDescription.Text = lsRead["description"].ToString();
                    TxtPlace.Text = lsRead["place"].ToString();
                    TxtRemark.Text = lsRead["remark"].ToString();
                    TxtStartDate.Text = lsGdb.SelectDateBudda(Convert.ToDateTime(lsRead["meetingstartdate"]));
                    TxtEndDate.Text = lsGdb.SelectDateBudda(Convert.ToDateTime(lsRead["meetingenddate"]));
                    TxtStartTime.Text = lsRead["meetingstarttime"].ToString();
                    TxtEndTime.Text = lsRead["meetingendtime"].ToString();
                    lsSQL = lsRead["meetingstarttime"].ToString();
                }
            }
            if (TxtMeetingID.Text == "")
            {
                TxtMeetingID.Text = "0";
            }
            lsRead.Close();
            lsSQL = "Select count(*) cnt From meetingcontact Where meetingid = '" + lsMeetingID + "'";
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    if (lsRead["cnt"].ToString() == "")
                    {
                        liCnt = 0;
                    }
                    else
                    {
                        liCnt = Convert.ToInt32(lsRead["cnt"].ToString());
                    }
                }
            }
            lsRead.Close();
            Pb1.Visible = true;
            Pb1.Maximum = liCnt;
            Application.DoEvents();
            GrdView.Sheets[0].RowCount = liCnt + 1;
            lsSQL = "Select m.skk9id,mc.*, c.flagprintlabel "
                + "From meetingcontact mc left join contact c on mc.contactid = c.contactid  left join member m on m.memid = mc.memid "
                + "Where mc.meetingid = '" + lsMeetingID + "' ";
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    GrdView.Sheets[0].SetText(i, liColMeetingContactID, lsRead["meetingcontactid"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMeetingContactName, lsRead["contactname"].ToString());
                    GrdView.Sheets[0].SetText(i, liColTypeMeetingContact, lsRead["typemeeting"].ToString());
                    GrdView.Sheets[0].SetText(i, liColCompanyName, lsRead["companyname"].ToString());
                    GrdView.Sheets[0].SetText(i, liColPositionName, lsRead["positionname"].ToString());
                    GrdView.Sheets[0].SetText(i, colTmemNameT, lsRead["tmemnamet"].ToString());
                    GrdView.Sheets[0].SetText(i, colMemNameT, lsRead["memnamet"].ToString());
                    GrdView.Sheets[0].SetText(i, liColPrintLabel, lsRead["flagprintlabel"].ToString());
                    GrdView.Sheets[0].SetText(i, colContactID, lsRead["contactid"].ToString());
                    GrdView.Sheets[0].SetText(i, liColFlag, "0");
                    if (lsRead["flagvisit"].ToString() == "1")
                    {
                        GrdView.Sheets[0].SetValue(i, liColFlagVisit, true);
                    }
                    else
                    {
                        GrdView.Sheets[0].SetValue(i, liColFlagVisit, false);
                    }
                    //GrdView.Sheets[0].SetText(i, liColFlagVisit, lsRead["flagvisit"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMemID, lsRead["skk9id"].ToString());
                    if ((i % 2) != 0)
                    {
                        GrdView.Sheets[0].Rows[i].BackColor = Color.LightGoldenrodYellow;
                    }
                    i++;
                    Pb1.Value = i;
                }
            }
            GrdView.Sheets[0].SetActiveCell(i, liColMeetingContactID);
            //if (GrdView.Sheets[0].RowCount > 22)
            //{
            //    GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            //}
            lsRead.Close();
            Pb1.Visible = false;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void ClearPrintLabel(Boolean chk)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
            {
                if (chk)
                {
                    GrdView.Sheets[0].Cells[i, liColPrintLabel].Text = "0";
                }
                else
                {
                    GrdView.Sheets[0].Cells[i, liColPrintLabel].Text = "1";
                }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        public MeetingAdd()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void MemberMeetingAdd_Load(object sender, EventArgs e)
        {
            Int32 liW = this.Width;
            this.WindowState = FormWindowState.Maximized;
            Int32 liH = this.Height;
            //this.WindowState = FormWindowState.Normal;
            //this.Width = liW;
            //this.Height = liH-20;
            GrdView.Height = this.Height - 85;
            this.StartPosition = FormStartPosition.CenterScreen;
            PaintGrdView();
            PaintGrdCommittee();
            Pb1.Visible = false;
            SL1.Visible = false;
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                if (lsGdb.ConnectDatabase() == false)
                {
                    CloseForm();
                }
            }
            Application.DoEvents();
            SelectMeetingContact();
        }
        private Boolean SaveMeeting()
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Int32 liMeeting = 0;
            Pb1.Visible = true;
            Pb1.Maximum = GrdView.Sheets[0].RowCount - 1;
            string lsContactName="", lsCompanyName="", lsPositionName="", lsTypeMeeting="", lsMeetingContactID="", lsFlag="", lsFlagVisit="", lsMemID="";
            string tmemnamet = "", memnamet = "", contactid="";
            if (TxtMeetingID.Text == "")
            {
                TxtMeetingID.Text = "0";
            }
            try
            {
                lsTblMeeting.MeetingID = Convert.ToInt32(TxtMeetingID.Text);
                lsTblMeeting.MeetingNameT = TxtMeetingNameT.Text;
                lsTblMeeting.Description = TxtDescription.Text;
                lsTblMeeting.MeetingStartDate = Convert.ToDateTime(TxtStartDate.Text);
                lsTblMeeting.MeetingEndDate = Convert.ToDateTime(TxtEndDate.Text);
                lsTblMeeting.MeetingStartTime = TxtStartTime.Text;
                lsTblMeeting.MeetingEndTime = TxtEndTime.Text;
                lsTblMeeting.Plase = TxtPlace.Text;
                lsTblMeeting.Year = Convert.ToDateTime(TxtStartDate.Text).Year.ToString();
                lsTblMeeting.Remark = TxtRemark.Text;
                liMeeting = lsTblMeeting.CreateMeeting(lsGdb.Gdb);
                
                //lsTblMeeting.DeleteMeetingContactALL(Convert.ToInt32(TxtMeetingID.Text), lsGdb.Gdb);
                for (Int32 i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
                {
                    lsContactName = GrdView.Sheets[0].GetText(i, liColMeetingContactName);
                    if (lsContactName != "")
                    {
                        lsCompanyName = GrdView.Sheets[0].GetText(i, liColCompanyName);
                        lsMeetingContactID = GrdView.Sheets[0].GetText(i, liColMeetingContactID);
                        lsTypeMeeting = GrdView.Sheets[0].GetText(i, liColTypeMeetingContact);
                        lsPositionName = GrdView.Sheets[0].GetText(i, liColPositionName);
                        lsFlag = GrdView.Sheets[0].GetText(i, liColFlag);
                        lsMemID = GrdView.Sheets[0].GetText(i, liColMemID);
                        tmemnamet = GrdView.Sheets[0].Cells[i, colTmemNameT].Text;
                        memnamet = GrdView.Sheets[0].Cells[i, colMemNameT].Text;
                        contactid = GrdView.Sheets[0].Cells[i, colContactID].Text;
                        if (contactid == "")
                        {
                            contactid = "0";
                        }
                        if (Convert.ToBoolean(GrdView.Sheets[0].GetValue(i,liColFlagVisit)))
                        {
                            lsFlagVisit = "1";
                        }
                        else
                        {
                            lsFlagVisit = "0";
                        }
                        
                        if (lsMeetingContactID == "0")
                        {
                            lsTblMeeting.CreateMeetingContact(liMeeting, Convert.ToInt32(lsMeetingContactID), lsContactName, lsCompanyName, lsPositionName, lsTypeMeeting, "", lsFlagVisit, lsMemID, Meeting.FlagContact.Contact, tmemnamet, memnamet, contactid, lsGdb.Gdb);
                            GrdView.Sheets[0].Rows[i].BackColor = Color.Pink;
                        }
                        else
                        {
                            switch (lsFlag)
                            {
                                case "3":
                                    {
                                        lsTblMeeting.DeleteMeetingContact(liMeeting, Convert.ToInt32(lsMeetingContactID), lsGdb.Gdb);
                                        GrdView.Sheets[0].Rows[i].BackColor = Color.Pink;
                                        break;
                                    }
                                case "1":
                                    {
                                        //lsTblMeeting.UpdateMeetingContact(liMeeting, Convert.ToInt32(lsMeetingContactID), lsContactName, lsCompanyName, lsPositionName, lsTypeMeeting, "", lsGdb.Gdb);
                                        lsTblMeeting.CreateMeetingContact(liMeeting, Convert.ToInt32(lsMeetingContactID), lsContactName, lsCompanyName, lsPositionName, lsTypeMeeting, "", lsFlagVisit, lsMemID, Meeting.FlagContact.Contact, tmemnamet, memnamet, contactid, lsGdb.Gdb);
                                        GrdView.Sheets[0].Rows[i].BackColor = Color.Pink;
                                        break;
                                    }
                            }
                        }
                        //GrdView.Sheets[0].Rows[i].BackColor = Color.Pink;
                        Pb1.Value = i;
                        Application.DoEvents();
                    }
                    //lsTblMeeting.UpdateMeetingContactWithoutSelect(liMeeting, lsGdb.Gdb);
                }
            }
            catch (Exception e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล Meeting ได้ " ;
                lsGdb.WriteLogError(ls, e, "", "Create Meeting ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            Pb1.Visible = false;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            if (liMeeting>0)
            {
                MessageBox.Show("บันทึกข้อมูล  Meeting เรียบร้อย", "บันทึกข้อมูล");
            }
            return true;
        }
        private void saveclose_Click(object sender, EventArgs e)
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
            GrdView.Sheets[0].SetActiveCell(0, 0);
            SaveMeeting();
            CloseForm();
        }
        private void BtnClear_Click(object sender, EventArgs e)
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
            PaintGrdView();
            Int32 i = GrdView.Sheets[0].RowCount;
            lsTblMeeting.DeleteMeetingContactALL(Convert.ToInt32(TxtMeetingID.Text), lsGdb.Gdb);
            //GrdView.Sheets[0].SetText(0, liColCompanyName, "aaaaaaa");
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string ls = "";
            Int32 liSheetIndex = 0;
            MeetingSearchContact frm = new MeetingSearchContact();
            frm.Connnection = lsGdb.Gdb;
            switch (GrdView.ActiveSheet.SheetName)
            {
                case "ผู้มาประชุม":
                    {
                        frm.FlagMeetingContact = MeetingSearchContact.FlagContact.Contact;
                        break;
                    }
                case "กรรมการ":
                    {
                        frm.FlagMeetingContact = MeetingSearchContact.FlagContact.Committee;
                        break;
                    }
                case "ผู้สื่อข่าว":
                    {
                        frm.FlagMeetingContact = MeetingSearchContact.FlagContact.Reporter;
                        break;
                    }
            }
            frm.ShowDialog(this);
            if (frm.DataCount > 0)
            {
                switch (GrdView.ActiveSheet.SheetName)
                {
                    case "ผู้มาประชุม":
                        {
                            liSheetIndex = 0;
                            break;
                        }
                    case "กรรมการ":
                        {
                            liSheetIndex = 1;
                            break;
                        }
                    case "ผู้สื่อข่าว":
                        {
                            liSheetIndex = 2;
                            break;
                        }
                }
                GrdView.Sheets[liSheetIndex].AddRows(GrdView.Sheets[2].ActiveRowIndex, frm.DataCount);
                for (Int32 i = 0; i <= frm.DataCount - 1; i++)
                {
                    if (frm.DataArr[i, 2] != null)
                    {
                        ls = frm.DataArr[i, 2].ToString();
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, liColMeetingContactID, frm.DataArr[i, 0].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, liColMeetingContactName, frm.DataArr[i, 1].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, liColCompanyName, frm.DataArr[i, 2].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, liColPositionName, frm.DataArr[i, 3].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, liColTypeMeetingContact, frm.DataArr[i, 4].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, liColPrintLabel, frm.DataArr[i, 5].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, colTmemNameT, frm.DataArr[i, 6].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, colMemNameT, frm.DataArr[i, 7].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, colContactID, frm.DataArr[i, 8].ToString());
                        GrdView.Sheets[liSheetIndex].SetText(GrdView.Sheets[liSheetIndex].ActiveRowIndex + i, liColMemID, frm.DataArr[i, 9].ToString());
                    }
                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            GrdView.Sheets[0].AddRows(GrdView.Sheets[0].ActiveRowIndex, 1);
            GrdView.Sheets[0].SetText(GrdView.Sheets[0].ActiveRowIndex, liColFlag, "1");
            GrdView.Sheets[0].Cells[GrdView.Sheets[0].ActiveRowIndex, liColMeetingContactID, GrdView.Sheets[0].ActiveRowIndex, liColFlag].ForeColor = Color.Red;
            GrdView.Sheets[0].Cells[GrdView.Sheets[0].ActiveRowIndex, liColMeetingContactID, GrdView.Sheets[0].ActiveRowIndex, liColFlag].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            GrdView.Sheets[0].SetText(GrdView.Sheets[0].ActiveRowIndex, liColFlag, "3");
            GrdView.Sheets[0].Rows[GrdView.Sheets[0].ActiveRowIndex].BackColor = Color.DarkGray;
        }
        private void GrdView_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            GrdView.Sheets[0].SetText(e.Row, liColFlag, "1");
            GrdView.Sheets[0].Cells[e.Row, liColMeetingContactID, e.Row, liColFlag].ForeColor = Color.Red;
            GrdView.Sheets[0].Cells[e.Row, liColMeetingContactID, e.Row, liColFlag].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        }
        private void prnlistname_Click(object sender, EventArgs e)
        {
            GrdView.Sheets[0].SetActiveCell(0, 0);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            //lsTblMeeting.UpdateMeetingContactWithoutSelect(Convert.ToInt32(TxtMeetingID.Text), Pb1 , lsGdb.Gdb);
            Report Rpt = new Report();
            Rpt.PrintGrdMeeting(GrdView);
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            ReportView frm = new ReportView();
            frm.lsReportName = "rptmeetingsign";
            frm.HLine1 = TxtMeetingNameT.Text;
            frm.HLine2 = TxtDescription.Text;
            frm.HLine3 = TxtPlace.Text;
            frm.Show(this);
        }
        private void ExporttoWord(string aFlag, string aSort)
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
            string sql = "Select count(*) cnt From meetingcontact Where meetingid = '" + TxtMeetingID.Text + "' and contactname <> '' and flagvisit = '1'";
            if (aFlag == "1")
            {
                sql = "Select count(*) cnt From meetingcontact Where meetingid = '" + TxtMeetingID.Text + "' and contactname <> ''";
            }
            else
            {
                sql = "Select count(*) cnt From meetingcontact Where meetingid = '" + TxtMeetingID.Text + "' and contactname <> '' and flagvisit = '1'";
            }

            Int32 liCnt = 0, i = 0;
            MySqlCommand lsComm = new MySqlCommand(sql, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    liCnt = Convert.ToInt32(lsRead["cnt"].ToString());
                }
            }
            lsRead.Close();
            if (liCnt == 0)
            {
                MessageBox.Show("ไม่มีข้อมูล", "Export");
                return;
            }
            string[,] lsArr = new string[liCnt + 1, 4];
            if (aFlag == "1")
            {
                if (aSort == "memnamet")
                {
                    sql = "Select mc.contactname, mc.companyname, mc.tmemnamet, mc.memnamet, m.skk9id "
                        + "From meetingcontact mc left join member m on mc.memid = m.memid "
                        + "Where mc.meetingid = '" + TxtMeetingID.Text + "' and mc.contactname <> '' Order By mc.tmemnamet, mc.memnamet";
                }
                else
                {
                    sql = "Select mc.contactname, mc.companyname, mc.tmemnamet, mc.memnamet, m.skk9id "
                        + "From meetingcontact mc left join member m on mc.memid = m.memid "
                        + "Where mc.meetingid = '" + TxtMeetingID.Text + "' and mc.contactname <> '' Order By mc.tmemnamet, mc.memnamet";
                }
            }
            else
            {
                if (aSort == "memnamet")
                {
                    sql = "Select mc.contactname, mc.companyname, mc.tmemnamet, mc.memnamet, m.skk9id "
                        + "From meetingcontact mc left join member m on mc.memid = m.memid "
                        + "Where mc.meetingid = '" + TxtMeetingID.Text + "' and mc.contactname <> '' and mc.flagvisit = '1' Order By tmemnamet, mc.memnamet";
                }
                else
                {
                    sql = "Select mc.contactname, mc.companyname, mc.tmemnamet, mc.memnamet, m.skk9id "
                        + "From meetingcontact mc left join member m on mc.memid = m.memid "
                        + "Where mc.meetingid = '" + TxtMeetingID.Text + "' and mc.contactname <> '' and mc.flagvisit = '1' Order By mc.tmemnamet, mc.companyname";
                }
            }
            lsComm.CommandText = sql;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsArr[i, 0] = lsRead["contactname"].ToString();
                    lsArr[i, 1] = lsRead["memnamet"].ToString();
                    lsArr[i, 2] = lsRead["tmemnamet"].ToString();
                    lsArr[i, 3] = lsRead["skk9id"].ToString();
                    i++;
                }
            }
            lsRead.Close();

            string lsMeetingFileName = lsIni.GetString("thahr30", "exportmeetingfilename", "meeting.doc");


            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = TxtMeetingNameT.Text;
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();
            oPara1.Range.Text = TxtDescription.Text;
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();
            oPara1.Range.Text = TxtPlace.Text;

            //Insert a paragraph at the end of the document.
            //Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara2.Range.Text = "Heading 2";
            //oPara2.Format.SpaceAfter = 6;
            //oPara2.Range.InsertParagraphAfter();

            ////Insert another paragraph.
            //Word.Paragraph oPara3;
            //oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara3.Range.Text = "This is a sentence of normal text. Now here is a table:";
            //oPara3.Range.Font.Bold = 0;
            //oPara3.Format.SpaceAfter = 24;
            //oPara3.Range.InsertParagraphAfter();

            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, liCnt, 5, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;

            oTable.Columns[1].Width = oWord.InchesToPoints(1); //Change width of columns 1 & 2
            oTable.Columns[2].Width = oWord.InchesToPoints(3);
            oTable.Columns[3].Width = oWord.InchesToPoints(3);
            oTable.Columns[4].Width = oWord.InchesToPoints(4);
            oTable.Columns[5].Width = oWord.InchesToPoints(5);
            int r, c;
            string strText;
            for (r = 0; r <= liCnt - 1; r++)
                for (c = 0; c <= 5; c++)
                {
                    strText = "r" + r + "c" + c;
                    switch (c)
                    {
                        case 1:
                            {
                                oTable.Cell(r, c).Range.Text = r.ToString();
                                break;
                            }
                        case 2:
                            {
                                oTable.Cell(r, c).Range.Text = lsArr[r, 0].ToString();
                                break;
                            }
                        case 3:
                            {
                                oTable.Cell(r, c).Range.Text = lsArr[r, 1].ToString();
                                break;
                            }
                        case 4:
                            {
                                oTable.Cell(r, c).Range.Text = lsArr[r, 2].ToString();
                                break;
                            }
                        case 5:
                            {
                                oTable.Cell(r, c).Range.Text = lsArr[r, 3].ToString();
                                break;
                            }
                    }
                }
            //Add text after the chart.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("THE END.");


            //Process myProcess = new Process();
            //string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //myProcess.StartInfo.FileName = Application.StartupPath + "\\" + lsMeetingFileName;
            //myProcess.StartInfo.CreateNoWindow = true;
            //myProcess.Start();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            MessageBox.Show("Export to Word success", "Export");
        }
        private void print_Click(object sender, EventArgs e)
        {

        }
        private void printLabel_Click(object sender, EventArgs e)
        {
            GrdView.Sheets[0].SetActiveCell(0, 0);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            //lsTblMeeting.UpdateMeetingContactWithoutSelect(Convert.ToInt32(TxtMeetingID.Text), Pb1 , lsGdb.Gdb);
            Report Rpt = new Report();
            Rpt.PrintGrdMeetingLabel(GrdView, TxtMeetingNameT.Text, TxtDescription.Text, TxtPlace.Text);
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            ReportView frm = new ReportView();
            frm.lsReportName = "rptmeetinglabel";
            frm.HLine1 = TxtMeetingNameT.Text;
            frm.HLine2 = TxtDescription.Text;
            frm.HLine3 = TxtPlace.Text;
            frm.Show(this);
        }

        private void toWordSome_Click(object sender, EventArgs e)
        {
            
        }
        private void toWordAll_Click(object sender, EventArgs e)
        {
            
        }

        private void ex_sort_Thai_Click(object sender, EventArgs e)
        {
            ExporttoWord("2", "memnamet");
        }

        private void ex_sort_Eng_Click(object sender, EventArgs e)
        {
            ExporttoWord("2", "memnamee1");
        }

        private void ex_all_sort_Thai_Click(object sender, EventArgs e)
        {
            ExporttoWord("1", "memnamet");
        }

        private void ex_all_sort_Eng_Click(object sender, EventArgs e)
        {
            ExporttoWord("1", "memnamee1");
        }

        private void btnClearPrintLabel_Click(object sender, EventArgs e)
        {
            ClearPrintLabel(true);
        }

        private void btnSetPrintLabel_Click(object sender, EventArgs e)
        {
            ClearPrintLabel(false);
        }
    }
}