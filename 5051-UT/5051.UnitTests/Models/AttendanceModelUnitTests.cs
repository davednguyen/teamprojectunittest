using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5051.Models;
using _5051.UnitTests.MailService;
using System.Net.Mail;
using System.Net;

namespace _5051.UnitTests.Models
{
    [TestClass]
    public class AttendanceModelUnitTests
    {
        public TestContext TestContext { get; set; }

        SendEmailFunctions mailService = new SendEmailFunctions();
        private static string senderEmail = "<enter email address here>";
        private static string senderEmailPassword = "<enter email passord here>";
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
            mail.Subject = "Test result for :" + "Attendance Model Unit Tests";
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
        public void Models_AttendanceModel_Default_Instantiate_Should_Pass()
        {

            // Act
            var result = new AttendanceModel();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
            listOfRows = listOfRows + string.Format(greenRow, "Models_AttendanceModel_Default_Instantiate_Should_Pass", "passed");
        }

        [TestMethod]
        public void Models_AttendanceModel_Default_Instantiate_With_Null_Should_Fail()
        {
            // Arange
            var myData = new AttendanceModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(result, null, TestContext.TestName);
            listOfRows = listOfRows + string.Format(greenRow, "Models_AttendanceModel_Default_Instantiate_With_Null_Should_Fail", "passed");
        }

        [TestMethod]
        public void Models_AttendanceModel_Default_Instantiate_With_Valid_Data_Should_Pass()
        {
            // Arange
            var myData = new AttendanceModel();
            var myDataNew = new AttendanceModel
            {
                Emotion = EmotionStatusEnum.Sad
            };

            // Act
            var result = myData.Update(myDataNew);

            // Assert
            Assert.AreEqual(result.Emotion, myDataNew.Emotion, TestContext.TestName);
            listOfRows = listOfRows + string.Format(greenRow, "Models_AttendanceModel_Default_Instantiate_With_Valid_Data_Should_Pass", "passed");
        }

        [TestMethod]
        public void Models_AttendanceModel_Default_Instantiate_Get_Set_Should_Pass()
        {
            //arrange
            var result = new AttendanceModel();
            var expectStudentId = "GoodID1";
            var expectIn = DateTime.UtcNow;
            var expectOut = DateTime.UtcNow;
            //var expectStatus = _5051.Models.StudentStatusEnum.In;
            //var expectDuration = TimeSpan.Zero;
            var expectedIsNew = false;
            var expectEmotion = _5051.Models.EmotionStatusEnum.Neutral;
            var expectEmotionUri = Emotion.GetEmotionURI(expectEmotion);
            
            // Act
            result.StudentId = expectStudentId;
            result.In = expectIn;
            result.Out = expectOut;
            //result.Status = expectStatus;
            result.IsNew = expectedIsNew;
            result.Emotion = expectEmotion;
            result.EmotionUri = expectEmotionUri;
            listOfRows = listOfRows + string.Format(greenRow, "Models_AttendanceModel_Default_Instantiate_Get_Set_Should_Pass", "passed");
            // Assert
            Assert.IsNotNull(result.Id, TestContext.TestName);
            Assert.AreEqual(expectStudentId, result.StudentId, TestContext.TestName);
            Assert.AreEqual(expectIn, result.In, TestContext.TestName);
            Assert.AreEqual(expectOut, result.Out, TestContext.TestName);
            //Assert.AreEqual(expectStatus, result.Status, TestContext.TestName);
            Assert.AreEqual(expectEmotion, result.Emotion, TestContext.TestName);
            Assert.AreEqual(expectEmotionUri, result.EmotionUri, TestContext.TestName);

            Assert.AreEqual(expectedIsNew, result.IsNew, TestContext.TestName);

        }
        #endregion Instantiate
    }
}
