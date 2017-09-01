using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace AutomationPracticeConventional
{
    /// <summary>
    /// Summary description for AutomationPracticeTests
    /// </summary>
    [TestClass]
    public class AutomationPracticeTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string url;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            url = "http://automationpractice.com";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void Open_AutomationPractice()
        {

            wait.Until(x => x.FindElement(By.Id("page")));
        }

        [TestMethod]
        public void When_I_click_Contact_Us_Contact_Form_displays()
        {
            var bycontactlink = By.Id("contact-link");
            var contactLink = driver.FindElement(bycontactlink);

            contactLink.Click();

            var contactHeaderBy = By.XPath("//*[@id=\"center_column\"]/h1");
            wait.Until(x => x.FindElement(contactHeaderBy));

            var header = driver.FindElement(contactHeaderBy);

            Assert.AreEqual("CUSTOMER SERVICE - CONTACT US", header.Text);
        }

        [TestMethod]
        public void When_Contact_Us_is_filled_properly_form_is_submitted()
        {

            var contactUsButton = driver.FindElement(By.Id("contact-link"));
            contactUsButton.Click();

            By byHeaderXpath = By.XPath("//*[@id=\"center_column\"]/h1");
            By byContactFormBox = By.ClassName("contact-form-box");
            wait.Until(wt => wt.FindElement(byContactFormBox));

            var subjectDD = driver.FindElement(By.Id("id_contact"));
            SelectElement subject = new SelectElement(subjectDD);
            subject.SelectByText("Webmaster");

            var emailText = driver.FindElement(By.Id("email"));
            emailText.SendKeys("valid@email.com");

            var orderRefText = driver.FindElement(By.Id("id_order"));
            orderRefText.SendKeys("random");

            var messageText = driver.FindElement(By.Id("message"));
            messageText.SendKeys("This is a test message. The quick brown fox jumps over the lazy dog");

            var sendButton = driver.FindElement(By.Id("submitMessage"));
            sendButton.Click();

            By byMessageReturn = By.XPath("//*[@id=\"center_column\"]/p");
            wait.Until(wt => wt.FindElement(byMessageReturn));

            var messageReturn = driver.FindElement(byMessageReturn);
            Assert.AreEqual("Your message has been successfully sent to our team.", messageReturn.Text);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
