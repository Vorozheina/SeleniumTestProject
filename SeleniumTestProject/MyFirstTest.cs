using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTestProject.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestProject
{
    public class MyFirstTest
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void OpenMainPageTest()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            HomePage homePage = new HomePage();
            PageFactory.InitElements(driver, homePage);
            homePage.UrlHomeClick.Click();
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void MainScenarioTest()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            HomePage homePage = new HomePage();
            PageFactory.InitElements(driver, homePage);
            IWebElement webElementH2 = homePage.GetHomePageH2;

            Assert.AreEqual("Welcome", webElementH2.Text);
            Assert.AreEqual("http://localhost:8080/", driver.Url);

            homePage.UrlFindOwnersClick.Click();

            FindOwnersPage findOwnersPage = new FindOwnersPage();
            PageFactory.InitElements(driver, findOwnersPage);
            //findOwnersPage.
        }


        [Test]
        public void MainPageIsOpenedTest()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            Assert.AreEqual("Welcome", driver.FindElement(By.CssSelector("h2")).Text);
            driver.Close();
            driver.Quit();
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
            //driver.FindElement(By.CssSelector("a[href *= 'owners']")).Click();
            //driver.FindElement(By.CssSelector("button[type='submit'")).Click();
            //IWebElement tableElement = driver.FindElement(By.Id("vets"));
            //Assert.IsTrue(tableElement.Displayed);
            FindOwnersPage findOwnersPage = new FindOwnersPage();
            PageFactory.InitElements(driver, findOwnersPage);
            findOwnersPage.UrlFindOwnersClick.Click();
            findOwnersPage.BtnFindOwnerClick.Click();
            IWebElement tableElement = driver.FindElement(By.Id("vets"));
            Assert.IsTrue(tableElement.Displayed);
            driver.Close();
            driver.Quit();
        }
        [Test]
        public void QuantityOfOwners10Test()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.CssSelector("a[href *= 'owners']")).Click();
            driver.FindElement(By.CssSelector("button[type='submit'")).Click();
            Assert.AreEqual(10, driver.FindElements(By.CssSelector("tr")).Count-1);
            driver.Close();
            driver.Quit();
        }
    }
}
