using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumTestProject.Base;

namespace SeleniumTestProject.Pages
{
    public class ResultOfSearchOwnerPage : Page
    {
        public ResultOfSearchOwnerPage() : base()
        { }

        /// <summary>Таблица с результатом поиска владельца домашних животных</summary>
        public IWebElement TableFindOwnerResult => driver.FindElement(By.Id("vets"));

        /// <summary>Таблица с результатом поиска владельца домашних животных</summary>
        public IList<IWebElement> TableFindOwnerResultRows => driver.FindElements(By.CssSelector("tr"));
                
        /// <summary>Выбор владельца домашних животных по имени</summary>
        public IWebElement SelectProfileByName(string fullName) => driver.FindElement(By.LinkText(fullName));
    }
}
