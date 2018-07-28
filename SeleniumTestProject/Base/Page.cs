using OpenQA.Selenium;


namespace SeleniumTestProject.Base
{
    public abstract class Page
    {
        public IWebDriver driver;

        public Page() => driver = Browsers.GetDriver;

        public string PageSource => this.driver.PageSource;
                

    }
}
