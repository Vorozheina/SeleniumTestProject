using OpenQA.Selenium;
using SeleniumTestProject.Pages;


namespace SeleniumTestProject.Base
{
    public abstract class Page
    {
        public IWebDriver driver;

        public Page() => driver = Browsers.GetDriver;

        public string PageSource => driver.PageSource;

        /// <summary>Кнопка-логотип для перехода на главную страницу</summary>
        public IWebElement BtnLogoGoHome => driver.FindElement(By.CssSelector("button[type='button'"));

        public HomePage ClickBtnLogoGoHome()
        {
            BtnLogoGoHome.Click();
            return new HomePage();
        }

        /// <summary>Кнопка-ссылка для перехода на главную страницу</summary>
        public IWebElement UrlHome => driver.FindElement(By.CssSelector("a[title='home page'"));

        public HomePage ClickUrlHome()
        {
            UrlHome.Click();
            return new HomePage();
        }

        /// <summary>Кнопка-ссылка для перехода на страницу поиска владельцев домашних животных</summary>
        public IWebElement UrlFindOwners => driver.FindElement(By.CssSelector("a[title = 'find owners'"));

        public FindOwnersPage ClickUrlFindOwners()
        {
            UrlFindOwners.Click();
            return new FindOwnersPage();
        }
        
    }
}
