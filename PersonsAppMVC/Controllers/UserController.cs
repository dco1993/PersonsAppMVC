using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonsAppMVC.Models;
using System.Text;
using System.Net.Http.Json;
using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.Processors;


namespace PersonsAppMVC.Controllers {
    public class UserController : Controller {

        [HttpGet]
        public async Task<IActionResult> UsersList() {

            ApiCaller.InitializeClient();

            List<UserModel> users = await UserProcessor.GetAllUsers();

            return View(users);

        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int id) {

            ApiCaller.InitializeClient();

            UserModel user = await UserProcessor.GetUserById(id);

            return View(user);

        }

        public ViewResult AddUser() => View();

        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel user) {

            ApiCaller.InitializeClient();

            var postRequest = await UserProcessor.CreateUser(user);

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UserUpdate(int id) {

            ApiCaller.InitializeClient();

            UserModel user = await UserProcessor.GetUserById(id);

            return View(user);

        }

        [HttpPut]
        public async Task<IActionResult> UserUpdate(UserModel putUser) {

            ApiCaller.InitializeClient();

            var putRequest = await UserProcessor.UpdateUser(putUser);

            return View(putRequest);

        }

        public ViewResult DeleteUser() => View();

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id) {

            ApiCaller.InitializeClient();

            string deleteRequest = await UserProcessor.DeleteUser(id);

            return View(deleteRequest);

        }

    }
}
