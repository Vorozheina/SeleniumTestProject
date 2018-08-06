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
using GistsFromMyProfileTestProject.Base;
using GistsFromMyProfileTestProject.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GistsFromMyProfileTestProject
{
    public class GistsFromMyProfileTests
    {

        public RestClient restClient;
        public RestRequest restRequest;
        public IRestResponse restResponse;
        public string RequestBody;
        
        [SetUp]
        // Создаем гист для дальнейших проверок
        public void SetUp()
        {
            restClient = new RestClient(ConfigurationManager.AppSettings["URL"]);
            restClient.Authenticator = new HttpBasicAuthenticator(Data.GetAuthentification().Login, Data.GetAuthentification().Password);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("content-type", "application/json;  charset=utf-8");
            RequestBody = JsonConvert.SerializeObject(Data.GetRequest(Properties.Resources.Request));
            restRequest.AddParameter("application/json", RequestBody, ParameterType.RequestBody);
            restResponse = restClient.Execute(restRequest);

        }

        [Test]
        // Проверяем, удалось ли создать гист; ответ 201 (Created)
        public void Gist_Post()
        {
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode, "The gist is not created");            
        }

        [Test]
        // Редактируем гист и проверяем, что его удалось отредактировать; ответ 200 (OK)
        public void Gist_Patch()
        {
            Response response = new Response();            
            response = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            string gist_id = response.Id;
                        
            restClient = new RestClient(ConfigurationManager.AppSettings["URL"] + "/" + gist_id);
            restClient.Authenticator = new HttpBasicAuthenticator(Data.GetAuthentification().Login, Data.GetAuthentification().Password);
            restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("content-type", "application/json;  charset=utf-8");
            RequestBody = JsonConvert.SerializeObject(Data.GetRequest(Properties.Resources.PatchedRequest));
            restRequest.AddParameter("application/json", RequestBody, ParameterType.RequestBody);
            restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode, "The gist is not edited");            
        }

        [Test]
        // Отмечаем гист "избранным" и проверяем, что это удалось; ответ 204 (No Content)
        public void Gist_Put()
        {
            Response response = new Response();
            response = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            string gist_id = response.Id;

            restClient = new RestClient(ConfigurationManager.AppSettings["URL"] + "/" + gist_id + "/star");
            restClient.Authenticator = new HttpBasicAuthenticator(Data.GetAuthentification().Login, Data.GetAuthentification().Password);
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("content-length", "0");
            restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.NoContent, restResponse.StatusCode, "The gist is not starred");
        }

        [Test]
        // Удаляем гист и проверяем, что это удалось; ответ 204 (No Content)
        public void Gist_Delete()
        {
            Response response = new Response();
            response = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            string gist_id = response.Id;

            restClient = new RestClient(ConfigurationManager.AppSettings["URL"] + "/" + gist_id);
            restClient.Authenticator = new HttpBasicAuthenticator(Data.GetAuthentification().Login, Data.GetAuthentification().Password);
            restRequest = new RestRequest(Method.DELETE);
            restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.NoContent, restResponse.StatusCode, "The gist is not deleted");
        }

        [TearDown]
        public void TearDown()
        {}
    }
}
