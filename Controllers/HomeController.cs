using Microsoft.AspNetCore.Mvc;
using Moment2___MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moment2___MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var JsonStr = System.IO.File.ReadAllText("players.json");
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<PlayerModel>>(JsonStr);
            return View(JsonObj);
        }

        [HttpGet("/Info")]
        public IActionResult About()
        {
            // Get session variable
            string output = HttpContext.Session.GetString("username");
            // Check if variable is given
            if (output != null)
            {
                ViewBag.nameoutput = "Hej, " + output + "! ";
            }
            else
            {
                ViewBag.nameoutput = "Hejsan okänd... ";
            }

            return View();
        }

        [HttpGet("/Spelare")]
        public IActionResult Players([FromQuery]string username)
        {
            if(username != null)
            { 
            HttpContext.Session.SetString("username", username); // Add name to session variable
            ViewBag.input = username;
            }
            return View(new PlayerModel());
        }

        [HttpPost("/Spelare")]
        public IActionResult Players(PlayerModel model)
        {
            
            if (ModelState.IsValid)
            {
                // Read existing file
                var JsonStr = System.IO.File.ReadAllText("players.json");
                var JsonObj = JsonConvert.DeserializeObject<List<PlayerModel>>(JsonStr);
                JsonObj.Add(model);
                // Convert to JSON
                // Store
                System.IO.File.WriteAllText("players.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                ModelState.Clear();
            }
            return View(new PlayerModel());
        }
    }
}
