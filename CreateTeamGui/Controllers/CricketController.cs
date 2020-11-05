using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Model;
using TeamAPI.Controllers;

namespace CreateTeamGui.Controllers
{
    public class CricketController : Controller
    {
        
        // GET: Cricket
        public ActionResult CoachIndex()
        {
            IEnumerable<TeamMembers> team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56453/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TeamMembers/GetAllMembers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IList<TeamMembers>>();
                    readTask.Wait();

                    team = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                   team= Enumerable.Empty<TeamMembers>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(team);
           
        }
        [HttpGet]
        public ActionResult CoachEdit()
        {
            IEnumerable<TeamMembers> team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56453/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TeamMembers/GetAllMembers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TeamMembers>>();
                    readTask.Wait();

                    team = readTask.Result;
                }
            }
            return View(team);
        }

        [HttpPost]
        public ActionResult CoachEdit(List<TeamMembers> team)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:56453/api/");

                    //HTTP POST

                    var putTask = client.PutAsJsonAsync<List<TeamMembers>>("TeamMembers/UpdateCoachList", team);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("CoachIndex");
                    }
                    else
                    {
                        ViewBag.error = new Exception(result.ReasonPhrase);
                    }
                }
                return View(team);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

       
       
        public ActionResult CaptainIndex()
        {
            IEnumerable<TeamMembers> team = null;
        
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56453/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TeamMembers/GetIsSelectedDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IList<TeamMembers>>();
                    readTask.Wait();

                    team = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    team = Enumerable.Empty<TeamMembers>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(team);

        }
        [HttpGet]
        public ActionResult CaptainEdit()
        {
            IEnumerable<TeamMembers> team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56453/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TeamMembers/GetIsSelectedDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TeamMembers>>();
                    readTask.Wait();

                    team = readTask.Result;
                }
            }
            return View(team);
        }

        [HttpPost]
        public ActionResult CaptainEdit(List<TeamMembers> team)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:56453/api/");

                    //HTTP POST

                    var putTask = client.PutAsJsonAsync<List<TeamMembers>>("TeamMembers/UpdateCaptainList", team);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("CaptainIndex");
                    }
                    else
                    {
                        ViewBag.error = new Exception(result.ReasonPhrase);
                    }
                }
                return View(team);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        public ActionResult IsPlaying()
        {
            IEnumerable<TeamMembers> team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56453/api/");
                //HTTP GET
                var responseTask = client.GetAsync("TeamMembers/GetIsPlayingDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IList<TeamMembers>>();
                    readTask.Wait();

                    team = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    team = Enumerable.Empty<TeamMembers>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(team);

        }
    }
}