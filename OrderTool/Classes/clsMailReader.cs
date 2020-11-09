using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OrderTool.Classes
{
    class clsMailReader
    {

        #region Public Properties

        #endregion

        #region Private Properties

        private string MailServer { get; set; }
        private string UserLogin { get; set; }
        private string UserPassword { get; set; }
        private int Port { get; set; }



        #endregion

        #region Constructor 
        clsMailReader(string pMailServer, string pUserLogin, string pUserPassword, int pPort) 
        {
            this.MailServer = pMailServer;
            this.UserLogin = pUserLogin;
            this.UserPassword = pUserPassword;
            this.Port = pPort;
        }
        #endregion

        #region Public Methods

        public void GetAmazonOrders() 
        {
            // Get the Order Mail via IMAP

            using (var client = new ImapClient()) 
            {
                // Remove this token because I dont have it.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Login
                client.Authenticate(this.UserLogin, this.UserPassword);

                // Get Inbox
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                // Filter Mails
                var results = inbox.Search(SearchOptions.All, SearchQuery.FromContains("bestellbestaetigung@amazon.de"));

                // Get the results

                List<MimeMessage> messages = new List<MimeMessage>();

                foreach (var mailId in results.UniqueIds)
                {
                    MimeMessage message = inbox.GetMessage(mailId);
                    messages.Add(message);
                }

                // Create OrderObjects
                List<clsOrder> orders = new List<clsOrder>();

                foreach (MimeMessage message in messages)
                {
                    //clsOrder order = new clsOrder(
                    //    message.MessageId,
                    //    message.Body,
                    //    message.Subject,
                    //    message.Subject.Split('"').Last().TrimEnd('"'),
                    //
                    //) ;

                    orders.Add(order);
                }
                

                // Disconnect client
                client.Disconnect(true);
            }

        }

        #endregion

        #region Private Methods
        #endregion

    }
}
