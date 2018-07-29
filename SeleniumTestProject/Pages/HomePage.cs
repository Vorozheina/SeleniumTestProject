using OpenQA.Selenium;
using SeleniumTestProject.Base;


namespace SeleniumTestProject.Pages
{
    class HomePage : Page
    {
        public HomePage() : base()
        { }
        /// <summary>Поиск заголовка загруженной страницы</summary>
        public IWebElement GetHomePageH2 => driver.FindElement(By.CssSelector("h2"));       


    }
}
