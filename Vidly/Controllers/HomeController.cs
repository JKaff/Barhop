using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RestSharp.Extensions;
using Vidly.Views.Shared;
using Yelp.Api.Models;
using System.Configuration;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            Client _client = new Client(ConfigurationManager.AppSettings["yelp_api_key"]);
            var res = await _client.GetBusinessAsync("chucks-fish-tuscaloosa");

            Debug.WriteLine(res);

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}