using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Room
    {
        public int _id;
        public static Character _character = null;
        public static Monster _monster = null;
        public string _log;

        public Room()
        {
            _id = 0;
            _character = null;
            _monster = new Monster();
        }
        public string GetLog()
        {
            return _log;
        }
        public void GiveExperience()
        {
            _character.ChangeExperience(_monster.GetExperience());
        }
        public void GiveItem()
        {
            _character.GetInventory().AddItem(_monster.GetItem().GetId());
        }
        public void Restart()
        {
            if(Game.GetGameUser().GetId() < 8){
                Game.GetGameUser().SetRoomNumber(1);
            } else if(8 <= Game.GetGameUser().GetId() && Game.GetGameUser().GetId() < 14){
                Game.GetGameUser().SetRoomNumber(8);
            } else if(14 <= Game.GetGameUser().GetId() && Game.GetGameUser().GetId() < 20) {
                Game.GetGameUser().SetRoomNumber(14);
            } else {

            }
            _character.GetInventory().ClearInventory();
        }
        //Randomly generates an Item and gives it to the current Character
        public void TreasureChestEvent()
        {
            Random random = new Random();
            int randomItemNum = random.Next(1, 100);
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"SELECT * FROM items WHERE items.id = @item_id;@INSERT INTO inventories (character_id, item_id) VALUES (@character_id, @item_id);";

            MySqlParameter charIdPara = new MySqlParameter("@character_id", _character.GetId());
            MySqlParameter randomItemNumber = new MySqlParameter("@item_id", randomItemNum);

            cmd.Parameters.Add(charIdPara);
            cmd.Parameters.Add(randomItemNumber);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }
        //Button Triggers Event
        public void FightEvent(){
            //Need some listening event
            _monster.Defend(_character.Attack());
            if(_monster.CheckDeath()){
                Game.GetGameConsole().Append("<p>You killed "+ _monster.GetName() + " with a " + _monster.Attack() + " damage attack.  </p>");
                Game.GetGameConsole().Append("<p>You gained " + _monster.GetExperience() + ". </p>");
                GiveExperience();
                Game.GetGameConsole().Append("<p>You gained " + _monster.GetItem().GetName() + ". </p>");
                GiveItem();
            } else {
                Game.GetGameConsole().Append("<p>You attack " + _monster.GetName() + " for " + _character.Attack() + ". </p>");
            }
            //Need some delay before the monster attacks
            if(_character.CheckDeath()){
                Game.GetGameConsole().Append("<p>You died... " + _monster.GetName() + " attacked you for " + _monster.Attack() +"<p>");
                Restart();
            } else {
                Game.GetGameConsole().Append("<p>" + _monster.GetName() + " attacks you for " + _monster.Attack() + " . <p>");
            }
        }

        public bool Run(){
            Random rnd = new Random();
            int luck = rnd.Next(_character.GetCharisma(), 10); // creates a number between players charisma and 10;
            if(luck >= 6){
                return true;
            } else {
                return false;
            }

        }
        public int GetId()
        {
            return _id;
        }
        public Character GetCharacter()
        {
            return _character;
        }
        public Monster GetMonster()
        {
            return _monster;
        }
    }
}
