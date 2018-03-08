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

        [HttpGet("/Character/AddItemToEquipped/")]
        public IActionResult CharacterAddItemToEquipped(int itemId)
        {
            Item myItem = Item.Find(itemId);
            Console.WriteLine("Adding Equipped Item");
            Game.GetGameUser().GetCharacter().AddItemToEquipped(myItem);
            return Json(myItem);
        }
    }
}
