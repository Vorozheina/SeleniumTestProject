using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace SeleniumTestProject.Base
{
    public class Browsers
    {
        private static IWebDriver webDriver;
        private static string baseURL = ConfigurationManager.AppSettings["URL"];
        private static string browser = ConfigurationManager.AppSettings["Browser"];
        
        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();                    
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            GoTo(baseURL);


        }
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static IWebDriver GetDriver
        {
            get { return webDriver; }
        }
        public static void GoTo(string url)
        {
            webDriver.Url = url;
        }
        public static void Close()
        {
            webDriver.Quit();
        }
        public static string Url
        {
            get { return webDriver.Url; }            
        }
        public static void GoBack()
        {
            webDriver.Navigate().Back();
        }
    }
}
