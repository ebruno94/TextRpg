using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;

namespace TextRpg.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("/User/Form/{messageId}")]
        public ActionResult Form(int messageId)
        {
            string message = "";
            if (messageId = 1)
            {
                message = "Please pick a new username. The username you submitted was already taken.";
            }
            else if (messageId = 2)
            {
                message = "The password and confirmation passwords you submitted were not the same.";
            }
            return View(message);
        }

        [HttpPost("/User/Create")]
        public ActionResult Create()
        {
            string name = Request.Form["name"];
            string username = Request.Form["username"];
            string email = Request.Form["email"];
            string password = Request.Form["password1"];
            string confirmPassword = Request.Form["password2"];

            if (password.Equals(confirmPassword))
            {
                GameUser myGameUser = new GameUser(name, username, password, email, 1);
                if (myGameUser.Save())
                {
                    Game.SetGameUser(myGameUser);
                    return RedirectToAction("Display");
                }
                return RedirectToAction("Form", new {messageId=1});
            }
            return RedirectToAction("Form", new {messageId=2});
        }

        [HttpGet("/User/Display")]
        public ActionResult Display()
        {
            return View();
        }

        [HttpGet("/User/Logout")]
        public ActionResult Logout()
        {
            Game.Logout();
            return RedirectToAction("Index", "Home"); 
        }
    }
}
