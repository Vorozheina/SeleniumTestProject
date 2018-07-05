using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class MyFirstTest
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void myFirstTest()
        {
            driver.Navigate().GoToUrl("https://www.swtestacademy.com");
            Assert.AreEqual("Software Test Academy", driver.Title);
            driver.Close();
            driver.Quit();
        }
        [Test]
        public void OpenMainPageTest()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.Close();
            driver.Quit();
        }
        public void MainPageIsOpenedTest()
        {
        }
        [Test]
        public void ThePageIsMainTest()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            Assert.AreEqual("http://localhost:8080/", driver.Url);
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void OpenFindOwnersFrameTest()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.CssSelector("a[href *= 'owners']")).Click();
            driver.Close();
            driver.Quit();
        }
        
        [Test]
        public void LoadOwnersSuccessfullyTest()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.CssSelector("a[href *= 'owners']")).Click();
            driver.FindElement(By.CssSelector("button[type='submit'")).Click();
            IWebElement tableElement = driver.FindElement(By.Id("vets"));
            Assert.IsTrue(tableElement.Displayed);
            driver.Close();
            driver.Quit();
        }
    }
}
