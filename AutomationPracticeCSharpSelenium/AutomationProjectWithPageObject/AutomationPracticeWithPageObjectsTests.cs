using AutomationProjectWithPageObject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationProjectWithPageObject
{
    [TestClass]
    public class AutomationPracticeWithPageObjectsTests
    {
        private ContactUsPage contactUsPage;

        [TestInitialize]
        public void SetupAndNavigate()
        {
            contactUsPage = new ContactUsPage();
            contactUsPage.MaximizeWindow();
            contactUsPage.GoToPage();
        }

        [TestMethod]
        public void When_Contact_Us_Url_is_navigated_to_Customer_Service_Form_is_displayed()
        {
            Assert.AreEqual("CUSTOMER SERVICE - CONTACT US", contactUsPage.Header.Text);
        }

        [TestMethod]
        public void When_Contact_Us_Form_is_filled_properly_form_is_submitted()
        {
            contactUsPage.SelectSubjectHeadingByText("Webmaster");
            contactUsPage.EmailAddressText.SendKeys("valid@email.com");
            contactUsPage.OrderReferenceText.SendKeys("random");
            contactUsPage.MessageText.SendKeys("This is a test message. The quick brown fox jumps over the lazy dog");

            contactUsPage.ClickSend();

            Assert.AreEqual("Your message has been successfully sent to our team.", contactUsPage.MessageReturn.Text);
        }

        [TestCleanup]
        public void TearDown()
        {
            contactUsPage.Close();
            contactUsPage.WebDriver.Quit();
        }
    }
}