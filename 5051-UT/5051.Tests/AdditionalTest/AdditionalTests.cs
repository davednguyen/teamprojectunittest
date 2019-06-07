using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using _5051;
using _5051.Controllers;
using _5051.Models;
using _5051.Backend;
using _5051.Tests.MailService;
using System.Net.Mail;
using System.Net;

namespace _5051.Tests.AdditionalTest
{
    /// <summary>
    /// David 's mock test list
    /// </summary>
    [TestClass]
    public class AdditionalTests
    {
        public AdditionalTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        /// David 's mock test list
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// David 's mock test list
        /// </summary>
        [TestMethod]
        public void MockControllerTestAvartaController()
        {
            Mock<AvatarSelectController> mockObject = new Mock<AvatarSelectController>();
            Assert.AreEqual(mockObject, null);
        }

        /// <summary>
        /// David 's mock test list
        /// </summary>
        [TestMethod]
        public void MockControllerTestBaseController()
        {
            Mock<BaseController> mockObject = new Mock<BaseController>();
            Assert.AreEqual(mockObject, null);
        }

        /// <summary>
        /// David 's mock test list
        /// </summary>
        [TestMethod]
        public void MockControllerTestHomeController()
        {
            Mock<HomeController> mockObject = new Mock<HomeController>();
            Assert.AreEqual(mockObject, null);
        }

        /// <summary>
        /// David 's mock test list
        /// </summary>
        [TestMethod]
        public void MockControllerTestKioskController()
        {
            Mock<KioskController> mockObject = new Mock<KioskController>();
            Assert.AreEqual(mockObject, null);
        }

        /// <summary>
        /// David 's mock test list
        /// </summary>
        [TestMethod]
        public void MockControllerTestKioskSettingsController()
        {
            Mock<KioskSettingsController> mockObject = new Mock<KioskSettingsController>();
            Assert.AreEqual(mockObject, null);
        }

        /// <summary>
        /// David 's mock test list
        /// </summary>
        [TestMethod]
        public void MockControllerTestPortalController()
        {
            Mock<PortalController> mockObject = new Mock<PortalController>();
            Assert.AreEqual(mockObject, null);
        }
    }
}
