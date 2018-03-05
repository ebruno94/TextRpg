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
        public User GetUser()
        {
            return _currentUser;
        }
        public Room GetRoom()
        {
            return _room;
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

        }
        public void Restart()
        {

        }

    }

}
