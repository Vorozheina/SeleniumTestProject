using System.Collections.Generic;
using NUnit.Framework;
using System.Configuration;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace RestAPITestProject
{
    public class RestAPITests
    {
        public RestClient restClient; 
        public RestRequest restRequest;
        public IRestResponse restResponse;

        [SetUp]
        public void SetUp()
        {
            restClient = new RestClient(ConfigurationManager.AppSettings["URL"]);
            restRequest = new RestRequest(Method.GET);
            restResponse = restClient.Execute(restRequest);

        }

        [Test]
        public void VerifyHttpStatusCode()
        {
            // Проверить, что возвращается код ответа 200 (успех) = OK
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        }

        [Test]
        public void VerifyHttpResponseHeader()
        {
            // Проверить, что заголовок полученного ответа content-type не пустой и выглядит как "application/json; charset=utf-8"
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(restResponse.ContentType, "The 'content-type' part of the header is empty.");
                Assert.AreEqual("application/json; charset=utf-8", restResponse.ContentType, "The 'content-type' part of the header has another description.");
            });
        }

        [Test]
        public void VerifyHttpResponseBody()
        {
            // Проверить, что на странице находятся данные о 10 пользователях
            IList<User> userList = JsonConvert.DeserializeObject<List<User>>(restResponse.Content);
            Assert.AreEqual(10, userList.Count, "The count of users is not equal to 10.");
        }


        [TearDown]
        public void CleanUp()
        {
            
        }
    }
}
