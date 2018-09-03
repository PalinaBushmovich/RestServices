using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using TestWebProject.REST.REST_dto;
using TestWebProject.REST;
using RESTservices.Utilities;
using RESTservices.RESTdto;
using Newtonsoft.Json;

namespace RESTservices
{
    [TestClass]
    public class WebServicesTests
    {
        private string _url = "https://jsonplaceholder.typicode.com/users";

        [TestMethod]
        public void VerifyResponceStatusCode()
        {
            HttpStatusCode responceCode = HTTPrequests.GetResponseStatusCode(HTTPrequests.ExecuteGetRequest(_url));
            Assert.AreEqual(Convert.ToString(responceCode), "OK");
        }

        [TestMethod]
        public void VerifyResultContentTypeHeader()
        {
            string headerName = "Headers";
            string contentType = "Content-Type";
            string contentTypeValueExpected = "application/json; charset=utf-8";
            string headerValue = HTTPrequests.GetResponseHeader(HTTPrequests.ExecuteGetRequest(_url), headerName);
            string contentTypeValue = HTTPrequests.GetResponseHeader(HTTPrequests.ExecuteGetRequest(_url), contentType);
            Assert.AreEqual(contentTypeValue, contentTypeValueExpected);
        }

        [TestMethod]
        public void VerifyBodyOfGetRequest()
        {
            UserPostDTO userPostRequest = new UserPostDTO();
            string userPostRequestJson = JsonConvert.SerializeObject(userPostRequest);

            var response = HTTPrequests.ExecutePostRequest(_url, userPostRequestJson);

            string location = HTTPrequests.GetResponseHeader(HTTPrequests.ExecutePostRequest(_url, userPostRequestJson), "location");

            string body = HTTPrequests.GetResponseBody(HTTPrequests.ExecuteGetRequest(location));
           
            UserGetDTO userGetResponse = JsonConvert.DeserializeObject<UserGetDTO>(body);

            Assert.IsTrue(RestComparator.CompareUserDTOs(userPostRequest, userGetResponse));
        }
    }
}
