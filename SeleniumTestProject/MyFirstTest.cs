using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using SeleniumTestProject.Pages;
using SeleniumTestProject.Base;
using SeleniumTestProject.Helpers;
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

            // Открываем окно браузера и переходим на главную страницу проекта Spring - Petclinic

            var homePage = new HomePage();

            // Получаем заголовок h2 с главной страницы
            IWebElement webElementHomePageH2 = homePage.GetHomePageH2;

            // Проверяем, что страница открылась (сравниваем заголовки h2)
            Assert.AreEqual("Welcome", webElementHomePageH2.Text, "The 'Home Page' is not opened");
            // Проверяем, что мы находимся на главной странице
            Assert.AreEqual(ConfigurationManager.AppSettings["URL"], Browsers.Url, "The page is not 'Home Page'");

            homePage.UrlFindOwners.Click();
                        
            // Переходим на страницу поиска владельцев домашних животных
            var findOwnersPage = new FindOwnersPage();

            // Получаем список всех владельцев домашних животных
            var resultOfSearchOwnerPage = findOwnersPage.ClickFindOwnerButton();
            
            // Проверяем, что список владельцев появился
            Assert.IsTrue(resultOfSearchOwnerPage.TableFindOwnerResult.Displayed, "The 'Find Owners Page' is not displayed");
            
            // Проверяем, что в нем содержится 10 записей
            
            Assert.AreEqual(10, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1, "The count of rows is not equal to 10");
            /*
            findOwnersPage.UrlFindOwners.Click();
            findOwnersPage.BtnAddNewOwner.Click();
            
            // Создаем профиль нового владельца домашних животных, заполняем поля формы для создания профиля
            var newOwnerPage = new NewOwnerPage();

            // Загружаем данные для создания нового пользователя из json'а
            Owner owner = Data.GetOwner();
            
            string FirstName = owner.FirstName;
            string LastName = owner.LastName;
            string Address = owner.Address;
            string City = owner.City;
            string Telephone = owner.Telephone;
            string FullName = String.Concat(FirstName + " ", LastName);
            
            newOwnerPage.FieldOwnerFirstName.SendKeys(FirstName);
            newOwnerPage.FieldOwnerLastName.SendKeys(LastName);
            newOwnerPage.FieldOwnerAddress.SendKeys(Address);
            newOwnerPage.FieldOwnerCity.SendKeys(City);
            newOwnerPage.FieldOwnerTelephone.SendKeys(Telephone);
            newOwnerPage.BtnAddOwner.Click();
            
            var ownerProfilePage = new OwnerProfilePage();

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
            Assert.AreEqual(11, findOwnersPage.TableFindOwnerResultRows().Count - 1, "The count of rows is not equal to 11");
            //Assert.AreEqual(11, resultOfSearchOwnerPage.TableFindOwnerResultRows.Count - 1, "The count of rows is not equal to 11");

            // Проверяем, что в таблице владельцев содержатся данные о новом владельце
            Assert.IsTrue(findOwnersPage.PageSource.Contains(FullName), "The 'Find Owners Page' does not contain the Name data");
            Assert.IsTrue(findOwnersPage.PageSource.Contains(Address), "The 'Find Owners Page' does not contain the Address data");
            Assert.IsTrue(findOwnersPage.PageSource.Contains(City), "The 'Find Owners Page' does not contain the City data");
            Assert.IsTrue(findOwnersPage.PageSource.Contains(Telephone), "The 'Find Owners Page' does not contain the Telephone data");

            // Переходим в профиль выбранного владельца домашних животных
            findOwnersPage.SelectProfileByName(FullName).Click();
            
            // Переходим в форму добавления записи о домашнем животном
            ownerProfilePage.BtnAddNewPet.Click();

            // Возвращаемся назад
            Browsers.GoBack();

            // Добавляем информацию о домашнем животном
            ownerProfilePage.BtnAddNewPet.Click();

            var newPetPage = new NewPetPage();

            // Проверяем, что создание записи о питомце идет именно для указанного владельца
            Assert.AreEqual(FullName, newPetPage.FieldPetOwner.Text);

            string PetName = owner.Pets[0].PetName;
            string PetBirthDate = owner.Pets[0].PetBirthDate;
            
            // Заполняем профиль домашнего животного
            newPetPage.FieldPetName.SendKeys(PetName);
            newPetPage.FieldPetBirthDate.SendKeys(PetBirthDate);
            Random intPetType = new Random();
            int petTypeNumber = intPetType.Next(0, 5);
            newPetPage.SelectPetType(petTypeNumber).Click();
            string PetType = newPetPage.SelectPetType(petTypeNumber).Text;

            // Подтверждаем добавление записи о новом питомце
            newPetPage.BtnAddPet.Click();

            // Проверяем, что запись о питомце добавилась в профиль владельца
            Assert.Greater(ownerProfilePage.TableOwnerProfilePetRows.Count, 0, "The data was not added to 'Pets and Visists Table'");

            // Проверяем информацию о питомце в таблице питомцев и посещений ветеринара
            Assert.IsNotNull(ownerProfilePage.FindPetDataInTable(PetName, PetBirthDate, PetType), "The pet's data is not consistent with 'Pets and Visits Table's data");

            // Переходим к редактированию профиля питомца
            ownerProfilePage.LnkEditPet(PetName).Click();

            var editPetPage = new EditPetPage();

            // Меняем тип питомца
            petTypeNumber = intPetType.Next(0, 5);
            editPetPage.SelectPetType(petTypeNumber).Click();
            PetType = editPetPage.SelectPetType(petTypeNumber).Text;

            // Подвтерждаем изменения
            editPetPage.BtnEditPet.Click();
            
            // Проверяем, что тип домашнего питомца был изменен
            Assert.AreEqual(PetType, ownerProfilePage.GetTypeOfPet(PetName).Text, "The type of the pet was not changed");
            
            ownerProfilePage.LnkAddVisit(PetName).Click();

            // Добавляем запись о посещении ветеринара
            var newVisitPage = new NewVisitPage();

            string Description = owner.Pets[0].Visits[0].DescriptionOfVisit;

            // Указываем причину посещения ветеринара
            newVisitPage.FieldVisitDescription.SendKeys(Description);

            // Подтверждаем добавление записи о посещении ветеринара
            newVisitPage.BtnAddVisit.Click();

            // Проверяем, что запись о посещении ветеринара добавилась в таблицу питомцев и посещений
            Assert.IsNotNull(ownerProfilePage.FindDescriptionOfVisitInTable(PetName, Description), "The description was not added to 'Pets and Visits Table'");
              */          
        }

        [TearDown]
        public void CleanUp()
        {
            Browsers.Close();
        }
        



    }
}
