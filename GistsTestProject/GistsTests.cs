using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GistsTestProject
{
    public class GistsTests
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string Login;
        public string Password;
        public string RequestBody;

        [SetUp]
        public void SetUp()
        {
            byte[] bytesJsonAuth = GistsTestProject.Properties.Resources.LoginPassword;
            string stringJsonAuth = Encoding.UTF8.GetString(bytesJsonAuth);
            JObject jsonAuth = JObject.Parse(stringJsonAuth);
            Login = (string)jsonAuth.SelectToken("Login");
            Password = (string)jsonAuth.SelectToken("Password");
        }

        [Test]
        public void VerifyHttpStatusCode()
        {
            // Проверить, что возвращается код ответа 200 (успех)
            restClient = new RestClient(ConfigurationManager.AppSettings["URL"]);
            restRequest = new RestRequest(Method.GET);
            restClient.Authenticator = new HttpBasicAuthenticator(Login, Password);
            IRestResponse restResponse = restClient.Execute(restRequest);
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        }

        [Test]
        public void VerifyHttpResponseHeader()
        {
            // Проверить, что заголовок полученного ответа content-type не пустой и выглядит как "application/json; charset=utf-8"
            restRequest = new RestRequest(Method.GET);
            restClient = new RestClient(ConfigurationManager.AppSettings["URL"]);
            restRequest = new RestRequest(Method.GET);
            restClient.Authenticator = new HttpBasicAuthenticator(Login, Password);
            IRestResponse restResponse = restClient.Execute(restRequest);
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
            restRequest = new RestRequest(Method.GET);
            restClient = new RestClient(ConfigurationManager.AppSettings["URL"]);
            restRequest = new RestRequest(Method.GET);
            restClient.Authenticator = new HttpBasicAuthenticator(Login, Password);
            IRestResponse restResponse = restClient.Execute(restRequest);
            IList<User> userList = JsonConvert.DeserializeObject<List<User>>(restResponse.Content);
            Assert.AreEqual(10, userList.Count);
        }

        [TearDown]
        public void CleanUp()
        {
            
        }
    }
}
