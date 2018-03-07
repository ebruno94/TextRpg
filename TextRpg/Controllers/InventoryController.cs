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
            return Json(Item.Find(itemIndex));
        }
    }
}
