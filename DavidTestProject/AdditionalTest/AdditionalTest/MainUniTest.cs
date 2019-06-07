using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdditionalTest
{
    [TestClass]
    public class MainUniTest
    {
        IWebDriver driver;
        string homeURL = "http://localhost:59052/";

        [TestInitialize]
        public void SetupTest()
        {
            driver = new ChromeDriver((@"C:\Users\dnguyen\Desktop\truonghoc\teamprojectdemo\teamprojectunittest\DavidTestProject\AdditionalTest\AdditionalTest\bin\Debug\"), new ChromeOptions());
        }

        [TestMethod]
        public void LoadPageAndSelectUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(homeURL);           
            IWebElement MikeAvarta = driver.FindElement(By.Name("Mike"));
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            MikeAvarta.Click();
            IWebElement avatarButton = driver.FindElement(By.Id("avatarLinkPortalIndex"));
            IWebElement imgSource = avatarButton.FindElement(By.CssSelector("#avatarLinkPortalIndex > img"));
            string imageSrcValue = imgSource.GetAttribute("src");
            Thread.Sleep(milliseconds);
            avatarButton.Click();

        }

        [TestMethod]
        public void LoadPageAndSelectUserGetAvataImageValue()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(homeURL);
            IWebElement MikeAvarta = driver.FindElement(By.Name("Mike"));
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            MikeAvarta.Click();
            IWebElement avatarButton = driver.FindElement(By.Id("avatarLinkPortalIndex"));
            IWebElement imgSource = avatarButton.FindElement(By.CssSelector("#avatarLinkPortalIndex > img"));
            string imageSrcValue = imgSource.GetAttribute("src");
            string expectedImageSrc = "http://localhost:59052/Content/img/Avatars_dark.png";
            //driver.Close();
            Assert.AreEqual(expectedImageSrc, imageSrcValue);         
        }
    }
}
