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
            _health = 500;
            _attackDamage = 66;
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
        //EXPERIENCE/LEVEL FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public void StatUpdate()
        {
            //Level Adjustment
            _health = 500 + _level*25;
            _attackDamage = 66 + _level*25;
            _dexterity = 1 + _level;

            //Inventory Adjustment





        }
        //EXPERIENCE/LEVEL FUNCTIONS END HERE ------------------------------------------------------------->

        //ATTACK FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public double Attack()
        {
            int outputDamage = 1*_level + (_attackDamage/100)*_level;
            return outputDamage;
        }
        //ATTACK FUNCTIONS END HERE ------------------------------------------------------------->

        //DEFEND FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public void Defend(int inputDamage)
        {
            int outputDamage = 0;
            if(Dodge() == true)
            {
                //Nice dodge
            } else {
                outputDamage = this.ArmorDamageReduction(inputDamage);
                _health = _health - outputDamage;
            }
        }
        //
        public double ArmorDamageReduction(double inputDamage)
        {
            double outputDamage = inputDamage;
            double damageMultiplier = 1;
            double totalArmor = GetCharacterTotalArmor;

            if(totalArmor >= 0)
            {
                damageMultiplier = (100/(100+totalArmor));
            } else {
                damageMultiplier = 1;
            }

            return outputDamage*damageMultiplier;
        }
        //Used with ArmorDamage Reduction to calculate how much damage one swing does.
        public double GetCharacterTotalArmor()
        {
            totalArmor = 0;

            for(int i = 0; i < _inventory.Count; i ++)
            {
                total += _inventory[i].GetArmor();
            }
            return totalArmor;
        }
        public bool Dodge()
        {
            int baseDodgeChance = 10; //10%
            int totalDodgeChance = baseDodgeChance + this.GetDexterity()*2;
            Random random = new Random();
            int dodge = random.Next(1,101);
            if(dodge <= totalDodgeChance)
            {
                return true;
            } else {
                return false;
            }
        }
        //DEFEND FUNCTIONS END HERE ------------------------------------------------------------->
    }

}
