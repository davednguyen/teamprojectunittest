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
            driver = new ChromeDriver((@"C:\Users\dzzn\Desktop\truonghoc\teamprojectunittest\DavidTestProject\AdditionalTest\AdditionalTest\bin\Debug\"), new ChromeOptions());
        }

        [TestMethod]
        public void LoadPageAndSelectUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(homeURL);           
            IWebElement MikeAvarta = driver.FindElement(By.Id("e219a7f5-0b9e-48fa-a1e0-8b4bc02a20d9"));
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
            IWebElement MikeAvarta = driver.FindElement(By.Id("e219a7f5-0b9e-48fa-a1e0-8b4bc02a20d9"));
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            MikeAvarta.Click();
            IWebElement avatarButton = driver.FindElement(By.Id("avatarLinkPortalIndex"));
            IWebElement imgSource = avatarButton.FindElement(By.CssSelector("#avatarLinkPortalIndex > img"));
            string imageSrcValue = imgSource.GetAttribute("src");
            string expectedImageSrc = "http://localhost:59052/Content/img/Avatars_dark.png";
            driver.Close();
            Assert.AreEqual(expectedImageSrc, imageSrcValue);         
        }
    }
}
