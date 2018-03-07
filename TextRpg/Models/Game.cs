using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Game
    {

        private static GameUser _currentGameUser = null;
        private static Room _currentRoom = new Room();
        private static GameConsole _gameConsole = new GameConsole();

        public static void SetGameUser(GameUser myGameUser)
        {
            _currentGameUser = myGameUser;
        }

        public static void SetCurrentRoom(Room currentRoom)
        {
            _currentRoom = currentRoom;
        }

        public static void SetGameConsole(GameConsole myGameConsole)
        {
            _gameConsole = myGameConsole;
        }
        public static GameUser GetGameUser()
        {
            return _currentGameUser;
        }
        public static Room GetRoom()
        {
            return _currentRoom;
        }
        public static GameConsole GetGameConsole()
        {
            return _gameConsole;
        }

        public static void LetThereBeLight()
        {

        }

        public static void CheckEndGame()
        {

        }
        public static void Update()
        {

        }

        public static void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE users SET room_number = @room_number, character_id = @character_id WHERE id = @id;";
            var roomPara = new MySqlParameter("@room_number", _currentRoom);
            var charIdPara = new MySqlParameter("@character_id", _currentGameUser.GetCharacter().GetId());
            var userIdPara = new MySqlParameter("@id", _currentGameUser.GetId());
            cmd.Parameters.Add(roomPara);
            cmd.Parameters.Add(charIdPara);
            cmd.Parameters.Add(userIdPara);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public static void Logout()
        {
            _currentGameUser = null;
        }

        public static void Restart()
        {

        }

    }

}
