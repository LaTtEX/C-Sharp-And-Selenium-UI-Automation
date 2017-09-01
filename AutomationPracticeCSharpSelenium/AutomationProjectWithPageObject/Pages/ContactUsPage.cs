using AutomationProjectWithPageObject.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutomationProjectWithPageObject.Pages
{
    public class ContactUsPage : WebPage
    {
        private const string ContactUsUrl = "http://automationpractice.com/index.php?controller=contact";

        public ContactUsPage() : this(GetChromeDriver())
        {
        }

        public ContactUsPage(IWebDriver driver) : base(driver, ContactUsUrl)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"center_column\"]/h1")]
        public IWebElement Header { get; set; }

        [FindsBy(How = How.Id, Using = "id_contact")]
        public IWebElement SubjectHeadingDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailAddressText { get; set; }

        [FindsBy(How = How.Id, Using = "id_order")]
        public IWebElement OrderReferenceText { get; set; }

        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement MessageText { get; set; }

        [FindsBy(How = How.Id, Using = "submitMessage")]
        public IWebElement SendButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"center_column\"]/p")]
        public IWebElement MessageReturn { get; set; }


        public void ClickSend()
        {
            this.SendButton.Click();
            Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"center_column\"]/p")));
        }

        public override void GoToPage()
        {
            base.GoToPage();
            Wait.Until(x => x.FindElement(By.Id("page")));
        }

        public void SelectSubjectHeadingByText(string text)
        {
            var dd = new SelectElement(this.SubjectHeadingDropdown);
            dd.SelectByText(text);
        }
    }
}
