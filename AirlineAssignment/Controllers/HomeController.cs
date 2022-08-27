using AirlineAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace AirlineAssignment.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7190/api");
        HttpClient client;

        
        List<ManageAirline> ManageAirlines = new List<ManageAirline>();
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }


        public IActionResult Index()
        {
            List<ManageAirline> ManageAirlines = new List<ManageAirline>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Airline").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ManageAirlines = JsonConvert.DeserializeObject<List<ManageAirline>>(data);
            }
            return View(ManageAirlines);
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

