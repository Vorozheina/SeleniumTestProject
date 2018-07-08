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
        public static IWebDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/");
        }
        [Test]
        public void MainScenarioTest()
        {
            HomePage homePage = new HomePage();
            PageFactory.InitElements(driver, homePage);
            IWebElement webElementHomePageH2 = homePage.GetHomePageH2;

            Assert.AreEqual("Welcome", webElementHomePageH2.Text);
            Assert.AreEqual("http://localhost:8080/", driver.Url);

            homePage.UrlFindOwnersClick.Click();

            FindOwnersPage findOwnersPage = new FindOwnersPage();
            PageFactory.InitElements(driver, findOwnersPage);
            findOwnersPage.BtnFindOwnerClick.Click();

            ResultOfSearchOwnerPage resultOfSearchOwnerPage = new ResultOfSearchOwnerPage();
            PageFactory.InitElements(driver, resultOfSearchOwnerPage);
            IWebElement webElementFindOwnersPage = resultOfSearchOwnerPage.TableFindOwnerResult;

            Assert.IsTrue(webElementFindOwnersPage.Displayed);
            Assert.AreEqual(10, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1);

            resultOfSearchOwnerPage.UrlFindOwnersClick.Click();
            findOwnersPage.BtnAddNewOwnerClick.Click();

            NewOwnerPage newOwnerPage = new NewOwnerPage();
            PageFactory.InitElements(driver, newOwnerPage);
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

            OwnerProfilePage ownerProfilePage = new OwnerProfilePage();
            PageFactory.InitElements(driver, ownerProfilePage);

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

            //driver.Navigate().GoToUrl("http://localhost:8080/owners/11");
            driver.Navigate().Back();
            
            ownerProfilePage.BtnAddNewPetClick.Click();

            NewPetPage newPetPage = new NewPetPage();
            PageFactory.InitElements(driver, newPetPage);

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

            EditPetPage editPetPage = new EditPetPage();
            PageFactory.InitElements(driver, editPetPage);

            editPetPage.OptionPetType.FindElement(By.CssSelector("option[value='dog']")).Click();
            editPetPage.BtnEditPetClick.Click();

            PetType = "dog";

            Assert.AreEqual(PetType, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[3]")).Text);

            ownerProfilePage.LnkAddVisitClick.Click();

            NewVisitPage newVisitPage = new NewVisitPage();
            PageFactory.InitElements(driver, newVisitPage);

            string Description = "Vaccination";


            newVisitPage.FieldVisitDescriptionText.SendKeys(Description);
            
            newVisitPage.BtnAddVisitClick.Click();

            Assert.AreEqual(Description, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[2]/table/tbody/tr[1]/td[2]")).Text);

        }



    }
}
