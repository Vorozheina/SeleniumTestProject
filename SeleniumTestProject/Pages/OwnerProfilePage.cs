using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class OwnerProfilePage : HomePage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/table[1]/tbody/tr[1]/td/b")]
        public IWebElement FieldOwnerProfileNameText { get; set; }
                
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/table[1]/tbody/tr[2]/td")]
        public IWebElement FieldOwnerProfileAddressText { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/table[1]/tbody/tr[3]/td")]
        public IWebElement FieldOwnerProfileCityText { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/table[1]/tbody/tr[4]/td")]
        public IWebElement FieldOwnerProfileTelephoneText { get; set; }

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
    }
} 
