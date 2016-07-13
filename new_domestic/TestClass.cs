﻿using System;
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
        private int dom = 0, sep = 0, swi = 0,zus = 0, tax = 0;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = @"https://clicpltest.egroup.hu";
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
        public void DomesticTest()
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
            driver.FindElement(By.Id("gvDomesticPartnerSearch_tccell0_3")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("Input_Details")).Clear();
            driver.FindElement(By.Id("Input_Details")).SendKeys("automaticTest");
            driver.FindElement(By.Id("Input_ExtRef")).Clear();
            driver.FindElement(By.Id("Input_ExtRef")).SendKeys("automaticTest");
            driver.FindElement(By.Id("Input_Amount_formatted")).Clear();
            driver.FindElement(By.Id("Input_Amount_formatted")).SendKeys("1000,00");
            driver.FindElement(By.Id("actionButton_Save")).Click();
            try
            {
                driver.FindElement(By.Id("actionButton_Save")).Click();
                Thread.Sleep(1000);
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            catch (Exception)
            {
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            Thread.Sleep(1000);
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

        [Test]
        public void SepaTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login/Login");
            driver.FindElement(By.LinkText("Login with RSA token [DEMO]")).Click();
            driver.FindElement(By.Id("loginId")).Clear();
            driver.FindElement(By.Id("loginId")).SendKeys("100003");
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("submit")).Click();
            sep = int.Parse(driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[2]/td[2]")).Text);
            // ERROR: Caught exception [Error: locator strategy either id or name must be specified explicitly.]
            driver.Navigate().GoToUrl(baseURL + "/Sepa/New");
            driver.FindElement(By.Id("Input_BnName-Search")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("gvForeignPartnerSearch_DXDataRow17")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("Input_Details")).Clear();
            driver.FindElement(By.Id("Input_Details")).SendKeys("automaticTest");
            driver.FindElement(By.Id("Input_ExtRef")).Clear();
            driver.FindElement(By.Id("Input_ExtRef")).SendKeys("automaticTest");
            //new SelectElement(driver.FindElement(By.Id("Input_CountryId"))).SelectByText("GERMANY");
            driver.FindElement(By.Id("Input_Amount_formatted")).Clear();
            driver.FindElement(By.Id("Input_Amount_formatted")).SendKeys("1000,00");
            driver.FindElement(By.Id("actionButton_Save")).Click();
            try
            {
                driver.FindElement(By.Id("actionButton_Save")).Click();
                Thread.Sleep(1000);
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            catch (Exception)
            {
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual((sep + 1).ToString(), driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[2]/td[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        [Test]
        public void SwiftTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login/Login");
            driver.FindElement(By.LinkText("Login with RSA token [DEMO]")).Click();
            driver.FindElement(By.Id("loginId")).Clear();
            driver.FindElement(By.Id("loginId")).SendKeys("100003");
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("submit")).Click();
            swi = int.Parse(driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[3]/td[2]")).Text);
            // ERROR: Caught exception [Error: locator strategy either id or name must be specified explicitly.]
            driver.Navigate().GoToUrl(baseURL + "/Swift/New");
            driver.FindElement(By.Id("Input_BnName-Search")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("gvForeignPartnerSearch_DXDataRow14")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("Input_Details")).Clear();
            driver.FindElement(By.Id("Input_Details")).SendKeys("automaticTest");
            driver.FindElement(By.Id("Input_ExtRef")).Clear();
            driver.FindElement(By.Id("Input_ExtRef")).SendKeys("automaticTest");
            //new SelectElement(driver.FindElement(By.Id("Input_CountryId"))).SelectByText("GERMANY");
            driver.FindElement(By.Id("Input_Amount_formatted")).Clear();
            driver.FindElement(By.Id("Input_Amount_formatted")).SendKeys("1000,00");
            driver.FindElement(By.Id("actionButton_Save")).Click();
            try
            {
                driver.FindElement(By.Id("actionButton_Save")).Click();
                Thread.Sleep(1000);
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            catch (Exception)
            {
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual((swi + 1).ToString(), driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[3]/td[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        [Test]
        public void ZUSTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login/Login");
            driver.FindElement(By.LinkText("Login with RSA token [DEMO]")).Click();
            driver.FindElement(By.Id("loginId")).Clear();
            driver.FindElement(By.Id("loginId")).SendKeys("100003");
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("submit")).Click();
            zus = int.Parse(driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[4]/td[2]")).Text);
            // ERROR: Caught exception [Error: locator strategy either id or name must be specified explicitly.]
            driver.Navigate().GoToUrl(baseURL + "/DomesticZus/New");
            driver.FindElement(By.Id("Input_Amount_formatted")).Clear();
            driver.FindElement(By.Id("Input_Amount_formatted")).SendKeys("1000,00");
            driver.FindElement(By.Id("Input_DecisionAgreement")).Clear();
            driver.FindElement(By.Id("Input_DecisionAgreement")).SendKeys("40");
            driver.FindElement(By.Id("Input_DeclarationDate")).Clear();
            driver.FindElement(By.Id("Input_DeclarationDate")).SendKeys("201610");
            driver.FindElement(By.Id("Input_DeclarationNumber")).Clear();
            driver.FindElement(By.Id("Input_DeclarationNumber")).SendKeys("40");

            driver.FindElement(By.Id("Input_PayerSupplementaryIdNumber")).SendKeys("YXN083441");
            
            driver.FindElement(By.Id("actionButton_Save")).Click();
            try
            {
                driver.FindElement(By.Id("actionButton_Save")).Click();
                Thread.Sleep(1000);
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            catch (Exception)
            {
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual((zus + 1).ToString(), driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[4]/td[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        /* CANNOT BE DONE AT VERSION 1.1.1481.0 !!!
        [Test]
        public void TaxTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login/Login");
            driver.FindElement(By.LinkText("Login with RSA token [DEMO]")).Click();
            driver.FindElement(By.Id("loginId")).Clear();
            driver.FindElement(By.Id("loginId")).SendKeys("100003");
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("submit")).Click();
            tax = int.Parse(driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[5]/td[2]")).Text);
            // ERROR: Caught exception [Error: locator strategy either id or name must be specified explicitly.]
            driver.Navigate().GoToUrl(baseURL + "/DomesticTax/New");
            new SelectElement(driver.FindElement(By.Id("Input_BnAddressBnName"))).SelectByText("Aleksandrów Kujawski - Urząd Skarbowy");
            driver.FindElement(By.Id("Input_Amount_formatted")).Clear();
            driver.FindElement(By.Id("Input_Amount_formatted")).SendKeys("1000,00");

            

            driver.FindElement(By.Id("Input_PayerSupplementaryIdNumber")).SendKeys("YXN083441");

            driver.FindElement(By.Id("actionButton_Save")).Click();
            try
            {
                driver.FindElement(By.Id("actionButton_Save")).Click();
                Thread.Sleep(1000);
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            catch (Exception)
            {
                driver.Navigate().GoToUrl(baseURL + "/Home/Dashboard");
            }
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual((tax + 1).ToString(), driver.FindElement(By.XPath(".//*[@id='main']/div[5]/div[2]/div/div/div/table/tbody/tr[5]/td[2]]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        */

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
