using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ClassLibrary.Models;
using System.Net.Http.Json;
using System.Net.Http;

namespace ClassLibrary.Processors {
    public static class UserProcessor {

        static string url = "https://personsapi.azurewebsites.net/api/users/";

        public static async Task<List<UserModel>> GetAllUsers() { 
        
            List<UserModel> users = new List<UserModel>();

            using (var cliente = ApiCaller.ApiClient) {

                var getRequest = await cliente.GetAsync(url);

                if (getRequest.IsSuccessStatusCode) {

                    var result = await getRequest.Content.ReadAsStringAsync();

                    users = JsonConvert.DeserializeObject<List<UserModel>>(result);

                    return users;

                } else {

                    throw new Exception(getRequest.ReasonPhrase);

                }

            }

        }

        public static async Task<UserModel> GetUserById(int id) { 
        
            UserModel user = new UserModel();

            using (var cliente = ApiCaller.ApiClient) {

                var getUser = await cliente.GetAsync(url + id);

                if (getUser.IsSuccessStatusCode) {

                    var result = await getUser.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<UserModel>(result);

                    return user;

                } else {

                    throw new Exception(getUser.ReasonPhrase);

                }

            }
        
        }

        public static async Task<UserModel> CreateUser(UserModel user) {

            using (var cliente = ApiCaller.ApiClient)
            {
                var data = JsonConvert.SerializeObject(new
                {
                    user.UsrNome,
                    user.UsrSbnome,
                    user.UsrNasci,
                    user.UsrEmail,
                    user.UsrBio
                });

                StringContent dataPost = new StringContent(data, Encoding.UTF8, "application/json");

                var postUser = await cliente.PostAsync(url, dataPost);

                if (postUser.IsSuccessStatusCode)
                {
                    return user;
                } else
                {
                    throw new Exception(postUser.ReasonPhrase);
                }
            }
        }

        public static async Task<UserModel> UpdateUser(UserModel user)
        {
            using (var cliente = ApiCaller.ApiClient)
            {
                var data = JsonConvert.SerializeObject(new {
                    user.UsrId,
                    user.UsrNome,
                    user.UsrSbnome,
                    user.UsrNasci,
                    user.UsrEmail,
                    user.UsrBio
                });

                StringContent putData = new StringContent(data, Encoding.UTF8, "application/json");

                var putUser = await cliente.PutAsync(url, putData);

                if (putUser.IsSuccessStatusCode)
                {
                    return user;

                } else {
                    throw new Exception(putUser.ReasonPhrase);
                }
            }
        }

        public static async Task<string> DeleteUser(int id)
        {
            using (var cliente = ApiCaller.ApiClient)
            {
                var deleteUser = await cliente.DeleteAsync(url+id);

                if (deleteUser.IsSuccessStatusCode)
                {
                    return deleteUser.StatusCode.ToString();

                } else
                {
                    throw new Exception(deleteUser.ReasonPhrase);
                }
            }
        }

    }
}
