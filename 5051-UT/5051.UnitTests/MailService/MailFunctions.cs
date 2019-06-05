using System;
using System.Net.Mail;
using System.Net;

namespace _5051.UnitTests.MailService
{
    public class MailFunctions : iMailFunctions
    {
        private static string senderEmail = "attendancestarwebtest@outlook.com";
        private static string senderEmailPassword = "Password123456";

        #region
        public string BuildHTMLBody(string testTitle, string testResult,int count)
        {
            string table = " <table style=\"width:20%\"> <tr style=\"border:1px solid #dddddd\"><th style=\"border:1px solid #dddddd\"> Test Name </th><th style=\"border:1px solid #dddddd\">Test Result</th><th style=\"border:1px solid #dddddd\">Row number</th></tr><tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"border:1px solid #dddddd\">{1}</td><td style=\"border:1px solid #dddddd\">{2}</td></tr></table>";
            string emailBody = string.Format(table, testTitle, testResult,count);
            return emailBody;
        }
        #endregion

        #region
        public string BuildHTMLBodyV2(string testTitle, string testResult, int count, string sheetUrl)
        {
            string table = " <table style=\"width:20%\"> <tr style=\"border:1px solid #dddddd\"><th style=\"border:1px solid #dddddd\"> Test Name </th><th style=\"border:1px solid #dddddd\">Test Result</th><th style=\"border:1px solid #dddddd\">Row number</th><th style=\"border:1px solid #dddddd\">Sheet Url</th></tr><tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"border:1px solid #dddddd\">{1}</td><td style=\"border:1px solid #dddddd\">{2}</td><td style=\"border:1px solid #dddddd\">{3}</td></tr></table>";
            string emailBody = string.Format(table, testTitle, testResult, count,sheetUrl);
            return emailBody;
        }
        #endregion

        #region
        public string BuildHTMLBodyV3(string testTitle, string testResult, int count, string sheetUrl, string sourceSheetUrl)
        {
            string table = "<body><table style=\"width:20%\"> <tr style=\"border:1px solid #dddddd\"><th style=\"border:1px solid #dddddd\"> Test Name </th><th style=\"border:1px solid #dddddd\">Test Result</th><th style=\"border:1px solid #dddddd\">Row number</th><th style=\"border:1px solid #dddddd\">Sheet Url</th><th style=\"border:1px solid #dddddd\">Source Sheet Url</th></tr><tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"border:1px solid #dddddd\">{1}</td><td style=\"border:1px solid #dddddd\">{2}</td><td style=\"border:1px solid #dddddd\">{3}</td><td style=\"border:1px solid #dddddd\">{4}</td></tr></table><IFRAME WIDTH=1000 HEIGHT=700 FRAMEBORDER=0 SRC=\"https://app.smartsheet.com/b/publish?EQBCT=693fcfb24f0a40f1a60d1dc18301475d\"></IFRAME></body>";
            string emailBody = string.Format(table, testTitle, testResult, count, sheetUrl, sourceSheetUrl);
            return emailBody;
        }
        #endregion

        #region
        public string GenerateCSVFileName(string fileTitle)
        {
            string fileLocationString = @"C:\Users\{0}\Desktop\{1}";
            string currentUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string filePath = string.Format(fileLocationString, currentUserName, fileTitle);
            return filePath;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="testResult"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool SendEmailService(string title, string testResult, string emailAddress)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(emailAddress);
                mail.Subject = "Test result for :" + title;
                mail.Body = testResult;
                mail.IsBodyHtml = true;
                SmtpClient mailClient = new SmtpClient("smtp-mail.outlook.com");
                mailClient.Port = 587;
                mailClient.Credentials = new NetworkCredential(senderEmail, senderEmailPassword);
                mailClient.EnableSsl = true;
                mailClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="testResult"></param>
        /// <param name="emailAddress"></param>
        /// <param name="fileLocation"></param>
        /// <returns></returns>
        public bool SendEmailServiceV2(string title, string testResult, string emailAddress, string fileLocation)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(emailAddress);
                mail.Subject = "Test result for :" + title;
                mail.Attachments.Add(new Attachment(fileLocation));
                mail.Body = testResult;
                mail.IsBodyHtml = true;
                SmtpClient mailClient = new SmtpClient("smtp.live.com");
                mailClient.Port = 25;
                mailClient.Credentials = new NetworkCredential(senderEmail, senderEmailPassword);
                mailClient.EnableSsl = true;
                mailClient.Send(mail);
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
