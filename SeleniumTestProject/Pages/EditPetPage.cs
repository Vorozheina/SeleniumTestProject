using OpenQA.Selenium;


namespace SeleniumTestProject.Pages
{
    class EditPetPage : NewPetPage
    {
        public EditPetPage() : base()
        { }

        public IWebElement BtnEditPet => driver.FindElement(By.CssSelector("button[type='submit']"));
        
    }
}
