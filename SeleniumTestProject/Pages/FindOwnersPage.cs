using OpenQA.Selenium;
using SeleniumTestProject.Base;
using System.Collections.Generic;

namespace SeleniumTestProject.Pages
{
    class FindOwnersPage : Page
    {
        public FindOwnersPage() : base()
        { }

        /// <summary>Поле ввода фамилии владельца для поиска</summary>
        public IWebElement FieldFindOwner => driver.FindElement(By.CssSelector("input[id='lastName']"));

        /// <summary>Кнопка для поиска владельца домашних животных</summary>
        public IWebElement BtnFindOwner => driver.FindElement(By.CssSelector("button[type='submit'"));
        
        /// <summary>Кнопка для добавления нового владельца домашних животных</summary>
        public IWebElement BtnAddNewOwner => driver.FindElement(By.CssSelector("a[href *='new'"));

        /// <summary>Нажимаем на кнопку поиска владельцев для получения списка владельцев домашних животных</summary>
        public ResultOfSearchOwnerPage ClickFindOwnerButton()
        {
            BtnFindOwner.Click();
            return new ResultOfSearchOwnerPage();
        }

        
    }
}
