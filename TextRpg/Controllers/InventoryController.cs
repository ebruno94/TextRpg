using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;
using System;

namespace TextRpg.Controllers
{
    public class InventoryController : Controller
    {
        [HttpPost("/Inventory/AddItem")]
        public IActionResult AddItem(int index)
        {
            Game.GetGameUser().GetCharacter().GetInventory().AddItem(index);
            Console.WriteLine("itemIndex: " + index);

            Monster newMonster = new Monster();

            return Json(newMonster);
        }
    }
}
