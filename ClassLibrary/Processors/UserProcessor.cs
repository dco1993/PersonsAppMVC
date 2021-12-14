using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ClassLibrary.Models;

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

    }
}
