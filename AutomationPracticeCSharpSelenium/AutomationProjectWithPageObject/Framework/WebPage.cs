using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationProjectWithPageObject.Framework
{
    public abstract class WebPage
    {
        public WebPage(IWebDriver driver, string url)
        {
            this.WebDriver = driver;
            this.Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            this.Url = url;
        }

        public WebDriverWait Wait { get; set; }
        public IWebDriver WebDriver { get; private set; }
        public string Url { get; protected set; }

        public virtual void GoToPage()
        {
            WebDriver.Navigate().GoToUrl(Url);
        }

        public void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }

        public void Close()
        {
            WebDriver.Close();
        }

        // Static helpers
        public static IWebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        public static IWebDriver InternetExplorerDriver()
        {
            return new InternetExplorerDriver();
        }

    }
}
