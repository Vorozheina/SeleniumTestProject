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
            string PetType = "cat";
            //json!!!

            newPetPage.FieldPetName.SendKeys(PetName);
            newPetPage.FieldPetBirthDate.SendKeys(PetBirthDate);
            newPetPage.SelectPetType(PetType).Click();
            
            
            newPetPage.BtnAddPet.Click();

            Assert.Greater(ownerProfilePage.TableOwnerProfilePetRows.Count, 0);
            /*
            
            Assert.AreEqual(PetName, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[1]")).Text);
            Assert.AreEqual(PetBirthDate, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[2]")).Text);
            Assert.AreEqual(PetType, ownerProfilePage.TableOwnerProfile.FindElement(By.XPath(".//tr/td[1]/dl/dd[3]")).Text);
            */
            /*
            ownerProfilePage.LnkEditPetCLick.Click();

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
            */
        }

        [TearDown]
        public void CleanUp()
        {
            Browsers.Close();
        }
        



    }
}
