using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SeleniumTestProject.Pages
{
    class ResultOfSearchOwnerPage : HomePage
    {
        [FindsBy(How = How.Id, Using = "vets")]
        public IWebElement TableFindOwnerResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr")]
        public IList<IWebElement> TableFindOwnerResultRows { get; set; }
                
    }
}
