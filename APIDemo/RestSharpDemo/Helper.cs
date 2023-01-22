using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;

        public RestClient SetUrl(string baseUrl)
        {
            this.client = new RestClient(baseUrl);
            return this.client;
        }

        public RestRequest CreateGetRequest(string endpoint)
        {
            request = new RestRequest(endpoint,Method.Get);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public RestRequest CreatePostRequest(string endpoint, string payload)
        {
            request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json",payload,ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreatePutRequest(string endpoint, string payload)
        {
            request = new RestRequest(endpoint, Method.Put);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreateDeleteRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.Put);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public RestResponse GetResponse(RestRequest restRequest)
        {
            restRequest.RequestFormat = DataFormat.Json;
            return this.client.Execute(restRequest);
        }
    }
}
