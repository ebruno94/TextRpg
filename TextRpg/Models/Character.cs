using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Character
    {
        private string _name;
        private int _id;
        private int _level;
        private int _experience;
        private int _maxHealth;
        private int _health;
        private int _armor;
        private int _attackDamage;
        private int _intelligence;
        private int _dexterity;
        private int _luck;
        private int _charisma;
        private static Inventory _inventory;

        public Character()
        {
            _level = 1;
            _experience = 0;
            _health = 500;
            _maxHealth = 500;
            _armor = 0;
            _attackDamage = 66;
            _intelligence = 1;
            _dexterity = 1;
            _luck = 1;
            _charisma = 1;
            _inventory = null;
        }

        public Character(string name, int level, int exp, int maxhp, int hp, int armor, int ad, int iq, int dex, int lck, int charisma, int charId)
        {
            _name = name;
            _level = level;
            _experience = exp;
            _maxHealth = maxhp;
            _health = hp;
            _armor = armor;
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
            _attackDamage += attackDamage
        }
        public void ChangeArmor(int armor)
        {
            _armor += armor;
        }
        public void ChangeIntelligence(int intelligence)
        {
            _intelligence += intelligence;
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
        public int GetArmor()
        {
            return _armor;
        }
        public int GetAttackDamage()
        {
            return _attackDamage;
        }
        public int GetIntelligence()
        {
            return _intelligence;
        }
        public int GetDexterity()
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
        public int ExperienceForLevel(int inputLevel)
        {
            double experienceRequiredForLevel = Math.Pow(2, (inputLevel+1)/2.5)
            return Int32.Parse(experienceRequiredForLevel);
        }
        public int GetExperienceForNextLevel()
        {
            return Int32.Parse(ExperienceForLevel(_level+1));
        }
        public void CheckForLevelUp()
        {
            if(_experience >= ExperienceForLevel(_level+1))
            {
                _level += _level + 1;
            }
        }
        //EXPERIENCE/LEVEL FUNCTIONS END HERE ------------------------------------------------------------->

        //ATTACK FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public int Attack()
        {
            this.StatUpdate();
            int outputDamage = 1*_level + (_attackDamage/100)*_level;
            return Int32.Parse(outputDamage);
        }
        //ATTACK FUNCTIONS END HERE ------------------------------------------------------------->

        //DEFEND FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public void Defend(int inputDamage)
        {
            this.StatUpdate();
            int outputDamage = 0;
            if(Dodge() == true)
            {
                //Nice dodge
            } else {
                outputDamage = this.ArmorDamageReduction(inputDamage);
                _health = Int32.Parse(_health - outputDamage);
            }

        }
        //
        public int ArmorDamageReduction(int inputDamage)
        {
            int outputDamage = inputDamage;
            int damageMultiplier = 1;
            int totalArmor = GetCharacterTotalArmor;

            if(totalArmor >= 0)
            {
                damageMultiplier = (100/(100+totalArmor));
            } else {
                damageMultiplier = 1;
            }

            return Int32.Parse(outputDamage*damageMultiplier);
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
        public bool CheckDeath()
        {
            if(_health <= 0){
                return true;
            } else {
                return false;
            }
        }
    }

}
