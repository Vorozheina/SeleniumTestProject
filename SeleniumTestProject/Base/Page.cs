using OpenQA.Selenium;


namespace SeleniumTestProject.Base
{
    public abstract class Page
    {
        public IWebDriver driver;

        public Page(IWebDriver driver) => this.driver = driver;

        public string PageSource => this.driver.PageSource;
                

    }
}
