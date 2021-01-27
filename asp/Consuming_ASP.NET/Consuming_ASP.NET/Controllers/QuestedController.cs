﻿using Consuming_ASP.NET.Models;
using Consuming_ASP.NET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ActionResult = System.Web.Mvc.ActionResult;

namespace Consuming_ASP.NET.Controllers
{
    public class QuestedController : Controller
    {
        private string ip = "http://192.168.72.2:8080";
        // GET: Quested
        private readonly Service _questionsService;
        [System.Web.Mvc.Route("api/questions")]

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<Questions> quested = new List<Questions>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(ip);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("?age=25");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    quested = JsonConvert.DeserializeObject<List<Questions>>(EmpResponse);

                }
                return View(quested);
            }
        }

        // GET: Quested/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
            //var credential = MongoCredential.
        }
        public ActionResult Question()
        {
            return View();
        }


        public ActionResult Login(System.Web.Mvc.FormCollection collection)
        {
            try
            {
                String username = collection["username"];
                String password = collection["password"];
            }
            catch { }
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Score(List<HighScore> score)
        {
            //List<Score> quested = new List<Score>();
            score = new List<HighScore>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(ip);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/scores/top");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //quested = JsonConvert.DeserializeObject<List<Score>>(EmpResponse);
                    score = JsonConvert.DeserializeObject<List<HighScore>>(EmpResponse);

                }
                return View(score);
            }
        }
        // POST: Quested/Create
        /*[Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult<Questions>> Create([FromBody] Questions s)
        {
            try
            {
                // TODO: Add insert logic here

                await _questionsService.Create(s);
                return Microsoft.AspNetCore.Mvc.CreatedAtRoute("Get", new { id = s.question_id.ToString() }, s);

            }
            catch
            {
                return View();
            }
        }*/

        /*public ActionResult Score()
        {
            return View();
        }*/

        // GET: Quested/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quested/Edit/5
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Edit(int id, System.Web.Mvc.FormCollection collection)
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

        // GET: Quested/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Quested/Delete/5
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Delete(int id, System.Web.Mvc.FormCollection collection)
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
