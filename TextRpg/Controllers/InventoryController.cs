using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace TextRpg.Controllers
{
    public class InventoryController : Controller
    {
        [HttpPost("/Inventory/AddItem")]
        public IActionResult AddItem(int index)
        {
            Game.GetGameUser().GetCharacter().GetInventory().AddItem(index);
            Console.WriteLine("itemIndex: " + index);
            Item myItem = Item.Find(index);
            Console.WriteLine("My item is called a " + myItem.GetName());
            string result = JsonConvert.SerializeObject(myItem);

            return Json(myItem);
        }
    }
}
