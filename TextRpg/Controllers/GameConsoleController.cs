using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;
using System;

namespace TextRpg.Controllers
{
    public class GameConsoleController : Controller
    {
        [HttpPost("/GameConsole/Append")]
        public string Append(string message)
        {
            Game.GetGameConsole().Append(message);
            Console.WriteLine(Game.GetGameConsole().GetGameLog());
            return Game.GetGameConsole().GetGameLog();
        }
    }
}
