using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;
using System;

namespace TextRpg.Controllers
{
    public class GameController : Controller
    {
        [HttpGet("/Game/Create")]
        public ActionResult Create()
        {
            GameConsole myGameConsole = new GameConsole();
            Game.SetGameConsole(myGameConsole);
            return RedirectToAction("Room1", "Room");
        }
    }
}
