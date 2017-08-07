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
    public partial class MemberCopyAddress : Form
    {
        private string lsSubDistrictCodeAddress = "", lsDistrictCodeAddress = "", lsProvCodeAddress = "", lsMemNameE="", lsMemID="";
        Boolean lbPageLoad = false;
        Int32 liAddressIDOLD = 0, liAddressID=0;
        Connection lsGdb = new Connection();
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
        public string MemID
        {
            get
            {
                return lsMemID;
            }
            set
            {
                lsMemID = value.Trim();
            }
        }
        public string MemNameE
        {
            get
            {
                return lsMemNameE;
            }
            set
            {
                lsMemNameE = value.Trim();
            }
        }
        public Int32 AddressIDOLD
        {
            get
            {
                return liAddressIDOLD;
            }
            set
            {
                liAddressIDOLD = value;
            }
        }
        private void SelectAddress(Int32 aAddressID)
        {
            lbPageLoad = true;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select a.*, p.provnamet, p.provnamee, d.districtnamet, d.districtnamee, s.subdistrictnamet, s.subdistrictnamee "
                + "From address a LEFT JOIN province p on a.provcode = p.provcode LEFT JOIN district d on a.districtcode = d.districtcode "
                + "LEFT JOIN subdistrict s on a.subdistrictcode = s.subdistrictcode "
                + "Where addressid = " + aAddressID;
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        lsSQL = lsRead["addressname"].ToString();
                        liAddressIDOLD = Convert.ToInt32(lsRead["addressid"]);
                        CboAddress.SelectedValue = lsRead["addresscode"].ToString();
                        CboAddressNew.SelectedValue = lsRead["addresscode"].ToString();
                        TxtMemNameEAddress.Text = lsMemNameE;
                        TxtMemNameEAddressNew.Text = lsMemNameE;
                        TxtAddressNameAddress.Text = lsRead["addressname"].ToString();
                        TxtAddressNameAddressNew.Text = lsRead["addressname"].ToString();
                        TxtEmailAddress.Text = lsRead["email"].ToString();
                        TxtEmailAddressNew.Text = lsRead["email"].ToString();
                        TxtWebSiteAddress.Text = lsRead["website"].ToString();
                        TxtWebSiteAddressNew.Text = lsRead["website"].ToString();
                        TxtPostCodeAddress.Text = lsRead["postcode"].ToString();
                        TxtPostCodeAddressNew.Text = lsRead["postcode"].ToString();
                        TxtTelephoneAddress.Text = lsRead["telephone"].ToString();
                        TxtTelephoneAddressNew.Text = lsRead["telephone"].ToString();
                        TxtLine1.Text = lsRead["line1"].ToString();
                        TxtLine1New.Text = lsRead["line1"].ToString();
                        TxtFaxAddress.Text = lsRead["fax"].ToString();
                        TxtFaxAddressNew.Text = lsRead["fax"].ToString();

                        lsSubDistrictCodeAddress = lsRead["subdistrictcode"].ToString();
                        lsDistrictCodeAddress = lsRead["districtcode"].ToString();
                        lsProvCodeAddress = lsRead["provcode"].ToString();
                        if (lsRead["flaglang"].ToString() == "1")
                        {
                            ChkThaiAddress.Checked = true;
                            ChkThaiAddressNew.Checked = true;
                            TxtProvNameAddress.Text = lsRead["provnamet"].ToString();
                            TxtProvNameAddressNew.Text = lsRead["provnamet"].ToString();
                            TxtDistrictAddress.Text = lsRead["districtnamet"].ToString();
                            TxtDistrictAddressNew.Text = lsRead["districtnamet"].ToString();
                            TxtSubDistrictAddress.Text = lsRead["subdistrictnamet"].ToString();
                            TxtSubDistrictAddressNew.Text = lsRead["subdistrictnamet"].ToString();
                        }
                        else
                        {
                            ChkEnglishAddress.Checked = true;
                            ChkEnglishAddressNew.Checked = true;
                            TxtProvNameAddress.Text = lsRead["provnamee"].ToString();
                            TxtProvNameAddressNew.Text = lsRead["provnamee"].ToString();
                            TxtDistrictAddress.Text = lsRead["districtnamee"].ToString();
                            TxtDistrictAddressNew.Text = lsRead["districtnamee"].ToString();
                            TxtSubDistrictAddress.Text = lsRead["subdistrictnamee"].ToString();
                            TxtSubDistrictAddressNew.Text = lsRead["subdistrictnamee"].ToString();
                        }
                        //TxtPostCode.Text = lsRead["postcode"].ToString();
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["addressname"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsRead.Close();
            lbPageLoad = false;
        }
        private Boolean SaveAddress()
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
            Address lstblAddress = new Address();
            lstblAddress.AddressName = TxtAddressNameAddressNew.Text;
            lstblAddress.Line1 = TxtLine1New.Text;
            lstblAddress.AddressId = liAddressID;
            lstblAddress.RefID = TxtMemID.Text;
            if (TxtSubDistrictAddressNew.Text == "")
            {
                MessageBox.Show("ตำบลไม่มีข้อมูล กรุณาเลือกตำบาล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                lstblAddress.SubDistrictCode = "-";
                //return false;
            }
            else
            {
                lstblAddress.SubDistrictCode = lsSubDistrictCodeAddress;
            }
            if (ChkEnglishAddressNew.Checked == true)
            {
                lstblAddress.FlagLanguage = Address.Flaglanguage1.English;
            }
            else
            {
                lstblAddress.FlagLanguage = Address.Flaglanguage1.Thai;
            }
            if (TxtDistrictAddressNew.Text != "")
            {
                lstblAddress.DistrictCode = lsDistrictCodeAddress;
            }
            else
            {
                MessageBox.Show("อำเภอไม่มีข้อมูล กรุณาเลือกอำเภอ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                //return false;
                lstblAddress.DistrictCode = "-";
            }
            if (TxtProvNameAddressNew.Text != "")
            {
                lstblAddress.ProvCode = lsProvCodeAddress;
            }
            else
            {
                MessageBox.Show("จังหวัดไม่มีข้อมูล กรุณาเลือกจังหวัด", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                //return false;
                lstblAddress.ProvCode = "-";
            }
            lstblAddress.PostCode = TxtPostCodeAddressNew.Text;
            lstblAddress.Telephone = TxtTelephoneAddressNew.Text;
            lstblAddress.Website = TxtWebSiteAddressNew.Text;
            lstblAddress.Email = TxtEmailAddressNew.Text;
            lstblAddress.AddressCode = CboAddressNew.SelectedValue.ToString();
            lstblAddress.Fax = TxtFaxAddressNew.Text;
            lstblAddress.CreateAddress(lsGdb.Gdb);
            return true;
        }
        private void CloseForm()
        {
            this.Close();
        }
        public MemberCopyAddress()
        {
            InitializeComponent();
        }

        private void MemberCopyAddress_Load(object sender, EventArgs e)
        {
            lbPageLoad = true;
            lsGdb.SelectCbo(CboAddress, "", Connection.TableIniT.CboAddress);
            lsGdb.SelectCbo(CboAddressNew, "", Connection.TableIniT.CboAddress);
            SelectAddress(liAddressIDOLD);
            TxtMemID.Text=lsMemID;
            lbPageLoad = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void saveclose_Click(object sender, EventArgs e)
        {
            SaveAddress();
            CloseForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            if (ChkEnglishAddressNew.Checked == true)
            {
                TxtSubDistrictAddressNew.Text = frm.SubDistrictNameE;
                TxtDistrictAddressNew.Text = frm.DistrictNameE;
                TxtProvNameAddressNew.Text = frm.ProvNameE;
            }
            else
            {
                TxtSubDistrictAddressNew.Text = frm.SubDistrictNameT;
                TxtDistrictAddressNew.Text = frm.DistrictNameT;
                TxtProvNameAddressNew.Text = frm.ProvNameT;
            }

            TxtPostCodeAddressNew.Text = frm.PostCode;
            lsProvCodeAddress = frm.ProvCode;
            lsDistrictCodeAddress = frm.DistrictCode;
            lsSubDistrictCodeAddress = frm.SubDistrictCode;
        }
    }
}