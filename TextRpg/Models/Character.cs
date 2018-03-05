using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Character
    {
        private int _level;
        private int _experience;
        private double _health;
        private double _attackDamage;
        private int _intelligence;
        private double _dexterity;
        private int _luck;
        private int _charisma;
        private static Inventory _inventory;

        public Character()
        {
            _level = 1;
            _experience = 0;
            _health = 100;
            _attackDamage = 1;
            _intelligence = 1;
            _dexterity = 1;
            _luck = 1;
            _charisma = 1;
            _inventory = null;
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
        public void ChangeHealth(double health)
        {
            _health += health;
        }
        public void ChangeAttackDamage(double attackDamage)
        {
            _attackDamage += attackDamage
        }
        public void ChangeIntelligence(int intelligence)
        {
            _intelligence += intelligence;
        }
        public void ChangeDexterity(double dexterity)
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
        public double GetHealth()
        {
            return _health;
        }
        public double GetAttackDamage()
        {
            return _attackDamage;
        }
        public int GetIntelligence()
        {
            return _intelligence;
        }
        public double GetDexterity()
        {
            return _dexterity;
        }
        public int GetLuck()
        {
            return _luck;
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
