using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class EditPetPage : NewPetPage
    {
        public EditPetPage(IWebDriver driver) : base(driver)
        { }

        public IWebElement BtnEditPet => driver.FindElement(By.CssSelector("button[type='submit']"));
        
    }
}
