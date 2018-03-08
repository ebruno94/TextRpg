using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;
using System;

namespace TextRpg.Controllers
{
    public class CharacterController : Controller
    {
        [HttpGet("/Character/Form")]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost("/Character/Create")]
        public ActionResult Create()
        {
            string name = Request.Form["name"];
            Character myCharacter = new Character(name, Game.GetGameUser().GetId());
            Console.WriteLine("GameUserId: " + Game.GetGameUser().GetId());
            Game.GetGameUser().SetCharacter(myCharacter);
            myCharacter.Save();
            return RedirectToAction("Display", "User");
        }
    }
}
