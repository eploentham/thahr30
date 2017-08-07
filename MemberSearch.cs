using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
namespace ThaHr30
{   
    public partial class MemberSearch : Form
    {
        System.Collections.ArrayList svCollection = new System.Collections.ArrayList(10);
        private Boolean lbPageLoad = false;
        Connection lsGdb = new Connection();
        public MemberSearch()
        {
            InitializeComponent();
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;            
            GrdView.Visible = false;
            Int16 liRow = 6;
            GrdView.ActiveSheet.RowCount = 0;
            GrdView.ActiveSheet.ColumnCount = 3;
            GrdView .Height = 682 ;
            GrdView.Width = 1017 ;
            GrdView.ActiveSheet.SetColumnWidth(0, 350);
            GrdView.ActiveSheet.SetColumnWidth(1, 605);            
            FarPoint.Win.Spread.CellType.ImageCellType cellPic = new FarPoint.Win.Spread.CellType.ImageCellType();
            cellPic.Style = FarPoint.Win.RenderStyle.Stretch;
            GrdView.Sheets[0].Columns[0].CellType = cellPic;
            FarPoint.Win.Spread.CellType.TextCellType cellText = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[1].CellType = cellText;
            GrdView.ActiveSheet.SetColumnLabel(0,0, "Hotel");
            GrdView.ActiveSheet.SetColumnLabel(0,1, "Description");
            GrdView.ActiveSheet.SetColumnVisible(2, false);
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.Sheets[0].RowHeader.Visible = false;
            GrdView.Sheets[0].ColumnHeader.Visible = false;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.Visible = true;
        }
        private void SelectPicture(string aProvCode, string aLocationCode, string aMemid)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();            
            string lsSQL = "", lsFileName="", lsPath = Application.StartupPath + "\\member", lsMemID="" ;
            Int32 i = 0;
            //MessageBox.Show("lsPath " + lsPath, "lsMemID " + lsMemID);
            if (aProvCode != "")
            {
                if (aProvCode != "10")
                {
                    lsSQL = "Select count(*) as cnt From memberpicture p, member m Where p.memid = m.memid and m.provcode = '" + aProvCode + "'";
                }
                else if (aLocationCode != "")
                {
                    lsSQL = "Select count(*) as cnt From memberpicture p, member m "
                        + "Where p.memid = m.memid and m.provcode = '" + aProvCode + "' and m.locationcode = '" + aLocationCode + "'";
                }                
            }
            else if (aMemid !="")
                {
                    lsSQL = "Select count(*) as cnt From memberpicture p, member m Where p.memid = m.memid and m.memid = '" + aMemid + "'";
                }
            else
            {
                lsSQL = "Select count(*) as cnt From memberpicture p, member m Where p.memid = m.memid and m.locationcode = '" + aLocationCode + "'";
            }
            //MessageBox.Show("lsSQL " + lsSQL, "lsMemID " + lsSQL);
            MySqlCommand Comm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = Comm1.ExecuteReader();
            if (lsRead1.HasRows)
            {
                while (lsRead1.Read())
                {
                    i = Convert.ToInt16(lsRead1["cnt"]);
                }
            }
            lsRead1.Close();
            GrdView.ActiveSheet.RowCount = i;
            i = 0;
            if (aProvCode != "")
            {
                if (aProvCode != "10")
                {
                    lsSQL = "Select p.* From memberpicture p, member m "
                        + "Where p.memid = m.memid and substring(picid,6,3) = 100 and m.provcode = '" + aProvCode + "'";
                }
                else if (aLocationCode != "")
                {
                    lsSQL = "Select p.* From memberpicture p, member m "
                        + "Where p.memid = m.memid and substring(picid,6,3) = 100 and m.provcode = '" + aProvCode + "' and m.locationcode = '" + aLocationCode + "'";
                }                
            }
            else if (aMemid != "")
            {
                lsSQL = "Select p.* From memberpicture p, member m "
                    + "Where p.memid = m.memid and substring(picid,6,3) = 100 and m.memid = '" + aMemid + "'";
            }
            else
            {
                lsSQL = "Select p.* From memberpicture p, member m "
                        + "Where p.memid = m.memid and substring(picid,6,3) = 100 and m.locationcode = '" + aLocationCode + "'";
            }
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {                    
                    lsFileName = "";
                    lsMemID = "";
                    lsFileName = lsRead["filename"].ToString();
                    lsMemID = lsRead["memid"].ToString();
                    //MessageBox.Show("lsPath1 " + lsPath, "lsMemID1 " + lsMemID);
                    Image img = Image.FromFile(lsPath + "\\" + lsMemID + "\\" + lsFileName);
                    GrdView.Sheets[0].Cells[i, 0].Value = img;
                    GrdView.Sheets[0].Cells[i, 1].Value = lsMemID;
                    GrdView.Sheets[0].SetRowHeight(i, 270);
                    //GrdView.ActiveSheet.SetText(i, 0, lsRead["picid"].ToString());
                    //GrdView.ActiveSheet.SetText(i, 1, lsRead["desct"].ToString());

                    i++;
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            lbPageLoad = true;
            lsGdb.ConnectDatabase();
            lsGdb.SelectCbo(CboProv.ComboBox, "", Connection.TableIniT.Province);
            //lsGdb.SelectCbo(CboMember.ComboBox, "", Connection.TableIniT.Member);
            lsGdb.SelectCbo(CboLocation.ComboBox, "", Connection.TableIniT.Location);
            PaintGrdView();
            lbPageLoad = false;
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        //if (MessageBox.Show("Do you exit Program", "Exit Program", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        //{
                        //    Application.Exit();
                        //}
                        CloseFrm();
                        break;
                    }
                case Keys.PageUp:
                    //axWindowsMediaPlayer1.Ctlcontrols.stop();
                    //axWindowsMediaPlayer1.Ctlcontrols.play();
                    //axWindowsMediaPlayer2.Ctlcontrols.play();
                    break;
                case Keys.F2:
                    VoucherAdd lsReserveForm = new VoucherAdd();
                    lsReserveForm.ShowDialog(this);
                    break;
                case Keys.F6:
                    MemberAdd lsMemberAdd = new MemberAdd();
                    lsMemberAdd.ShowDialog(this);
                    break;
                case Keys.F7:
                    ShopSendData lsSendData = new ShopSendData();
                    lsSendData.ShowDialog(this);
                    break;
            }
        }
        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {            
            //GrdView .ActiveSheet .geta
            MemberPicture lsViewPic = new MemberPicture();            
            lsViewPic.lsHotelCode = GrdView.ActiveSheet.GetText(e.Row, 2);
            lsViewPic.MemID = GrdView.Sheets[0].Cells[e.Row, 1].Value.ToString();
            lsViewPic.ShowDialog(this);
            lsViewPic.Activate();
        }
        private void CloseFrm()
        {
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            CloseFrm();
        }

        private void CboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                lbPageLoad = true;
                lsGdb.SelectCbo(CboMember.ComboBox, CboProv.ComboBox.SelectedValue.ToString(), Connection.TableIniT.Member);
                if (CboProv.ComboBox.SelectedValue.ToString() != "10")
                {
                    SelectPicture(CboProv.ComboBox.SelectedValue.ToString(), CboLocation.ComboBox.SelectedValue.ToString(),"");
                }
                else
                {
                    GrdView.Sheets[0].RowCount = 0;
                }
                lbPageLoad = false;
            }
        }

        private void CboProv_Click(object sender, EventArgs e)
        {

        }

        private void CboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                lbPageLoad = true;
                lsGdb.SelectCbo(CboMember.ComboBox, CboProv.ComboBox.SelectedValue.ToString(), Connection.TableIniT.Member);
                if (CboProv.ComboBox.SelectedValue.ToString() == "10")
                {
                    SelectPicture(CboProv.ComboBox.SelectedValue.ToString(), CboLocation.ComboBox.SelectedValue.ToString(),"");
                }
                else 
                {
                    SelectPicture(CboProv.ComboBox.SelectedValue.ToString(), CboLocation.ComboBox.SelectedValue.ToString(),"");
                }
                lbPageLoad = false;
            }
        }

        private void GrdView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void CboLocation_Click(object sender, EventArgs e)
        {

        }

        private void CboMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                lbPageLoad = true;
                SelectPicture("", "", CboMember.ComboBox.SelectedValue.ToString());
                lbPageLoad = false;
            }
        }
    }    
}