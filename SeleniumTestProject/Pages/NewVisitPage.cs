using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class NewVisitPage : HomePage
    {
        public NewVisitPage(IWebDriver driver) : base(driver)
        { }

        [FindsBy(How = How.XPath, Using = "//*[@id='date']")]
        public IWebElement FieldVisitDateText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='description']")]
        public IWebElement FieldVisitDescriptionText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement BtnAddVisitClick { get; set; }
    }
}
