using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ThaHr30
{
    public partial class MeetingView : Form
    {
        private Int32 liColMeetingID = 0, liColMeetingNameE = 1, liColPlace = 2, liColStartDate = 3, liColEndDate = 4;
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile();
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
        private void PaintGrdView()
        {

            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            GrdView.Reset();
            GrdView.ActiveSheet.RowCount = 1;
            GrdView.ActiveSheet.ColumnCount = 5;
            GrdView.Height = this.Height - 60;
            GrdView.Width = this.Width - 30;
            GrdView.Top = 35;
            GrdView.Left = 12;

            FarPoint.Win.Spread.CellType.TextCellType cellTxt = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[liColMeetingID, liColEndDate].CellType = cellTxt;
            GrdView.Sheets[0].Columns[liColMeetingID].Visible = false;

            GrdView.ActiveSheet.SetColumnWidth(liColMeetingID, 72);
            GrdView.ActiveSheet.SetColumnWidth(liColMeetingNameE, 300);
            GrdView.ActiveSheet.SetColumnWidth(liColPlace, 300);
            GrdView.ActiveSheet.SetColumnWidth(liColStartDate, 90);
            GrdView.ActiveSheet.SetColumnWidth(liColEndDate, 90);

            GrdView.ActiveSheet.SetColumnLabel(0, liColMeetingID, "meetingid");
            GrdView.ActiveSheet.SetColumnLabel(0, liColMeetingNameE, "ชื่อการประชุม");
            GrdView.ActiveSheet.SetColumnLabel(0, liColPlace, "สถานที่ประชุม");
            GrdView.ActiveSheet.SetColumnLabel(0, liColStartDate, "วันที่ประชุม");
            GrdView.ActiveSheet.SetColumnLabel(0, liColEndDate, "ถึงวันที่");

            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Visible = true;

            GrdView.ActiveSheet.Columns[liColMeetingID, liColEndDate].AllowAutoSort = true;
            GrdView.ActiveSheet.Columns[liColMeetingID, liColEndDate].AllowAutoFilter = true;
            
            GrdView.AllowColumnMove = true;
        }
        private void SelectMeeting(string aYear)
        {
            Int32 i = 0, liCnt=0;
            string lsSQL = "Select count(*) cnt From meeting Where year = '" + aYear + "'";
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
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    if (lsRead["cnt"].ToString() =="0")
                    {
                        liCnt = 0;
                    }
                    else 
                    {
                        liCnt = Convert.ToInt32(lsRead["cnt"]);
                    }                    
                }
            }
            lsRead.Close();
            GrdView.ActiveSheet.RowCount = liCnt;
            lsSQL = "Select * From meeting Where year = '" + aYear + "'";
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    GrdView.ActiveSheet.SetText(i, liColMeetingID, lsRead["meetingid"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColMeetingNameE, lsRead["meetingnamet"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColPlace, lsRead["place"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColStartDate, lsGdb.SelectDateBudda(Convert.ToDateTime(lsRead["meetingstartdate"].ToString())));
                    GrdView.ActiveSheet.SetText(i, liColEndDate, lsGdb.SelectDateBudda(Convert.ToDateTime(lsRead["meetingenddate"].ToString())));
                    i++;
                }
            }
            lsRead.Close();
        }
        public MeetingView()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void MemberMeetingView_Load(object sender, EventArgs e)
        {
            PaintGrdView();
            Pb1.Visible = false;
            SL1.Visible = false;
            Int32 liYear = System.DateTime.Now.Year;
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                if (lsGdb.ConnectDatabase() == false)
                {
                    CloseForm();
                }
            }
            else
            {
                lsGdb.Gdb.Close();
                lsGdb.Gdb.Open();
                //lsGdb.ConnectDatabase();
            }
            SelectMeeting(liYear.ToString());
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            MeetingAdd frm = new MeetingAdd();
            frm.Connnection = lsGdb.Gdb;
            frm.MeetingID = GrdView.ActiveSheet.GetText(e.Row, liColMeetingID);
            frm.ShowDialog();
            SelectMeeting(System.DateTime.Now.Year.ToString());
        }

        private void NewMember_Click(object sender, EventArgs e)
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
            MeetingAdd frm = new MeetingAdd();
            frm.Connnection = lsGdb.Gdb;
            frm.MeetingID = "";
            frm.ShowDialog(this);
            SelectMeeting("2007");
        }

        private void MeetingView_Activated(object sender, EventArgs e)
        {
            //SelectMeeting("2007");
        }
    }
}