using NUnit.Framework;
using OpenQA.Selenium;
using System;
using SeleniumTestProject.Pages;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumTestProject.Base;
using Newtonsoft.Json;

namespace SeleniumTestProject
{
    public class MyFirstTest
    {
        [SetUp]
        public void SetUp()
        {
            Browsers.Init();
        }

        [Test]
        public void MainScenarioTest()
        {
            IWebDriver driver = Browsers.getDriver;

            //json
            

            var homePage = new HomePage(driver);

            IWebElement webElementHomePageH2 = homePage.GetHomePageH2;

            Assert.AreEqual("Welcome", webElementHomePageH2.Text, "The Home Page has not opened, the header is ");
            Assert.AreEqual("http://localhost:8080/", driver.Url);

            homePage.UrlFindOwnersClick.Click();
            
            var findOwnersPage = new FindOwnersPage(driver);
            findOwnersPage.BtnFindOwnerClick.Click();

            var resultOfSearchOwnerPage = new ResultOfSearchOwnerPage(driver);
            IWebElement webElementFindOwnersPage = resultOfSearchOwnerPage.TableFindOwnerResult;

            Assert.IsTrue(webElementFindOwnersPage.Displayed);
            Assert.AreEqual(10, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1);

            resultOfSearchOwnerPage.UrlFindOwnersClick.Click();
            findOwnersPage.BtnAddNewOwnerClick.Click();

            var newOwnerPage = new NewOwnerPage(driver);

            string FirstName = "Ivan";
            string LastName = "Ivanov";
            string Address = "15 Osenny Blvd.";
            string City = "Moscow";
            string Telephone = "4957771234";
            string FullName = String.Concat(FirstName + " ", LastName);

            newOwnerPage.FieldOwnerFirstNameText.SendKeys(FirstName);
            newOwnerPage.FieldOwnerLastNameText.SendKeys(LastName);
            newOwnerPage.FieldOwnerAddressText.SendKeys(Address);
            newOwnerPage.FieldOwnerCityText.SendKeys(City);
            newOwnerPage.FieldOwnerTelephoneText.SendKeys(Telephone);
            newOwnerPage.BtnAddOwnerClick.Click();

            var ownerProfilePage = new OwnerProfilePage(driver);

            Assert.AreEqual(FullName, ownerProfilePage.FieldOwnerProfileNameText.Text);
            Assert.AreEqual(Address, ownerProfilePage.FieldOwnerProfileAddressText.Text);
            Assert.AreEqual(City, ownerProfilePage.FieldOwnerProfileCityText.Text);
            Assert.AreEqual(Telephone, ownerProfilePage.FieldOwnerProfileTelephoneText.Text);

            Assert.AreEqual(0, ownerProfilePage.TableOwnerProfile.FindElements(By.CssSelector("tr")).Count);

            ownerProfilePage.UrlFindOwnersClick.Click();

            findOwnersPage.BtnFindOwnerClick.Click();

            Assert.AreEqual(11, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1);

            Assert.IsNotNull(resultOfSearchOwnerPage.TableFindOwnerResult.FindElement(By.LinkText(FullName)));
            Assert.IsNotNull(resultOfSearchOwnerPage.TableFindOwnerResult.FindElement(By.XPath(".//td[text() = '" + Address + "']")));
            Assert.IsNotNull(resultOfSearchOwnerPage.TableFindOwnerResult.FindElement(By.XPath(".//td[text() = '" + City + "']")));
            Assert.IsNotNull(resultOfSearchOwnerPage.TableFindOwnerResult.FindElement(By.XPath(".//td[text() = '" + Telephone + "']")));

            resultOfSearchOwnerPage.TableFindOwnerResult.FindElement(By.LinkText(FullName)).Click();

            ownerProfilePage.BtnAddNewPetClick.Click();

            driver.Navigate().Back();

            ownerProfilePage.BtnAddNewPetClick.Click();

            var newPetPage = new NewPetPage(driver);

            Assert.AreEqual(FullName, newPetPage.FieldPetOwnerText.Text);

            string PetName = "Tom";
            string PetBirthDate = "2015-04-04";
            string PetType = "cat";

            newPetPage.FieldPetNameText.SendKeys(PetName);
            newPetPage.FieldPetBirthDateText.SendKeys(PetBirthDate);
            newPetPage.OptionPetType.FindElement(By.CssSelector("option[value='cat']")).Click();

            newPetPage.BtnAddPetClick.Click();

            Assert.IsNotNull(ownerProfilePage.TableOwnerProfile.FindElements(By.CssSelector("tr")));

            Assert.AreEqual(PetName, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[1]")).Text);
            Assert.AreEqual(PetBirthDate, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[2]")).Text);
            Assert.AreEqual(PetType, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[3]")).Text);

            ownerProfilePage.LnkEditPetClick.Click();

            var editPetPage = new EditPetPage(driver);

            editPetPage.OptionPetType.FindElement(By.CssSelector("option[value='dog']")).Click();
            editPetPage.BtnEditPetClick.Click();

            PetType = "dog";

            Assert.AreEqual(PetType, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[3]")).Text);

            ownerProfilePage.LnkAddVisitClick.Click();

            var newVisitPage = new NewVisitPage(driver);

            string Description = "Vaccination";


            newVisitPage.FieldVisitDescriptionText.SendKeys(Description);

            newVisitPage.BtnAddVisitClick.Click();

            Assert.AreEqual(Description, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[2]/table/tbody/tr[1]/td[2]")).Text);
        }

        [TearDown]
        public void CleanUp()
        {
            Browsers.Close();
        }
        



    }
}
