using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonsAppMVC.Models;


namespace PersonsAppMVC.Controllers {
    public class UserController : Controller {

        string url = "https://personsapi.azurewebsites.net/api/users";

        // GET: UserController
        public async Task<IActionResult> UsersList() {

            List<PersonsModel> persons = new List<PersonsModel>();

            using (var httpClient = new HttpClient()) {
                using (var result = await httpClient.GetAsync(url)) {
                    string response = await result.Content.ReadAsStringAsync();
                    persons = JsonConvert.DeserializeObject<List<PersonsModel>>(response);
                }
            }
            return View(persons);
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
