﻿using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class OwnerProfilePage : HomePage
    {
        public OwnerProfilePage(IWebDriver driver) : base(driver)
        { }

        public IWebElement FieldOwnerProfileName => driver.FindElement(By.XPath(".//th[text()='Name']/following-sibling::td/b"));

        public IWebElement FieldOwnerProfileAddress => driver.FindElement(By.XPath(".//th[text()='Address']/following-sibling::td"));

        public IWebElement FieldOwnerProfileCity => driver.FindElement(By.XPath(".//th[text()='City']/following-sibling::td"));

        public IWebElement FieldOwnerProfileTelephone => driver.FindElement(By.XPath(".//th[text()='Telephone']/following-sibling::td"));

        public IList<IWebElement> TableOwnerProfilePetRows => driver.FindElements(By.XPath(".//h2[text()='Pets and Visits']/following-sibling::table//tr"));

        public IWebElement BtnEditOwner => driver.FindElement(By.LinkText("Edit Owner"));

        public IWebElement BtnAddNewPet => driver.FindElement(By.LinkText("Add New Pet"));


        //
        public IWebElement FindPetDataInTable(string PetName, string PetBirthDate = "", string PetType = "")
        {
            IList<IWebElement> webElements = TableOwnerProfilePetRows;
            foreach (IWebElement el in webElements)
            {
                if (el.FindElement(By.XPath(".//dt[text() = 'Name']/following-sibling::dd[1]")).Text == PetName)
                    if (PetBirthDate.Length == 0 || PetType.Length == 0)
                        return el;
                    else
                        if (el.FindElement(By.XPath(".//dt[text() = 'Birth Date']/following-sibling::dd[1]")).Text == PetBirthDate
                            && el.FindElement(By.XPath(".//dt[text() = 'Type']/following-sibling::dd[1]")).Text == PetType)
                        return el;
            }
            return null;

        }

        public IWebElement LnkEditPet(string PetName)
        {
            IWebElement webElement = FindPetDataInTable(PetName); ;
            return webElement.FindElement(By.LinkText("Edit Pet"));
        }

        public IWebElement GetTypeOfPet(string PetName)
        {
            IWebElement webElement = FindPetDataInTable(PetName);
            return webElement.FindElement(By.XPath(".//dt[text() = 'Type']/following-sibling::dd[1]"));
        }

        public IWebElement LnkAddVisit(string PetName)
        {
            IWebElement webElement = FindPetDataInTable(PetName); ;
            return webElement.FindElement(By.LinkText("Add Visit"));
        }

        public IList<IWebElement> TableOfVisitsRows(string PetName)
        {
            IWebElement webElement = FindPetDataInTable(PetName);
            return webElement.FindElements(By.CssSelector("table[class='table-condensed']"));
        }

        public IWebElement FindDescriptionOfVisitInTable(string PetName, string Description)
        {
            IList<IWebElement> webElements = TableOfVisitsRows(PetName);
            foreach (IWebElement el in webElements)
            {
                if (el.FindElement(By.XPath(".//tr/td[2]")).Text == Description)
                    return el;
            }
            return null;
        }
    }
}