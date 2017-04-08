using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace bolVS17_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            var client = new HttpClient();

            var response = await client.GetAsync(MySettings.API_URL + "/api/values");

            var json = response.Content.ReadAsStringAsync();

            ViewData["Message"] = $"Called the WebAPI and got {json.Result} as a result";
            return View();

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
