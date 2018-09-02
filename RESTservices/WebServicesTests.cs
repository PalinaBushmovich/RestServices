using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using TestWebProject.REST.REST_dto;
using TestWebProject.REST;
using RESTservices.Utilities;
using RESTservices.RESTdto;

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
        public void VerifyResultCountHeader()
        {
            string headerName = "Count";
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
            string userPostRequestJson = JsonSerialization.SerializeToJson(userPostRequest);
            string userId = HTTPrequests.GetResponseHeader(HTTPrequests.ExecutePostRequest(_url, userPostRequestJson), "id");
            string body = HTTPrequests.GetResponseBody(HTTPrequests.ExecuteGetRequest(_url + '/' + userId));          
            UserGetDTO userGetResponse = JsonSerialization.DeserializeFromJson<UserGetDTO>(body);
            Assert.IsTrue(RestComparator.CompareUserDTOs(userPostRequest, userGetResponse));
        }
    }
}
