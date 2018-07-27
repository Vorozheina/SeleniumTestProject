using System.Collections.Generic;
using NUnit.Framework;
using System.Configuration;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace GistsTestProject
{
    public class GistsTests
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
            // Проверить, что возвращается код ответа 200 (успех)
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        }

        [Test]
        public void VerifyHttpResponseHeader()
        {
            // Проверить, что заголовок полученного ответа content-type не пустой и выглядит как "application/json; charset=utf-8"
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(restResponse.ContentType);
                Assert.AreEqual("application/json; charset=utf-8", restResponse.ContentType);
            });
        }

        [Test]
        public void VerifyHttpResponseBody()
        {
            // Проверить, что на странице находятся данные о 10 пользователях
            IList<User> userList = JsonConvert.DeserializeObject<List<User>>(restResponse.Content);
            Assert.AreEqual(10, userList.Count);
        }


        [TearDown]
        public void CleanUp()
        {
            
        }
    }
}
