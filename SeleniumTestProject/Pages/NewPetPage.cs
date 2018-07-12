using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTestProject.Pages
{
    class NewPetPage : HomePage
    {
        public NewPetPage(IWebDriver driver) : base(driver)
        { }


        public IWebElement FieldPetOwner => driver.FindElement(By.XPath(".//label[text()='Owner']/following-sibling::div/span"));
        
        public IWebElement FieldPetName => driver.FindElement(By.CssSelector("input[id='name']"));

        public IWebElement FieldPetBirthDate => driver.FindElement(By.CssSelector("input[id='birthDate']"));

        public IWebElement OptionPetType => driver.FindElement(By.CssSelector("select[id='type']"));

        public IWebElement BtnAddPet => driver.FindElement(By.CssSelector("button[type='submit']"));

        public IWebElement SelectPetType(string petType) => this.OptionPetType.FindElement(By.CssSelector("option[value='" + petType + "']"));

    }
}
