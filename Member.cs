using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//using System.Runtime.InteropServices;
namespace ThaHr30
{
    class Member
    {
        Connection lsGdb = new Connection();
        private string lsMemID = "", lsMemNameE1 = "", lsMemNameE2 = "", lsMemNameT = "", lsTMemCode = "", lsRegionCode = "", lsTBisCode = "", lsHotelChain = "", lsStartDate="", lsEndDate="", lsRegisDate="", lsSKK9ID="";
        private string lsStar = "", lsFlagGreenLeft = "", lsFlagSend = "", lsRemark="", lsProvCode="", lsTypePriceBaht="", lsNationCode="", lsFlagSale="", lsFlagResign="";
        private Int32 liNumRoom = 0, liHotelRating = 0, liOwnerID = 0, liNoteID = 0, liAddressID=0;
        private decimal ldoPriceStart = 0, ldoPriceEnd = 0, ldoMemRate=0, ldoDeposit=0;
        private string lsPicId = "", lsPicDescT="", lsPicDescE="", lsPicFileName="", lsPicRemark="", lsLocationCode="", lsEMailAcc="", lsRemarkResign="";
        string lsFlagMeeting = "0", lsFlagSpa = "0", lsFlagRestaurant = "0", lsFlagBusiness = "0", lsFlagFitness="0";
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
        public string SKK9ID
        {
            get
            {
                return lsSKK9ID;
            }
            set
            {
                lsSKK9ID = value.Trim();
            }
        }
        public string MemNameE1
        {
            get
            {
                return lsMemNameE1;
            }
            set
            {
                lsMemNameE1 = value.Trim();
                if (lsMemNameE1.Contains("'"))
                {
                    lsMemNameE1 = lsMemNameE1.Replace("'", "''");
                }
            }
        }
        public Int32 OwnerID
        {
            get
            {
                return liOwnerID;
            }
            set
            {
                liOwnerID = value;
            }
        }
        public Int32 AddressID
        {
            get
            {
                return liAddressID;
            }
            set
            {
                liAddressID = value;
            }
        }
        public Int32 NoteID
        {
            get
            {
                return liNoteID;
            }
            set
            {
                liNoteID = value;
            }
        }
        public string MemNameE2
        {
            get
            {
                return lsMemNameE2;
            }
            set
            {
                lsMemNameE2 = value.Trim();
                if (lsMemNameE2.Contains("'"))
                {
                    lsMemNameE2 = lsMemNameE2.Replace("'", "''");
                }
            }
        }
        public string MemNameT
        {
            get
            {
                return lsMemNameT;
            }
            set
            {
                lsMemNameT = value.Trim();
                if (lsMemNameT.Contains("'"))
                {
                    lsMemNameT = lsMemNameT.Replace("'", "''");
                }
            }
        }
        public string TMemCode
        {
            get
            {
                return lsTMemCode;
            }
            set
            {
                lsTMemCode = value;
            }
        }
        public string RegionCode
        {
            get
            {
                return lsRegionCode;
            }
            set
            {
                lsRegionCode = value;
            }
        }
        public string FlagSend
        {
            get
            {
                return lsFlagSend;
            }
            set
            {
                lsFlagSend = value;
            }
        }
        
        public string FlagResign
        {
            get
            {
                return lsFlagResign;
            }
            set
            {
                lsFlagResign = value;
            }
        }
        public string FlagGreenLeft
        {
            get
            {
                return lsFlagGreenLeft;
            }
            set
            {
                lsFlagGreenLeft = value;
            }
        }
        public Int32 NumRoom
        {
            get
            {
                return liNumRoom;
            }
            set
            {
                liNumRoom = value;
            }
        }
        public Int32 HotelRating
        {
            get
            {
                return liHotelRating;
            }
            set
            {
                liHotelRating = value;
            }
        }
        public string HotelChain
        {
            get
            {
                return lsHotelChain;
            }
            set
            {
                lsHotelChain = value;
            }
        }
        public decimal PriceStart
        {
            get
            {
                return ldoPriceStart;
            }
            set
            {
                ldoPriceStart = value;
            }
        }
        public decimal PriceEnd
        {
            get
            {
                return ldoPriceEnd;
            }
            set
            {
                ldoPriceEnd = value;
            }
        }
        public decimal Deposit
        {
            get
            {
                return ldoDeposit;
            }
            set
            {
                ldoDeposit = value;
            }
        }
        public decimal MemberRate
        {
            get
            {
                return ldoMemRate;
            }
            set
            {
                ldoMemRate = value;
            }
        }
        public string TBisCode
        {
            get
            {
                return lsTBisCode;
            }
            set
            {
                lsTBisCode = value;
            }
        }
        public string Star
        {
            get
            {
                return lsStar;
            }
            set
            {
                lsStar = value;
            }
        }
        public string Remark
        {
            get
            {
                return lsRemark;
            }
            set
            {
                lsRemark = value.Trim();
                if (lsRemark.Contains("'"))
                {
                    lsRemark = lsRemark.Replace("'", "''");
                }
            }
        }
        public string RemarkResign
        {
            get
            {
                return lsRemarkResign;
            }
            set
            {
                lsRemarkResign = value.Trim();
                if (lsRemarkResign.Contains("'"))
                {
                    lsRemarkResign = lsRemarkResign.Replace("'", "''");
                }
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
                lsProvCode = value;
            }
        }
        public string TypePriceBaht
        {
            get
            {
                return lsTypePriceBaht;
            }
            set
            {
                if (value.Trim() == "True")
                {
                    lsTypePriceBaht = "1";
                }
                else if (value.Trim() == "False")
                {
                    lsTypePriceBaht = "0";
                }
                else
                {
                    lsTypePriceBaht = value.Trim();
                }
            }
        }
        public string FlagSale
        {
            get
            {
                return lsFlagSale;
            }
            set
            {
                lsFlagSale = value.Trim();
            }
        }
        public string NationCode
        {
            get
            {
                return lsNationCode;
            }
            set
            {
                lsNationCode = value.Trim();
                if (lsNationCode == "")
                {
                    lsNationCode = "-";
                }
            }
        }
        public string PicId
        {
            get
            {
                return lsPicId;
            }
            set
            {
                lsPicId = value.Trim();
            }
        }
        public string Location
        {
            get
            {
                return lsLocationCode;
            }
            set
            {
                lsLocationCode = value.Trim();
            }
        }
        public string PicFileName
        {
            get
            {
                return lsPicFileName;
            }
            set
            {
                lsPicFileName = value.Trim();
            }
        }
        public string PictureDescT
        {
            get
            {
                return lsPicDescT;
            }
            set
            {
                lsPicDescT = value.Trim();
                if (lsPicDescT.Contains("'"))
                {
                    lsPicDescT = lsPicDescT.Replace("'", "''");
                }
            }
        }
        public string PictureDescE
        {
            get
            {
                return lsPicDescE;
            }
            set
            {
                lsPicDescE = value.Trim();
                if (lsPicDescE.Contains("'"))
                {
                    lsPicDescE = lsPicDescE.Replace("'", "''");
                }
            }
        }
        public string PictureRemark
        {
            get
            {
                return lsPicRemark;
            }
            set
            {
                lsPicRemark = value.Trim();
                if (lsPicRemark.Contains("'"))
                {
                    lsPicRemark = lsPicRemark.Replace("'", "''");
                }
            }
        }
        public string EMailAccount
        {
            get
            {
                return lsEMailAcc;
            }
            set
            {
                lsEMailAcc = value.Trim();
                if (lsEMailAcc.Contains("'"))
                {
                    lsEMailAcc = lsPicDescT.Replace("'", "''");
                }
            }
        }
        public string StartDate
        {
            get
            {
                return lsStartDate;
            }
            set
            {
                lsStartDate = value.Trim();
            }
        }
        public string EndDate
        {
            get
            {
                return lsEndDate;
            }
            set
            {
                lsEndDate = value.Trim();
            }
        }
        public string RegisDate
        {
            get
            {
                return lsRegisDate;
            }
            set
            {
                lsRegisDate = value.Trim();
            }
        }
        public string FlagMeeting
        {
            get
            {
                return lsFlagMeeting;
            }
            set
            {
                lsFlagMeeting = value.Trim();
            }
        }
        public string FlagSpa
        {
            get
            {
                return lsFlagSpa;
            }
            set
            {
                lsFlagSpa = value.Trim();
            }
        }
        public string FlagRestaurant
        {
            get
            {
                return lsFlagRestaurant;
            }
            set
            {
                lsFlagRestaurant = value.Trim();
            }
        }
        public string FlagFitness
        {
            get
            {
                return lsFlagFitness;
            }
            set
            {
                lsFlagFitness = value.Trim();
            }
        }
        public string FlagBusiness
        {
            get
            {
                return lsFlagBusiness;
            }
            set
            {
                lsFlagBusiness = value.Trim();
            }
        }
        public Boolean UpdateDefaultDeposit(string aMemID, decimal aDeposit, MySqlConnection aConn)
        {
            string lsSQL = "Update member Set deposit = " + aDeposit + " Where memid = '" + aMemID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean UpdateFlagSend(string aMemID, string aCounterid, MySqlConnection aConn)
        {
            string lsSQL = "Update member Set flagsend = '2' Where memid = '" + aMemID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean UpdateFlagPrintSKK9(string aMemID, MySqlConnection aConn)
        {
            string lsSQL = "Update member Set flagprintskk9 = '1' Where memid = '" + aMemID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean UpdateFlagPrintSKK9ClearAll( MySqlConnection aConn)
        {
            string lsSQL = "Update member Set flagprintskk9 = '0'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean UpdateTypePriceBath(string aMemID, Boolean aBath, MySqlConnection aConn)
        {
            Boolean lbReturn = true;
            string lsSQL = "";
            if (aBath == true)
            {
                lsSQL = "Update member Set typepricebaht = '0' Where memid = '" + aMemID + "'";
            }
            else
            {
                lsSQL = "Update member Set typepricebaht = '1' Where memid = '" + aMemID + "'";
            }
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return lbReturn;
        }
        public Boolean UpdateDepositMemberPriceList(string aPLID, decimal aDeposit, MySqlConnection aConn)
        {
            Boolean lbReturn = true;
            string lsSQL = "Update memberpricelist Set deposit = " + aDeposit + " Where plid = '" + aPLID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return lbReturn;
        }
        public Boolean MemberDelete(string aMemID, string aMemNameT, MySqlConnection aConn)
        {
            Boolean lbReturn = true;
            string lsSQL = "", ls="";
            if (MessageBox.Show("ต้องการลบสมาชิก " + aMemID + " " + aMemNameT, "ลบข้อมูล", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                lsSQL = "Select vouno, hotelcode From voucher Where hotelcode = '" + aMemID + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
                MySqlDataReader lsRead;
                lsRead = lsComm.ExecuteReader();
                if (lsRead.HasRows)
                {
                    while (lsRead.Read())
                    {
                        ls = ls + lsRead["vouno"].ToString() + "\n";
                        
                    }
                    MessageBox.Show("มีข้อมูลการจองห้องพัก\n" + ls, "ไม่สามารถลบข้อมูลได้", MessageBoxButtons.OK);
                    
                    
                    
                    lsRead.Close();
                }
                else
                {
                    lsRead.Close();
                    lsSQL = "Delete From member Where memid ='" + aMemID + "'";
                    lsComm.CommandText = lsSQL;
                    lsComm.ExecuteNonQuery();
                    lsSQL = "Delete From address Where refid = '" + aMemID + "'";
                    lsComm.CommandText = lsSQL;
                    lsComm.ExecuteNonQuery();
                    lsSQL = "Delete From contact Where refid = '" + aMemID + "'";
                    lsComm.CommandText = lsSQL;
                    lsComm.ExecuteNonQuery();
                    lsSQL = "Delete From membernote Where refid = '" + aMemID + "'";
                    lsComm.CommandText = lsSQL;
                    lsComm.ExecuteNonQuery();
                    lsSQL = "Delete From memberowner Where refid = '" + aMemID + "'";
                    lsComm.CommandText = lsSQL;
                    lsComm.ExecuteNonQuery();
                    lsSQL = "Delete From memberpicture Where memid = '" + aMemID + "'";
                    lsComm.CommandText = lsSQL;
                    lsComm.ExecuteNonQuery();
                    lsSQL = "Delete From memberpricelist Where memid = '" + aMemID + "'";
                    lsComm.CommandText = lsSQL;
                    lsComm.ExecuteNonQuery();
                }
            }
            return lbReturn ;
        }
        public Boolean MemberResign(string aMemID, DateTime ResignDate, string aRemarkResign, MySqlConnection aConn)
        {
            string lsSQL = "Update member Set flagresign = '1', flagsale = '3', flag = '3', flagsend = '1', remarkresign = '"
                    +aRemarkResign + "' Where memid = '" + aMemID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean MemberReEntry(string aMemID, MySqlConnection aConn)
        {
            string lsSQL = "Update member Set flagresign = '0', flagsale = '1', flag = '1', flagsend = '1' Where memid = '" + aMemID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean CreateMember(MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "";
            Int32 liMax = 0;
            Connection lsConn = new Connection();
            lsConn.ConnectDatabase();
            
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead;
            if (lsMemID == "")
            {
                lsSQL = "select max(memid) as cnt From member ";
                lsComm.CommandText = lsSQL;
                
                
                lsRead = lsComm.ExecuteReader();
                while (lsRead.Read())
                {
                    liMax = Convert.ToInt32(lsRead["cnt"].ToString());
                }
                lsRead.Close();
                liMax++;
                lsMemID = liMax.ToString("00000");
            }
            if (lsFlagSale == "")
            {
                lsFlagSale = "1";
            }
            
            try
            {
                lsSQL = "Delete From member Where memid = '" + lsMemID + "'";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lsSQL = "Insert Into member(memid, memnamee1, memnamet, tmemcode, "
                    + "regioncode, numroom, hotelrating, flagsend, "
                    + "flaggreenleft, tbiscode, pricestart, priceend, "
                    + "hotelchaincode, star, remark, provcode, "
                    + "typepricebaht, memrate, flagsend001, flagsend002, flagsend003, "
                    + "nationcode, flagsale, locationcode, emailaccount, "
                    + "startdate, enddate, regisdate, skk9id, flag, "
                    + "memnamee2, ownerid, addressid, flagresign, "
                    + "noteid, remarkresign, deposit, flagrestaurant, "
                    + "flagmeeting, flagspa, flagfitness, flagbusiness) "
                    + "Values('" + lsMemID + "','" + lsMemNameE1 + "','" + lsMemNameT + "','" + lsTMemCode + "','"
                    + lsRegionCode + "'," + liNumRoom + "," + liHotelRating + ",'" + lsFlagSend + "','"
                    + lsFlagGreenLeft + "','" + lsTBisCode + "'," + ldoPriceStart + "," + ldoPriceEnd + ",'"
                    + lsHotelChain + "','" + lsStar + "','" + lsRemark + "','" + lsProvCode + "','"
                    + lsTypePriceBaht + "'," + ldoMemRate + ",'1','1','1','"
                    + lsNationCode + "','" + lsFlagSale + "','" + lsLocationCode + "','" + lsEMailAcc + "','" 
                    + lsStartDate + "','" + lsEndDate + "','" + lsRegisDate + "','" + lsSKK9ID + "','1','"
                    + lsMemNameE2+"',"+liOwnerID+"," + liAddressID + ",'"+ lsFlagResign + "'," 
                    + liNoteID + ",'" +lsRemarkResign+ "',"+ldoDeposit+",'" + lsFlagRestaurant + "','" 
                    + lsFlagMeeting + "','"+ lsFlagSpa + "','" + lsFlagFitness + "','" + lsFlagBusiness + "')";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล Member ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "Create Member ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean CreateOwner(string aOwner, Int32 aOwnerID, string aRefID, MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            Int32 liMax = 0;
            string lsSQL = "", lsOwner = "";
            try
            {
                lsSQL = "select max(ownerid) as cnt From memberowner ";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                MySqlDataReader lsRead = lsComm.ExecuteReader();
                while (lsRead.Read())
                {
                    liMax = Convert.ToInt32(lsRead["cnt"].ToString());
                }
                lsRead.Close();
                liMax++;
                liOwnerID = liMax;
                lsOwner = aOwner.Replace("'", "''");
                lsSQL = "Delete From memberowner Where refid = '" + aRefID + "' and ownerid = '" + liOwnerID + "'";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lsSQL = "Insert Into memberowner(refid, ownerid, ownernamet)"
                    + "Values('" + aRefID + "'," + liOwnerID + ",'" + lsOwner + "')";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lsSQL = "Update member Set ownerid = " + liOwnerID + " Where memid = '" + aRefID + "'";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล CreateOwner ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CreateOwner");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean CreateNote(string aNote, Int32 aNoteID, string aRefID, MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            Int32 liMax = 0;
            string lsSQL = "", lsNote="";
            try
            {
                MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
                if (aNoteID == 0)
                {
                    lsSQL = "select max(noteid) as cnt From membernote ";
                    lsComm1.CommandText = lsSQL;
                    MySqlDataReader lsRead = lsComm1.ExecuteReader();
                    while (lsRead.Read())
                    {
                        liMax = Convert.ToInt32(lsRead["cnt"].ToString());
                    }
                    lsRead.Close();
                    liMax++;
                    liNoteID = liMax;
                }
                else
                {
                    liNoteID = aNoteID;
                }
                lsNote = aNote.Replace("'", "''");
                lsSQL = "Delete From membernote Where refid = '" + aRefID + "' and noteid = '" + liNoteID + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                lsComm.ExecuteNonQuery();
                lsSQL = "Insert Into membernote(refid, noteid, note)"
                    + "Values('" + aRefID + "'," + liNoteID + ",'" + lsNote + "')";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lsSQL = "Update member Set noteid = '" + liNoteID + "' Where memid = '" + aRefID + "'";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล CreateNote ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CreateNote");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean CreatePriceList(string aPlCode, decimal aPriceStart, decimal aPriceEnd, decimal aDeposit, string aRemark, MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "", lsPLID="";
            try
            {
                lsPLID = lsMemID + aPlCode;
                lsSQL = "Delete From memberpricelist Where plid = '"+lsPLID+"'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                lsComm.ExecuteNonQuery();
                lsSQL = "Insert Into memberpricelist(memid, plcode, pricestart, priceend, deposit, remark, plid)"
                    + "Values('" + lsMemID + "','" + aPlCode + "'," + aPriceStart + "," + aPriceEnd + "," + aDeposit +",'"
                    + aRemark + "','" + lsPLID + "')";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล CreatePriceList ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CreatePriceList");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean MemberCancel(string aMemID)
        {
            Boolean lbReturn = false;
            string lsSQL = "";
            //Int32 liMax = 0;
            try
            {
                Connection lsConn = new Connection();
                lsConn.ConnectDatabase();
                lsSQL = "Update member Set flag = '3', flagsend = '1', flagsale = '3' "
                    + "Where memid= '" + aMemID + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, lsConn.Gdb);
                lsComm.ExecuteNonQuery();
                lsConn.Gdb.Close();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถ ยกเลิก member ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CancelMember ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean MemberNoSale(string aMemID)
        {
            Boolean lbReturn = false;
            string lsSQL = "";
            //Int32 liMax = 0;
            try
            {
                Connection lsConn = new Connection();
                lsConn.ConnectDatabase();
                lsSQL = "Update member Set flag = '1', flagsale = '3', flagsend = '1' "
                    + "Where memid= '" + aMemID + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, lsConn.Gdb);
                lsComm.ExecuteNonQuery();
                lbReturn = true;
                lsConn.Gdb.Close();
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถ ห้ามขายได้ member ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CancelMember ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean CreateMemberPicture(MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "";
            try
            {
                lsSQL = "Delete From memberpicture Where picid = '" + lsPicId + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                lsComm.ExecuteNonQuery();
                lsSQL = "Insert Into memberpicture(memid, picid, desct, desce, filename, remark)"
                    + "Values('" + lsMemID + "','" + lsPicId + "','" + lsPicDescT + "','" + lsPicDescE + "','"
                    + lsPicFileName + "','" + lsPicRemark + "')";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล CreateMemberPicture ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CreateMemberPicture");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public string SendPriceList(string aMemId, string aConnHost, string aConnDesc, string aDatebase)
        {
            string lsSQL = "", lsReturn="";
            MySqlConnection lsConnHost = new MySqlConnection("Data Source=" + aConnHost + ";Database=" + aDatebase + ";User ID=root;Password=Ekartc2c5");
            lsConnHost.Open();
            MySqlConnection lsConnDesc = new MySqlConnection("Data Source=" + aConnDesc + ";Database=" + aDatebase + ";User ID=root;Password=Ekartc2c5");
            lsConnDesc.Open();
            lsSQL = "Select * From memberpricelist Where memid = '" + aMemId + "'";
            MySqlCommand lsCommHost = new MySqlCommand(lsSQL, lsConnHost);
            MySqlDataReader lsReadHost;
            lsReadHost = lsCommHost.ExecuteReader();
            if (lsReadHost.HasRows)
            {
                while (lsReadHost.Read())
                {
                    lsSQL = "Delete From memberpricelist Where memid = '" + aMemId + "' and plcode = '" + lsReadHost["plcode"].ToString() + "'" ;
                    MySqlCommand lsCommDesc = new MySqlCommand(lsSQL, lsConnDesc);
                    lsCommDesc.ExecuteNonQuery();
                    lsSQL = "Insert Into memberpricelist (memid, plcode, pricestart, priceend) " 
                        + "Values('" + lsReadHost["memid"].ToString() + "','" + lsReadHost["plcode"].ToString() + "'," + lsReadHost["pricestart"].ToString() + "," + lsReadHost["priceend"].ToString() + ") ";
                    MySqlCommand lsCommDesc1 = new MySqlCommand(lsSQL, lsConnDesc);
                    lsReturn = lsReturn + lsReadHost["plcode"].ToString();
                    lsCommDesc1.ExecuteNonQuery();
                }
            }
            lsReadHost.Close();
            lsConnDesc.Close();
            lsConnHost.Close();
            lsConnHost.Dispose();
            lsConnDesc.Dispose();
            return lsReturn;
        }
        public Boolean GenDatatoKingPower()
        {
            return true;
        }
    }
}
