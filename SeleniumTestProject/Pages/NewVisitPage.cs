using OpenQA.Selenium;
using SeleniumTestProject.Base;

namespace SeleniumTestProject.Pages
{
    class NewVisitPage : Page
    {
        public NewVisitPage() : base()
        { }

        public IWebElement FieldVisitDate => driver.FindElement(By.XPath("//*[@id='date']"));

        public IWebElement FieldVisitDescription => driver.FindElement(By.CssSelector("input[id='description']"));

        public IWebElement BtnAddVisit => driver.FindElement(By.CssSelector("button[type='submit']"));
        
    }
}
