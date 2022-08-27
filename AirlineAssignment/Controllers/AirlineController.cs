using AirlineAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AirlineAssignment.Controllers
{

    public class AirlineController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7190/api");
        HttpClient client;


        List<ManageAirline> ManageAirlines = new List<ManageAirline>();
        public AirlineController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }


        [Authorize(Policy = "readonlypolicy")]
        public IActionResult Index()
        {
            List<ManageAirline> ManageAirlines = new List<ManageAirline>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Airline").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ManageAirlines = JsonConvert.DeserializeObject<List<ManageAirline>> (data);
            }
            return View(ManageAirlines);
        }


        [Authorize(Policy = "writepolicy")]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateOrUpdate(ManageAirline manageAirline)
        {
            string data = JsonConvert.SerializeObject(manageAirline);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            if (manageAirline.Id == 0)
            {
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Airline", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Create", manageAirline);
            }
            else
            {
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + $"/Airline?Id={manageAirline.Id}", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Create", manageAirline);
            }
        }

        [Authorize(Policy = "writepolicy")]
        public ActionResult Delete(int Id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"/Airline?Id={Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest("Something went Wrong");
        }
        [Authorize(Policy = "writepolicy")]
        public ActionResult Edit(ManageAirline manageAirline)
        {
            return View("Create", manageAirline);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }


        public ActionResult Search(string searchString)
        {
            List<ManageAirline> books = new List<ManageAirline>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Airline/" + searchString).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ManageAirlines = JsonConvert.DeserializeObject<List<ManageAirline>>(data);
            }
            return View("Index", ManageAirlines);
        }

    }
}
