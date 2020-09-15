using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientWebApp.Models;
namespace ClientWebApp.Controllers
{
    public class SchoolWebApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49479/");

            return client;
        }
    }
    public class SchoolController : Controller
    {

        SchoolWebApi api = new SchoolWebApi();

        [HttpGet]
        public ActionResult Index()
        {
            List<SchoolViewModel> schools = new List<SchoolViewModel>();
            using (var client = api.Initial())
            {

                //HTTP GET
                var responseTask = client.GetAsync("api/students");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<SchoolViewModel>>();
                    readTask.Wait();

                    schools = readTask.Result;



                }
                return View(schools);
            }
        }
       // var responseTask = client.GetAsync("member");
        // GET: School
        

        // GET: School/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: School/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: School/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: School/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: School/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
