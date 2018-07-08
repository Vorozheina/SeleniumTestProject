using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages
{
    class NewPetPage : HomePage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/form/div[1]/div[1]/div/span")]
        public IWebElement FieldPetOwnerText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='name']")]
        public IWebElement FieldPetNameText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='birthDate']")]
        public IWebElement FieldPetBirthDateText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "select[id='type']")]
        public IWebElement OptionPetType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement BtnAddPetClick { get; set; }
    }
}
