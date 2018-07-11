using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class FindOwnersPage : HomePage
    {
        public FindOwnersPage(IWebDriver driver) : base(driver)
        { }

        /// <summary>Строка ввода поиска владельца по фамилии</summary>
        [FindsBy(How = How.CssSelector, Using = "input[id='lastName']")]
        public IWebElement FieldFindOwnerText { get; set; }

        /// <summary>Кнопка для поиска владельца</summary>
        [FindsBy(How = How.CssSelector, Using = "button[type='submit'")]
        public IWebElement BtnFindOwnerClick { get; set; }

        //кнопка для добавления новой записи
        [FindsBy(How = How.CssSelector, Using = "a[href *='new'")]
        public IWebElement BtnAddNewOwnerClick { get; set; }

        
    }
}
