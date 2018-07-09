using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class HomePage
    {

        [FindsBy(How = How.CssSelector, Using = "h2")]
        public IWebElement GetHomePageH2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='button'")]
        public IWebElement BtnLogoGoHomeClick { get; set; }

        //переход на главную страницу
        [FindsBy(How = How.CssSelector, Using = "a[title='home page'")]
        public IWebElement UrlHomeClick { get; set; }

        //переход на страницу с владельцами животных
        [FindsBy(How = How.CssSelector, Using = "a[title='find owners'")]
        public IWebElement UrlFindOwnersClick { get; set; }

        //переход на страницу с ветеринарами
        [FindsBy(How = How.CssSelector, Using = "a[title='veterinarians'")]
        public IWebElement UrlVeterinariansClick { get; set; }

        //переход на страницу с сообщением об ошибке
        [FindsBy(How = How.CssSelector, Using = "a[title *='RuntimeException'")]
        public IWebElement UrlErrorClick { get; set; }


    }
}
