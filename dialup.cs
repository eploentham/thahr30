using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace ThaHr30
{
    class DialUP
    {
        const int INTERNET_CONNECTION_MODEM = 1;
        const int INTERNET_CONNECTION_LAN = 2;
        const int INTERNET_CONNECTION_PROXY = 4;
        const int INTERNET_CONNECTION_MODEM_BUSY = 8;
        public const int INTERNET_DIAL_UNATTENDED = 0x8000;
        const int INTERNET_AUTODIAL_FORCE_ONLINE = 1;
        const int INTERNET_AUTODIAL_FORCE_UNATTENDED = 2;
        const int INTERNET_AUTODIAL_FAILIFSECURITYCHECK = 4;
        public int lsConnect = 0;
        [DllImport("wininet.dll")]
        private extern static int InternetDial(IntPtr hwndParent, string lpszConnectoid, int dwFlags, out int lpdwConnection, int dwReserved);
        private int m_mlConnection = 0;
        private bool m_isConnected = false;
        public int DialUp()
        {
            m_mlConnection = 0; 		//MessageBox.Show(m_mlConnection.ToString());		
            //int zez = //!!!This is part of code that we are using for call InternetDial 	
            lsConnect = InternetDial(IntPtr.Zero, "True", INTERNET_DIAL_UNATTENDED, out m_mlConnection, 0);
            return m_mlConnection;
        }
        [DllImport("wininet.dll")]
        private static extern Int32 InternetHangUp(Int32 lpdwConnection, Int32 dwReserved);
        public int DisConnect(Int32 lpdwConnection)
        {
            InternetHangUp(lpdwConnection, 0);
            return 0;
        }
    }
}
