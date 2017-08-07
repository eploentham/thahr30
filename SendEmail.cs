using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
//using Outlook = Microsoft.Office.Interop.Outlook;
namespace ThaHr30
{
    public partial class SendEmail : Form
    {
        public SendEmail()
        {
            InitializeComponent();
        }

        private void SendEmail_Load(object sender, EventArgs e)
        {
            
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Create the Outlook application.
        //        Outlook.Application oApp = new Outlook.Application();

        //        // Get the NameSpace and Logon information.
        //        Outlook.NameSpace oNS = oApp.GetNamespace("mapi");

        //        // Log on by using a dialog box to choose the profile.
        //        oNS.Logon(Missing.Value, Missing.Value, true, true);

        //        // Alternate logon method that uses a specific profile.
        //        // TODO: If you use this logon method, 
        //        //  change the profile name to an appropriate value.
        //        //oNS.Logon("YourValidProfile", Missing.Value, false, true); 

        //        // Create a new mail item.
        //        Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

        //        // Set the subject.
        //        oMsg.Subject = "Send Using OOM in C#";

        //        // Set HTMLBody.
        //        String sHtml;
        //        sHtml = "<HTML>\n" +
        //           "<HEAD>\n" +
        //           "<TITLE>Sample GIF</TITLE>\n" +
        //           "</HEAD>\n" +
        //           "<BODY><P>\n" +
        //           "<h1><Font Color=Green>Inline graphics</Font></h1></P>\n" +
        //           "</BODY>\n" +
        //           "</HTML>";
        //        oMsg.HTMLBody = sHtml;

        //        // Add a recipient.
        //        Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
        //        // TODO: Change the recipient in the next line if necessary.
        //        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("eploentham@gmail.com");
        //        oRecip.Resolve();

        //        // Send.
        //        oMsg.Send();

        //        // Log off.
        //        oNS.Logoff();

        //        // Clean up.
        //        oRecip = null;
        //        oRecips = null;
        //        oMsg = null;
        //        oNS = null;
        //        oApp = null;
        //    }

        // // Simple error handling.
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{0} Exception caught.", ex);
        //    }

        //    // Default return value.
        //    //return 0;
        //}
    }
}