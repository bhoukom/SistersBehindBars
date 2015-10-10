using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace SistersBehindBars.Web.Services
{
    public class SslMail
    {
        public void SendMail(MailMessageEventArgs e)
        {
            GetSmtpClient().Send(e.Message);
            
            //Since the message is sent here, set cancel=true so the original SmtpClient will not try to send the message too:
            e.Cancel = true;

        }

        public static void SendMail(MailMessage msg)
        {
            GetSmtpClient().Send(msg);
        }

        public static SmtpClient GetSmtpClient()
        {
            return new SmtpClient();
        }
    }
}