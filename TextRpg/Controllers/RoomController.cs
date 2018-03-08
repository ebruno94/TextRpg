using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;
using System;


namespace TextRpg.Controllers
{
    public class RoomController: Controller
    {
        [HttpGet("/Room/1")]
        public ActionResult Room1()
        {
            Room newRoom = Room.Find(1);
            newRoom.SetCharacter(Game.GetGameUser().GetCharacter());
            Game.GetGameUser().GetCharacter().SetRoomNumber(1);
            Game.GetGameUser().GetCharacter().GetInventory();

            return View();
        }
        [HttpGet("/Room/2")]
        public ActionResult Room2(int monsterId)
        {
            Room newRoom = Room.Find(2);
            newRoom.SetCharacter(Game.GetGameUser().GetCharacter());
            Game.GetGameUser().GetCharacter().SetRoomNumber(2);
            Game.GetGameUser().GetCharacter().Update();
            Game.GetGameUser().GetCharacter().GetInventory();
            return View();
        }
        [HttpGet("/Room/3")]
        public ActionResult Room3()
        {
            return View();
        }
        [HttpGet("/Room/4")]
        public ActionResult Room4()
        {
            return View();
        }
        [HttpGet("/Room/5")]
        public ActionResult Room5()
        {
            return View();
        }
        [HttpGet("/Room/6")]
        public ActionResult Room6()
        {
            return View();
        }
        [HttpGet("/Room/7")]
        public ActionResult Room7()
        {
            return View();
        }
        [HttpGet("/Room/8")]
        public ActionResult Room8()
        {
            return View();
        }
        [HttpGet("/Room/9")]
        public ActionResult Room9()
        {
            return View();
        }
        [HttpGet("/Room/10")]
        public ActionResult Room10()
        {
            return View();
        }
        [HttpGet("/Room/11")]
        public ActionResult Room11()
        {
            return View();
        }
        [HttpGet("/Room/12")]
        public ActionResult Room12()
        {
            return View();
        }
        [HttpGet("/Room/13")]
        public ActionResult Room13()
        {
            return View();
        }
        [HttpGet("/Room/14")]
        public ActionResult Room14()
        {
            return View();
        }
        [HttpGet("/Room/15")]
        public ActionResult Room15()
        {
            return View();
        }
        [HttpGet("/Room/16")]
        public ActionResult Room16()
        {
            return View();
        }
        [HttpGet("/Room/17")]
        public ActionResult Room17()
        {
            return View();
        }
        [HttpGet("/Room/18")]
        public ActionResult Room18()
        {
            return View();
        }
        [HttpGet("/Room/19")]
        public ActionResult Room19()
        {
            return View();
        }
        [HttpGet("/Room/20")]
        public ActionResult Room20()
        {
            return View();
        }
        [HttpGet("/Room/21")]
        public ActionResult Room21()
        {
            return View();
        }
        [HttpGet("/Room/22")]
        public ActionResult Room22()
        {
            return View("Room1");
        }
      }
}
