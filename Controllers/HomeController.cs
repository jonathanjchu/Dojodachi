using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;
using Dojodachi.Resources;


namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Dojodachi");
        }

        [HttpGet]
        [Route("dojodachi")]
        public IActionResult Dojodachi()
        {
            var domo = GetFromSession();
            SaveToViewBag(domo);

            if (domo.IsWin)
            {
                ViewBag.Message = "Congratulations, you win!";
                ViewBag.IsRestart = true;
            }
            else if (!domo.IsAlive)
            {
                ViewBag.Message = "Dojodachi is dead T_T";
                ViewBag.IsRestart = true;
            }
            else
            {
                ViewBag.Message = TempData["Message"];
            }

            return View();
        }


        [HttpGet]
        [Route("dojodachi/feed")]
        public IActionResult Feed()
        {
            var domo = GetFromSession();
            TempData["Message"] = domo.Eat();
            SaveDojodachiToSession(domo);
            // ViewBag.Message = HttpContext.Session.GetString("Domogachi");

            return RedirectToAction("Dojodachi");
        }

        [HttpGet]
        [Route("dojodachi/play")]
        public IActionResult Play()
        {
            var domo = GetFromSession();

            TempData["Message"] = domo.Play();

            SaveDojodachiToSession(domo);

            return RedirectToAction("Dojodachi");
        }

        [HttpGet]
        [Route("dojodachi/work")]
        public IActionResult Work()
        {
            var domo = GetFromSession();
            TempData["Message"] = domo.Work();
            SaveDojodachiToSession(domo);

            return RedirectToAction("Dojodachi");
        }

        [HttpGet]
        [Route("dojodachi/sleep")]
        public IActionResult Sleep()
        {
            var domo = GetFromSession();
            TempData["Message"] = domo.Sleep();
            SaveDojodachiToSession(domo);

            return RedirectToAction("Dojodachi");
        }

        [HttpGet]
        [Route("dojodachi/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            ViewBag.Message = string.Empty;
            return RedirectToAction("Dojodachi");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Domogachi GetFromSession()
        {
            return HttpContext.Session.GetObjectFromJson("Domogachi");
        }

        private void SaveDojodachiToSession(Domogachi domo)
        {
            HttpContext.Session.SetObjectAsJson("Domogachi", domo);
        }

        private void SaveToViewBag(Domogachi domo)
        {
            ViewBag.Fullness = domo.Fullness;
            ViewBag.Happiness = domo.Happiness;
            ViewBag.Meals = domo.Meals;
            ViewBag.Energy = domo.Energy;
        }

    }
}
