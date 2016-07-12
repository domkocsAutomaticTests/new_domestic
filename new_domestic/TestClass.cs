using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class NewDomestic
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private int dom = 0;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://clicpltest.egroup.hu/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheNewDomesticTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login/Login");
            driver.FindElement(By.LinkText("Login with RSA token [DEMO]")).Click();
            driver.FindElement(By.Id("loginId")).Clear();
            driver.FindElement(By.Id("loginId")).SendKeys("100003");
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("submit")).Click();
            dom = int.Parse(driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[1]/td[2]")).Text);
            // ERROR: Caught exception [Error: locator strategy either id or name must be specified explicitly.]
            driver.Navigate().GoToUrl(baseURL + "/Domestic/New");
            driver.FindElement(By.Id("Input_BnName-Search")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("gvDomesticPartnerSearch_tccell0_3")).Click();
            driver.FindElement(By.Id("Input_Details")).Clear();
            driver.FindElement(By.Id("Input_Details")).SendKeys("automaticTest");
            driver.FindElement(By.Id("Input_ExtRef")).Clear();
            driver.FindElement(By.Id("Input_ExtRef")).SendKeys("automaticTest");
            driver.FindElement(By.Id("Input_Amount_formatted")).Clear();
            driver.FindElement(By.Id("Input_Amount_formatted")).SendKeys("1000,00");
            try
            {
                driver.FindElement(By.Id("actionButton_Save")).Click();
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            catch (Exception)
            {
                driver.FindElement(By.Id("actionButton_Save")).Click();
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            //
            try
            {
                Assert.AreEqual((dom + 1).ToString(), driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[1]/td[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            // ERROR: Caught exception [Error: locator strategy either id or name must be specified explicitly.]
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
