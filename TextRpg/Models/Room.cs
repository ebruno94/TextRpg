using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Room
    {
        public int _id;
        public int _number;
        public static Character _character = null;
        public static Monster _monster = null;
        public string _log;

        public Room()
        {
            _id = 0;
            _character = null;
            _monster = new Monster();
        }
        public Room(int id, int number, Character character, Monster newMonster)
        {
            _id = id;
            _number = number;
            _character = character;
            _monster = newMonster;
        }
        public void SetCharacter(Character inputCharacter){
            _character = inputCharacter;
        }
        public void SetMonster(Monster inputMonster){
            _monster = inputMonster;
        }
        public void SetId(int inputId){
            _id = inputId;
        }
        public void SetRoomNumber(int inputNumber)
        {
            _number = inputNumber;
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

        public static Room Find(int myId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM rooms WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = myId;
            cmd.Parameters.Add(searchId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            int id = 0;
            int number = 0;
            int monster_id = 0;

            while(rdr.Read())
            {
                id = (int) rdr.GetInt32(0);
                number = (int) rdr.GetInt32(1);
                monster_id = (int) rdr.GetInt32(2);


            }
            Room newRoom = new Room();
            newRoom.SetId(id);
            newRoom.SetRoomNumber(number);
            newRoom.SetMonster(Monster.Find(monster_id));
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newRoom;
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
