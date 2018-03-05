using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Room
    {
        private int _id;
        private static Character _character;
        private static Monster _monster;

        public Room()
        {
            _id = 0;
            _character = null;
            _monster = null;
        }
        public void GiveExperience()
        {
            //Open SQL connection add experience to Character based on Monsetr
        }
        public Item TreasureChestEvent()
        {
            //Randomly generates an Item and appends it to the user database table.
        }

        public void BeginFight()
        {
            
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
