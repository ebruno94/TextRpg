using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Monster
    {
        private string _name;
        private int _level;
        private int _experience;
        private int _health;
        private int _maxHealth;
        private int _attackDamage;
        private int _dexterity;
        private int _charisma;
        private static Item _monsterItem;
        private string _imgUrl;
        private int _armor;
        private string _audio;

        public Monster()
        {
            _name = "";
            _level = 1;
            _experience = 0;
            _health = 100;
            _maxHealth = 100;
            _attackDamage = 1;
            _dexterity = 1;
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
        public void ChangeCharisma(int charisma)
        {
            _charisma = charisma;
        }
        //Getters
        public int GetLevel()
        {
            return _level;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string inputName)
        {
            _name = inputName;
        }
        public string GetAudio()
        {
            return _audio;
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
        public string GetImgUrl()
        {
            return _imgUrl;
        }
        //EXPERIENCE/LEVEL UPDATE FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public void StatUpdate()
        {
            //Level Adjustment for monsters
            _maxHealth = 500 + _level*25;
            _attackDamage = 66 + _level*25;
            _dexterity = 1 + _level;
        }
        //ATTACK FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public int Attack()
        {
            this.StatUpdate();
            int outputDamage = 1*_level + (_attackDamage/100)*_level;
            return (int) (outputDamage);
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
                _health = (int) (_health - outputDamage);
            }

        }
        //
        public int ArmorDamageReduction(int inputDamage)
        {
            int outputDamage = inputDamage;
            int damageMultiplier = 1;
            int totalArmor = _armor;

            if(totalArmor >= 0)
            {
                damageMultiplier = (100/(100+totalArmor));
            } else {
                damageMultiplier = 1;
            }

            return (int) (outputDamage*damageMultiplier);
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
