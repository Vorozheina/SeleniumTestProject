﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages
{
    class NewVisitPage : HomePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='date']")]
        public IWebElement FieldVisitDateText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='description']")]
        public IWebElement FieldVisitDescriptionText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement BtnAddVisitClick { get; set; }
    }
}
