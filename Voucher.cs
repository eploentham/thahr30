using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace ThaHr30
{
    class Voucher : Connection
    {
        Connection lsGdb = new Connection();
        private string lsVouNO = "", lsTableName = "", lsRoomNO = "", lsMAC = "", lsYear = "", lsMonth = "";
        private string lsVouDate = "", lsStaffCode = "", lsCounter1 = "", lsCouNO = "", lsShiftCode = "";
        private string lsHotelCode = "", lsResTime = "", lsGuestFirstName = "", lsGuestLastName = "", lsNationCode = "", lsRoomCode = "";
        private Int32 liVisitT = 0, liPax = 0, liResRooms = 0, liPersoninTrip = 0, liPrefix = 0;
        private decimal ldoRoomRate = 0, ldoDepositAMT = 0, ldoRoomRate1 = 0, ldoPriceEnd=0;
        private string lsStatusCode = "", lsCheckInTime = "", lsCheckOutTime = "", lsConfirmPerson = "", lsCardID="";
        private string lsRemark = "", lsFlag = "", lsProvCode = "", lsMemPlCode="", lsTaxi="",lsBreakFast="", lsRemarkReturn="", lsPay_Type="";
        public string VouNO
        {
            get
            {
                return lsVouNO;
            }
            set
            {
                lsVouNO = value.Trim();
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
        public string MemPlCode
        {
            get
            {
                return lsMemPlCode;
            }
            set
            {
                lsMemPlCode = value.Trim();
            }
        }
        //public Boolean Return
        //{
        //    get
        //    {
        //        return Return;
        //    }
        //    set
        //    {
        //        Return = value;
        //    }
        //}
        public string Pay_Type
        {
            get
            {
                return lsPay_Type;
            }
            set
            {
                lsPay_Type = value.Trim();
            }
        }
        public string CreaditCardID
        {
            get
            {
                return lsCardID ;
            }
            set
            {
                lsCardID = value.Trim();
            }
        }
        public string RemarkReturn
        {
            get
            {
                return lsRemarkReturn;
            }
            set
            {
                lsRemarkReturn = value.Trim();
            }
        }
        public string Taxi
        {
            get
            {
                return lsTaxi;
            }
            set
            {
                lsTaxi = value.Trim();
            }
        }
        public string Breakfast
        {
            get
            {
                return lsBreakFast;
            }
            set
            {
                lsBreakFast = value.Trim();
            }
        }
        public string MAC
        {
            get
            {
                return lsMAC;
            }
            set
            {
                lsMAC = value.Trim();
            }
        }
        public string TableName
        {
            get
            {
                return lsTableName;
            }
            set
            {
                lsTableName = value.Trim();
            }
        }
        public DateTime VouDate
        {
            get
            {
                DateTime ld;
                ld = Convert.ToDateTime(lsVouDate);
                return ld;
            }
            set
            {
                string ls = "";
                DateTime ld;
                ld = value;
                //ls = ld.Year.ToString() + "-" + ld.Month.ToString() + "-" + ld.Day.ToString();
                ls = lsGdb.SelectDateMySQL(ld);
                lsVouDate = ls;
            }
        }
        public string GuestFirstName
        {
            get
            {
                return lsGuestFirstName;
            }
            set
            {
                lsGuestFirstName = value.Trim();
                if (lsGuestFirstName.Contains("'"))
                {
                    lsGuestFirstName = lsGuestFirstName.Replace("'", "''");
                }
            }
        }
        public string GuestLastName
        {
            get
            {
                return lsGuestLastName;
            }
            set
            {
                lsGuestLastName = value.Trim();
                if (lsGuestLastName.Contains("'"))
                {
                    lsGuestLastName = lsGuestLastName.Replace("'", "''");
                }
            }
        }
        public string StaffCode
        {
            get
            {
                return lsStaffCode;
            }
            set
            {
                lsStaffCode = value;
            }
        }
        public string Counter1
        {
            get
            {
                return lsCounter1;
            }
            set
            {
                lsCounter1 = value.Trim();
            }
        }
        public string CouNO
        {
            get
            {
                return lsCouNO;
            }
            set
            {
                lsCouNO = value;
            }
        }
        public string ShiftCode
        {
            get
            {
                return lsShiftCode;
            }
            set
            {
                lsShiftCode = value;
            }
        }
        public string HotelCode
        {
            get
            {
                return lsHotelCode;
            }
            set
            {
                lsHotelCode = value;
            }
        }
        public string ResTime
        {
            get
            {
                return lsResTime;
            }
            set
            {
                lsResTime = value;
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
                lsNationCode = value;
            }
        }
        public string RoomCode
        {
            get
            {
                return lsRoomCode;
            }
            set
            {
                lsRoomCode = value.Trim();
            }
        }
        public Int32 VisitT
        {
            get
            {
                return liVisitT;
            }
            set
            {
                liVisitT = value;
            }
        }
        public Int32 PreFix
        {
            get
            {
                return liPrefix;
            }
            set
            {
                liPrefix = value;
            }
        }
        public Int32 PersoninTrip
        {
            get
            {
                return liPersoninTrip;
            }
            set
            {
                liPersoninTrip = value;
            }
        }
        public Int32 Pax
        {
            get
            {
                return liPax;
            }
            set
            {
                liPax = value;
            }
        }
        public Decimal RoomRate
        {
            get
            {
                return ldoRoomRate;
            }
            set
            {
                ldoRoomRate = value;
            }
        }
        public Decimal RoomRate1
        {
            get
            {
                return ldoRoomRate1;
            }
            set
            {
                ldoRoomRate1 = value;
            }
        }
        public Decimal DepositAMT
        {
            get
            {
                return ldoDepositAMT;
            }
            set
            {
                ldoDepositAMT = value;
            }
        }
        public DateTime CheckInTime
        {
            get
            {
                DateTime ld;
                ld = Convert.ToDateTime(lsCheckInTime);
                return ld;
            }
            set
            {
                string ls = "";
                DateTime ld;
                ld = value;
                ls = lsGdb.SelectDateMySQL(ld);
                lsCheckInTime = ls;
            }
        }
        public DateTime CheckOutTime
        {
            get
            {
                DateTime ld;
                ld = Convert.ToDateTime(lsCheckOutTime);
                return ld;
            }
            set
            {
                string ls = "";
                DateTime ld;
                ld = value;
                //ls = ld.Year.ToString() + "-" + ld.Month.ToString() + "-" + ld.Day.ToString();
                ls = lsGdb.SelectDateMySQL(ld);
                lsCheckOutTime = ls;
            }
        }
        public string StatusCode
        {
            get
            {
                return lsStatusCode;
            }
            set
            {
                lsStatusCode = value;
            }
        }
        public string ConfirmPerson
        {
            get
            {
                return lsConfirmPerson;
            }
            set
            {
                lsConfirmPerson = value.Trim();
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
        public string Flag
        {
            get
            {
                return lsFlag;
            }
            set
            {
                lsFlag = value;
            }
        }
        public Int32 ResRooms
        {
            get
            {
                return liResRooms;
            }
            set
            {
                liResRooms = value;
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
        public string RoomNO
        {
            get
            {
                return lsRoomNO;
            }
            set
            {
                lsRoomNO = value.Trim();
            }
        }
        public string Year
        {
            get
            {
                return lsYear;
            }
            set
            {
                lsYear = value.Trim();
            }
        }
        public Boolean ReturnVoucher(string aVouNO, string aRemark, DateTime aDate, MySqlConnection Conn)
        {
            string lsSQL = "";
            try
            {
                lsSQL = "Update voucher Set flagreturn = true, remarkreturn = '" + aRemark + "', flag = '5', returndate = '" + lsGdb.SelectDateMySQL(aDate) + ", flagsend = '1' Where vouno = '" + aVouNO + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                lsComm.ExecuteNonQuery();
            }
            catch(MySqlException e)
            {
                string ls = "ไม่สามารถ ยกเลิก Return ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CancelVoidVoucher ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
            return true;
        }
        public Boolean ConfirmVoucher(string aVouNO, string aConfirmBy, string aRoomNO, string aRemark, decimal aRoomRate1, MySqlConnection Conn)
        {
            string lsSQL = "";
            //Connection lsConn = new Connection();
            //lsConn.ConnectDatabase();
            try
            {
                lsSQL = "Update voucher Set flagconfirm = '2', confirmperson = '"
                    + aConfirmBy + "', roomno = '" + aRoomNO + "', confirmremark = '" + aRemark + "', roomrate1 = " + aRoomRate1
                    + ", flagsend = '1' Where vouno = '" + aVouNO + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                lsComm.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถ ยกเลิก Void ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "ConfirmVoucher ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
            return true;
        }
        public void UpdateFlagSend(MySqlConnection Conn)
        {
            string lsSQL = "";
            try
            {
                lsSQL = "Update voucher Set flagsend = '2' "
                    + "Where vouno = '" + lsVouNO + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                lsComm.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถ ยกเลิก Void ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "UpdateFlagSend ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
        }
        public void CancelNoShowVoucher(string aCounter, string aVouNo)
        {
            string lsSQL = "";
            //Int32 liMax = 0;
            Connection lsConn = new Connection();
            lsConn.ConnectDatabase();
            lsSQL = "Update voucher Set flag = '2', flagsend = '1' "
                + "Where counter1= '" + aCounter + "' and vouno = '" + aVouNo + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsConn.Gdb);
            lsComm.ExecuteNonQuery();
            lsConn.Gdb.Close();
        }
        public void NoShowVoucher(string aCounter, string aVouNo)
        {
            string lsSQL = "";
            //Int32 liMax = 0;
            Connection lsConn = new Connection();
            lsConn.ConnectDatabase();
            lsSQL = "Update voucher Set flag = '4', flagsend ='1' "
                + "Where counter1= '" + aCounter + "' and vouno = '" + aVouNo + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsConn.Gdb);
            lsComm.ExecuteNonQuery();
            lsConn.Gdb.Close();
        }
        public void VoidVoucher(string aCounter, string aVouNo)
        {
            string lsSQL = "";
            string lsVoidDate = "";
            lsVoidDate = DateTime.Today.Year.ToString("00") + "-" + DateTime.Today.Month.ToString("00") + "-" + DateTime.Today.Day.ToString("00") + " " + DateTime.Today.Hour.ToString("00") + ":" + DateTime.Today.Minute.ToString("00") + ":" + DateTime.Today.Second.ToString("00");

            //Int32 liMax = 0;
            Connection lsConn = new Connection();
            lsConn.ConnectDatabase();
            lsSQL = "Update voucher Set flag = '3', voiddate = '" + lsVoidDate + "', flagsend = '1' "
                + "Where counter1= '" + aCounter + "' and vouno = '" + aVouNo + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsConn.Gdb);
            lsComm.ExecuteNonQuery();
            lsConn.Gdb.Close();
        }
        public Boolean CancelReturnVoucher(string aVouNO, string aRemark, MySqlConnection Conn)
        {
            string lsSQL = "";
            try
            {
                lsSQL = "Update voucher Set flagreturn = false, remarkreturn = '" + aRemark + "', flag = '2', flagsend = '1' "
                    + " Where vouno = '" + aVouNO + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
                lsComm.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถ Cancel Return ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CancelVoidVoucher ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
            return true;
        }
        public void CancelVoidVoucher(string aCounter, string aVouNo)
        {
            string lsSQL = "";
            //Int32 liMax = 0;
            try
            {
                Connection lsConn = new Connection();
                lsConn.ConnectDatabase();
                lsSQL = "Update voucher Set flag = '2', flagsend = '1' "
                    + "Where counter1= '" + aCounter + "' and vouno = '" + aVouNo + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, lsConn.Gdb);
                lsComm.ExecuteNonQuery();
                lsConn.Gdb.Close();
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถ ยกเลิก Void ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "CancelVoidVoucher ");
                //MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
        }
        public string SelectNewVoucherNO(MySqlConnection Conn)
        {
            Int32 liMax = 0;
            string lsSQL = "Select max(substring(vouno,6,6)) as cnt From voucher Where counter1 = '" + lsCounter1 + "'";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead = lsComm1.ExecuteReader();
            while (lsRead.Read())
            {
                liMax = Convert.ToInt32(lsRead["cnt"].ToString());
            }
            lsRead.Close();
            liMax++;
            string lsYear = Convert.ToString(DateTime.Today.Year + 543).Substring(2);
            string lsVouNO = lsYear + lsCounter1 + liMax.ToString("000000");
            return lsVouNO;
        }
        public string CreateVoucher(MySqlConnection Conn)
        {
            string lsReturn = "";
            string sql = "", lsYear = "";
            try
            {
                //Connection lsConn = new Connection();
                //lsConn.ConnectDatabase();
                if (lsVouNO == "")
                {
                    lsVouNO = SelectNewVoucherNO(Conn);
                }
                //lsFlag = "1";
                if (lsFlag =="Using")
                {
                    lsFlag = "1";
                }
                if (lsFlag == "0")
                {
                    lsFlag = "1";
                }
                String chk = "";
                sql = "Select vouno From " + lsTableName + " Where vouno = '" + lsVouNO + "'";
                MySqlCommand lsComm = new MySqlCommand(sql, Conn);
                MySqlDataReader rs;
                rs = lsComm.ExecuteReader();
                if (rs.HasRows)
                {
                    chk = "0";                    
                }
                else
                {
                    chk = "1";                    
                }
                rs.Close();
                //sql = "Lock Tables " + lsTableName + " WRITE; Delete From " + lsTableName + " Where vouno = '" + lsVouNO + "' and counter1 = '" + lsCounter1 + "'";
                if (chk == "0")
                {
                    sql = "Update voucher Set voudate = '" + lsVouDate + "', staffcode = '" + lsStaffCode + "', counter1 = '" + lsCounter1 + "',"
                        + "couno = '" + lsCouNO + "', shiftcode = '" + lsShiftCode + "', hotelcode = '" + lsHotelCode +
                        "', restime = '" + lsResTime + "', guestfirstname = '" + lsGuestFirstName + "', nationcode = '" + lsNationCode
                        + "', roomcode = '" + lsRoomCode + "', visitt = '" + liVisitT + "', pax = '" + liPax + "', roomrate = '" + ldoRoomRate
                        + "', statuscode = '" + lsStatusCode + "', depositamt = '" + ldoDepositAMT + "', checkindate = '" + lsCheckInTime
                        + "', checkoutdate = '" + lsCheckOutTime + "', confirmperson = '" + lsConfirmPerson
                        + "', remark = '" + lsRemark + "', flag = '" + lsFlag + "', resrooms = '" + liResRooms
                        + "', guestlastname = '" + lsGuestLastName + "', provcode = '" + lsProvCode
                        + "', flagsend = '1', roomno = '" + lsRoomNO + "', mac = '" + lsMAC
                        + "', flagconfirm = '1', personintrip = " + liPersoninTrip + ", prefix = " + liPrefix
                        + ", roomrate1 = " + ldoRoomRate1 + ", memplcode = '" + lsMemPlCode
                        + "', priceend = " + ldoPriceEnd + ", taxi = " + lsTaxi
                        + ", breakfast = " + lsBreakFast + ", user = user(), sysdate = sysdate(), "
                        + "pay_type = '" + lsPay_Type + "', cardid = '" + lsCardID + "' "
                        + "Where vouno = '" + lsVouNO + "'";
                    lsComm.CommandText = sql;
                    lsComm.ExecuteNonQuery();
                }
                else
                {
                    sql = "Delete From " + lsTableName + " Where vouno = '" + lsVouNO + "'";// and counter1 = '" + lsCounter1 + "'";
                    lsComm.CommandText = sql;
                    lsComm.ExecuteNonQuery();
                    if (lsTableName == "accrecvoucher")
                    {
                        sql = "Insert Into " + lsTableName + "(vouno, voudate, staffcode, counter1, "
                            + "couno, shiftcode, hotelcode, restime, "
                            + "guestfirstname, nationcode, roomcode, visitt, "
                            + "pax, roomrate, statuscode, depositamt, "
                            + "checkindate, checkoutdate, confirmperson, remark, "
                            + "flag, resrooms, guestlastname, provcode, "
                            + "flagsend, roomno, mac, flagconfirm, "
                            + "personintrip, prefix, roomrate1, memplcode, "
                            + "priceend, taxi, breakfast, year, month, user, sysdate, "
                            + "pay_type, cardid) "
                            + "Values('" + lsVouNO + "','" + lsVouDate + "','" + lsStaffCode + "','" + lsCounter1 + "','"
                            + lsCouNO + "','" + lsShiftCode + "','" + lsHotelCode + "','" + lsResTime + "','"
                            + lsGuestFirstName + "','" + lsNationCode + "','" + lsRoomCode + "','" + liVisitT + "','"
                            + liPax + "','" + ldoRoomRate + "','" + lsStatusCode + "','" + ldoDepositAMT + "','"
                            + lsCheckInTime + "','" + lsCheckOutTime + "','" + lsConfirmPerson + "','" + lsRemark + "','"
                            + lsFlag + "','" + liResRooms + "','" + lsGuestLastName + "','" + lsProvCode + "',"
                            + "'1','" + lsRoomNO + "','" + lsMAC + "','1',"
                            + liPersoninTrip + "," + liPrefix + "," + ldoRoomRate1 + ",'" + lsMemPlCode + "',"
                            + ldoPriceEnd + "," + lsTaxi + "," + lsBreakFast + ",'" + lsYear + "','" + lsMonth + "', user(), sysdate(),'"
                            + lsPay_Type + "','" + lsCardID + "'); Unlock Tables;";
                    }
                    else
                    {
                        sql = "Insert Into " + lsTableName + "(vouno, voudate, staffcode, counter1, "
                            + "couno, shiftcode, hotelcode, restime, "
                            + "guestfirstname, nationcode, roomcode, visitt, "
                            + "pax, roomrate, statuscode, depositamt, "
                            + "checkindate, checkoutdate, confirmperson, remark, "
                            + "flag, resrooms, guestlastname, provcode, "
                            + "flagsend, roomno, mac, flagconfirm, "
                            + "personintrip, prefix, roomrate1, memplcode, "
                            + "priceend, taxi, breakfast, user, sysdate, "
                            + "pay_type, cardid) "
                            + "Values('" + lsVouNO + "','" + lsVouDate + "','" + lsStaffCode + "','" + lsCounter1 + "','"
                            + lsCouNO + "','" + lsShiftCode + "','" + lsHotelCode + "','" + lsResTime + "','"
                            + lsGuestFirstName + "','" + lsNationCode + "','" + lsRoomCode + "','" + liVisitT + "','"
                            + liPax + "','" + ldoRoomRate + "','" + lsStatusCode + "','" + ldoDepositAMT + "','"
                            + lsCheckInTime + "','" + lsCheckOutTime + "','" + lsConfirmPerson + "','" + lsRemark + "','"
                            + lsFlag + "','" + liResRooms + "','" + lsGuestLastName + "','" + lsProvCode + "',"
                            + "'1','" + lsRoomNO + "','" + lsMAC + "','1',"
                            + liPersoninTrip + "," + liPrefix + "," + ldoRoomRate1 + ",'" + lsMemPlCode + "',"
                            + ldoPriceEnd + "," + lsTaxi + "," + lsBreakFast + ", user(), sysdate(),'"
                            + lsPay_Type + "','" + lsCardID + "'); Unlock Tables;";
                    }
                    lsComm.CommandText = sql;
                    lsComm.ExecuteNonQuery();
                }
                lsReturn = lsVouNO;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล Voucher ได้ " + sql;
                lsGdb.WriteLogError(ls, e, sql, "CreateVoucher ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lsReturn;
        }
    }
}
