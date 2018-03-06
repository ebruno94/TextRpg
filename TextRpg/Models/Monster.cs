using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Monster
    {
        private int _level;
        private int _experience;
        private int _health;
        private int _maxHealth;
        private int _attackDamage;
        private int _dexterity;
        private int _luck;
        private int _charisma;
        private static Item _monsterItem;
        private string _imgUrl;
        private int _armor;

        public Monster()
        {
            _level = 1;
            _experience = 0;
            _health = 100;
            _maxHealth = 100;
            _attackDamage = 1;
            _dexterity = 1;
            _luck = 1;
            _charisma = 1;
            _armor = 0;
        }
        //Change functions
        public void ChangeLevel(int level)
        {
            _level += level;
        }
        public void ChangeExperience(int experience)
        {
            _experience += experience;
        }
        public void ChangeMaxHealth(int health)
        {
            _maxHealth += health;
        }
        public void ChangeHealth(int health)
        {
            _health += health;
        }
        public void ChangeAttackDamage(int attackDamage)
        {
            _attackDamage += attackDamage;
        }
        public void ChangeDexterity(int dexterity)
        {
            _dexterity = dexterity;
        }
        public void ChangeLuck(int luck)
        {
            _luck = luck;
        }
        public void ChangeCharisma(int charisma)
        {
            _charisma = charisma;
        }
        //Getters
        public int GetLevel()
        {
            return _level;
        }
        public int GetExperience()
        {
            return _experience;
        }
        public int GetMaxHealth()
        {
            return _maxHealth;
        }
        public int GetHealth()
        {
            return _health;
        }
        public int GetAttackDamage()
        {
            return _attackDamage;
        }
        public int GetDexterity()
        {
            return _dexterity;
        }
        public int GetLuck()
        {
            return _luck;
        }
        public string GetImgUrl()
        {
            return _imgUrl;
        }

        public int Attack()
        {
            int outputDamage = 0;

            return outputDamage;
        }
        public int Defend(int inputDamage)
        {
            int damageTaken = inputDamage;

            return damageTaken;
        }

    }

}
