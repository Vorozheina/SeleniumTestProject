using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestProject.Base
{
    public abstract class Page
    {
        public IWebDriver driver;

        public Page(IWebDriver driver) => this.driver = driver;

        public string PageSource => this.driver.PageSource;
                

    }
}
