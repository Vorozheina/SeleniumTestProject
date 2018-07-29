﻿using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestProject.Base;

namespace SeleniumTestProject.Pages
{
    class NewPetPage : Page
    {
        public NewPetPage() : base()
        { }


        public IWebElement FieldPetOwner => driver.FindElement(By.XPath(".//label[text()='Owner']/following-sibling::div/span"));
        
        public IWebElement FieldPetName => driver.FindElement(By.CssSelector("input[id='name']"));

        public IWebElement FieldPetBirthDate => driver.FindElement(By.CssSelector("input[id='birthDate']"));

        public IWebElement OptionPetType => driver.FindElement(By.CssSelector("select[id='type']"));

        public IWebElement BtnAddPet => driver.FindElement(By.CssSelector("button[type='submit']"));

        public IWebElement SelectPetType(int i)
        {
            SelectElement selectElement = new SelectElement(OptionPetType);
            IList<IWebElement> options = selectElement.Options;
            IWebElement firstOption = options[i];
            return firstOption;
        }

    }
}
