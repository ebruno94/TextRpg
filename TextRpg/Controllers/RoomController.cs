using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;

namespace TextRpg.Controllers
{
    public class RoomController: Controller
    {
        [HttpGet("/Room/1")]
        public ActionResult Room1()
        {
            return View("Room1");
        }

        public IActionResult DisplayCritter()
        {
        
        }
    }
}
