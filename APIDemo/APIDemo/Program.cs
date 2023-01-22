using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //create host
            var client = new RestClient("https://reqres.in/");

            //create request
            var request = new RestRequest("api/users?page=2"); // endpoint
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            //send request and host
            RestResponse response = client.Execute(request,Method.Get);

            //display response
            var content = response.Content;
            Console.WriteLine(content);
            Console.ReadKey();

        }
    }
}
