﻿using OpenQA.Selenium;


namespace SeleniumTestProject.Base
{
    public abstract class Page
    {
        public IWebDriver driver;

        public Page() => driver = Browsers.GetDriver;

        public string PageSource => driver.PageSource;

        /// <summary>Кнопка-логотип для перехода на главную страницу</summary>
        public IWebElement BtnLogoGoHome => driver.FindElement(By.CssSelector("button[type='button'"));

        /// <summary>Кнопка-ссылка для перехода на главную страницу</summary>
        public IWebElement UrlHome => driver.FindElement(By.CssSelector("a[title='home page'"));

        /// <summary>Кнопка-ссылка для перехода на страницу поиска владельцев домашних животных</summary>
        public IWebElement UrlFindOwners => driver.FindElement(By.CssSelector("a[title = 'find owners'"));

        /// <summary>Кнопка-ссылка для на страницу со списком ветеринаров</summary>
        public IWebElement UrlVeterinarians => driver.FindElement(By.CssSelector("a[title = 'veterinarians'"));

        /// <summary>Кнопка-ссылка для на страницу с сообщением об ошибке</summary>
        public IWebElement UrlError => driver.FindElement(By.CssSelector("a[title *='RuntimeException'"));
    }
}
