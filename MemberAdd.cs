using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.VisualBasic;
using System.Reflection;
//using Outlook = Microsoft.Office.Interop.Outlook;
namespace ThaHr30
{
    public partial class MemberAdd : Form
    {
        string[] lsplcode;
        private Int32 liColPLType = 0, liColPLPriceStart = 1, liColPLPriceEnd = 2, liColPLRemark = 4, liColPLDeposit = 3, liColPLPLID = 5;
        public string lsMemID = "", lsFlagNew = "", lsNode = "", lsArrayPriceList="", lsMemNameE="";
        private string lsSubDistrictCodeAddress = "",lsDistrictCodeAddress="",lsProvCodeAddress="",lsSubDistrictCodeContact = "",lsDistrictCodeContact="",lsProvCodeContact="", lsRemarkResign="", lsNoteID="";
        decimal ldoDeposit = 0;
        Connection lsGdb = new Connection();
        Member lstblMember = new Member();
        Contact lstblContact = new Contact();
        IniFile lsIni = new IniFile();
        private NodeMember leNode;
        private enum NodeMember
        {
            Member, Address, Contact, Note, Owner, Voucher, Price, Picture
        }
        Boolean lbPageLoad = false;
        Int32 liAddressID = 0, liNoteID=0, liOwnerID=0, liContactID=0, liAddressIDDefault=0, liNoteIDDefault=0;
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
        private void PaintGrdPriceList()
        {
            string lsSQL = "";
            //lsGdb.ConnectDatabase();
            lsSQL = "Select * From typeroom";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            //string[] lsAA = new string[] { "Single", "Double", "Suite", "Tripple", "Twin" };
            string[] lsAA = new string[Convert.ToInt32(lsArrayPriceList)];
            lsplcode = new string[Convert.ToInt32(lsArrayPriceList)];
            if (lsRead.HasRows)
            {
                Int32 i = 0;
                while (lsRead.Read())
                {
                    if (lsRead["plcode"].ToString() != null)
                    {
                        lsAA[i] = lsRead["plnamee"].ToString();
                        lsplcode[i] = lsRead["plcode"].ToString();
                        i++;
                    }
                }
            }
            lsRead.Close();
            //FarPoint.Win.Spread.Cell aCell;
            GrdPriceList.Visible = false;
            GrdPriceList.Reset();
            GrdPriceList.ActiveSheet.RowCount = 1;
            GrdPriceList.ActiveSheet.ColumnCount = 6;
            //GrdView.Height = this.Height - 150;5
            //GrdView.Width = this.Width - 30;
            //GrdView.Top = 75;
            //GrdView.Left = 12;
            GrdPriceList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdPriceList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdPriceList.ActiveSheet.SetColumnWidth(liColPLType, 150);
            GrdPriceList.ActiveSheet.SetColumnWidth(liColPLPriceStart, 80);
            GrdPriceList.ActiveSheet.SetColumnWidth(liColPLPriceEnd, 80);
            GrdPriceList.ActiveSheet.SetColumnWidth(liColPLRemark, 200);
            GrdPriceList.ActiveSheet.SetColumnWidth(liColPLDeposit, 80);
            GrdPriceList.ActiveSheet.SetColumnWidth(liColPLPLID, 80);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.ComboBoxCellType cell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            col = GrdPriceList.ActiveSheet.Columns[liColPLType];
            cell.Items = lsAA;
            cell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            col.CellType = cell;
            //comboType.Items = new String[] { "Red", "Green", "Blue" };
            //fpSpread1.Sheets[0].Cells[2, 2].CellType = comboType;
            FarPoint.Win.Spread.CellType.CurrencyCellType cellDecimal = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            col = GrdPriceList.ActiveSheet.Columns[liColPLPriceStart,liColPLDeposit];
            cellDecimal.DecimalPlaces = 2;
            cellDecimal.CurrencySymbol = "฿";
            col.CellType = cellDecimal;
            FarPoint.Win.Spread.CellType.TextCellType cell2 = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdPriceList.ActiveSheet.Columns[liColPLRemark, liColPLPLID];
            col.CellType = cell2;
            GrdPriceList.ActiveSheet.SetColumnLabel(0, liColPLType, "ประเภทห้อง");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, liColPLPriceStart, "ราคาเริ่มต้น");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, liColPLPriceEnd, "ราคาสิ้นสุด");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, liColPLRemark, "หมายเหตุ");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, liColPLDeposit, "Deposit");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, liColPLPLID, "PLID");
            GrdPriceList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdPriceList.BorderStyle = BorderStyle.None;
            GrdPriceList.Visible = true;
        }
        private void PaintGrdContact()
        {
            GrdContact.Visible = false;
            GrdContact.Reset();
            GrdContact.BorderStyle = BorderStyle.None;
            GrdContact.ActiveSheet.RowCount = 1;
            GrdContact.ActiveSheet.ColumnCount = 5;
            GrdContact.ActiveSheet.SetColumnWidth(0, 200);
            GrdContact.ActiveSheet.SetColumnWidth(1, 250);
            GrdContact.ActiveSheet.SetColumnWidth(2, 150);
            GrdContact.ActiveSheet.SetColumnWidth(3, 100);
            GrdContact.ActiveSheet.SetColumnLabel(0, 0, "ชื่อผู้ติดต่อ");
            GrdContact.ActiveSheet.SetColumnLabel(0, 1, "ที่อยู่");
            GrdContact.ActiveSheet.SetColumnLabel(0, 2, "E-mail");
            GrdContact.ActiveSheet.SetColumnLabel(0, 3, "หมายเหตุ");
            GrdContact.ActiveSheet.SetColumnLabel(0, 4, "contactid");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdContact.ActiveSheet.Columns[0, 4];
            col.Locked = true;
            col.CellType = cell;
            GrdContact.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdContact.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdContact.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdContact.Visible = true;
        }
        private void PaintGrdVoucher()
        {
            GrdVoucher.Visible = false;
            GrdVoucher.Reset();
            GrdVoucher.BorderStyle = BorderStyle.None;
            GrdVoucher.ActiveSheet.RowCount = 1;
            GrdVoucher.ActiveSheet.ColumnCount = 5;
            GrdVoucher.ActiveSheet.SetColumnWidth(0, 100);
            GrdVoucher.ActiveSheet.SetColumnWidth(1, 300);
            GrdVoucher.ActiveSheet.SetColumnWidth(2, 150);
            GrdVoucher.ActiveSheet.SetColumnWidth(3, 100);
            GrdVoucher.ActiveSheet.SetColumnLabel(0, 0, "Vou NO");
            GrdVoucher.ActiveSheet.SetColumnLabel(0, 1, "Counter");
            GrdVoucher.ActiveSheet.SetColumnLabel(0, 2, "Guest Name");
            GrdVoucher.ActiveSheet.SetColumnLabel(0, 3, "วันที่เข้าพัก");
            GrdVoucher.ActiveSheet.SetColumnLabel(0, 4, "สถานะ");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdVoucher.ActiveSheet.Columns[0, 3];
            col.Locked = true;
            col.CellType = cell;
            GrdVoucher.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdVoucher.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdVoucher.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdVoucher.Visible = true;
        }
        private void PaintGrdPicture()
        {
            GrdPicture.Visible = false;
            GrdPicture.Reset();
            GrdPicture.BorderStyle = BorderStyle.None;
            GrdPicture.ActiveSheet.RowCount = 1;
            GrdPicture.ActiveSheet.ColumnCount = 4;
            GrdPicture.ActiveSheet.SetColumnWidth(0, 100);
            GrdPicture.ActiveSheet.SetColumnWidth(1, 250);
            GrdPicture.ActiveSheet.SetColumnWidth(2, 250);
            GrdPicture.ActiveSheet.SetColumnWidth(3, 150);
            GrdPicture.ActiveSheet.SetColumnLabel(0, 0, "picid");
            GrdPicture.ActiveSheet.SetColumnLabel(0, 1, "คำบรรยาย");
            GrdPicture.ActiveSheet.SetColumnLabel(0, 2, "Description");
            GrdPicture.ActiveSheet.SetColumnLabel(0, 3, "filename");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdPicture.ActiveSheet.Columns[0, 3];
            col.Locked = true;
            col.CellType = cell;
            GrdPicture.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdPicture.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdPicture.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdPicture.Visible = true;
        }
        private void PaintGrdNote()
        {
            GrdNote.Visible = false;
            GrdNote.Reset();
            GrdNote.BorderStyle = BorderStyle.None;
            GrdNote.ActiveSheet.RowCount = 2;
            GrdNote.ActiveSheet.ColumnCount = 2;
            GrdNote.ActiveSheet.SetColumnWidth(0, 100);
            GrdNote.ActiveSheet.SetColumnWidth(1, 500);
            GrdNote.ActiveSheet.SetColumnLabel(0, 0, "noteid");
            GrdNote.ActiveSheet.SetColumnLabel(0, 1, "Note");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdNote.ActiveSheet.Columns[0, 1];
            col.Locked = true;
            col.CellType = cell;
            GrdNote.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdNote.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdNote.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdNote.Visible = true;
        }
        private void PaintGrdOwner()
        {
            GrdOwner.Visible = false;
            GrdOwner.Reset();
            GrdOwner.BorderStyle = BorderStyle.None;
            GrdOwner.ActiveSheet.RowCount = 2;
            GrdOwner.ActiveSheet.ColumnCount = 2;
            GrdOwner.ActiveSheet.SetColumnWidth(0, 100);
            GrdOwner.ActiveSheet.SetColumnWidth(1, 500);
            GrdOwner.ActiveSheet.SetColumnLabel(0, 0, "ownerid");
            GrdOwner.ActiveSheet.SetColumnLabel(0, 1, "Owner Name");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdOwner.ActiveSheet.Columns[0, 1];
            col.Locked = true;
            col.CellType = cell;
            GrdOwner.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdOwner.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdOwner.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdOwner.Visible = true;
        }
        private void PaintGrdAddress()
        {
            //GrdAddress.Visible = false;
            //GrdAddress.Reset();
            //GrdAddress.BorderStyle = BorderStyle.None;
            //GrdAddress.ActiveSheet.RowCount = 1;
            //GrdAddress.ActiveSheet.ColumnCount = 5;
            //GrdAddress.ActiveSheet.SetColumnWidth(0, 100);
            //GrdAddress.ActiveSheet.SetColumnWidth(1, 300);
            //GrdAddress.ActiveSheet.SetColumnWidth(2, 150);
            //GrdAddress.ActiveSheet.SetColumnWidth(3, 100);
            //GrdAddress.ActiveSheet.SetColumnLabel(0, 0, "ชื่อที่อยู่");
            //GrdAddress.ActiveSheet.SetColumnLabel(0, 1, "ที่อยู่");
            //GrdAddress.ActiveSheet.SetColumnLabel(0, 2, "E-mail");
            //GrdAddress.ActiveSheet.SetColumnLabel(0, 3, "หมายเหตุ");
            //GrdAddress.ActiveSheet.SetColumnLabel(0, 4, "addreddid");
            //FarPoint.Win.Spread.Column col;
            //FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            //col = GrdAddress.ActiveSheet.Columns[0, 3];
            //col.Locked = true;
            //col.CellType = cell;
            //GrdAddress.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            //GrdAddress.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //GrdAddress.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;  

            //GrdAddress.Visible = true;
        }
        public MemberAdd()
        {            
            InitializeComponent();
        }
        private void SelectNote(Int32 aNoteID)
        {
            lbPageLoad = true;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select * From membernote Where noteid = " + aNoteID ;
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        liNoteID = Convert.ToInt32(lsRead["noteid"]);
                        lsSQL = lsRead["note"].ToString();
                        //TxtMemNameENote.Text = lsMemNameE;
                        TxtNote.Text = lsRead["note"].ToString();
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["note"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsRead.Close();
            lbPageLoad = false;
        }
        private void SelectContact(Int32 aContactID)
        {
            lbPageLoad = true;
            string lsSQL = "";
            //TxtContactMemNameE.Text = lsMemNameE;
            Int32 i = 0;
            lsSQL = "Select c.*, p.provnamet, p.provnamee, d.districtnamet, d.districtnamee, s.subdistrictnamet, s.subdistrictnamee "
                + "From contact c left join province p on c.provcode = p.provcode left join district d on c.districtcode  = d.districtcode "
                + "left join subdistrict s on c.subdistrictcode = s.subdistrictcode  Where c.contactid = " + aContactID ;
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        liContactID = Convert.ToInt32(lsRead["contactid"]);
                        TxtContactNameT.Text = lsRead["contactnamet"].ToString();
                        TxtContactNameE.Text = lsRead["contactnamee"].ToString();
                        TxtContactSurNameT.Text = lsRead["contactsurnamet"].ToString();
                        TxtContactSurNameE.Text = lsRead["contactsurnamee"].ToString();
                        TxtContactPositionT.Text = lsRead["positiont"].ToString();
                        TxtContactemail.Text = lsRead["email"].ToString();
                        TxtContactwww.Text = lsRead["email"].ToString();
                        TxtContactTele.Text = lsRead["telephone"].ToString();
                        TxtContactMobile.Text = lsRead["mobile"].ToString();
                        TxtContactLine1.Text = lsRead["line1"].ToString();
                        TxtSubDistrictContact.Text = lsRead["subdistrictnamet"].ToString();
                        TxtDistrictContact.Text = lsRead["districtnamet"].ToString();
                        TxtProvContact.Text = lsRead["provnamet"].ToString();
                        TxtPostCodeContact.Text = lsRead["postcode"].ToString();
                        if (lsRead["flagskk9"].ToString()=="1")
                        {
                            ChkSkk9.Checked = true;
                        }
                        else
                        {
                            ChkSkk9.Checked = false;
                        }
                        if (lsRead["flagmeeting"].ToString() == "1")
                        {
                            ChkContactMeeting.Checked = true;
                        }
                        else
                        {
                            ChkContactMeeting.Checked = false;
                        }
                        if (lsRead["flagprintlabel"].ToString() == "1")
                        {
                            ChkPrintLabel.Checked = true;
                        }
                        else
                        {
                            ChkPrintLabel.Checked = false;
                        }
                        if (lsRead["flaglang"].ToString() == "1")
                        {
                            ChkThaiContact.Checked = true;
                            TxtProvContact.Text = lsRead["provnamet"].ToString();
                            TxtDistrictContact.Text = lsRead["districtnamet"].ToString();
                            TxtSubDistrictContact.Text = lsRead["subdistrictnamet"].ToString();
                        }
                        else
                        {
                            ChkEnglishContact.Checked = true;
                            TxtProvContact.Text = lsRead["provnamee"].ToString();
                            TxtDistrictContact.Text = lsRead["districtnamee"].ToString();
                            TxtSubDistrictContact.Text = lsRead["subdistrictnamee"].ToString();
                        }
                        lsSubDistrictCodeContact = lsRead["subdistrictcode"].ToString();
                        lsDistrictCodeContact = lsRead["districtcode"].ToString();
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["contactnamet"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsRead.Close();
            lbPageLoad = false;
        }
        private void SelectOwner(string aOwnerID)
        {
            lbPageLoad = true;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select * From memberowner Where ownerid = '" + aOwnerID + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        liOwnerID = Convert.ToInt32(lsRead["ownerid"]);
                        lsSQL = lsRead["ownernamet"].ToString();
                        //TxtOwnerMemNameE.Text = lsMemNameE;
                        TxtOwnerOld.Text = lsRead["ownernamet"].ToString();
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["ownernamet"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsRead.Close();
            lbPageLoad = false;
        }
        private void SelectAddress(Int32 aAddressID)
        {
            lbPageLoad = true;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select a.*, p.provnamet, p.provnamee, d.districtnamet, d.districtnamee, s.subdistrictnamet, s.subdistrictnamee "
                + "From address a LEFT JOIN province p on a.provcode = p.provcode LEFT JOIN district d on a.districtcode = d.districtcode "
                + "LEFT JOIN subdistrict s on a.subdistrictcode = s.subdistrictcode "
                +"Where addressid = " + aAddressID ;
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
                        liAddressID = Convert.ToInt32(lsRead["addressid"]);
                        CboTH11.SelectedValue = lsRead["addresscode"].ToString();
                        TxtMemNameE.Text = lsMemNameE;
                        TxtTH12.Text = lsRead["addressname"].ToString();
                        TxtTH15.Text = lsRead["email"].ToString();
                        TxtTH14.Text = lsRead["website"].ToString();
                        TxtTH24.Text = lsRead["postcode"].ToString();
                        TxtTH25.Text = lsRead["telephone"].ToString();
                        TxtTH13.Text = lsRead["line1"].ToString();
                        TxtTH26.Text = lsRead["fax"].ToString();
                        
                        lsSubDistrictCodeAddress = lsRead["subdistrictcode"].ToString();
                        lsDistrictCodeAddress = lsRead["districtcode"].ToString();
                        lsProvCodeAddress = lsRead["provcode"].ToString();
                        if (lsRead["flaglang"].ToString() == "1")
                        {
                            ChkThaiAddress.Checked = true;
                            TxtTH23.Text = lsRead["provnamet"].ToString();
                            TxtTH22.Text = lsRead["districtnamet"].ToString();
                            TxtTH21.Text = lsRead["subdistrictnamet"].ToString();
                        }
                        else
                        {
                            ChkEnglishAddress.Checked = true;
                            TxtTH23.Text = lsRead["provnamee"].ToString();
                            TxtTH22.Text = lsRead["districtnamee"].ToString();
                            TxtTH21.Text = lsRead["subdistrictnamee"].ToString();
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
            //lsGdb.SelectCboProvDistrSubDistr(CboProvAddress, CboDistrictAddress, CboSubDistrictAddress, TxtPostCodeAddress, lsSubDistrCode, Connection.TableIniT.CboDistrictFromSubDistrict);
            lbPageLoad = false;
        }
        private void SelectAddress(string aMemID, string aAddressCode)
        {
            lbPageLoad = true;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select a.*, p.provnamet, p.provnamee, d.districtnamet, d.districtnamee, s.subdistrictnamet, s.subdistrictnamee "
                + "From address a LEFT JOIN province p on a.provcode = p.provcode LEFT JOIN district d on a.districtcode = d.districtcode "
                + "LEFT JOIN subdistrict s on a.subdistrictcode = s.subdistrictcode "
                + "Where addresscode = '" + aAddressCode+"' and refid = '"+ aMemID+ "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        switch (aAddressCode)
                        {
                            case ("106"):
                                {
                                    lsSQL = lsRead["addressname"].ToString();
                                    liAddressID = Convert.ToInt32(lsRead["addressid"]);
                                    CboTH11.SelectedValue = lsRead["addresscode"].ToString();
                                    TxtMemNameE.Text = lsMemNameE;
                                    TxtTH12.Text = lsRead["addressname"].ToString();
                                    TxtTH15.Text = lsRead["email"].ToString();
                                    TxtTH14.Text = lsRead["website"].ToString();
                                    TxtTH24.Text = lsRead["postcode"].ToString();
                                    TxtTH25.Text = lsRead["telephone"].ToString();
                                    TxtTH13.Text = lsRead["line1"].ToString();
                                    TxtTH26.Text = lsRead["fax"].ToString();

                                    lsSubDistrictCodeAddress = lsRead["subdistrictcode"].ToString();
                                    lsDistrictCodeAddress = lsRead["districtcode"].ToString();
                                    lsProvCodeAddress = lsRead["provcode"].ToString();
                                    if (lsRead["flaglang"].ToString() == "1")
                                    {
                                        ChkThaiAddress.Checked = true;
                                        TxtTH23.Text = lsRead["provnamet"].ToString();
                                        TxtTH22.Text = lsRead["districtnamet"].ToString();
                                        TxtTH21.Text = lsRead["subdistrictnamet"].ToString();
                                    }
                                    else
                                    {
                                        ChkEnglishAddress.Checked = true;
                                        TxtTH23.Text = lsRead["provnamee"].ToString();
                                        TxtTH22.Text = lsRead["districtnamee"].ToString();
                                        TxtTH21.Text = lsRead["subdistrictnamee"].ToString();
                                    }
                                    //TxtPostCode.Text = lsRead["postcode"].ToString();
                                    break;
                                }
                            case ("107"):
                                {
                                    lsSQL = lsRead["addressname"].ToString();
                                    liAddressID = Convert.ToInt32(lsRead["addressid"]);
                                    CboEH11.SelectedValue = lsRead["addresscode"].ToString();
                                    TxtMemNameE.Text = lsMemNameE;
                                    TxtEH12.Text = lsRead["addressname"].ToString();
                                    TxtEH15.Text = lsRead["email"].ToString();
                                    TxtEH14.Text = lsRead["website"].ToString();
                                    TxtEH24.Text = lsRead["postcode"].ToString();
                                    TxtEH25.Text = lsRead["telephone"].ToString();
                                    TxtEH13.Text = lsRead["line1"].ToString();
                                    TxtEH26.Text = lsRead["fax"].ToString();

                                    lsSubDistrictCodeAddress = lsRead["subdistrictcode"].ToString();
                                    lsDistrictCodeAddress = lsRead["districtcode"].ToString();
                                    lsProvCodeAddress = lsRead["provcode"].ToString();
                                    if (lsRead["flaglang"].ToString() == "1")
                                    {
                                        ChkThaiAddress.Checked = true;
                                        TxtEH23.Text = lsRead["provnamet"].ToString();
                                        TxtEH22.Text = lsRead["districtnamet"].ToString();
                                        TxtEH21.Text = lsRead["subdistrictnamet"].ToString();
                                    }
                                    else
                                    {
                                        ChkEnglishAddress.Checked = true;
                                        TxtEH23.Text = lsRead["provnamee"].ToString();
                                        TxtEH22.Text = lsRead["districtnamee"].ToString();
                                        TxtEH21.Text = lsRead["subdistrictnamee"].ToString();
                                    }
                                    break;
                                }
                            case ("108"):
                                {
                                    lsSQL = lsRead["addressname"].ToString();
                                    liAddressID = Convert.ToInt32(lsRead["addressid"]);
                                    CboTO11.SelectedValue = lsRead["addresscode"].ToString();
                                    TxtMemNameE.Text = lsMemNameE;
                                    TxtTO12.Text = lsRead["addressname"].ToString();
                                    TxtTO15.Text = lsRead["email"].ToString();
                                    TxtTO14.Text = lsRead["website"].ToString();
                                    TxtTO24.Text = lsRead["postcode"].ToString();
                                    TxtTO25.Text = lsRead["telephone"].ToString();
                                    TxtTO13.Text = lsRead["line1"].ToString();
                                    TxtTO26.Text = lsRead["fax"].ToString();

                                    lsSubDistrictCodeAddress = lsRead["subdistrictcode"].ToString();
                                    lsDistrictCodeAddress = lsRead["districtcode"].ToString();
                                    lsProvCodeAddress = lsRead["provcode"].ToString();
                                    if (lsRead["flaglang"].ToString() == "1")
                                    {
                                        ChkThaiAddress.Checked = true;
                                        TxtTO23.Text = lsRead["provnamet"].ToString();
                                        TxtTO22.Text = lsRead["districtnamet"].ToString();
                                        TxtTO21.Text = lsRead["subdistrictnamet"].ToString();
                                    }
                                    else
                                    {
                                        ChkEnglishAddress.Checked = true;
                                        TxtTO23.Text = lsRead["provnamee"].ToString();
                                        TxtTO22.Text = lsRead["districtnamee"].ToString();
                                        TxtTO21.Text = lsRead["subdistrictnamee"].ToString();
                                    }
                                    break;
                                }
                            case ("109"):
                                {
                                    lsSQL = lsRead["addressname"].ToString();
                                    liAddressID = Convert.ToInt32(lsRead["addressid"]);
                                    CboTD11.SelectedValue = lsRead["addresscode"].ToString();
                                    TxtMemNameE.Text = lsMemNameE;
                                    TxtTD12.Text = lsRead["addressname"].ToString();
                                    TxtTD15.Text = lsRead["email"].ToString();
                                    TxtTD14.Text = lsRead["website"].ToString();
                                    TxtTD24.Text = lsRead["postcode"].ToString();
                                    TxtTD25.Text = lsRead["telephone"].ToString();
                                    TxtTD13.Text = lsRead["line1"].ToString();
                                    TxtTD26.Text = lsRead["fax"].ToString();

                                    lsSubDistrictCodeAddress = lsRead["subdistrictcode"].ToString();
                                    lsDistrictCodeAddress = lsRead["districtcode"].ToString();
                                    lsProvCodeAddress = lsRead["provcode"].ToString();
                                    if (lsRead["flaglang"].ToString() == "1")
                                    {
                                        ChkThaiAddress.Checked = true;
                                        TxtTD23.Text = lsRead["provnamet"].ToString();
                                        TxtTD22.Text = lsRead["districtnamet"].ToString();
                                        TxtTD21.Text = lsRead["subdistrictnamet"].ToString();
                                    }
                                    else
                                    {
                                        ChkEnglishAddress.Checked = true;
                                        TxtTD23.Text = lsRead["provnamee"].ToString();
                                        TxtTD22.Text = lsRead["districtnamee"].ToString();
                                        TxtTD21.Text = lsRead["subdistrictnamee"].ToString();
                                    }
                                    break;
                                }
                            case ("110"):
                                {
                                    lsSQL = lsRead["addressname"].ToString();
                                    liAddressID = Convert.ToInt32(lsRead["addressid"]);
                                    CboED11.SelectedValue = lsRead["addresscode"].ToString();
                                    TxtMemNameE.Text = lsMemNameE;
                                    TxtED12.Text = lsRead["addressname"].ToString();
                                    TxtED15.Text = lsRead["email"].ToString();
                                    TxtED14.Text = lsRead["website"].ToString();
                                    TxtED24.Text = lsRead["postcode"].ToString();
                                    TxtED25.Text = lsRead["telephone"].ToString();
                                    TxtED13.Text = lsRead["line1"].ToString();
                                    TxtED26.Text = lsRead["fax"].ToString();

                                    lsSubDistrictCodeAddress = lsRead["subdistrictcode"].ToString();
                                    lsDistrictCodeAddress = lsRead["districtcode"].ToString();
                                    lsProvCodeAddress = lsRead["provcode"].ToString();
                                    if (lsRead["flaglang"].ToString() == "1")
                                    {
                                        ChkThaiAddress.Checked = true;
                                        TxtED23.Text = lsRead["provnamet"].ToString();
                                        TxtED22.Text = lsRead["districtnamet"].ToString();
                                        TxtED21.Text = lsRead["subdistrictnamet"].ToString();
                                    }
                                    else
                                    {
                                        ChkEnglishAddress.Checked = true;
                                        TxtED23.Text = lsRead["provnamee"].ToString();
                                        TxtED22.Text = lsRead["districtnamee"].ToString();
                                        TxtED21.Text = lsRead["subdistrictnamee"].ToString();
                                    }
                                    break;
                                }
                        }
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
            //lsGdb.SelectCboProvDistrSubDistr(CboProvAddress, CboDistrictAddress, CboSubDistrictAddress, TxtPostCodeAddress, lsSubDistrCode, Connection.TableIniT.CboDistrictFromSubDistrict);
            lbPageLoad = false;
        }
        private void SelectVoucher(string aStartDate, string aEndDate, string aMemID)
        {
            PaintGrdVoucher();
            GrdVoucher.ActiveSheet.RowCount = 19;
            string lsSQL = "";
            string lsStartDate = "", lsEndDate = "";
            DateTime ldStart = new DateTime();
            DateTime ldEndate = new DateTime();
            ldStart = Convert.ToDateTime(aStartDate);
            ldEndate = Convert.ToDateTime(aEndDate);
            lsStartDate = ldStart.Year.ToString("0000") + "-" + ldStart.Month.ToString("00") + "-" + ldStart.Day.ToString("00");
            lsEndDate = ldEndate.Year.ToString("0000") + "-" + ldEndate.Month.ToString("00") + "-" + ldEndate.Day.ToString("00");
            Int32 i = 0;
            lsSQL = "Select * From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '" + lsEndDate + "' and hotelcode = '" + aMemID + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        //lsSQL = lsRead["plnamee"].ToString();
                        GrdVoucher.ActiveSheet.SetText(i, 0, lsRead["vouno"].ToString());
                        GrdVoucher.ActiveSheet.SetText(i, 1, lsRead["counter1"].ToString());
                        GrdVoucher.ActiveSheet.SetText(i, 2, lsRead["guestfirstname"].ToString() + " " + lsRead["guestlastname"].ToString());
                        GrdVoucher.ActiveSheet.SetText(i, 3, lsRead["checkindate"].ToString());
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["vouno"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
        }
        private void SelectPriceList()
        {
            PaintGrdPriceList();
            GrdPriceList.ActiveSheet.RowCount = 19;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select m.memid, m.plcode, m.pricestart, m.priceend, m.remark, p.plnamee, m.deposit, m.plid, mm.typepricebaht " 
                + "From memberpricelist m, typeroom p, member mm "
                + "Where m.memid = '" + lsMemID + "' and m.plcode = p.plcode and mm.memid = m.memid";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        if (lsRead["typepricebaht"].ToString() == "0")
                        {
                            ChkBaht.Checked = true;
                            ChkUS.Checked = false;
                        }
                        else
                        {
                            ChkUS.Checked = true;
                            ChkBaht.Checked = false;
                        }
                        TxtDeposit.Value = Convert.ToDecimal(lsRead["deposit"]);
                        lsSQL = lsRead["plid"].ToString();
                        //GrdPriceList.ActiveSheet.SetText(i, liColPLType, lsRead["plnamee"].ToString());
                        string plIndex="";
                        for (int j = 0; j < lsplcode.Length - 1; j++)
                        {
                            plIndex = "";
                            if (lsplcode[j] == lsRead["plcode"].ToString())
                            {
                                plIndex = j.ToString();
                                break;
                            }
                        }
                        GrdPriceList.ActiveSheet.SetValue(i, liColPLType, plIndex);
                        GrdPriceList.ActiveSheet.SetText(i, liColPLPriceStart, lsRead["pricestart"].ToString());
                        GrdPriceList.ActiveSheet.SetText(i, liColPLPriceEnd, lsRead["priceend"].ToString());
                        GrdPriceList.ActiveSheet.SetText(i, liColPLRemark, lsRead["remark"].ToString());
                        GrdPriceList.ActiveSheet.SetText(i, liColPLDeposit, lsRead["deposit"].ToString());
                        GrdPriceList.ActiveSheet.SetText(i, liColPLPLID, lsRead["plid"].ToString());
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["deposit"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
        }
        private void SelectContact()
        {
            PaintGrdContact();
            GrdContact.ActiveSheet.RowCount = 9;
            //TxtContactMemNameE.Text = lsMemNameE;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select count(*) cnt From contact Where refid = '" + lsMemID + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    GrdContact.ActiveSheet.RowCount = Convert.ToInt32(lsRead["cnt"]);
                }
            }
            lsRead.Close();
            lsSQL = "Select * From contact Where refid = '" + lsMemID + "'";
            Comm.CommandText = lsSQL;
            
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        GrdContact.ActiveSheet.SetText(i, 0, lsRead["contactnamet"].ToString() + " " + lsRead["contactsurnamet"].ToString());
                        GrdContact.ActiveSheet.SetText(i, 1, lsRead["line1"].ToString());
                        GrdContact.ActiveSheet.SetText(i, 2, lsRead["email"].ToString());
                        GrdContact.ActiveSheet.SetText(i, 3, lsRead["remark"].ToString());
                        GrdContact.ActiveSheet.SetText(i, 4, lsRead["contactid"].ToString());
                        if (lsRead["flagskk9"].ToString() == "1")
                        {
                            GrdContact.ActiveSheet.Rows[i].BackColor = Color.Pink;
                        }
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["contactnamet"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                //GrdView.DataSource = lsRead;
            }
            if (GrdContact.ActiveSheet.RowCount > 5)
            {
                GrdContact.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            lsRead.Close();
        }
        private void SelectAddress()
        {
            //PaintGrdAddress();
            //GrdAddress.ActiveSheet.RowCount = 9;
            //string lsSQL = "";
            //Int32 i = 0;
            //lsSQL = "Select addressname, addressid, refid, line1, email, remark, addresscode From address Where refid = '"+ lsMemID + "'";
            //MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            //MySqlDataReader lsRead;
            //lsRead = Comm.ExecuteReader();
            //if (lsRead.HasRows)
            //{
            //    while (lsRead.Read())
            //    {
            //        try
            //        {
            //            lsSQL = lsRead["addresscode"].ToString();
            //            CboAddress.SelectedValue = lsRead["addresscode"].ToString();
            //            GrdAddress.ActiveSheet.SetText(i, 0, lsRead["addressname"].ToString());
            //            GrdAddress.ActiveSheet.SetText(i, 1, lsRead["line1"].ToString());
            //            GrdAddress.ActiveSheet.SetText(i, 2, lsRead["email"].ToString());
            //            GrdAddress.ActiveSheet.SetText(i, 3, lsRead["remark"].ToString());
            //            GrdAddress.ActiveSheet.SetText(i, 4, lsRead["addressid"].ToString());
            //            i++;
            //        }
            //        catch (Exception e)
            //        {
            //            i++;
            //            MessageBox.Show(lsRead["addressname"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            //        }
            //    }
            //}
            //lsRead.Close();
        }
        private void SelectNote()
        {
            PaintGrdNote();
            GrdNote.ActiveSheet.RowCount = 9;
            string lsSQL = "";
            Int32 i = 0;
            //TxtMemNameENote.Text = lsMemNameE;
            lsSQL = "Select * From membernote Where refid = '" + lsMemID + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        lsSQL = lsRead["note"].ToString();
                        GrdNote.ActiveSheet.SetText(i, 0, lsRead["noteid"].ToString());
                        GrdNote.ActiveSheet.SetText(i, 1, lsSQL);
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["noteid"].ToString() + " " + lsRead["note"].ToString() + " \n" + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
        }
        private void SelectOwner()
        {
            PaintGrdOwner();
            GrdOwner.ActiveSheet.RowCount = 9;
            string lsSQL = "";
            Int32 i = 0;
            //TxtMemNameENote.Text = lsMemNameE;
            lsGdb.SelectCbo(CboOwnerNew, "", Connection.TableIniT.MemberOwner);
            lsSQL = "Select * From memberowner Where refid = '" + lsMemID + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        lsSQL = lsRead["ownernamet"].ToString();
                        GrdOwner.ActiveSheet.SetText(i, 0, lsRead["ownerid"].ToString());
                        GrdOwner.ActiveSheet.SetText(i, 1, lsSQL);
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["ownerid"].ToString() + " " + lsRead["ownernamet"].ToString() + " \n" + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
        }
        private void SelectPicture()
        {
            PaintGrdPicture();
            GrdPicture.ActiveSheet.RowCount = 9;
            string lsSQL = "";
            Int32 i = 0;
            //TxtMemNamePicture.Text = lsMemNameE;
            lsSQL = "Select * From memberpicture Where memid = '" + lsMemID + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        //lsSQL = lsRead["addressname"].ToString();
                        GrdPicture.ActiveSheet.SetText(i, 0, lsRead["picid"].ToString());
                        GrdPicture.ActiveSheet.SetText(i, 1, lsRead["desct"].ToString());
                        GrdPicture.ActiveSheet.SetText(i, 2, lsRead["desce"].ToString());
                        GrdPicture.ActiveSheet.SetText(i, 3, lsRead["filename"].ToString());
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["picid"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
        }
        private void SelectPicture(string aPicId)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select * From memberpicture Where picid = '" + aPicId + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        TxtFileName.Text = lsRead["filename"].ToString();
                        TxtDescT.Text = lsRead["desct"].ToString();
                        TxtDescE.Text = lsRead["desce"].ToString();
                        TxtPicId.Text = aPicId;
                        i++;
                    }
                    catch (Exception e)
                    {
                        i++;
                        MessageBox.Show(lsRead["filename"].ToString() + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
            if (File.Exists(Application.StartupPath + "\\member\\" + lsMemID + "\\" + TxtFileName.Text))
            {
                Pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Pic.ImageLocation = Application.StartupPath + "\\member\\" + lsMemID + "\\" + TxtFileName.Text;
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void SelectMember(string aMemId)
        {
            string lsSQL = "", lsSubDistrictCode="";
            Boolean lbVoidDate=true;
            //MySql.Data.Types.MySqlDateTime ldDate;
            Int32 i = 0;
            //IniFile lsIni = new IniFile("thahr30.ini");
            //string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            //string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            //MySqlConnection Conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=root;Password=Ekartc2c5");
            //Conn.Open();
            lsSQL = "Select m.*, m.ownerid, o.ownernamet, a.addressid, a.line1, a.subdistrictcode, a.districtcode, "
                +"a.provcode, a.website, a.telephone, a.postcode, a.fax, n.noteid, n.note "
                + "From member m LEFT JOIN  memberowner o on m.ownerid = o.ownerid "
                + "LEFT JOIN  address a on m.addressid = a.addressid Left Join membernote n on m.noteid = n.noteid "
                + "Where memid = '" + aMemId + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            i = 0;
            while (lsRead.Read())
            {
                i++;
                TxtMemID.Text = lsRead["memid"].ToString();
                TxtNameE1.Text = lsRead["memnamee1"].ToString();
                lsMemNameE = TxtNameE1.Text;
                TxtNameE2.Text = lsRead["memnamee2"].ToString();
                TxtNameT.Text = lsRead["memnamet"].ToString();
                TxtRating.Text = lsRead["hotelrating"].ToString();
                CboTMem.SelectedValue = lsRead["tmemcode"].ToString();
                CboTBis.SelectedValue = lsRead["tbiscode"].ToString();
                CboHotelChain.SelectedValue = lsRead["hotelchaincode"].ToString();
                CboRegion.SelectedValue = lsRead["regioncode"].ToString();
                CboStar.SelectedValue = lsRead["star"].ToString();
                CboGreenL.SelectedValue = lsRead["flaggreenleft"].ToString();
                CboProvMem.SelectedValue = lsRead["provcode"].ToString();
                CboRegion.SelectedValue = lsRead["regioncode"].ToString();
                CboNation.SelectedValue = lsRead["nationcode"].ToString();
                CboGreenL.SelectedValue = lsRead["flaggreenleft"].ToString();
                CboLocation.SelectedValue = lsRead["locationcode"].ToString();
                TxtMemOwner.Text = lsRead["ownernamet"].ToString();
                //TxtRemark.Text = lsRead["remark"].ToString();
                lsSQL = lsRead.GetValue(4).ToString();
                TxtNumRooms.Value = Convert.ToInt32(lsRead["numroom"].ToString());
                TxtPriceStart1.Value = Convert.ToDecimal(lsRead["pricestart"]);
                TxtPriceEnd1.Value = Convert.ToDecimal(lsRead["priceend"]);
                TxtMemRate.Value = Convert.ToDecimal(lsRead["memrate"]);
                TxtMemNameE.Text = TxtNameE1.Text + " [" + TxtMemID.Text + "]";
                TxtEMailAcc.Text = lsRead["emailaccount"].ToString();
                liOwnerID = Convert.ToInt32(lsRead["ownerid"]);
                liAddressIDDefault = Convert.ToInt32(lsRead["addressid"]);
                liNoteIDDefault = Convert.ToInt32(lsRead["noteid"]);
                ldoDeposit = Convert.ToDecimal(lsRead["deposit"]);
                lbVoidDate = lsRead.GetMySqlDateTime("startdate").IsValidDateTime;
                if (lbVoidDate == true)
                {
                    TxtMemStartDate.Text = lsGdb.SelectDate(Convert.ToDateTime(lsRead["startdate"].ToString()), Connection.FlagDate.DateShow, lsIni);
                }
                lbVoidDate = lsRead.GetMySqlDateTime("enddate").IsValidDateTime;
                if (lbVoidDate == true)
                {
                    TxtMemEndDate.Text = lsGdb.SelectDate(Convert.ToDateTime(lsRead["enddate"].ToString()), Connection.FlagDate.DateShow, lsIni);
                }
                lbVoidDate = lsRead.GetMySqlDateTime("regisdate").IsValidDateTime;
                if (lbVoidDate == true)
                {
                    TxtMemRegisDate.Text = lsGdb.SelectDate(Convert.ToDateTime(lsRead["regisdate"]), Connection.FlagDate.DateShow, lsIni);
                }
                //TxtMemNameEAddress.Text = TxtMemNameE.Text;
                TxtSKK9.Text = lsRead["skk9id"].ToString();
                if (lsRead["flag"].ToString() == "1")
                {
                    ChkFlag.Checked = true;
                }
                else
                {
                    ChkFlag.Checked = false;
                }
                if (lsRead["typepricebaht"].ToString() == "1")
                {
                    ChkBaht.Checked = true;
                    ChkUS.Checked = false ;
                }
                else
                {
                    ChkBaht.Checked = false ;
                    ChkUS.Checked = true;
                }
                if (lsRead["flagsale"].ToString() == "1")
                {
                    ChkSale.Checked = true;
                }
                else
                {
                    ChkSale.Checked = false;
                }
                if (lsRead["flagrestaurant"].ToString() == "1")
                {
                    ChkRestaurant.Checked = true;
                }
                else
                {
                    ChkRestaurant.Checked = false;
                }
                if (lsRead["flagfitness"].ToString() == "1")
                {
                    ChkFitness.Checked = true;
                }
                else
                {
                    ChkFitness.Checked = false;
                }
                if (lsRead["flagspa"].ToString() == "1")
                {
                    ChkSpa.Checked = true;
                }
                else
                {
                    ChkSpa.Checked = false;
                }
                if (lsRead["flagmeeting"].ToString() == "1")
                {
                    ChkMeeting.Checked = true;
                }
                else
                {
                    ChkMeeting.Checked = false;
                }
                if (lsRead["flagbusiness"].ToString() == "1")
                {
                    ChkBusiness.Checked = true;
                }
                else
                {
                    ChkBusiness.Checked = false;
                }
                TxtDAddressName.Text = lsRead["addressid"].ToString();
                TxtDAddressLine1.Text = lsRead["line1"].ToString();
                TxtDAddressWebSite.Text = lsRead["website"].ToString();
                TxtDAddresTele.Text = lsRead["telephone"].ToString();
                TxtDAddressPostCode.Text = lsRead["postcode"].ToString();
                TxtDAddressFax.Text = lsRead["fax"].ToString();
                TxtMemNote.Text = lsRead["note"].ToString();
                lsSubDistrictCode = lsRead["subdistrictcode"].ToString();
                lsNoteID = lsRead["noteid"].ToString(); 
                lsRemarkResign = lsRead["remarkresign"].ToString();
                
                if (lsRead["flagresign"].ToString()=="1")
                {
                    TxtMemStatus.Text = "สมาชิกลาออก";
                    resignMember.Text = "สมาชิกกลับมาสมัครใหม่";
                    SL1.Text = "หมายเหตุการลาออกของสมาชิก " + lsRemarkResign;
                    SL1.Items[0].Text = "หมายเหตุการลาออกของสมาชิก " + lsRemarkResign;
                }
                else
                {
                    TxtMemStatus.Text = "";
                    resignMember.Text = "สมาชิกลาออก";
                }
                if (lsRead["flag"].ToString() == "1")
                {
                    TxtMemStatus.Text = "ใช้งาน";
                    if (lsRead["flagsale"].ToString() == "1")
                    {
                        TxtMemStatus.Text = "ใช้งาน ให้ขายได้";
                    }
                    else
                    {
                        TxtMemStatus.Text = "ใช้งาน ไม่ให้ขาย";
                    }
                }
            }
            lsRead.Close();
            lsSQL = lsGdb.SelectTxtProvDistrSubDistrictPostCode(TxtDAddressProv, TxtDAddressDistrict, TxtDAddressSubDistrict, TxtDAddressPostCode, lsSubDistrictCode);
        }
        private void MemberAdd_Load(object sender, EventArgs e)
        {
            lbPageLoad = true;
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
            lsGdb.SelectCbo(CboRegion, "", Connection.TableIniT.Region);
            lsGdb.SelectCbo(CboNation, "", Connection.TableIniT.Nationality);
            lsGdb.SelectCbo(CboTMem, "", Connection.TableIniT.TypeMem);
            lsGdb.SelectCbo(CboTBis, "", Connection.TableIniT.TypeBis);
            lsGdb.SelectCbo(CboHotelChain, "", Connection.TableIniT.HotelChain);
            lsGdb.SelectCbo(CboStar, "", Connection.TableIniT.Star);
            lsGdb.SelectCbo(CboGreenL, "", Connection.TableIniT.GreenLeft);
            lsGdb.SelectCbo(CboProvMem, "", Connection.TableIniT.Province);
            lsGdb.SelectCbo(CboLinkPicture, lsMemID, Connection.TableIniT.CboLinkPicture);
            lsGdb.SelectCbo(CboLocation, "", Connection.TableIniT.Location);
            lsGdb.SelectCbo(CboTH11,"", Connection.TableIniT.CboAddress);
            //lsGdb.SelectCbo(TxtMemOwner, "", Connection.TableIniT.MemberOwner);
            SelectMember(lsMemID);
            VisibleGroupBoxFalse();
            GbInformation.Visible = true;
            GbAddressDefault.Visible = true;
            //GbInformation.Top = 37;
            //GbInformation.Left = 207;
            //SetPositionGb();
            lsArrayPriceList = lsIni.GetString("thahr30", "arraypricelist", "19");
            string lsFlagSaveMember = lsIni.GetString("thahr30", "flagsavemember", "1");
            if (lsFlagSaveMember == "1")
            {
                savenew.Enabled = true;
                saveclose.Enabled = true;
            }
            else
            {
                savenew.Enabled = false;
                saveclose.Enabled = false;
            }
            PaintGrdPriceList();
            lsNode = "information";
            leNode = NodeMember.Member;
            this.Width = 1060;
            lbPageLoad = false;
            SetPositionTabAddress();
        }
        private void SetPositionTabAddress()
        {
            labelEH11.Top = labelTH11.Top;
            labelEH11.Left = labelTH11.Left;
            labelEH12.Top = labelTH12.Top;
            labelEH12.Left = labelTH12.Left;
            labelEH13.Top = labelTH13.Top;
            labelEH13.Left = labelTH13.Left;
            labelEH14.Top = labelTH14.Top;
            labelEH14.Left = labelTH14.Left;
            labelEH15.Top = labelTH15.Top;
            labelEH15.Left = labelTH15.Left;
            labelEH21.Top = labelTH21.Top;
            labelEH21.Left = labelTH21.Left;
            labelEH22.Top = labelTH22.Top;
            labelEH22.Left = labelTH22.Left;
            labelEH23.Top = labelTH23.Top;
            labelEH23.Left = labelTH23.Left;
            labelEH24.Top = labelTH24.Top;
            labelEH24.Left = labelTH24.Left;
            labelEH25.Top = labelTH25.Top;
            labelEH25.Left = labelTH25.Left;
            labelEH26.Top = labelTH26.Top;
            labelEH26.Left = labelTH26.Left;

            CboEH11.Top = CboTH11.Top;
            CboEH11.Left = CboTH11.Left;
            TxtEH12.Top = TxtTH12.Top;
            TxtEH12.Left = TxtTH12.Left;
            TxtEH13.Top = TxtTH13.Top;
            TxtEH13.Left = TxtTH13.Left;
            TxtEH14.Top = TxtTH14.Top;
            TxtEH14.Left = TxtTH14.Left;
            TxtEH15.Top = TxtTH15.Top;
            TxtEH15.Left = TxtTH15.Left;
            BtnEH21.Top = BtnTH21.Top;
            BtnEH21.Left = BtnTH21.Left;
            TxtEH21.Top = TxtTH21.Top;
            TxtEH21.Left = TxtTH21.Left;
            TxtEH22.Top = TxtTH22.Top;
            TxtEH22.Left = TxtTH22.Left;
            TxtEH23.Top = TxtTH23.Top;
            TxtEH23.Left = TxtTH23.Left;
            TxtEH24.Top = TxtTH24.Top;
            TxtEH24.Left = TxtTH24.Left;
            TxtEH25.Top = TxtTH25.Top;
            TxtEH25.Left = TxtTH25.Left;
            TxtEH26.Top = TxtTH26.Top;
            TxtEH26.Left = TxtTH26.Left;


            labelTO11.Top = labelTH11.Top;
            labelTO11.Left = labelTH11.Left;
            labelTO12.Top = labelTH12.Top;
            labelTO12.Left = labelTH12.Left;
            labelTO13.Top = labelTH13.Top;
            labelTO13.Left = labelTH13.Left;
            labelTO14.Top = labelTH14.Top;
            labelTO14.Left = labelTH14.Left;
            labelTO15.Top = labelTH15.Top;
            labelTO15.Left = labelTH15.Left;
            labelTO21.Top = labelTH21.Top;
            labelTO21.Left = labelTH21.Left;
            labelTO22.Top = labelTH22.Top;
            labelTO22.Left = labelTH22.Left;
            labelTO23.Top = labelTH23.Top;
            labelTO23.Left = labelTH23.Left;
            labelTO24.Top = labelTH24.Top;
            labelTO24.Left = labelTH24.Left;
            labelTO25.Top = labelTH25.Top;
            labelTO25.Left = labelTH25.Left;
            labelTO26.Top = labelTH26.Top;
            labelTO26.Left = labelTH26.Left;

            CboTO11.Top = CboTH11.Top;
            CboTO11.Left = CboTH11.Left;
            TxtTO12.Top = TxtTH12.Top;
            TxtTO12.Left = TxtTH12.Left;
            TxtTO13.Top = TxtTH13.Top;
            TxtTO13.Left = TxtTH13.Left;
            TxtTO14.Top = TxtTH14.Top;
            TxtTO14.Left = TxtTH14.Left;
            TxtTO15.Top = TxtTH15.Top;
            TxtTO15.Left = TxtTH15.Left;
            BtnTO21.Top = BtnTH21.Top;
            BtnTO21.Left = BtnTH21.Left;
            TxtTO21.Top = TxtTH21.Top;
            TxtTO21.Left = TxtTH21.Left;
            TxtTO22.Top = TxtTH22.Top;
            TxtTO22.Left = TxtTH22.Left;
            TxtTO23.Top = TxtTH23.Top;
            TxtTO23.Left = TxtTH23.Left;
            TxtTO24.Top = TxtTH24.Top;
            TxtTO24.Left = TxtTH24.Left;
            TxtTO25.Top = TxtTH25.Top;
            TxtTO25.Left = TxtTH25.Left;
            TxtTO26.Top = TxtTH26.Top;
            TxtTO26.Left = TxtTH26.Left;


            labelTD11.Top = labelTH11.Top;
            labelTD11.Left = labelTH11.Left;
            labelTD12.Top = labelTH12.Top;
            labelTD12.Left = labelTH12.Left;
            labelTD13.Top = labelTH13.Top;
            labelTD13.Left = labelTH13.Left;
            labelTD14.Top = labelTH14.Top;
            labelTD14.Left = labelTH14.Left;
            labelTD15.Top = labelTH15.Top;
            labelTD15.Left = labelTH15.Left;
            labelTD21.Top = labelTH21.Top;
            labelTD21.Left = labelTH21.Left;
            labelTD22.Top = labelTH22.Top;
            labelTD22.Left = labelTH22.Left;
            labelTD23.Top = labelTH23.Top;
            labelTD23.Left = labelTH23.Left;
            labelTD24.Top = labelTH24.Top;
            labelTD24.Left = labelTH24.Left;
            labelTD25.Top = labelTH25.Top;
            labelTD25.Left = labelTH25.Left;
            labelTD26.Top = labelTH26.Top;
            labelTD26.Left = labelTH26.Left;

            CboTD11.Top = CboTH11.Top;
            CboTD11.Left = CboTH11.Left;
            TxtTD12.Top = TxtTH12.Top;
            TxtTD12.Left = TxtTH12.Left;
            TxtTD13.Top = TxtTH13.Top;
            TxtTD13.Left = TxtTH13.Left;
            TxtTD14.Top = TxtTH14.Top;
            TxtTD14.Left = TxtTH14.Left;
            TxtTD15.Top = TxtTH15.Top;
            TxtTD15.Left = TxtTH15.Left;
            BtnTD21.Top = BtnTH21.Top;
            BtnTD21.Left = BtnTH21.Left;
            TxtTD21.Top = TxtTH21.Top;
            TxtTD21.Left = TxtTH21.Left;
            TxtTD22.Top = TxtTH22.Top;
            TxtTD22.Left = TxtTH22.Left;
            TxtTD23.Top = TxtTH23.Top;
            TxtTD23.Left = TxtTH23.Left;
            TxtTD24.Top = TxtTH24.Top;
            TxtTD24.Left = TxtTH24.Left;
            TxtTD25.Top = TxtTH25.Top;
            TxtTD25.Left = TxtTH25.Left;
            TxtTD26.Top = TxtTH26.Top;
            TxtTD26.Left = TxtTH26.Left;


            labelED11.Top = labelTH11.Top;
            labelED11.Left = labelTH11.Left;
            labelED12.Top = labelTH12.Top;
            labelED12.Left = labelTH12.Left;
            labelED13.Top = labelTH13.Top;
            labelED13.Left = labelTH13.Left;
            labelED14.Top = labelTH14.Top;
            labelED14.Left = labelTH14.Left;
            labelED15.Top = labelTH15.Top;
            labelED15.Left = labelTH15.Left;
            labelED21.Top = labelTH21.Top;
            labelED21.Left = labelTH21.Left;
            labelED22.Top = labelTH22.Top;
            labelED22.Left = labelTH22.Left;
            labelED23.Top = labelTH23.Top;
            labelED23.Left = labelTH23.Left;
            labelED24.Top = labelTH24.Top;
            labelED24.Left = labelTH24.Left;
            labelED25.Top = labelTH25.Top;
            labelED25.Left = labelTH25.Left;
            labelED26.Top = labelTH26.Top;
            labelED26.Left = labelTH26.Left;

            CboED11.Top = CboTH11.Top;
            CboED11.Left = CboTH11.Left;
            TxtED12.Top = TxtTH12.Top;
            TxtED12.Left = TxtTH12.Left;
            TxtED13.Top = TxtTH13.Top;
            TxtED13.Left = TxtTH13.Left;
            TxtED14.Top = TxtTH14.Top;
            TxtED14.Left = TxtTH14.Left;
            TxtED15.Top = TxtTH15.Top;
            TxtED15.Left = TxtTH15.Left;
            BtnED21.Top = BtnTH21.Top;
            BtnED21.Left = BtnTH21.Left;
            TxtED21.Top = TxtTH21.Top;
            TxtED21.Left = TxtTH21.Left;
            TxtED22.Top = TxtTH22.Top;
            TxtED22.Left = TxtTH22.Left;
            TxtED23.Top = TxtTH23.Top;
            TxtED23.Left = TxtTH23.Left;
            TxtED24.Top = TxtTH24.Top;
            TxtED24.Left = TxtTH24.Left;
            TxtED25.Top = TxtTH25.Top;
            TxtED25.Left = TxtTH25.Left;
            TxtED26.Top = TxtTH26.Top;
            TxtED26.Left = TxtTH26.Left;

        }
        private void SetPositionGb()
        {
            Int32 liTop = 233, liLeft = 6, liHeight = 221, liWidth = 690;
            GbInformation.Width = this.Width -180;
            GbPriceList.Top = GbInformation.Top;
            GbPriceList.Left = GbInformation.Left;
            GbAddress.Top = GbInformation.Top;
            GbAddress.Left = GbInformation.Left;
            GbAddress.Height = GbAddress.Height;    // 461
            GbAddress.Width = GbInformation.Width;      // 702
            GbAddressDefault.Width = GbAddress.Width;
            GbPriceList.Height = GbAddress.Height;
            GbPriceList.Width = GbAddress.Width;
            GbContact.Top = GbInformation.Top;
            GbContact.Left = GbInformation.Left;
            GbContact.Height = GbAddress.Height;
            GbContact.Width = GbAddress.Width;
            GbVoucher.Top = GbInformation.Top;
            GbVoucher.Left = GbInformation.Left;
            GbVoucher.Height = GbAddress.Height;
            GbVoucher.Width = GbAddress.Width;
            GbPicture.Top = GbInformation.Top;
            GbPicture.Left = GbInformation.Left;
            GbPicture.Height = GbAddress.Height;
            GbPicture.Width = GbAddress.Width;
            GbNote.Top = GbInformation.Top;
            GbNote.Left = GbInformation.Left;
            GbNote.Height = GbAddress.Height;
            GbNote.Width = GbAddress.Width;
            GbOwner.Top = GbInformation.Top;
            GbOwner.Left = GbInformation.Left;
            GbOwner.Height = GbAddress.Height;
            GbOwner.Width = GbAddress.Width;
            //GrdAddress.Top = GrdAddress.Top;        // 233
            //GrdAddress.Left = GrdAddress.Left;      // 6
            //GrdAddress.Width = GbAddress.Width - 20;
            GrdPriceList.Width = GbAddress.Width - 20;
            GrdContact.Top = liTop+25;
            GrdContact.Left = GrdContact.Left;      //
            GrdContact.Height = liHeight - 25;  //  221
            GrdContact.Width = liWidth;    //  690
            GrdVoucher.Top = GrdPriceList.Top;
            GrdVoucher.Left = GrdPriceList.Left;
            GrdVoucher.Height = GrdPriceList.Height;
            GrdVoucher.Width = liWidth;
            GrdPicture.Top = liTop;
            GrdPicture.Left = liLeft;
            GrdPicture.Height = liHeight;
            GrdPicture.Width = liWidth;
            GrdNote.Top = liTop;
            GrdNote.Left = liLeft;
            GrdNote.Height = liHeight;
            GrdNote.Width = liWidth;
            GrdOwner.Top = liTop;
            GrdOwner.Left = liLeft;
            GrdOwner.Height = liHeight;
            GrdOwner.Width = liWidth;
        }
        private void VisibleGroupBoxFalse()
        {
            GbAddressDefault.Visible = false;
            GbPriceList.Visible = false;
            GbAddress.Visible = false;
            GbContact.Visible = false;
            GbInformation.Visible = false;
            GbVoucher.Visible = false;
            GbPicture.Visible = false;
            GbNote.Visible = false;
            GbOwner.Visible = false;
        }
        private void SaveMemberAdd(Boolean aFlagCloseForm)
        {
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
            //lsMemNameE = TxtNameE1.Text.Substring(0, 1);
            if (lsNode == "Node0")
            {
                lsNode = "information";
                leNode = NodeMember.Member;
            }
            lsNode = TabMember.SelectedTab.Name.ToLower();
            switch (lsNode)
            {
                case "tabinformation":
                    {
                        if (SaveMember())
                        {
                            MessageBox.Show("Save OK", "Add Member", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabpricelist":
                    {
                        if (SavePriceList())
                        {
                            MessageBox.Show("Save Price List success", "Add Price List", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabaddress":
                    {
                        if (SaveAddress())
                        {
                            SelectAddress();
                            MessageBox.Show("Save More address success", "Add More address", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabcontact":
                    {
                        if (SaveContact())
                        {
                            SelectContact();
                            MessageBox.Show("Save Contact success", "Add Contact", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabpicture":
                    {
                        if (SavePicture())
                        {
                            MessageBox.Show("Save Pciture success", "save picture", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabnote":
                    {
                        if (SaveNote()==true)
                        {
                            SelectNote();
                            MessageBox.Show("Save Note success", "save note", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabowner":
                    {
                        if (SaveOwner())
                        {
                            MessageBox.Show("Save Owner success", "save owner", MessageBoxButtons.OK);
                        }
                        break;
                    }
            }
            if (aFlagCloseForm)
            {
                CloseForm();
            }
        }

        private Boolean SavePicture()
        {
            string lsPathDesc = Application.StartupPath + "\\member\\" + lsMemID;
            try
            {                
                lstblMember.MemID = TxtMemID.Text;
                lstblMember.PicId = TxtPicId.Text;
                lstblMember.PictureDescT = TxtDescT.Text;
                lstblMember.PictureDescE = TxtDescE.Text;
                lstblMember.PictureRemark = "-";
                lstblMember.PicFileName = TxtFileName.Text;
                lsGdb.CopyFile(TxtPathPic.Text + "\\" + TxtFileName.Text, lsPathDesc, TxtFileName.Text);
                lstblMember.CreateMemberPicture(lsGdb.Gdb);
            }
            catch (Exception e)
            {
                string ls = "ไม่สามารถ Copy Picture ได้ ";
                lsGdb.WriteLogError(ls, e, "", "CancelVoidVoucher ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return true;
        }
        private Boolean SaveContact()
        {            
            lstblContact.ContactID = liContactID;
            lstblContact.ContactNameE = TxtContactNameE.Text;
            lstblContact.ContactNameT = TxtContactNameT.Text;
            lstblContact.ContactSurnameE = TxtContactSurNameE.Text;
            lstblContact.ContactSurnametT = TxtContactSurNameT.Text;
            lstblContact.Line1 = TxtContactLine1.Text;
            lstblContact.RefID = TxtMemID.Text;
            if (TxtSubDistrictContact.Text == "")
            {
                MessageBox.Show("ตำบลไม่มีข้อมูล กรุณาเลือกตำบาล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                lstblContact.SubDistrictCode = "-";
                //return false;
            }
            else
            {
                lstblContact.SubDistrictCode = lsSubDistrictCodeContact;
            }
            if (TxtDistrictContact.Text != "")
            {
                lstblContact.DistrictCode = lsDistrictCodeContact;
            }
            else
            {
                MessageBox.Show("อำเภอไม่มีข้อมูล กรุณาเลือกอำเภอ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                //return false;
                lstblContact.DistrictCode = "-";
            }
            if (TxtProvContact.Text != "")
            {
                lstblContact.ProvCode = lsProvCodeContact;
            }
            else
            {
                MessageBox.Show("จังหวัดไม่มีข้อมูล กรุณาเลือกจังหวัด", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                //return false;
                lstblContact.ProvCode = "-";
            }
            if (ChkEnglishContact.Checked == true)
            {
                lstblContact.FlagLanguage = Contact.Flaglanguage1.English;
            }
            else
            {
                lstblContact.FlagLanguage = Contact.Flaglanguage1.Thai;
            }
            if (ChkSkk9.Checked == true)
            {
                lstblContact.FlagSkk9 = Contact.FlagShowSkk91.ShowSkk9;
            }
            else
            {
                lstblContact.FlagSkk9 = Contact.FlagShowSkk91.NoShowSkk9;
            }
            if (ChkContactMeeting.Checked)
            {
                lstblContact.FlagContactMeeting = Contact.FlagContactMeeting1.YesContactMeeting;
            }
            else
            {
                lstblContact.FlagContactMeeting = Contact.FlagContactMeeting1.NoContactMeeting;
            }
            if (ChkPrintLabel.Checked)
            {
                lstblContact.FlagPrintLabel = "1";
            }
            else
            {
                lstblContact.FlagPrintLabel = "0";
            }
            lstblContact.PostCode = TxtPostCodeContact.Text;
            lstblContact.Tele = TxtContactTele.Text;
            lstblContact.EMail = TxtContactemail.Text;
            lstblContact.PositionT = TxtContactPositionT.Text;
            lstblContact.CreateContact(lsGdb.Gdb);
            SelectContact();
            return true;
        }
        private Boolean SaveAddress()
        {
            Address lstblAddress = new Address();
            switch (TabMemberAddress.SelectedTab.Name.Substring(3, 3))
            {
                case ("106") :
                    {
                        lstblAddress.AddressName = TxtTH12.Text;
                        lstblAddress.Line1 = TxtTH13.Text;
                        lstblAddress.AddressId = liAddressID;
                        lstblAddress.RefID = TxtMemID.Text;
                        if (TxtTH21.Text == "")
                        {
                            MessageBox.Show("ตำบลไม่มีข้อมูล กรุณาเลือกตำบาล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            lstblAddress.SubDistrictCode = "-";
                            //return false;
                        }
                        else
                        {
                            lstblAddress.SubDistrictCode = lsSubDistrictCodeAddress;
                        }
                        if (ChkEnglishAddress.Checked == true)
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.English;
                        }
                        else
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.Thai;
                        }
                        if (TxtTH22.Text != "")
                        {
                            lstblAddress.DistrictCode = lsDistrictCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("อำเภอไม่มีข้อมูล กรุณาเลือกอำเภอ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.DistrictCode = "-";
                        }
                        if (TxtTH23.Text != "")
                        {
                            lstblAddress.ProvCode = lsProvCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("จังหวัดไม่มีข้อมูล กรุณาเลือกจังหวัด", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.ProvCode = "-";
                        }
                        lstblAddress.PostCode = TxtTH24.Text;
                        lstblAddress.Telephone = TxtTH25.Text;
                        lstblAddress.Website = TxtTH14.Text;
                        lstblAddress.Email = TxtTH15.Text;
                        //lstblAddress.AddressCode = CboTH11.SelectedValue.ToString();
                        lstblAddress.AddressCode = "106";
                        lstblAddress.Fax = TxtTH26.Text;
                        break;
                    }
                case ("107"):
                    {
                        lstblAddress.AddressName = TxtEH12.Text;
                        lstblAddress.Line1 = TxtEH13.Text;
                        lstblAddress.AddressId = liAddressID;
                        lstblAddress.RefID = TxtMemID.Text;
                        if (TxtEH21.Text == "")
                        {
                            MessageBox.Show("ตำบลไม่มีข้อมูล กรุณาเลือกตำบาล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            lstblAddress.SubDistrictCode = "-";
                            //return false;
                        }
                        else
                        {
                            lstblAddress.SubDistrictCode = lsSubDistrictCodeAddress;
                        }
                        if (ChkEnglishAddress.Checked == true)
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.English;
                        }
                        else
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.Thai;
                        }
                        if (TxtEH22.Text != "")
                        {
                            lstblAddress.DistrictCode = lsDistrictCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("อำเภอไม่มีข้อมูล กรุณาเลือกอำเภอ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.DistrictCode = "-";
                        }
                        if (TxtEH23.Text != "")
                        {
                            lstblAddress.ProvCode = lsProvCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("จังหวัดไม่มีข้อมูล กรุณาเลือกจังหวัด", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.ProvCode = "-";
                        }
                        lstblAddress.PostCode = TxtEH24.Text;
                        lstblAddress.Telephone = TxtEH25.Text;
                        lstblAddress.Website = TxtEH14.Text;
                        lstblAddress.Email = TxtEH15.Text;
                        //lstblAddress.AddressCode = CboEH11.SelectedValue.ToString();
                        lstblAddress.AddressCode = "107";
                        lstblAddress.Fax = TxtEH26.Text;
                        break;
                    }
                case ("108"):
                    {
                        lstblAddress.AddressName = TxtTO12.Text;
                        lstblAddress.Line1 = TxtTO13.Text;
                        lstblAddress.AddressId = liAddressID;
                        lstblAddress.RefID = TxtMemID.Text;
                        if (TxtTO21.Text == "")
                        {
                            MessageBox.Show("ตำบลไม่มีข้อมูล กรุณาเลือกตำบาล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            lstblAddress.SubDistrictCode = "-";
                            //return false;
                        }
                        else
                        {
                            lstblAddress.SubDistrictCode = lsSubDistrictCodeAddress;
                        }
                        if (ChkEnglishAddress.Checked == true)
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.English;
                        }
                        else
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.Thai;
                        }
                        if (TxtTO22.Text != "")
                        {
                            lstblAddress.DistrictCode = lsDistrictCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("อำเภอไม่มีข้อมูล กรุณาเลือกอำเภอ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.DistrictCode = "-";
                        }
                        if (TxtTO23.Text != "")
                        {
                            lstblAddress.ProvCode = lsProvCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("จังหวัดไม่มีข้อมูล กรุณาเลือกจังหวัด", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.ProvCode = "-";
                        }
                        lstblAddress.PostCode = TxtTO24.Text;
                        lstblAddress.Telephone = TxtTO25.Text;
                        lstblAddress.Website = TxtTO14.Text;
                        lstblAddress.Email = TxtTO15.Text;
                        //lstblAddress.AddressCode = CboTO11.SelectedValue.ToString();
                        lstblAddress.AddressCode = "108";
                        lstblAddress.Fax = TxtTO26.Text;
                        break;
                    }
                case ("109"):
                    {
                        lstblAddress.AddressName = TxtTD12.Text;
                        lstblAddress.Line1 = TxtTD13.Text;
                        lstblAddress.AddressId = liAddressID;
                        lstblAddress.RefID = TxtMemID.Text;
                        if (TxtTD21.Text == "")
                        {
                            MessageBox.Show("ตำบลไม่มีข้อมูล กรุณาเลือกตำบาล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            lstblAddress.SubDistrictCode = "-";
                            //return false;
                        }
                        else
                        {
                            lstblAddress.SubDistrictCode = lsSubDistrictCodeAddress;
                        }
                        if (ChkEnglishAddress.Checked == true)
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.English;
                        }
                        else
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.Thai;
                        }
                        if (TxtTD22.Text != "")
                        {
                            lstblAddress.DistrictCode = lsDistrictCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("อำเภอไม่มีข้อมูล กรุณาเลือกอำเภอ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.DistrictCode = "-";
                        }
                        if (TxtTD23.Text != "")
                        {
                            lstblAddress.ProvCode = lsProvCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("จังหวัดไม่มีข้อมูล กรุณาเลือกจังหวัด", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.ProvCode = "-";
                        }
                        lstblAddress.PostCode = TxtTD24.Text;
                        lstblAddress.Telephone = TxtTD25.Text;
                        lstblAddress.Website = TxtTD14.Text;
                        lstblAddress.Email = TxtTD15.Text;
                        //lstblAddress.AddressCode = CboTD11.SelectedValue.ToString();
                        lstblAddress.AddressCode = "109";
                        lstblAddress.Fax = TxtTD26.Text;
                        break;
                    }
                case ("110"):
                    {
                        lstblAddress.AddressName = TxtED12.Text;
                        lstblAddress.Line1 = TxtED13.Text;
                        lstblAddress.AddressId = liAddressID;
                        lstblAddress.RefID = TxtMemID.Text;
                        if (TxtED21.Text == "")
                        {
                            MessageBox.Show("ตำบลไม่มีข้อมูล กรุณาเลือกตำบาล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            lstblAddress.SubDistrictCode = "-";
                            //return false;
                        }
                        else
                        {
                            lstblAddress.SubDistrictCode = lsSubDistrictCodeAddress;
                        }
                        if (ChkEnglishAddress.Checked == true)
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.English;
                        }
                        else
                        {
                            lstblAddress.FlagLanguage = Address.Flaglanguage1.Thai;
                        }
                        if (TxtED22.Text != "")
                        {
                            lstblAddress.DistrictCode = lsDistrictCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("อำเภอไม่มีข้อมูล กรุณาเลือกอำเภอ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.DistrictCode = "-";
                        }
                        if (TxtED23.Text != "")
                        {
                            lstblAddress.ProvCode = lsProvCodeAddress;
                        }
                        else
                        {
                            MessageBox.Show("จังหวัดไม่มีข้อมูล กรุณาเลือกจังหวัด", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK);
                            //return false;
                            lstblAddress.ProvCode = "-";
                        }
                        lstblAddress.PostCode = TxtED24.Text;
                        lstblAddress.Telephone = TxtED25.Text;
                        lstblAddress.Website = TxtED14.Text;
                        lstblAddress.Email = TxtED15.Text;
                        //lstblAddress.AddressCode = CboED11.SelectedValue.ToString();
                        lstblAddress.AddressCode = "110";
                        lstblAddress.Fax = TxtED26.Text;
                        break;
                    }
            }
            

            lstblAddress.CreateAddress(lsGdb.Gdb);
            return true;
        }
        private Boolean SavePriceList()
        {            
            decimal ldoPriceStart=0, ldoPriceEnd=0, ldoDeposit=0;
            string lsRemark="", lsPlCode="", lsSQL="";
            lstblMember.MemID = lsMemID;
            if (ChkBaht.Checked == true)
            {
                lstblMember.UpdateTypePriceBath(TxtMemID.Text, true, lsGdb.Gdb);
            }
            else
            {
                lstblMember.UpdateTypePriceBath(TxtMemID.Text, false, lsGdb.Gdb);
            }
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            for (int i = 0; i <= GrdPriceList.ActiveSheet.RowCount-1; i++)
            {
                lsRemark = GrdPriceList.ActiveSheet.GetText(i, 0);
                if (GrdPriceList.ActiveSheet.GetText(i, 0) != "")
                {

                    //lsPlCode = GrdPriceList.ActiveSheet.getn
                    string plindex = GrdPriceList.ActiveSheet.GetValue(i, 0).ToString();
                    lsPlCode = lsplcode[Convert.ToInt16(plindex)];
                    //lsPlCode = GrdPriceList.ActiveSheet.Cells[i, liColPLPLID].CellType;
                    //lsPlCode = GrdPriceList.ActiveSheet.GetValue(i, 0).ToString();
                    //lsPlCode = GrdPriceList.ActiveSheet.GetValue(i, liColPLPLID).ToString();
                    lsSQL = "Select plcode From typeroom Where plnamee = '" +lsPlCode +"'";
                    //lsSQL = "Select plcode From typeroom Where plnamee = '" + lsPlCode + "'";
                    lsComm.CommandText = lsSQL;
                    lsRead = lsComm.ExecuteReader();
                    /*if (lsRead.HasRows)
                    {
                        while (lsRead.Read())
                        {
                            lsPlCode = lsRead["plcode"].ToString();
                        }
                    }*/
                    lsRead.Close();
                    if (GrdPriceList.ActiveSheet.GetText(i, liColPLType) != "")
                    {
                        ldoPriceStart = Convert.ToDecimal(GrdPriceList.ActiveSheet.GetValue(i, liColPLPriceStart).ToString());
                        ldoPriceEnd = Convert.ToDecimal(GrdPriceList.ActiveSheet.GetValue(i, liColPLPriceEnd).ToString());
                        ldoDeposit = Convert.ToDecimal(GrdPriceList.ActiveSheet.GetValue(i, liColPLDeposit).ToString());
                        lsRemark = GrdPriceList.ActiveSheet.GetText(i, liColPLRemark).ToString();
                        lstblMember.CreatePriceList(lsPlCode, ldoPriceStart, ldoPriceEnd, ldoDeposit, lsRemark, lsGdb.Gdb);
                        //lstblMember.UpdateFlagSend(lsMemID, "001", lsGdb.Gdb);
                        //lstblMember.UpdateFlagSend(lsMemID, "003", lsGdb.Gdb);
                    }
                }
            }
            return true;
        }
        private Boolean SaveNote()
        {            
            if (lstblMember.CreateNote(TxtNote.Text, liNoteID, lsMemID, lsGdb.Gdb))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean SaveOwner()
        {            
            if (lstblMember.CreateOwner(CboOwnerNew.Text, liOwnerID, lsMemID, lsGdb.Gdb))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean SaveMember()
        {
            DateTime  ldVoidDate;            
            lstblMember.MemNameE1 = TxtNameE1.Text;
            lstblMember.MemNameE2 = TxtNameE2.Text;
            lstblMember.MemNameT = TxtNameT.Text;
            //lstblMember.Remark = TxtRemark.Text;
            lstblMember.NumRoom = Convert.ToInt32(TxtNumRooms.Value);
            lstblMember.PriceEnd = TxtPriceEnd1.Value;
            lstblMember.PriceStart = TxtPriceStart1.Value;
            lstblMember.HotelRating = Convert.ToInt32(TxtRating.Value);
            if (CboHotelChain.SelectedValue != null)
            {
                lstblMember.HotelChain = CboHotelChain.SelectedValue.ToString();
            }
            else
            {
                lstblMember.HotelChain = "-";
            }
            if (CboNation.SelectedValue != null)
            {
                lstblMember.NationCode = CboNation.SelectedValue.ToString();
            }
            else
            {
                lstblMember.NationCode = "-";
            }
            //lstblMember.RegionCode = CboRegion.SelectedValue.ToString();
            if (CboRegion.SelectedValue != null)
            {
                lstblMember.RegionCode = CboRegion.SelectedValue.ToString();
            }
            else
            {
                lstblMember.RegionCode = "-";
            }
            //lstblMember.TMemCode = CboTMem.SelectedValue.ToString();
            if (CboTMem.SelectedValue != null)
            {
                lstblMember.TMemCode = CboTMem.SelectedValue.ToString();
            }
            else
            {
                lstblMember.TMemCode = "-";
            }
            //lstblMember.TBisCode = CboTBis.SelectedValue.ToString();
            if (CboTBis.SelectedValue != null)
            {
                lstblMember.TBisCode = CboTBis.SelectedValue.ToString();
            }
            else
            {
                lstblMember.TBisCode = "-";
            }
            //lstblMember.FlagGreenLeft = CboGreenL.SelectedValue.ToString();
            if (CboGreenL.SelectedValue != null)
            {
                lstblMember.FlagGreenLeft = CboGreenL.SelectedValue.ToString();
            }
            else
            {
                lstblMember.FlagGreenLeft = "-";
            }
            if (CboProvMem.SelectedValue != null)
            {
                lstblMember.ProvCode = CboProvMem.SelectedValue.ToString();
            }
            else
            {
                lstblMember.ProvCode = "-";
            }
            if (ChkBaht.Checked)
            {
                lstblMember.TypePriceBaht = "1";
            }
            else
            {
                lstblMember.TypePriceBaht = "0";
            }
            if (ChkSale.Checked)
            {
                lstblMember.FlagSale = "1";
            }
            else
            {
                lstblMember.FlagSale = "0";
            }
            if (CboLocation.SelectedValue != null)
            {
                lstblMember.Location = CboLocation.SelectedValue.ToString();
            }
            else
            {
                lstblMember.Location = "-";
            }
            try
            {
                ldVoidDate = DateTime .Parse (TxtMemStartDate.Text);
                lstblMember.StartDate = lsGdb.SelectDateMySQL(Convert.ToDateTime(TxtMemStartDate.Text));
            }
            catch
            {
                lstblMember.StartDate = "2007-01-01";
            }
            try
            {
                ldVoidDate = DateTime.Parse(TxtMemEndDate.Text);
                lstblMember.EndDate = lsGdb.SelectDateMySQL(Convert.ToDateTime(TxtMemEndDate.Text));
            }
            catch
            {
                lstblMember.EndDate = "2007-01-01";
            }
            try
            {
                ldVoidDate = DateTime.Parse(TxtMemRegisDate.Text);
                lstblMember.RegisDate = lsGdb.SelectDateMySQL(Convert.ToDateTime(TxtMemRegisDate.Text));
            }
            catch
            {
                lstblMember.RegisDate = "2007-01-01";
            }
            if (ChkFitness.Checked)
            {
                lstblMember.FlagFitness = "1";
            }
            else
            {
                lstblMember.FlagFitness = "0";
            }
            if (ChkRestaurant.Checked)
            {
                lstblMember.FlagRestaurant = "1";
            }
            else
            {
                lstblMember.FlagRestaurant = "0";
            }
            if (ChkSpa.Checked)
            {
                lstblMember.FlagSpa = "1";
            }
            else
            {
                lstblMember.FlagSpa = "0";
            }
            if (ChkBusiness.Checked)
            {
                lstblMember.FlagBusiness = "1";
            }
            else
            {
                lstblMember.FlagBusiness = "0";
            }
            if (ChkMeeting.Checked)
            {
                lstblMember.FlagMeeting = "1";
            }
            else
            {
                lstblMember.FlagMeeting = "0";
            }
            if (CboStar.SelectedValue != null)
            {
                lstblMember.Star = CboStar.SelectedValue.ToString();
            }
            else
            {
                lstblMember.Star = "0";
            }
            //lstblMember.Star = CboStar.SelectedValue.ToString();
            lstblMember.MemID = TxtMemID.Text;
            lstblMember.FlagSend = "1";
            lstblMember.SKK9ID = TxtSKK9.Text;
            lstblMember.EMailAccount = TxtEMailAcc.Text;
            lstblMember.OwnerID = liOwnerID;
            lstblMember.NoteID = liNoteIDDefault;
            lstblMember.AddressID = liAddressIDDefault;
            lstblMember.RemarkResign = lsRemarkResign;
            lstblMember.Deposit = ldoDeposit;
            //lstblMember.CreateMember(lsGdb .Gdb);
            //lsGdb.Gdb.Close();
            //if (lsGdb.Gdb.State == ConnectionState.Closed)
            //{
            //    lsGdb.ConnectDatabase();
            //}
            
            if (lstblMember.CreateMember(lsGdb .Gdb))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void MemberAdd_KeyUp(object sender, KeyEventArgs e)
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
        private void TxtNameT_Enter(object sender, EventArgs e)
        {
            TxtNameT.BackColor = Color.SkyBlue;
        }
        private void TxtNameT_Leave(object sender, EventArgs e)
        {
            TxtNameT.BackColor = Color.White;
        }

        private void TxtNameE1_Enter(object sender, EventArgs e)
        {
            TxtNameE1.BackColor = Color.SkyBlue;
        }

        private void TxtNameE2_Enter(object sender, EventArgs e)
        {
            TxtNameE2.BackColor = Color.SkyBlue;
        }

        private void CboTMem_Enter(object sender, EventArgs e)
        {
            //CboTMem.BackColor = Color.SkyBlue;
        }

        private void TxtNumRooms_Enter(object sender, EventArgs e)
        {
            TxtNumRooms.BackColor = Color.SkyBlue;
        }

        private void TxtRating_Enter(object sender, EventArgs e)
        {
            TxtRating.BackColor = Color.SkyBlue;
        }

        private void TxtPriceStart1_Enter(object sender, EventArgs e)
        {
            TxtPriceStart1.BackColor = Color.SkyBlue;
        }

        private void TxtPriceEnd1_Enter(object sender, EventArgs e)
        {
            TxtPriceEnd1.BackColor = Color.SkyBlue;
        }

        private void TxtNameE1_Leave(object sender, EventArgs e)
        {
            TxtNameE1.BackColor = Color.White;
        }

        private void TxtNameE2_Leave(object sender, EventArgs e)
        {
            TxtNameE2.BackColor = Color.White;
        }

        private void TxtNumRooms_Leave(object sender, EventArgs e)
        {
            TxtNumRooms.BackColor = Color.White;
        }

        private void TxtRating_Leave(object sender, EventArgs e)
        {
            TxtRating.BackColor = Color.White;
        }

        private void TxtPriceStart1_Leave(object sender, EventArgs e)
        {
            TxtPriceStart1.BackColor = Color.White;
        }

        private void TxtPriceEnd1_Leave(object sender, EventArgs e)
        {
            TxtPriceEnd1.BackColor = Color.White;
        }

        private void TxtNameT_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtNameE1.SelectAll();
                        TxtNameE1.Focus();
                        break;
                    }
            }
        }

        private void TxtNameE1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtNameE2.SelectAll();
                        TxtNameE2.Focus();
                        break;
                    }
            }
        }

        private void TxtNameE2_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboTMem.SelectAll();
                        CboTMem.Focus();
                        break;
                    }
            }
        }

        private void CboTMem_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboRegion.SelectAll();
                        CboRegion.Focus();
                        break;
                    }
            }
        }

        private void CboRegion_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboTBis.SelectAll();
                        CboTBis.Focus();
                        break;
                    }
            }
        }

        private void CboTBis_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboGreenL.SelectAll();
                        CboGreenL.Focus();
                        break;
                    }
            }
        }
        private void CboGreenL_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboStar.SelectAll();
                        CboStar.Focus();
                        break;
                    }
            }
        }
        private void CboStar_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboHotelChain.SelectAll();
                        CboHotelChain.Focus();
                        break;
                    }
            }
        }
        private void CboHotelChain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtNumRooms.SelectAll();
                        TxtNumRooms.Focus();
                        break;
                    }
            }
        }
        private void TxtNumRooms_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtRating.SelectAll();
                        TxtRating.Focus();
                        break;
                    }
            }
        }
        private void TxtRating_KeyUp(object sender, KeyEventArgs e)
        {            
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtPriceStart1.SelectAll();
                        TxtPriceStart1.Focus();
                        break;
                    }
            }
        }
        private void TxtPriceStart1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtPriceEnd1.SelectAll();
                        TxtPriceEnd1.Focus();
                        break;
                    }
            }
        }
        private void TxtPriceEnd1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtPriceEnd1.SelectAll();
                        CboProvMem.Focus();
                        break;
                    }
            }
        }
        private void CboProvMem_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtRemark.SelectAll();
                        //TxtRemark.Focus();
                        break;
                    }
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void PrepareDateMaster()
        {
            string lsSQL = "";
            KingPower lsGen = new KingPower();
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=root;Password=Ekartc2c5");
            conn.Open();            
            lsSQL = "Select * From member Where memid = '" + TxtMemID.Text + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, conn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            //lsGen.CreateTextFile("master", lsRead);
            //lsSendVoucher.ConnectDatabase();
            if (lsGen.CreateTextProductFile("master", lsRead))
            {
                MessageBox.Show("เตรียมข้อมูล เรียบร้อย", "Prepare Data All", MessageBoxButtons.OK);
            }
            lsRead.Close();
        }
        private void GrdAddress_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SelectVoucher(TxtVouStartDate.Text, TxtVouEndDate.Text, lsMemID);
        }
        private void BtnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "All Files|*.*";
            OFD.Title = "Select a Cursor File";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Pic.ImageLocation = OFD.FileName;
                TxtPathPic.Text = OFD.FileName;
                FileInfo fi = new FileInfo(OFD.FileName);
                TxtPathPic.Text = fi.DirectoryName;
                TxtFileName.Text = fi.Name;
            }
        }
        private void CboLinkPicture_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                TxtPicId.Text = lsMemID + CboLinkPicture.SelectedValue.ToString();
            }
        }
        private void GrdPicture_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            SelectPicture(GrdPicture.ActiveSheet.GetText(e.Row, 0));
        }

        private void savenew_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SaveMemberAdd(true);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void TvwMem_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void textFileKingPowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepareDateMaster();
        }

        private void cancelMember_Click(object sender, EventArgs e)
        {
            Member lsTblMember = new Member();
            if (lsTblMember.MemberCancel(TxtMemID.Text))
            {
                MessageBox.Show("แก้ไขสถานะสมาชิก " + TxtMemNameE.Text + "\n" + "Cancel Member เรียบร้อย", "", MessageBoxButtons.OK);
            }
        }

        private void noSaleMember_Click(object sender, EventArgs e)
        {
            Member lsTblMember = new Member();
            if (lsTblMember.MemberNoSale(TxtMemID.Text))
            {
                MessageBox.Show("แก้ไขสถานะสมาชิก " + TxtMemNameE.Text + "\n" + "No Sale เรียบร้อย", "", MessageBoxButtons.OK);
            }
        }

        private void TxtMemID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectMember(TxtMemID.Text);
            }
        }

        private void resignMember_Click(object sender, EventArgs e)
        {
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
            Member lsTblMember = new Member();
            if (resignMember.Text == "สมาชิกลาออก")
            {
                if (MessageBox.Show("ต้องการเปลี่ยนสถานะสมาชิกเป็น ลาออก\n" + "MemID " + TxtMemID.Text, "เปลี่ยนแปลงสถานะสมาชิก", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    InputBoxResult lfReason = InputBox.Show("ป้อนหมายเหตุ การลาออกของสมาชิกเพื่อเก็บเป็น record ไว้", "หมายเหตุ สมาชิกลาออก", "-");
                    if (lsTblMember.MemberResign(TxtMemID.Text, DateTime.Today, lfReason.Text, lsGdb.Gdb))
                    {
                        MessageBox.Show("บันทึกการลาออกสมาชิกเรียบร้อย", "สมาชิกลาออก", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("ต้องการเปลี่ยนสถานะสมาชิก กลับมาใช้งานใหม่\n" + "MemID " + TxtMemID.Text, "เปลี่ยนแปลงสถานะสมาชิก", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    InputBoxResult lfReason = InputBox.Show("ป้อนหมายเหตุ การลาออกของสมาชิกเพื่อเก็บเป็น record ไว้", "หมายเหตุ สมาชิกลาออก", "-");
                    
                    if (lsTblMember.MemberReEntry(TxtMemID.Text, lsGdb.Gdb))
                    {
                        MessageBox.Show("บันทึกการกลับมาเป็นสมาชิกใหม่ เรียบร้อย", "สมาชิก re Entry", MessageBoxButtons.OK);
                    }
                }
            }
        }
        private void GrdNote_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string lsNoteID = "";
            lsNoteID = GrdNote.ActiveSheet.GetText(e.Row, 0);
            if (lsNoteID != "")
            {
                SelectNote(Convert.ToInt32(lsNoteID));
            }
        }
        private void GrdOwner_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            SelectOwner(GrdOwner.ActiveSheet.GetText(e.Row, 0));
        }
        private void GrdContact_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string lsContactID = "";
            lsContactID = GrdContact.ActiveSheet.GetText(e.Row, 4);
            if (lsContactID != "")
            {
                SelectContact(Convert.ToInt32(lsContactID));
            }
        }
        private void BtnSubDistrictAddress_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            lsGdb.Gdb.Close();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            if (ChkEnglishAddress.Checked == true)
            {
                TxtTH21.Text = frm.SubDistrictNameE;
                TxtTH22.Text = frm.DistrictNameE;
                TxtTH23.Text = frm.ProvNameE;
            }
            else
            {
                TxtTH21.Text = frm.SubDistrictNameT;
                TxtTH22.Text = frm.DistrictNameT;
                TxtTH23.Text = frm.ProvNameT;
            }
            
            TxtTH24.Text = frm.PostCode;
            lsProvCodeAddress = frm.ProvCode;
            lsDistrictCodeAddress = frm.DistrictCode;
            lsSubDistrictCodeAddress = frm.SubDistrictCode;
        }
        private void BtnSubDistrictContact_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            lsGdb.Gdb.Close();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            if (ChkEnglishContact.Checked == true)
            {
                TxtSubDistrictContact.Text = frm.SubDistrictNameE;
                TxtDistrictContact.Text = frm.DistrictNameE;
                TxtProvContact.Text = frm.ProvNameE;
            }
            else
            {
                TxtSubDistrictContact.Text = frm.SubDistrictNameT;
                TxtDistrictContact.Text = frm.DistrictNameT;
                TxtProvContact.Text = frm.ProvNameT;
            }
            TxtPostCodeContact.Text = frm.PostCode;
            lsProvCodeContact = frm.ProvCode;
            lsDistrictCodeContact = frm.DistrictCode;
            lsSubDistrictCodeContact = frm.SubDistrictCode;
        }
        private void SetAddNew()
        {
            switch (leNode)
            {
                case NodeMember.Contact:
                    {
                        TxtContactemail.Text = "";
                        TxtContactLine1.Text = "";
                        //TxtContactMemNameE.Text = "";
                        TxtContactMobile.Text = "";
                        TxtContactNameE.Text = "";
                        TxtContactNameT.Text = "";
                        TxtContactPositionT.Text = "";
                        TxtContactSurNameE.Text = "";
                        TxtContactSurNameT.Text = "";
                        TxtContactTele.Text = "";
                        TxtContactwww.Text = "";
                        TxtSubDistrictContact.Text = "";
                        TxtDistrictContact.Text = "";
                        TxtProvContact.Text = "";
                        TxtPostCodeContact.Text = "";
                        ChkThaiContact.Checked = true;
                        ChkEnglishContact.Checked = false;
                        ChkSkk9.Checked = false;
                        TxtContactNameT.Focus();
                        liContactID = 0;
                        //PaintGrdContact();
                        break;
                    }
                case NodeMember.Note:
                    {
                        TxtNote.Text = "";
                        liNoteID = 0;
                        TxtNote.Focus();
                        break;
                    }
            }
        }
        private void AddNew_Click(object sender, EventArgs e)
        {
            SetAddNew();
        }
        private void saveclose_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SaveMemberAdd(true);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void save_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SaveMemberAdd(false);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void dele_Click(object sender, EventArgs e)
        {
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
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Member lsTblMember = new Member();
            lsTblMember.MemberDelete(TxtMemID.Text, TxtNameT.Text, lsGdb.Gdb);
            MessageBox.Show("ลบข้อมูลเรียบร้อย", "DEL");
            CloseForm();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void ChkThaiAddress_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GrdPriceList_ComboDropDown(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            
        }

        private void GrdPriceList_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    {
                        GrdPriceList.ActiveSheet.SetActiveCell(e.Row, liColPLPriceStart);
                        //GrdPriceList .ActiveSheet .SetText (e.Row ,liColPLPLID ,lsMemID + GrdPriceList .ActiveSheet .GetDropDownFilterItems (liColPLType ));
                        break;
                    }
                case 1:
                    {
                        GrdPriceList.ActiveSheet.SetActiveCell(e.Row, liColPLPriceEnd);
                        break;
                    }
                case 2:
                    {
                        GrdPriceList.ActiveSheet.SetActiveCell(e.Row, liColPLRemark);
                        break;
                    }
            }
        }

        private void label45_DoubleClick(object sender, EventArgs e)
        {
            TxtTH12.Text = CboTH11.Text;
        }

        private void copyaddress_Click(object sender, EventArgs e)
        {
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
            MemberCopyAddress frm = new MemberCopyAddress();
            frm.Connnection = lsGdb.Gdb;
            frm.AddressIDOLD = liAddressID;
            frm.MemID = lsMemID;
            frm.MemNameE = TxtMemNameE.Text;
            frm.ShowDialog(this);
            SelectAddress();
        }

        //private void contactoutlook_Click(object sender, EventArgs e)
        //{
        //    Boolean lbFind = false;
        //    try
        //    {
        //        // Create the Outlook application.
        //        Outlook.Application oApp = new Outlook.Application();

        //        // Get the NameSpace and Logon information.
        //        Outlook.NameSpace oNS = oApp.GetNamespace("mapi");

        //        // Log on by using a dialog box to choose the profile.
        //        oNS.Logon(Missing.Value, Missing.Value, true, true);

        //        Outlook.ContactItem contact = oApp.GetNamespace("mapi").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
        //            .Items.Find(string.Format("[e-mail]='{0}' ", TxtContactemail.Text)) as Outlook.ContactItem;
        //        //Outlook.ContactItem contact = oApp.GetNamespace("mapi").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
        //        //    .Items.Find(string.Format("[LastName]='{0}' AND [FirstName]='{1}'", TxtContactSurNameT.Text, TxtContactNameT.Text)) as Outlook.ContactItem;
        //        if (contact != null)
        //        {
        //            contact.Delete();
        //        }
        //        // Alternate logon method that uses a specific profile.
        //        // TODO: If you use this logon method, 
        //        //  change the profile name to an appropriate value.
        //        //oNS.Logon("YourValidProfile", Missing.Value, false, true);
        //        Outlook.ContactItem OContact = (Outlook.ContactItem)oApp.CreateItem(Outlook.OlItemType.olContactItem);
        //        OContact.FirstName = TxtContactNameT.Text;
        //        OContact.LastName = TxtContactSurNameT.Text;
        //        OContact.CompanyName = TxtMemNameE.Text;
        //        OContact.MobileTelephoneNumber = TxtContactMobile.Text;
        //        OContact.WebPage = TxtContactwww.Text;
        //        OContact.HomeTelephoneNumber = TxtContactTele.Text;
        //        OContact.Email1Address = TxtContactemail.Text;
        //        OContact.HomeAddress = TxtContactLine1.Text;
        //        OContact.JobTitle = TxtContactPositionT.Text;
        //        OContact.Save();

        //        Int32 li = 0;
        //        string ls="";
        //        Outlook.MAPIFolder  DL = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
        //        Outlook.Items ItemDL = DL.Items;
        //        Int32 liCount = ItemDL.Count;
        //        foreach (object item in DL.Items)
        //        {
        //            if (item is Outlook.DistListItem)
        //            {
        //                li++;
        //                lbFind = false;
        //                ls = ls + DL.Items[li].ToString();
        //                Outlook.DistListItem list = (Outlook.DistListItem)item;
        //                ls = list.DLName;
        //                if (ls == TxtMemNameE.Text)
        //                {
        //                    lbFind = true;
        //                    for (int i = 0; i <= list.MemberCount; i++)
        //                    {
        //                        string name = null;
        //                        string phoneNo = null;
        //                        Outlook.Recipient recipient = list.GetMember(i);
        //                        if (recipient == null)
        //                        {
        //                            string email = recipient.Address;
        //                            object o = DL.Items.Find("[Email1Address] = '" + email + "'");
        //                            if (o is Outlook.ContactItem)
        //                            {
        //                                name = ((Outlook.ContactItem)o).FullName;
        //                                phoneNo = ((Outlook.ContactItem)o).MobileTelephoneNumber;
        //                                try
        //                                {
        //                                    //Add the items to a data table.
        //                                }
        //                                catch
        //                                {

        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (lbFind==false)
        //        {
        //            Outlook.Recipient aaa;
        //            aaa = oApp.Session.CreateRecipient(TxtContactNameT.Text + " " + TxtContactSurNameT.Text);
        //            aaa.Resolve();
        //            Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.CreateItem(Outlook.OlItemType.olDistributionListItem);
        //            //Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.de
        //            oDistList.DLName = TxtMemNameE.Text;
        //            oDistList.AddMember(aaa);
        //            oDistList.Save();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{0} Exception caught.", ex);
        //        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
        //    }
        //}

        private void ChkSkk9_CheckedChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                CheckFlagSkk9();
            }
        }

        private void CheckFlagSkk9()
        {
            string lsSQL = "";
            lsSQL = "Select * From contact Where flagskk9 = '1' and refid = '" + lsMemID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                lsSQL = "";
                while (lsRead.Read())
                {
                    lsSQL = lsSQL + lsRead["contactnamet"].ToString() + " " + lsRead["contactsurnamet"].ToString() + "\n";
                }
                MessageBox.Show("มีรายชื่ออยู่แล้ว  \n" + lsSQL, "");
            }
            lsRead.Close();
        }

        private void TabMember_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TabMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lsNode = TabMember.Name;
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            lsNode = TabMember.SelectedTab.Name.ToLower();
            switch (lsNode)
            {
                case "tabpricelist":
                    leNode = NodeMember.Price;
                    VisibleGroupBoxFalse();
                    GbPriceList.Visible = true;
                    GbPriceList.BringToFront();
                    SelectPriceList();
                    break;
                case "tabinformation":
                    leNode = NodeMember.Member;
                    VisibleGroupBoxFalse();
                    GbInformation.Visible = true;
                    GbAddressDefault.Visible = true;
                    break;
                case "tabaddress":
                    //TabMemberAddress.SelectedIndex = 0;
                    leNode = NodeMember.Address;
                    SelectAddress();
                    VisibleGroupBoxFalse();
                    GbAddress.Visible = true;
                    break;
                case "tabcontact":
                    leNode = NodeMember.Contact;
                    VisibleGroupBoxFalse();
                    SelectContact();
                    GbContact.Visible = true;
                    break;
                case "tabvoucher":
                    leNode = NodeMember.Voucher;
                    VisibleGroupBoxFalse();
                    PaintGrdVoucher();
                    //SelectVoucher(TxtVouStartDate.Text, TxtVouEndDate.Text, lsMemID);
                    GbVoucher.Visible = true;
                    break;
                case "tabpicture":
                    leNode = NodeMember.Picture;
                    VisibleGroupBoxFalse();
                    SelectPicture();
                    GbPicture.Visible = true;
                    break;
                case "tabnote":
                    leNode = NodeMember.Note;
                    VisibleGroupBoxFalse();
                    SelectNote();
                    GbNote.Visible = true;
                    break;
                case "tabowner":
                    leNode = NodeMember.Owner;
                    VisibleGroupBoxFalse();
                    SelectOwner();
                    GbOwner.Visible = true;
                    break;
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            //lsNode = TabMember.SelectedTab.Name;
        }
         private void Del_Click(object sender, EventArgs e)
        {
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
             lsNode = TabMember.SelectedTab.Name.ToLower();
            switch (lsNode)
            {
                //case "tabpricelist":
                //    {
                //        if (SavePriceList())
                //        {
                //            MessageBox.Show("Save Price List success", "Add Price List", MessageBoxButtons.OK);
                //        }
                //        break;
                //    }
                //case "tabaddress":
                //    {
                //        if (SaveAddress())
                //        {
                //            SelectAddress();
                //            MessageBox.Show("Save More address success", "Add More address", MessageBoxButtons.OK);
                //        }
                //        break;
                //    }
                case "tabcontact":
                    {
                        if (lstblContact.DeleteContactID(liContactID, lsGdb.Gdb))
                        {
                            SelectContact();
                            MessageBox.Show("Delete Contact success", "Delete Contact", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabpicture":
                    {
                        if (SavePicture())
                        {
                            MessageBox.Show("Save Pciture success", "save picture", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabnote":
                    {
                        if (SaveNote() == true)
                        {
                            SelectNote();
                            MessageBox.Show("Save Note success", "save note", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "tabowner":
                    {
                        if (SaveOwner())
                        {
                            MessageBox.Show("Save Owner success", "save owner", MessageBoxButtons.OK);
                        }
                        break;
                    }
            }
        }

        private void TabMemberAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectAddress(lsMemID , TabMemberAddress.SelectedTab.Name.Substring(3,3));
        }

        private void Tab107_Click(object sender, EventArgs e)
        {

        }

        private void BtnEH21_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            lsGdb.Gdb.Close();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            if (ChkEnglishAddress.Checked == true)
            {
                TxtEH21.Text = frm.SubDistrictNameE;
                TxtEH22.Text = frm.DistrictNameE;
                TxtEH23.Text = frm.ProvNameE;
            }
            else
            {
                TxtEH21.Text = frm.SubDistrictNameT;
                TxtEH22.Text = frm.DistrictNameT;
                TxtEH23.Text = frm.ProvNameT;
            }

            TxtEH24.Text = frm.PostCode;
            lsProvCodeAddress = frm.ProvCode;
            lsDistrictCodeAddress = frm.DistrictCode;
            lsSubDistrictCodeAddress = frm.SubDistrictCode;
        }

        private void BtnTO21_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            lsGdb.Gdb.Close();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            if (ChkEnglishAddress.Checked == true)
            {
                TxtTO21.Text = frm.SubDistrictNameE;
                TxtTO22.Text = frm.DistrictNameE;
                TxtTO23.Text = frm.ProvNameE;
            }
            else
            {
                TxtTO21.Text = frm.SubDistrictNameT;
                TxtTO22.Text = frm.DistrictNameT;
                TxtTO23.Text = frm.ProvNameT;
            }

            TxtTO24.Text = frm.PostCode;
            lsProvCodeAddress = frm.ProvCode;
            lsDistrictCodeAddress = frm.DistrictCode;
            lsSubDistrictCodeAddress = frm.SubDistrictCode;
        }

        private void BtnTD21_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            lsGdb.Gdb.Close();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            if (ChkEnglishAddress.Checked == true)
            {
                TxtTD21.Text = frm.SubDistrictNameE;
                TxtTD22.Text = frm.DistrictNameE;
                TxtTD23.Text = frm.ProvNameE;
            }
            else
            {
                TxtTD21.Text = frm.SubDistrictNameT;
                TxtTD22.Text = frm.DistrictNameT;
                TxtTD23.Text = frm.ProvNameT;
            }

            TxtTD24.Text = frm.PostCode;
            lsProvCodeAddress = frm.ProvCode;
            lsDistrictCodeAddress = frm.DistrictCode;
            lsSubDistrictCodeAddress = frm.SubDistrictCode;
        }

        private void BtnED21_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            lsGdb.Gdb.Close();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            if (ChkEnglishAddress.Checked == true)
            {
                TxtED21.Text = frm.SubDistrictNameE;
                TxtED22.Text = frm.DistrictNameE;
                TxtED23.Text = frm.ProvNameE;
            }
            else
            {
                TxtED21.Text = frm.SubDistrictNameT;
                TxtED22.Text = frm.DistrictNameT;
                TxtED23.Text = frm.ProvNameT;
            }

            TxtED24.Text = frm.PostCode;
            lsProvCodeAddress = frm.ProvCode;
            lsDistrictCodeAddress = frm.DistrictCode;
            lsSubDistrictCodeAddress = frm.SubDistrictCode;
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowSel =  GrdPriceList.ActiveSheet.ActiveRow.Index ;
            GrdPriceList.ActiveSheet.Rows.Remove(rowSel,1);
        }
    }
}