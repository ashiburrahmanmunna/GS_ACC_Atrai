using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace Atrai.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }




    public class EmailSender : IEmailSender
    {
        //private readonly EmailSettingModel _emailSettings;
        private readonly IEmailSettingRepository _emailSettingRepository;

        public EmailSender(IOptions<EmailSettingModel> emailSettings, IEmailSettingRepository emailSettingRepository)
        {
            //_emailSettings = emailSettings.Value;
            _emailSettingRepository = emailSettingRepository;
        }

        public Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var emailsettings = _emailSettingRepository.All(false).Where(x => x.IsActive == true).FirstOrDefault();
                #region formatter
                var message = "Active this link";//
                string text = $"Please click on this link to {subject}: {message}";
                #endregion

                MailMessage msg = new MailMessage();
                //msg.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
                //msg.From = new MailAddress("system@gtrbd.com");

                msg.From = new MailAddress(emailsettings.Sender, emailsettings.SenderName);
                //msg.From = new MailAddress("info@dominatebd.com");
                MailAddress addressBCC = new MailAddress("fahad@gtrbd.com");



                string[] mailSplit = email.Split(", ");
                foreach (var mail in mailSplit)
                {
                    msg.To.Add(new MailAddress(mail));
                }

                //msg.To.Add(new MailAddress(email));
                ////msg.Subject = subject;
                ////msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                ///msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Html));



                msg.Subject = subject;
                msg.Body = body;
                msg.Bcc.Add(addressBCC);

                msg.IsBodyHtml = true;// _smtpConfig.Value.IsBodyHTML; //true;


                //SmtpClient smtpClient = new SmtpClient("smtp.office365.com");
                ////SmtpClient smtpClient = new SmtpClient("mail.dominatebd.com");

                //////smtpClient.Credentials = new NetworkCredential("system@gtrbd.com", "GtR9944s");
                ////smtpClient.Credentials = new NetworkCredential("info@dominatebd.com", "MBRvO_BT[4my");

                //////smtpClient.Port = 587;

                ////smtpClient.Port = 465;
                ////smtpClient.UseDefaultCredentials = false;

                //////smtpClient.Timeout = 60000;
                ////smtpClient.EnableSsl = true;
                ////ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => { return true; };
                /////smtpClient.Send(msg);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (var client = new SmtpClient())
                {
                    //client.Host = "smtp.gmail.com";
                    client.Host = emailsettings.MailServer; //"smtp.gmail.com";
                    client.Port = emailsettings.MailPort;//587;
                                                         //client.Host = _smtpConfig.Value.Host; //"smtp.gmail.com";
                                                         //client.Port = _smtpConfig.Value.Port;//587;
                    client.EnableSsl = true;// _smtpConfig.Value.EnableSSL;// true;
                                            //client.Credentials = new NetworkCredential(config.GetSection("CredentialMail").Value, config.GetSection("CredentialPassword").Value);
                                            //client.Credentials = new NetworkCredential(_smtpConfig.Value.UserName, _smtpConfig.Value.Password);
                    client.Credentials = new NetworkCredential(emailsettings.Sender, emailsettings.Password);



                    client.Send(msg);

                }


            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return Task.CompletedTask;
        }

        //public string? fncSendMail(string mailType, string addFrom, string addFromCaption, string addTo, string addToCc, string addToBcc, string mailSubject, string mailBody, string pm)
        //{
        //    MailMessage mail = new MailMessage();
        //    SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

        //    try
        //    {
        //        mail.From = new MailAddress(addFrom, addFromCaption);
        //        mail.To.Add(addTo);
        //        mail.Subject = mailSubject;
        //        mail.Body = mailBody;
        //        mail.IsBodyHtml = true;

        //        SmtpServer.Port = 587;//Office 2003 : 265
        //        SmtpServer.Credentials = new System.Net.NetworkCredential(addFrom, pm);
        //        SmtpServer.EnableSsl = true;
        //        ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => { return true; };
        //        SmtpServer.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    return "mail";
        //}
    }
}