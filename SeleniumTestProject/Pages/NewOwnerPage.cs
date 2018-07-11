using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class NewOwnerPage : HomePage
    {
        public NewOwnerPage(IWebDriver driver) : base(driver)
        { }

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
