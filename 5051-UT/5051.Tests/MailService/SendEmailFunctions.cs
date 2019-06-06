using System;
using System.Net.Mail;
using System.Net;

namespace _5051.Tests.MailService
{
    public class SendEmailFunctions : iSendEmailFunctions
    {
        private static string senderEmail = "attendancestarwebtest@outlook.com";
        private static string senderEmailPassword = "Password123456";
        static string greenRow = "<tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"color:green;\">{1}</td></tr>";
        static string redRow = "<tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"color:red;\">{1}</td></tr>";
        static string fullTable = " <table style=\"width:20%\"> <tr style=\"border:1px solid #dddddd\"><th style=\"border:1px solid #dddddd\"> Test Name </th><th style=\"border:1px solid #dddddd\">Test Result</th></tr>{0}</table>";

        public string BuildRow(string testName, string testResult, bool result)
        {
            string row = string.Empty;
            if (result)
            {
                row = string.Format(greenRow, testName, testResult);
            }
            else
            {
                row = string.Format(redRow, testName, testResult);
            }
            return row;
        }

        public string BuildTable(string rows)
        {
            //string tableResult = string.Empty;
            string tableResult = string.Format(fullTable, rows);
            return tableResult;
        }

        #region
        public string BuildHTMLBody(string testTitle, string testResult,int count)
        {
            string table = " <table style=\"width:20%\"> <tr style=\"border:1px solid #dddddd\"><th style=\"border:1px solid #dddddd\"> Test Name </th><th style=\"border:1px solid #dddddd\">Test Result</th></tr><tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"border:1px solid #dddddd\">{1}</td></tr></table>";
            string emailBody = string.Format(table, testTitle, testResult);
            return emailBody;
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
        public string SendEmailService(string title, string testResult, string emailAddress)
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
                return "done";
            }
            catch (Exception ex)
            {
                return ex.ToString();
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

        public string SendEmailUsingGmailService(string title, string testResult, string emailAddress)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(senderEmail, senderEmailPassword),
                    EnableSsl = true
                };
                client.Send(senderEmail, emailAddress, title, testResult);
                return "done";
            }
            catch (Exception e)
            {
                return e.ToString();
            }           

        }

        public string GenerateCSVFileName(string fileTitle)
        {
            throw new NotImplementedException();
        }

        //public string SendEmailService(string title, string testResult, string emailAddress)
        //{
        //    throw new NotImplementedException();
        //}

        public string BuildHTMLBodyV2(string testTitle, string testResult, int count, string sheetUrl)
        {
            throw new NotImplementedException();
        }

        public string BuildHTMLBodyV3(string testTitle, string testResult, int count, string sheetUrl, string sourceSheetUrl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
