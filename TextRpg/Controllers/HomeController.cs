using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;

namespace TextRpg.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
