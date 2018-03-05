using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class GameDisplay
    {
        private static Character _character;
        private static Monster _monster;
        private static Map _map;

        public GameDisplay()
        {
            _character = null;
            _monster = null;
            _map = null;
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

        public Character GetCharacter()
        {
            return _character;
        }
        public Monster GetMonster()
        {
            return _monster;
        }
        public Map GetMap()
        {
            
        }

    }

}
