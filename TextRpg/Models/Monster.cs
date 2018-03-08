using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Monster
    {
        public string _name;
        public int _level;
        public int _experience;
        public int _health;
        public int _maxHealth;
        public int _attackDamage;
        public int _dexterity;
        public int _charisma;
        public static Item _monsterItem;
        public string _imgUrl;
        public int _armor;
        public string _audio;
        public int _id;

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

        public Monster (string name, string imgUrl, int level, int max_hp, int hp, int armor, int attackDamage,int charisma,int dexterity, int item_id, int experience, string audio)
        {
            _name = name;
            _imgUrl = imgUrl;
            _level = level;
            _maxHealth = max_hp;
            _health = hp;
            _armor = armor;
            _attackDamage = attackDamage;
            _charisma = charisma;
            _dexterity = dexterity;
            _experience = experience;
            _monsterItem = Item.Find(item_id);
            _audio = audio;
        }
        public void UpdateHealth()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"UPDATE monsters SET hp = @hp ,max_hp = @max_hp WHERE id = @monsterId;";

            MySqlParameter health = new MySqlParameter();
            health.ParameterName = "@hp";
            health.Value = _health;
            cmd.Parameters.Add(health);

            MySqlParameter maxHealth = new MySqlParameter();
            maxHealth.ParameterName = "@max_hp";
            maxHealth.Value = _maxHealth;
            cmd.Parameters.Add(maxHealth);

            MySqlParameter monsterId = new MySqlParameter();
            monsterId.ParameterName = "@monsterId";
            monsterId.Value = _id;
            cmd.Parameters.Add(monsterId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        //Change functions
        public void ChangeLevel(int level)
        {
            _level += level;
        }
        public Item GetItem()
        {
            return _monsterItem;
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
        public void SetId(int id)
        {
          _id = id;
        }
        public int GetId()
        {
          return _id;
        }
        //EXPERIENCE/LEVEL UPDATE FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public void StatUpdate()
        {
            //Level Adjustment for monsters
            _attackDamage = _attackDamage + (_level-1)*10;
            _dexterity = (int) .5 + (_level-1);
        }
        //ATTACK FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public int Attack()
        {
            this.StatUpdate();
            int outputDamage = 1*_level + (_attackDamage);
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
                Console.WriteLine("Dodge");
            } else {
                outputDamage = this.ArmorDamageReduction(inputDamage);
                _health = (int) (_health - inputDamage);
            }
            Console.WriteLine("Monster Health: " + _health);

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

        public static Monster Find(int myId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM monsters WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = myId;
            cmd.Parameters.Add(searchId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            int id = 0;
            string name = "";
            string imgUrl = "";
            int level = 0;
            int max_hp = 0;
            int hp = 0;
            int armor = 0;
            int attackDamage = 0;
            int charisma = 0;
            int dexterity = 0;
            int item_id = 0;
            int experience = 0;
            string audio = "";

            while(rdr.Read())
            {
                id = (int) rdr.GetInt32(0);
                name = rdr.GetString(1);
                imgUrl = rdr.GetString(2);
                level = (int) rdr.GetInt32(3);
                max_hp = (int) rdr.GetInt32(4);
                hp = (int) rdr.GetInt32(5);
                armor = (int) rdr.GetInt32(6);
                attackDamage = (int) rdr.GetInt32(7);
                charisma = (int) rdr.GetInt32(8);
                dexterity = (int) rdr.GetInt32(9);
                item_id = (int) rdr.GetInt32(10);
                experience = (int) rdr.GetInt32(11);
                audio = rdr.GetString(12);

            }
            Monster newMonster = new Monster(name, imgUrl, level, max_hp, hp, armor, attackDamage, charisma, dexterity, item_id, experience, audio);
            newMonster.SetId(id);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newMonster;
        }
    }

}
