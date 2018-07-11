using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class EditPetPage : NewPetPage
    {
        public EditPetPage(IWebDriver driver) : base(driver)
        { }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement BtnEditPetClick { get; set; }

    }
}
