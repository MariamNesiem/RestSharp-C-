using Newtonsoft.Json;
using RestSharp;
using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Demo
    {
        private readonly Helper helper;
        public Demo()
        {
            helper = new Helper();
        }
        public UsersRes GetUsers(string baseUrl)
        {
            helper.SetUrl(baseUrl);
            var request = helper.CreateGetRequest("api/users?page=2");
            var reponse = helper.GetResponse(request);
            UsersRes users = HandleContent.GetContent<UsersRes>(reponse);

            return users;
        }
        public AddUserRes AddUsers(string baseUrl, dynamic payload)
        {

            helper.SetUrl(baseUrl);
            var payloadString = HandleContent.SetContent(payload);
            var request = helper.CreatePostRequest("api/users", payloadString);
            var reponse = helper.GetResponse(request);
            AddUserRes newUser = HandleContent.GetContent<AddUserRes>(reponse);

            return newUser;
        }

        public UpdateUserRes UpdateUser(string baseUrl, dynamic payload,string userID)
        {

            helper.SetUrl(baseUrl);
            var payloadString = HandleContent.SetContent(payload);
            var request = helper.CreatePutRequest("api/users/"+userID, payloadString);
            var reponse = helper.GetResponse(request);
            UpdateUserRes updatedUser = HandleContent.GetContent<UpdateUserRes>(reponse);

            return updatedUser;
        }

        public HttpStatusCode DeleteUser(string baseUrl, string userID)
        {
            helper.SetUrl(baseUrl);
            var request = helper.CreateDeleteRequest("api/users/" + userID);
            var response = helper.GetResponse(request);
           // UpdateUserRes updatedUser = HandleContent.GetContent<UpdateUserRes>(response);

            return response.StatusCode;
        }
    }
}
