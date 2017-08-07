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
    public partial class StaffPrivileges : Form
    {
        Int32 liColScreenName = 1, liColView = 3, liColAdd = 4, liColEdit = 5, liColDele =6, liColNodeParentID=7, liColGroup=0, liColNameT=2;
        string lsStaffName="";
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile();
        Staff lstblStaff = new Staff();
        Boolean lbPageLoad = false;
        private string lsStaffID = "";
        FarPoint.Win.Spread.Column colPrivileges;
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
        public string StaffName
        {
            get
            {
                return lsStaffName;
            }
            set
            {
                lsStaffName = value;
            }
        }
        public StaffPrivileges()
        {
            InitializeComponent();
        }
        private void PaintGrdGroup()
        {
            GrdGroup.Visible = false;
            GrdGroup.Reset();
            GrdGroup.BorderStyle = BorderStyle.None;
            GrdGroup.ActiveSheet.RowCount = 2;
            GrdGroup.ActiveSheet.ColumnCount = 8;
            GrdGroup.Height = this.Height - 130;
            GrdGroup.Width = this.Width - 30;
            GrdGroup.Top = 65;
            GrdGroup.Left = 12;
            GrdGroup.ActiveSheet.SetColumnWidth(liColGroup, 100);
            GrdGroup.ActiveSheet.SetColumnWidth(liColNameT , 180);
            GrdGroup.ActiveSheet.SetColumnWidth(liColScreenName , 150);
            GrdGroup.ActiveSheet.SetColumnWidth(liColView , 50);
            GrdGroup.ActiveSheet.SetColumnWidth(liColAdd , 50);
            GrdGroup.ActiveSheet.SetColumnWidth(liColEdit , 50);
            GrdGroup.ActiveSheet.SetColumnWidth(liColDele , 50);
            GrdGroup.ActiveSheet.SetColumnLabel(0, liColGroup, "Group");
            GrdGroup.ActiveSheet.SetColumnLabel(0, liColScreenName, "screenname");
            GrdGroup.ActiveSheet.SetColumnLabel(0, liColNameT, "หน้าจอการทำงาน");
            GrdGroup.ActiveSheet.SetColumnLabel(0, liColView, "ดูข้อมูล");
            GrdGroup.ActiveSheet.SetColumnLabel(0, liColAdd, "เพิ่ม");
            GrdGroup.ActiveSheet.SetColumnLabel(0, liColEdit, "แก้ไข");
            GrdGroup.ActiveSheet.SetColumnLabel(0, liColDele, "ลบ");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdGroup.ActiveSheet.Columns[liColScreenName, liColScreenName];
            col.Locked = true;
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellChk = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            col = GrdGroup.ActiveSheet.Columns[liColView, liColDele];
            col.CellType = cellChk;
            FarPoint.Win.Spread.CellType.TextCellType cellText = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdGroup.ActiveSheet.Columns[liColNodeParentID, liColNodeParentID];
            col.CellType = cellText;
            col.Visible = false;
            //GrdGroup.Sheets[0].Cells[liColView, liColDele].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            GrdGroup.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdGroup.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdGroup.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdGroup.Visible = true;
        }
        //private void SelectGroup()
        //{
        //    PaintGrdGroup();
        //    string lsSQL = "";
        //    TreeNode ltN;
        //    TvwStaffGroup.Nodes.Clear();
        //    lsSQL = "Select * From staffgroup Where flag = '1'";
        //    MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
        //    MySqlDataReader lsRead;
        //    lsRead = Comm.ExecuteReader();
        //    if (lsRead.HasRows)
        //    {
        //        ltN = new TreeNode("กลุ่มผู้ใช้งาน");
        //        TvwStaffGroup.Nodes.Add(ltN);
        //        TvwStaffGroup.SelectedNode = ltN;
        //        while (lsRead.Read())
        //        {
        //            try
        //            {
        //                ltN = new TreeNode(lsRead ["groupname"].ToString());
        //                TvwStaffGroup.SelectedNode.Nodes.Add(ltN);
        //            }
        //            catch (Exception e)
        //            {
        //                MessageBox.Show(e.Message.ToString(), e.Source.ToString());
        //            }
        //        }
        //    }
        //    lsRead.Close();
        //}
        private void SelectStaffPrivileges(string aStaffID)
        {
            PaintGrdGroup();
            Int32 i=0, liCount=0;
            string lsSQL = "", lsScreenName="";
            Boolean lbView = false, lbAdd = false, lbEdit = false, lbDele = false;
            lsSQL = "Select count(screenname) cnt From screenname Where flag = '1' ";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    liCount = Convert.ToInt32(lsRead["cnt"]);
                }
            }
            lsRead.Close();
            ClearNew();
            GrdGroup.ActiveSheet.RowCount = liCount+1;
            lsSQL = "Select * From screenname Where flag = '1' Order By  sort1";
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            ClearNew();
            if (lsRead.HasRows)
            {
                
                while (lsRead.Read())
                {
                    try
                    {
                        lsSQL = lsRead["groupname"].ToString();
                        lsSQL = lsRead["nodenamet"].ToString();
                        lsSQL = lsRead["screenname"].ToString();
                        GrdGroup.ActiveSheet.SetText(i, liColGroup, lsRead["groupname"].ToString());
                        GrdGroup.ActiveSheet.SetText(i, liColNameT, lsRead["nodenamet"].ToString());
                        GrdGroup.ActiveSheet.SetText(i, liColScreenName, lsRead["screenname"].ToString());
                        GrdGroup.ActiveSheet.SetValue(i, liColNodeParentID, lsRead["nodeid"].ToString());
                        i++;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString(), e.Source.ToString());
                    }
                    if ((i % 2) != 0)
                    {
                        GrdGroup.ActiveSheet.Rows[i].BackColor = Color.LightGoldenrodYellow;
                    }
                }
            }
            lsRead.Close();
            for (i = 0; i <= GrdGroup.ActiveSheet.RowCount - 1; i++)
            {
                lsScreenName = GrdGroup.ActiveSheet.GetText(i, liColScreenName);
                lsSQL = "Select * From staffprivileges Where staffid = '" + lsStaffID + "' and screenname = '" + lsScreenName + "'";
                lsComm.CommandText = lsSQL;
                lsRead = lsComm.ExecuteReader();
                if (lsRead.HasRows)
                {
                    while (lsRead.Read())
                    {
                        lbView = false;
                        lbAdd = false;
                        lbEdit = false;
                        lbDele = false;
                        lbView = Convert.ToBoolean(lsRead["privilegesview"]);
                        lbAdd = Convert.ToBoolean(lsRead["privilegesadd"]);
                        lbEdit = Convert.ToBoolean(lsRead["privilegesedit"]);
                        lbDele = Convert.ToBoolean(lsRead["privilegesdele"]);
                        GrdGroup.ActiveSheet.SetValue(i, liColView, lbView);
                        GrdGroup.ActiveSheet.SetValue(i, liColAdd, lbAdd);
                        GrdGroup.ActiveSheet.SetValue(i, liColEdit, lbEdit);
                        GrdGroup.ActiveSheet.SetValue(i, liColDele, lbDele);
                    }
                }
                lsRead.Close();
            }
            if (GrdGroup.ActiveSheet.RowCount > 27)
            {
                GrdGroup.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
        }
        private Boolean SaveStaffPrivileges()
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
            string lsColView = "", lsColAdd="", lsColEdit="", lsColDele="", lsNodeParentID="";
            lstblStaff.DeleteStaffPrivilegesAll(lsStaffID, lsGdb.Gdb);
            for (Int32 i = 0; i <= GrdGroup.ActiveSheet.RowCount - 1; i++)
            {
                try
                {
                    lsColView = "";
                    lsColAdd = "";
                    lsColEdit = "";
                    lsColDele = "";
                    lsColView = GrdGroup.ActiveSheet.GetText(i, liColView);
                    lsColAdd = GrdGroup.ActiveSheet.GetText(i, liColAdd);
                    lsColEdit = GrdGroup.ActiveSheet.GetText(i, liColEdit);
                    lsColDele = GrdGroup.ActiveSheet.GetText(i, liColDele);
                    lsNodeParentID = GrdGroup.ActiveSheet.GetText(i, liColNodeParentID);
                    if (lsColView == "")
                    {
                        lsColView = "False";
                    }
                    if (lsColAdd == "")
                    {
                        lsColAdd = "False";
                    }
                    if (lsColEdit == "")
                    {
                        lsColEdit = "False";
                    }
                    if (lsColDele == "")
                    {
                        lsColDele = "False";
                    }
                    lstblStaff.CreateStaffPrivileges(lsStaffID, GrdGroup.ActiveSheet.GetText(i, liColScreenName), lsColView, lsColAdd, lsColEdit, lsColDele, lsNodeParentID, lsGdb.Gdb);
                }
                catch (Exception e)
                {
                    string ls = "ไม่สามารถบันทึกข้อมูล Staff ได้ ";
                    lsGdb.WriteLogError(ls, e, "", "SaveStaffPrivileges ");
                    MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            return true;
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void StaffGroup_Load(object sender, EventArgs e)
        {
            lbPageLoad = true;
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
            SelectStaffPrivileges(lsStaffID);
            lbPageLoad = false;
        }
        private void ClearNew()
        {
            TxtStaffName.Text = "";
        }
        private void SetGrdPrivileges(Int32 aRow, Boolean aFlag)
        {
            if (aFlag==true)
            {
                //colPrivileges = GrdGroup.ActiveSheet.cell
                GrdGroup.ActiveSheet.Cells[aRow, liColAdd].Locked = true;
                GrdGroup.ActiveSheet.Cells[aRow, liColEdit].Locked = true;
                GrdGroup.ActiveSheet.Cells[aRow, liColDele].Locked = true;
            }
            else 
            {
                GrdGroup.ActiveSheet.Cells[aRow, liColAdd].Locked = false ;
                GrdGroup.ActiveSheet.Cells[aRow, liColEdit].Locked = false;
                GrdGroup.ActiveSheet.Cells[aRow, liColDele].Locked = false;
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void newgroup_Click(object sender, EventArgs e)
        {
            ClearNew();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (SaveStaffPrivileges() == true)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล", MessageBoxButtons.OK);
            }
        }

        private void GrdGroup_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
        }

        private void GrdGroup_Click(object sender, EventArgs e)
        {
            
        }

        private void GrdGroup_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == liColView)
            {
                //string lsFlag = GrdGroup.ActiveSheet.GetValue(e.Row, liColView).ToString();
                //if (lsFlag == "True")
                //{
                //    SetGrdPrivileges(e.Row, true);
                //}
                //else
                //{
                //    SetGrdPrivileges(e.Row, false);
                //}
            }
        }
    }
}