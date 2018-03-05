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
        private string _log;

        public Room()
        {
            _id = 0;
            _character = null;
            _monster = null;
        }
        public string GetLog()
        {
            return _log;
        }
        public void GiveExperience()
        {
            //Open SQL connection add experience to Character based on Monsetr
        }
        public void Restart()
        {

        }
        public Item TreasureChestEvent()
        {
            //Randomly generates an Item and appends it to the user database table.
        }

        public void FightEvent(){
            while(_character.CheckDeath != true && _monsterAttack != true)
            {
                _monster.Defend(_character.Attack());
                if(_monster.CheckDeath()){
                    _log += "You killed "+ _monster.GetName() +" with a " + _monster.Attack() + " damage attack. " <br>;
                } else {
                    _log += "You attack " + _monster.GetName() " for " + _character.Attack() + " ." <br>;
                }
                if(_character.CheckDeath()){
                    _log += "You died... " + _monster.GetName() + " attacked you for " + _monster.Attack() <br>;
                } else {
                    _log += _monster.GetName() + " attacks you for " + _monster.Attack() + " ." <br>;
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
