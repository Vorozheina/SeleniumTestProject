using OpenQA.Selenium;


namespace SeleniumTestProject.Pages
{
    class NewVisitPage : HomePage
    {
        public NewVisitPage(IWebDriver driver) : base(driver)
        { }

        public IWebElement FieldVisitDate => driver.FindElement(By.XPath("//*[@id='date']"));

        public IWebElement FieldVisitDescription => driver.FindElement(By.CssSelector("input[id='description']"));

        public IWebElement BtnAddVisit => driver.FindElement(By.CssSelector("button[type='submit']"));
        
    }
}
