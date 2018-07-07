using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages
{
    class NewOwnerPage : HomePage
    {
        [FindsBy(How = How.CssSelector, Using = "input[id='firstName']")]
        public IWebElement FieldOwnerFirstNameText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='lastName']")]
        public IWebElement FieldOwnerLastNameText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='address']")]
        public IWebElement FieldOwnerAddressText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='city']")]
        public IWebElement FieldOwnerCityText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='telephone']")]
        public IWebElement FieldOwnerTelephoneText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit'")]
        public IWebElement BtnAddOwnerClick { get; set; }
    }
}
