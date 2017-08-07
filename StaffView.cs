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
    public partial class StaffView : Form
    {
        Int32 liColStaffID = 0, liColSatffName = 1, liColIDCard = 2, liColStaffType = 3, liColUserName = 4;
        string flagstaff = "";
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        FlagStaff flagStaff;
        public enum FlagStaff
        {
            Staff, Committee, PR, Guess
        }
        public FlagStaff FlagStafF
        {
            get
            {
                if (flagstaff == "1")
                {
                    flagStaff = FlagStaff.Staff;
                }
                else if (flagstaff == "2")
                {
                    flagStaff = FlagStaff.Committee;
                }
                else if (flagstaff == "3")
                {
                    flagStaff = FlagStaff.PR;
                }
                else if (flagstaff == "4")
                {
                    flagStaff = FlagStaff.Guess;
                }
                else
                {
                    flagStaff = FlagStaff.Staff;
                }
                return flagStaff;
            }
            set
            {
                flagStaff = value;
                if (flagStaff == FlagStaff.Staff)
                {
                    flagstaff = "1";
                }
                else if (flagStaff == FlagStaff.Committee)
                {
                    flagstaff = "2";
                }
                else if (flagStaff == FlagStaff.PR)
                {
                    flagstaff = "3";
                }
                else if (flagStaff == FlagStaff.Guess)
                {
                    flagstaff = "4";
                }
                else
                {
                    flagstaff = "3";
                }
            }
        }
        public StaffView()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
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
        private void PaintGrdView()
        {
            GrdView.Visible = false;
            GrdView.Reset();
            GrdView.ActiveSheet.RowCount = 1;
            GrdView.ActiveSheet.ColumnCount = 5;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 30;
            GrdView.Top = 35;
            GrdView.Left = 12;
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.ActiveSheet.Columns[0, liColUserName];
            col.CellType = cell;
            GrdView.ActiveSheet.SetColumnWidth(liColStaffID, 105);
            GrdView.ActiveSheet.SetColumnWidth(liColSatffName, 300);
            GrdView.ActiveSheet.SetColumnWidth(liColIDCard, 65);
            GrdView.ActiveSheet.SetColumnWidth(liColStaffType, 150);
            GrdView.ActiveSheet.SetColumnWidth(liColUserName, 150);
            if (flagStaff == FlagStaff.Staff)
            {
                GrdView.ActiveSheet.SetColumnLabel(0, liColStaffID, "StaffID");
                GrdView.ActiveSheet.SetColumnLabel(0, liColSatffName, "Staff Name");
                NewStaff.Text = " New Staff";
            }
            else if (flagStaff == FlagStaff.Committee)
            {
                GrdView.ActiveSheet.SetColumnLabel(0, liColStaffID, "CommitteeID");
                GrdView.ActiveSheet.SetColumnLabel(0, liColSatffName, "Committee Name");
                NewStaff.Text = " New Committee";
            }
            else if (flagStaff == FlagStaff.PR)
            {
                GrdView.ActiveSheet.SetColumnLabel(0, liColStaffID, "ID");
                GrdView.ActiveSheet.SetColumnLabel(0, liColSatffName, " Name");
                NewStaff.Text = " New ผู้สื่อข่าว";
            }
            else if (flagStaff == FlagStaff.Guess)
            {
                GrdView.ActiveSheet.SetColumnLabel(0, liColStaffID, "Guess ID");
                GrdView.ActiveSheet.SetColumnLabel(0, liColSatffName, "Guess Name");
                NewStaff.Text = " New Guess";
            }
            GrdView.ActiveSheet.SetColumnLabel(0, liColIDCard, "ID");
            GrdView.ActiveSheet.SetColumnLabel(0, liColStaffType, "Type");
            GrdView.ActiveSheet.SetColumnLabel(0, liColUserName, "UserName");
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.ActiveSheet.Columns[0, liColUserName].AllowAutoSort = true;
            GrdView.ActiveSheet.Columns[0, liColUserName].AllowAutoFilter = true;
            GrdView.Visible = true;
            GrdView.AllowColumnMove = true;
        }
        private Boolean SelectStaff()
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
            Boolean lbReturn = true;
            string lsSQL = "";
            Int32 i = 0, j = 0;
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            lsSQL = "Select count(*) as cnt From staff Where flagstaff = '"+ flagstaff + "'";
            MySqlCommand Comm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = Comm1.ExecuteReader();
            while (lsRead1.Read())
            {
                i = Convert.ToInt32(lsRead1["cnt"].ToString());
            }
            lsRead1.Close();
            GrdView.ActiveSheet.RowCount = i + 1;
            lsSQL = "Select * From staff Where flagstaff = '" + flagstaff + "' Order By staffname";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            i = 0;
            Pb1.Minimum = 0;
            Pb1.Maximum = GrdView.ActiveSheet.RowCount;
            Pb1.Visible = true;
            SL1.Visible = true;
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    j = i;
                    GrdView.ActiveSheet.SetText(i, liColStaffID, lsRead["staffcode"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColSatffName, lsRead["staffname"].ToString() + " " + lsRead ["staffsurname"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColIDCard, lsRead["id"].ToString());
                    //GrdView.ActiveSheet.SetText(i, liColStaffType, lsRead["username"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColUserName, lsRead["username"].ToString());
                    Pb1.Value = i;
                    SL1.Text = i.ToString() + " / " + (GrdView.ActiveSheet.RowCount - 1);
                    j = i % 2;
                    if ((j % 2) != 0)
                    {
                        GrdView.ActiveSheet.Rows[i].BackColor = Color.LightGoldenrodYellow;
                    }
                    i++;
                    //Application.DoEvents();
                }
            }
            else
            {
                lbReturn = false;
            }
            Pb1.Visible = false;
            SL1.Visible = false;
            lsRead.Close();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            return lbReturn;
        }
        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
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
            StaffAdd frmStaffAdd = new StaffAdd();
            frmStaffAdd.Connnection = lsGdb.Gdb;
            frmStaffAdd.FlagStafF = (StaffAdd.FlagStaff)flagStaff;
            frmStaffAdd.lsStaffID = GrdView.ActiveSheet.GetText(e.Row, 0);
            frmStaffAdd.Connnection = lsGdb.Gdb;
            frmStaffAdd.ShowDialog(this);
            SelectStaff();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void StaffView_Load(object sender, EventArgs e)
        {
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                if (lsGdb.ConnectDatabase() == false)
                {
                    CloseForm();
                }
            }
            //PaintGrdView();
            SelectStaff();
        }
        private void NewStaff_Click(object sender, EventArgs e)
        {
            StaffAdd lsFrm = new StaffAdd();
            lsFrm.Connnection = lsGdb.Gdb;
            lsFrm.FlagStafF = (StaffAdd.FlagStaff)flagStaff;
            lsFrm.FlagNew = true;
            lsFrm.ShowDialog(this);
            SelectStaff();
        }

    }
}