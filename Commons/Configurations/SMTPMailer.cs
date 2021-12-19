using System;
using System.Net.Mail;


namespace Commons.Configuration
{
    public static class SMTPMailer
    {
        public static bool SendMail(string EmailTo, string EmailSubject, string EmailBody)
        {

            MailMessage mail = new MailMessage();
            if (!string.IsNullOrEmpty(ConfigurationHelper.SMTPServer))
            {
                SmtpClient SmtpServer = new SmtpClient(ConfigurationHelper.SMTPServer);
                mail.From = new MailAddress(ConfigurationHelper.eMailFrom);
                mail.To.Add(new MailAddress(EmailTo));
                //if (!string.IsNullOrEmpty(CC)) { mail.CC.Add(new MailAddress(CC)); };
                //if (!string.IsNullOrEmpty(Bcc)) { mail.CC.Add(new MailAddress(Bcc)); };
                mail.Subject = EmailSubject;
                mail.IsBodyHtml = true;
                mail.Body = EmailBody;
                SmtpServer.Port = Convert.ToInt32(ConfigurationHelper.SMTPPort);
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationHelper.SMTPUser, ConfigurationHelper.SMTPPassword);
                SmtpServer.EnableSsl = true;

                try
                {
                    SmtpServer.Send(mail);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
