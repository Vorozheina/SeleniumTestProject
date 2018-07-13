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

            homePage.UrlFindOwners.Click();

                        
            var findOwnersPage = new FindOwnersPage(driver);
            findOwnersPage.BtnFindOwner.Click();
                        
            var resultOfSearchOwnerPage = new ResultOfSearchOwnerPage(driver);
            IWebElement webElementFindOwnersPage = resultOfSearchOwnerPage.TableFindOwnerResult;
            
            Assert.IsTrue(webElementFindOwnersPage.Displayed);
            Assert.AreEqual(10, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1);
            
            resultOfSearchOwnerPage.UrlFindOwners.Click();
            findOwnersPage.BtnAddNewOwner.Click();
            
            var newOwnerPage = new NewOwnerPage(driver);
            /*изменить на вызов Json!!!*/

            string FirstName = "Ivan";
            string LastName = "Ivanov";
            string Address = "15 Osenny Blvd.";
            string City = "Moscow";
            string Telephone = "4957771234";
            string FullName = String.Concat(FirstName + " ", LastName);

            /*изменить на вызов Json!!!*/

            newOwnerPage.FieldOwnerFirstName.SendKeys(FirstName);
            newOwnerPage.FieldOwnerLastName.SendKeys(LastName);
            newOwnerPage.FieldOwnerAddress.SendKeys(Address);
            newOwnerPage.FieldOwnerCity.SendKeys(City);
            newOwnerPage.FieldOwnerTelephone.SendKeys(Telephone);
            newOwnerPage.BtnAddOwner.Click();
            
            var ownerProfilePage = new OwnerProfilePage(driver);

            Assert.AreEqual(FullName, ownerProfilePage.FieldOwnerProfileName.Text);
            Assert.AreEqual(Address, ownerProfilePage.FieldOwnerProfileAddress.Text);
            Assert.AreEqual(City, ownerProfilePage.FieldOwnerProfileCity.Text);
            Assert.AreEqual(Telephone, ownerProfilePage.FieldOwnerProfileTelephone.Text);

            Assert.AreEqual(0, ownerProfilePage.TableOwnerProfilePetRows.Count);
                        
            ownerProfilePage.UrlFindOwners.Click();

            findOwnersPage.BtnFindOwner.Click();

            Assert.AreEqual(11, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1);

            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(FullName));
            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(Address));
            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(City));
            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(Telephone));

            resultOfSearchOwnerPage.SelectProfileByName(FullName).Click();
            
            ownerProfilePage.BtnAddNewPet.Click();

            driver.Navigate().Back();

            ownerProfilePage.BtnAddNewPet.Click();

            var newPetPage = new NewPetPage(driver);

            Assert.AreEqual(FullName, newPetPage.FieldPetOwner.Text);
            
            //json!!!
            string PetName = "Tom";
            string PetBirthDate = "2015-04-04";
            
            //json!!!

            newPetPage.FieldPetName.SendKeys(PetName);
            newPetPage.FieldPetBirthDate.SendKeys(PetBirthDate);
            newPetPage.SelectPetType(1).Click();

            string PetType = newPetPage.SelectPetType(1).Text;

            
            newPetPage.BtnAddPet.Click();

            Assert.Greater(ownerProfilePage.TableOwnerProfilePetRows.Count, 0);

            Assert.IsNotNull(ownerProfilePage.FindPetDataInTable(PetName, PetBirthDate, PetType));

            ownerProfilePage.LnkEditPet(PetName).Click();
            
       
            var editPetPage = new EditPetPage(driver);

            editPetPage.SelectPetType(2).Click();

            PetType = editPetPage.SelectPetType(2).Text;

            editPetPage.BtnEditPet.Click();
                     
            Assert.AreEqual(PetType, ownerProfilePage.GetTypeOfPet(PetName).Text);
            
            ownerProfilePage.LnkAddVisit(PetName).Click();

            var newVisitPage = new NewVisitPage(driver);

            string Description = "Vaccination";

            newVisitPage.FieldVisitDescription.SendKeys(Description);

            newVisitPage.BtnAddVisit.Click();

            Assert.IsNotNull(ownerProfilePage.FindDescriptionOfVisitInTable(PetName, Description));
            
        }

        [TearDown]
        public void CleanUp()
        {
            Browsers.Close();
        }
        



    }
}
