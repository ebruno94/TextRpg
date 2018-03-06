using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Room
    {
        private int _id;
        private static Character _character = null;
        private static Monster _monster = null;
        private string _log;

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
        public void Restart()
        {
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

        public void FightEvent(){
            while(_character.CheckDeath() != true && _monster.CheckDeath() != true)
            {
                //Need some listening event
                _monster.Defend(_character.Attack());
                if(_monster.CheckDeath()){
                    GiveExperience();
                    _log += "You killed "+ _monster.GetName() + " with a " + _monster.Attack() + " damage attack.  <br>";
                    _log += "You gained " + _monster.GetExperience() + ". <br>";
                } else {
                    _log += "You attack " + _monster.GetName() + " for " + _character.Attack() + ". <br>";
                }
                //Need some delay before the monster attacks
                if(_character.CheckDeath()){
                    _log += "You died... " + _monster.GetName() + " attacked you for " + _monster.Attack() +"<br>";
                } else {
                    _log += _monster.GetName() + " attacks you for " + _monster.Attack() + " . <br>";
                }
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
