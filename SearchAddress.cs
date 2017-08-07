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
    public partial class SearchAddress : Form
    {
        private string lsSubDistrictNameT="", lsDistrictNameT="", lsProvNameT="", lsPostCode="", lsSubDistrictCode="", lsDistrictCode="", lsProvCode="";
        private string lsChar = "", lsSubDistrictNameE = "", lsDistrictNameE = "", lsProvNameE = "";
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile();
        Boolean lbPageLoad = false;
        public SearchAddress()
        {
            InitializeComponent();
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
        public string  ProvNameT
        {
            get
            {
                return lsProvNameT;
            }
            set
            {
                lsProvNameT = value.Trim();
            }
        }
        public string ProvNameE
        {
            get
            {
                return lsProvNameE;
            }
            set
            {
                lsProvNameE = value.Trim();
            }
        }
        public string SubDistrictNameT
        {
            get
            {
                return lsSubDistrictNameT;
            }
            set
            {
                lsSubDistrictNameT = value.Trim();
            }
        }
        public string SubDistrictNameE
        {
            get
            {
                return lsSubDistrictNameE;
            }
            set
            {
                lsSubDistrictNameE = value.Trim();
            }
        }
        public string DistrictNameT
        {
            get
            {
                return lsDistrictNameT;
            }
            set
            {
                lsDistrictNameT = value.Trim();
            }
        }
        public string DistrictNameE
        {
            get
            {
                return lsDistrictNameE;
            }
            set
            {
                lsDistrictNameE = value.Trim();
            }
        }
        public string ProvCode
        {
            get
            {
                return lsProvCode;
            }
            set
            {
                lsProvCode = value.Trim();
            }
        }
        public string SubDistrictCode
        {
            get
            {
                return lsSubDistrictCode;
            }
            set
            {
                lsSubDistrictCode = value.Trim();
            }
        }
        public string DistrictCode
        {
            get
            {
                return lsDistrictCode;
            }
            set
            {
                lsDistrictCode = value.Trim();
            }
        }
        public string PostCode
        {
            get
            {
                return lsPostCode;
            }
            set
            {
                lsPostCode = value.Trim();
            }
        }
        private void SearchAddress_Load(object sender, EventArgs e)
        {

        }

        private void CboSubDistrict_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            lsGdb.SelectCbo(CboSubDistrict, e.KeyChar.ToString(), Connection.TableIniT.SubDistrict);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void CboSubDistrict_DropDownClosed(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                if (CboSubDistrict.SelectedValue.ToString() != null)
                {
                    lsGdb.SelectCboProvDistrSubDistr(CboProvName, CboDistrict, CboSubDistrict, TxtPostCode, CboSubDistrict.SelectedValue.ToString(), Connection.TableIniT.CboDistrictFromSubDistrict);
                    lsSubDistrictNameE = lsGdb.SubDistrictNameE;
                    lsDistrictNameE = lsGdb.DistrictNameE;
                    lsProvNameE = lsGdb.ProvNameE;
                }
            }
            catch (Exception ea)
            {
                string ls = "";
                ls = "1";
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            
            lsPostCode = CboSubDistrict.Text;
            lsSubDistrictNameT = CboSubDistrict.Text;
            lsDistrictNameT = CboDistrict.Text;
            lsProvNameT = CboProvName.Text;
            lsPostCode = TxtPostCode.Text;
            lsProvCode = CboProvName.SelectedValue.ToString();
            lsSubDistrictCode = CboSubDistrict.SelectedValue.ToString();
            lsDistrictCode = CboDistrict.SelectedValue.ToString();            
            CloseForm();
        }

        private void CboSubDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CboSubDistrict_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void CboProvName_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            lsGdb.SelectCbo(CboProvName, "", Connection.TableIniT.Province);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void CboProvName_DropDownClosed(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                if (CboProvName.SelectedValue.ToString() != null)
                {
                    lsGdb.SelectCbo(CboDistrict, CboProvName.SelectedValue.ToString(), Connection.TableIniT.District);
                }
                TxtPostCode.Text = "";
            }
            catch (Exception ea)
            {
                string ls = "";
                ls = "1";
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void CboDistrict_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                if (CboDistrict.SelectedValue.ToString() != null)
                {
                    lsGdb.SelectCbo(CboSubDistrict, CboDistrict.SelectedValue.ToString(), Connection.TableIniT.SubDistrict);
                }
                TxtPostCode.Text = "";
            }
            catch (Exception ea)
            {
                string ls = "";
                ls = "1";
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void CboDistrict_DropDownClosed(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                if (CboDistrict.SelectedValue.ToString() != null)
                {
                    lsGdb.SelectCbo(CboSubDistrict, CboDistrict.SelectedValue.ToString(), Connection.TableIniT.CboSubDistrictFromDistrict);
                }
            }
            catch (Exception ea)
            {
                string ls = "";
                ls = "1";
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
    }
}