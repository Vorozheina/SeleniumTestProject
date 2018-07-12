using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class NewOwnerPage : HomePage
    {
        public NewOwnerPage(IWebDriver driver) : base(driver)
        { }

        /// <summary>Поле с именем владельца домашнего животного</summary>
        public IWebElement FieldOwnerFirstName => driver.FindElement(By.CssSelector("input[id='firstName']"));

        /// <summary>Поле с фамилией владельца домашнего животного</summary>
        public IWebElement FieldOwnerLastName => driver.FindElement(By.CssSelector("input[id='lastName']"));

        /// <summary>Поле с адресом владельца домашнего животного</summary>
        public IWebElement FieldOwnerAddress => driver.FindElement(By.CssSelector("input[id='address']"));

        /// <summary>Поле с названием города владельца домашнего животного</summary>
        public IWebElement FieldOwnerCity => driver.FindElement(By.CssSelector("input[id='city']"));

        /// <summary>Поле с номером телефона владельца домашнего животного</summary>
        public IWebElement FieldOwnerTelephone => driver.FindElement(By.CssSelector("input[id='telephone']"));

        /// <summary>Кнопка для добавления владельца домашнего животного</summary>
        public IWebElement BtnAddOwner => driver.FindElement(By.CssSelector("button[type='submit'"));
        
    }
}
