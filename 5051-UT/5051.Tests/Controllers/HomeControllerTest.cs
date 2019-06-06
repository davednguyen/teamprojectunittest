using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5051.Controllers;
using _5051.Tests.MailService;
using System.Net.Mail;
using System.Net;

namespace _5051.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public TestContext TestContext { get; set; }
        SendEmailFunctions mailService = new SendEmailFunctions();
        private static string senderEmail = "attendancestarwebtest@outlook.com";
        private static string senderEmailPassword = "Password123456";
        static string greenRow = "<tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"color:green;\">{1}</td></tr>";
        static string redRow = "<tr style=\"border:1px solid #dddddd\"><td style=\"border:1px solid #dddddd\">{0}</td><td style=\"color:red;\">{1}</td></tr>";
        static string fullTable = " <table style=\"width:20%\"> <tr style=\"border:1px solid #dddddd\"><th style=\"border:1px solid #dddddd\"> Test Name </th><th style=\"border:1px solid #dddddd\">Test Result</th></tr>{0}</table>";
        static string listOfRows;

        [ClassCleanup()]
        public static void ClassCleanup()
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(senderEmail);
            mail.Subject = "Test result for :" + "Home Controller Test";
            mail.Body = string.Format(fullTable, listOfRows);
            mail.IsBodyHtml = true;
            SmtpClient mailClient = new SmtpClient("smtp-mail.outlook.com");
            mailClient.Port = 587;
            mailClient.Credentials = new NetworkCredential(senderEmail, senderEmailPassword);
            mailClient.EnableSsl = true;
            mailClient.Send(mail);
        }

        #region Instantiate
        [TestMethod]
        public void Controller_Home_Instantiate_Default_Should_Pass()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.GetType();

            // Assert
            Assert.AreEqual(result, new HomeController().GetType(), TestContext.TestName);
            listOfRows = listOfRows + string.Format(greenRow, "Controller_Home_Instantiate_Default_Should_Pass", "passed");
        }

        #endregion Instantiate

        #region IndexRegion

        [TestMethod]
        public void Controller_Home_Index_Default_Should_Pass()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
            listOfRows = listOfRows + string.Format(greenRow, "Controller_Home_Index_Default_Should_Pass", "passed");
        }

        #endregion IndexRegion

        #region ErrorRegion

        [TestMethod]
        public void Controller_Home_Error_Default_Should_Pass()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
            listOfRows = listOfRows + string.Format(greenRow, "Controller_Home_Error_Default_Should_Pass", "passed");
        }

        #endregion ErrorRegion
  
    }
}
