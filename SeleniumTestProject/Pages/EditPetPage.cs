using OpenQA.Selenium;
//using SeleniumTestProject.Base;

namespace SeleniumTestProject.Pages
{
    public class EditPetPage : NewPetPage
    {
        public EditPetPage() : base()
        { }

        public IWebElement BtnEditPet => driver.FindElement(By.CssSelector("button[type='submit']"));
        
    }
}
