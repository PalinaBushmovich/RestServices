﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TestWebProject.REST
{
    public static class HTTPrequests
    {

        private static Dictionary<string, string> headers = new Dictionary<string, string> { { "Authorization", "Basic Y2xlcmtmdWxsOlRob21zb24hMA==" } };

        public static HttpWebRequest ExecuteGetRequest(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            return request;
        }

        public static string GetResponseBody(HttpWebRequest executeRequest)
        {
            string bodyResponse;
            using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
            {
                using (StreamReader myStreamReader = new StreamReader(response.GetResponseStream()))
                {
                    bodyResponse = myStreamReader.ReadToEnd();
                }
                return bodyResponse;
            }
        }

        public static string GetResponseHeader(HttpWebRequest executeRequest, string headerName)
        {
            using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
            {
                return response.Headers.Get(headerName);
            }
        }

        public static HttpStatusCode GetResponseStatusCode(HttpWebRequest executeRequest)
        {
            using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
            {
                return response.StatusCode;
            }
        }

        public static HttpWebRequest ExecutePostRequest(string Url, string json)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json";
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            return request;
        }

        public static int GetUserId(string location)
        {
           string[] elementsList = location.Split('/');

            int numberOfTheLastElement = elementsList.Length - 1;

            int id = Convert.ToInt32(elementsList[numberOfTheLastElement]);
            return id;
        }

    }
}
