using OpenQA.Selenium;
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
                
        public IList<IWebElement> TableOwnerProfilePetRows => (driver.FindElement(By.XPath(".//h2[text()='Pets and Visits']/following-sibling::table"))).FindElements(By.CssSelector("tr"));



        public IWebElement BtnEditOwner => driver.FindElement(By.LinkText("Edit Owner"));

        public IWebElement BtnAddNewPet => driver.FindElement(By.LinkText("Add New Pet"));

        //public IWebElement LnkEditPet => driver.FindElement
        /*
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/table[2]")]
        public IWebElement TableOwnerProfile { get; set; }

        [FindsBy(How = How.LinkText, Using = "Edit Owner")]
        public IWebElement BtnEditOwnerClick { get; set; }

        [FindsBy(How = How.LinkText, Using = "Add New Pet")]
        public IWebElement BtnAddNewPetClick { get; set; }

        [FindsBy(How = How.LinkText, Using = "Edit Pet")]
        public IWebElement LnkEditPetClick { get; set; }

        [FindsBy(How = How.LinkText, Using = "Add Visit")]
        public IWebElement LnkAddVisitClick { get; set; }
        */
    }
} 
