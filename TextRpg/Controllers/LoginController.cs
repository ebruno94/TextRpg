using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;
using System;
namespace TextRpg.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("/Login/Form")]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost("/Login/Create")]
        public ActionResult Create()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            GameUser loginUser = GameUser.Find(GameUser.Login(username, password));
            Console.WriteLine(loginUser);
            if(loginUser.GetName() == "" || loginUser.GetName() == null){
              return RedirectToAction("Form");
            } else {
              Game.SetGameUser(loginUser);
              Game.GetGameUser().SetCharacter(Character.Find(Game.GetGameUser().GetId()));
              return RedirectToAction("Display", "User");
            }
        }
    }
}
