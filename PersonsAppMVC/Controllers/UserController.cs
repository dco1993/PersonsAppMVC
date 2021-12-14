﻿using Microsoft.AspNetCore.Http;
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

        string url = "https://personsapi.azurewebsites.net/api/users/";

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
        public async Task<IActionResult> AddUser(PersonsModel user) {

            PersonsModel postedUser = new PersonsModel();

            using ( var httpClient = new HttpClient()) {
                
                StringContent stringPost = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using ( var result = await httpClient.PostAsync(url, stringPost)) {

                    return View();

                }
            }

        }

        public async Task<IActionResult> UserUpdate(int id) {

            UserModel user = new UserModel();

            using (var httpClient = new HttpClient()) {
                using (var result = await httpClient.GetAsync(url + id)) {
                    string response = await result.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserModel>(response);
                }
            }

            return View(user);

        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserModel putUser) {

            using (var httpClient = new HttpClient()) {

                var content = new MultipartFormDataContent();
                content.Add(new StringContent(putUser.UsrId.ToString()), "UsrId");
                content.Add(new StringContent(putUser.UsrNome), "UsrNome");
                content.Add(new StringContent(putUser.UsrSbnome), "UsrSbnome");
                content.Add(new StringContent(putUser.UsrNasci.ToString()), "UsrNasci");
                content.Add(new StringContent(putUser.UsrEmail), "UsrEmail");
                content.Add(new StringContent(putUser.UsrBio), "UsrBio");

                var put = JsonConvert.SerializeObject(content);

                using (var result = await httpClient.PutAsJsonAsync(url, content)) {
                    string apiResponse = await result.Content.ReadAsStringAsync();
                    ViewBag.Result = "Sucesso!";
                    
                    return View();

                }
            }

        }

        // GET: UserController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: UserController/Create
        //public ActionResult Create() {
        //    return View();
        //}

        // POST: UserController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection) {
        //    try {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch {
        //        return View();
        //    }
        //}

        // GET: UserController/Edit/5
        //public ActionResult Edit(int id) {
        //    return View();
        //}

        // POST: UserController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection) {
        //    try {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch {
        //        return View();
        //    }
        //}

        // GET: UserController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: UserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection) {
        //    try {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch {
        //        return View();
        //    }
        //}
    }
}
