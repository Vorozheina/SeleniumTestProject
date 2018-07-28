using OpenQA.Selenium;


namespace SeleniumTestProject.Pages
{
    class FindOwnersPage : HomePage
    {
        public FindOwnersPage() : base()
        { }

        /// <summary>Поле ввода фамилии владельца для поиска</summary>
        public IWebElement FieldFindOwner => driver.FindElement(By.CssSelector("input[id='lastName']"));

        /// <summary>Кнопка для поиска владельца домашних животных</summary>
        public IWebElement BtnFindOwner => driver.FindElement(By.CssSelector("button[type='submit'"));

        /// <summary>Кнопка для добавления нового владельца домашних животных</summary>
        public IWebElement BtnAddNewOwner => driver.FindElement(By.CssSelector("a[href *='new'"));
        
    }
}
