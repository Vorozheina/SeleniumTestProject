using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages
{
    class ResultOfSearchOwnerPage : HomePage
    {
        [FindsBy(How = How.Id, Using = "vets")]
        public IWebElement TableFindOwnerResult { get; set; }
    }
}
