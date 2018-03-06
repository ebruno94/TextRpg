using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Game
    {
        private static GameUser _currentUser;
        private static Room _currentRoom;
        private static GameDisplay _gameDisplay;

        public Game()
        {
            _currentUser = null;
            _currentRoom = null;
            _gameDisplay = null;
        }
        public GameUser GetGameUser()
        {
            return _currentUser;
        }
        public Room GetRoom()
        {
            return _currentRoom;
        }
        public GameDisplay GetGameDisplay()
        {
            return _gameDisplay;
        }

        public static void LetThereBeLight()
        {

        }

        public void CheckEndGame()
        {

        }
        public void Update()
        {

        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE users SET room_number = @room_number, character_id = @character_id WHERE id = @id;";
            var roomPara = new MySqlParameter("@room_number", _currentRoom);
            var charIdPara = new MySqlParameter("@character_id", _currentUser.GetCharacter().GetId());
            var userIdPara = new MySqlParameter("@id", _currentUser.GetId());
            cmd.Parameters.Add(roomPara);
            cmd.Parameters.Add(charIdPara);
            cmd.Parameters.Add(userIdPara);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void Restart()
        {

        }

    }

}
