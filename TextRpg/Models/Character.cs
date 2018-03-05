using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Character
    {
        private int _id;
        private int _level;
        private int _experience;
        private double _health;
        private double _maxHealth;
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
            maxHealth = 500;
            _attackDamage = 66;
            _intelligence = 1;
            _dexterity = 1;
            _luck = 1;
            _charisma = 1;
            _inventory = null;
        }

        public Character(string name, int level, int exp, int hp, int ad, int iq, int dex, int lck, int charisma, int charId)
        {
            _level = level;
            _experience = exp;
            _health = hp;
            _attackDamage = ad;
            _intelligence = iq;
            _dexterity = dex;
            _luck = lck;
            _charisma = charisma;
            _inventory = new Inventory(charId);
            _inventory.UpdateInventoryStats();
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
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
        public void ChangeMaxHealth(double health)
        {
            _maxHealth += health;
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
        public double GetMaxHealth()
        {
            return _maxHealth;
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
        //EXPERIENCE/LEVEL UPDATE FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public void StatUpdate()
        {
            //Level Adjustment
            _maxHealth = 500 + _level*25;
            _attackDamage = 66 + _level*25;
            _dexterity = 1 + _level;

            //Inventory Adjustment
            this.UpdateInventoryStats();
        }
        public void LevelFunction()
        {
            if(ExperienceForLevel(_level+1) - ExperienceForLevel(_level) =< experience)
            {
                _level += _level + 1;
            }
        }
        public void ExperienceForLevel(int inputLevel)
        {
            double experienceRequiredForLevel = Math.Pow(2, (inputLevel+1)/2.5)
            return experienceRequiredForLevel;

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
                totalArmor += _inventory[i].GetArmor();
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
