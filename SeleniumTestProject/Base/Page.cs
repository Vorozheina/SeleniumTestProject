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
       public Page(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        
    }
}
