using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using SeleniumTestProject.Pages;
using SeleniumTestProject.Base;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;


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
            byte[] jsonBytes = Properties.Resources.Constants;

            string stringJsonConstants = Encoding.UTF8.GetString(jsonBytes);
            stringJsonConstants = stringJsonConstants.Substring(1);

            JObject jsonConstants = JObject.Parse(stringJsonConstants);

            // Открываем окно браузера и переходим на главную страницу проекта Spring - Petclinic
            IWebDriver driver = Browsers.getDriver;
            
            var homePage = new HomePage(driver);

            // Получаем заголовок h2 с главной страницы
            IWebElement webElementHomePageH2 = homePage.GetHomePageH2;

            // Проверяем, что страница открылась (сравниваем заголовки h2)
            Assert.AreEqual("Welcome", webElementHomePageH2.Text, "The 'Home Page' is not opened");
            // Проверяем, что мы находимся на главной странице
            Assert.AreEqual(ConfigurationManager.AppSettings["URL"], driver.Url, "The page is not 'Home Page'");

            homePage.UrlFindOwners.Click();
                        
            // Переходим на страницу поиска владельцев домашних животных
            var findOwnersPage = new FindOwnersPage(driver);
            findOwnersPage.BtnFindOwner.Click();
            
            // Получаем список всех владельцев домашних животных
            var resultOfSearchOwnerPage = new ResultOfSearchOwnerPage(driver);
            IWebElement webElementFindOwnersPage = resultOfSearchOwnerPage.TableFindOwnerResult;
            
            // Проверяем, что список владельцев появился
            Assert.IsTrue(webElementFindOwnersPage.Displayed, "The 'Find Owners Page' is not displayed");
            // Проверяем, что в нем содержится 10 записей
            Assert.AreEqual(10, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1, "The count of rows is not equal to 10");
            
            resultOfSearchOwnerPage.UrlFindOwners.Click();
            findOwnersPage.BtnAddNewOwner.Click();
            
            // Создаем профиль нового владельца домашних животных, заполняем поля формы для создания профиля
            var newOwnerPage = new NewOwnerPage(driver);

            string FirstName = (string)jsonConstants.SelectToken("owners[0].FirstName");
            string LastName = (string)jsonConstants.SelectToken("owners[0].LastName");
            string Address = (string)jsonConstants.SelectToken("owners[0].Address");
            string City = (string)jsonConstants.SelectToken("owners[0].City");
            string Telephone = (string)jsonConstants.SelectToken("owners[0].Telephone");
            string FullName = String.Concat(FirstName + " ", LastName);
            
            newOwnerPage.FieldOwnerFirstName.SendKeys(FirstName);
            newOwnerPage.FieldOwnerLastName.SendKeys(LastName);
            newOwnerPage.FieldOwnerAddress.SendKeys(Address);
            newOwnerPage.FieldOwnerCity.SendKeys(City);
            newOwnerPage.FieldOwnerTelephone.SendKeys(Telephone);
            newOwnerPage.BtnAddOwner.Click();
            
            var ownerProfilePage = new OwnerProfilePage(driver);

            // Проверяем, что в полях профиля находится соответствующая, введенная ранее информация
            Assert.AreEqual(FullName, ownerProfilePage.FieldOwnerProfileName.Text, "The Name is not consistent with the entered data");
            Assert.AreEqual(Address, ownerProfilePage.FieldOwnerProfileAddress.Text, "The Address is not consistent with the entered data");
            Assert.AreEqual(City, ownerProfilePage.FieldOwnerProfileCity.Text, "The City is not consistent with the entered data");
            Assert.AreEqual(Telephone, ownerProfilePage.FieldOwnerProfileTelephone.Text, "The Telephone is not consistent with the entered data");

            // Проверяем, что в таблице домашних животных и посещений ветеринара у указанного владельца нет записей
            Assert.AreEqual(0, ownerProfilePage.TableOwnerProfilePetRows.Count, "The 'Pets and Visits Table' has some data");

            // Переходим на страницу поиска владельцев домшаних животных
            ownerProfilePage.UrlFindOwners.Click();
            findOwnersPage.BtnFindOwner.Click();

            // Проверяем, что запись о новом владельце появилась
            Assert.AreEqual(11, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1, "The count of rows is not equal to 11");

            // Проверяем, что в таблице владельцев содержатся данные о новом владельце
            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(FullName), "The 'Find Owners Page' does not contain the Name data");
            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(Address), "The 'Find Owners Page' does not contain the Address data");
            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(City), "The 'Find Owners Page' does not contain the City data");
            Assert.IsTrue(resultOfSearchOwnerPage.PageSource.Contains(Telephone), "The 'Find Owners Page' does not contain the Telephone data");

            // Переходим в профиль выбранного владельца домашних животных
            resultOfSearchOwnerPage.SelectProfileByName(FullName).Click();
            
            // Переходим в форму добавления записи о домашнем животном
            ownerProfilePage.BtnAddNewPet.Click();

            // Возвращаемся назад
            driver.Navigate().Back();

            // Добавляем информацию о домашнем животном
            ownerProfilePage.BtnAddNewPet.Click();

            var newPetPage = new NewPetPage(driver);

            // Проверяем, что создание записи о питомце идет именно для указанного владельца
            Assert.AreEqual(FullName, newPetPage.FieldPetOwner.Text);
            
            string PetName = (string)jsonConstants.SelectToken("owners[0].pets[0].PetName");
            string PetBirthDate = (string)jsonConstants.SelectToken("owners[0].pets[0].PetBirthDate");
            
            // Заполняем профиль домашнего животного
            newPetPage.FieldPetName.SendKeys(PetName);
            newPetPage.FieldPetBirthDate.SendKeys(PetBirthDate);
            newPetPage.SelectPetType(1).Click();
            string PetType = newPetPage.SelectPetType(1).Text;

            // Подтверждаем добавление записи о новом питомце
            newPetPage.BtnAddPet.Click();

            // Проверяем, что запись о питомце добавилась в профиль владельца
            Assert.Greater(ownerProfilePage.TableOwnerProfilePetRows.Count, 0, "The data was not added to 'Pets and Visists Table'");

            // Проверяем информацию о питомце в таблице питомцев и посещений ветеринара
            Assert.IsNotNull(ownerProfilePage.FindPetDataInTable(PetName, PetBirthDate, PetType), "The pet's data is not consistent with 'Pets and Visits Table's data");

            // Переходим к редактированию профиля питомца
            ownerProfilePage.LnkEditPet(PetName).Click();

            var editPetPage = new EditPetPage(driver);

            // Меняем тип питомца
            editPetPage.SelectPetType(2).Click();
            PetType = editPetPage.SelectPetType(2).Text;

            // Подвтерждаем изменения
            editPetPage.BtnEditPet.Click();
            
            // Проверяем, что тип домашнего питомца был изменен
            Assert.AreEqual(PetType, ownerProfilePage.GetTypeOfPet(PetName).Text, "The type of the pet was not changed");
            
            ownerProfilePage.LnkAddVisit(PetName).Click();

            // Добавляем запись о посещении ветеринара
            var newVisitPage = new NewVisitPage(driver);

            string Description = (string)jsonConstants.SelectToken("owners[0].pets[0].visits[0].DescriptionOfVisit");

            // Указываем причину посещения ветеринара
            newVisitPage.FieldVisitDescription.SendKeys(Description);

            // Подтверждаем добавление записи о посещении ветеринара
            newVisitPage.BtnAddVisit.Click();

            // Проверяем, что запись о посещении ветеринара добавилась в таблицу питомцев и посещений
            Assert.IsNotNull(ownerProfilePage.FindDescriptionOfVisitInTable(PetName, Description), "The description was not added to 'Pets and Visits Table'");
            
        }

        [TearDown]
        public void CleanUp()
        {
            Browsers.Close();
        }
        



    }
}
