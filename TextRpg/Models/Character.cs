using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Character
    {
        public string _name;
        public int _id;
        public int _level;
        public int _experience;
        public int _maxHealth;
        public int _health;
        public int _armor;
        public int _attackDamage;
        public int _intelligence;
        public int _dexterity;
        public int _luck;
        public int _charisma;
        public int _roomNumber;
        public int _userId;
        public static Inventory _inventory;

        public Character(string name, int userId)
        {
            _name = name;
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
            _roomNumber = 1;
            _inventory = null;
            _userId = userId;
            _inventory = new Inventory(_id);
        }

        public Character(string name, int level, int exp, int maxhp, int hp, int armor, int ad, int iq, int dex, int lck, int charisma, int id, int roomNumber, int userId)
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
            _roomNumber = roomNumber;
            _id = id;
            _inventory = new Inventory(id);
            _inventory.UpdateInventoryStats();
            _userId = userId;
        }

        public static Character Find(int characterId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM characters WHERE user_id = @user_id;";
            var userIdPara = new MySqlParameter("@user_id", characterId);
            cmd.Parameters.Add(userIdPara);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id =  0;
            string name = "";
            int level = 0;
            int exp = 0;
            int maxHp = 0;
            int hp = 0;
            int ad = 0;
            int iq = 0;
            int dex = 0;
            int lck = 0;
            int charisma = 0;
            int roomNumber = 1;
            int armor = 0;
            int userId = 0;

            while (rdr.Read())
            {
                id =  rdr.GetInt32(0);
                name = rdr.GetString(1);
                level = rdr.GetInt32(2);
                exp = rdr.GetInt32(3);
                maxHp = rdr.GetInt32(4);
                hp = rdr.GetInt32(5);
                armor = rdr.GetInt32(6);
                ad = rdr.GetInt32(7);
                iq = rdr.GetInt32(8);
                dex = rdr.GetInt32(9);
                lck = rdr.GetInt32(10);
                charisma = rdr.GetInt32(11);
                roomNumber = (int) rdr.GetInt32(13);
                userId = (int) rdr.GetInt32(12);
            }
            Character thisCharacter = new Character(name, level, exp, maxHp, hp, armor, ad, iq, dex, lck, charisma, id, roomNumber, userId);
            return thisCharacter;
        }

        public int GetId()
        {
            return _id;
        }
        public void SetRoomNumber(int roomNum)
        {
            _roomNumber = roomNum;
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
            _attackDamage += attackDamage;
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
        public string GetName()
        {
            return _name;
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
        public int GetCharisma()
        {
            return _charisma;
        }
        public int GetRoomNumber()
        {
            return _roomNumber;
        }
        public int GetUserId()
        {
            return _userId;
        }
        public Inventory GetInventory()
        {
            return _inventory;
        }

        public void SetRoomNumber(int roomNumber)
        {
            _roomNumber = roomNumber;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO characters (name, level, experience, max_hp, hp, armor, ad, iq, dexterity, luck, charisma, user_id, room_number) VALUES (@name, @level, @experience, @maxHealth, @health, @armor, @attackDamage, @intelligence, @dexterity, @luck, @charisma, @userId, @roomNumber);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = _name;
            cmd.Parameters.Add(name);

            MySqlParameter level = new MySqlParameter();
            level.ParameterName = "@level";
            level.Value = _level;
            cmd.Parameters.Add(level);

            MySqlParameter experience = new MySqlParameter();
            experience.ParameterName = "@experience";
            experience.Value = _experience;
            cmd.Parameters.Add(experience);

            MySqlParameter maxHealth = new MySqlParameter();
            maxHealth.ParameterName = "@maxHealth";
            maxHealth.Value = _maxHealth;
            cmd.Parameters.Add(maxHealth);

            MySqlParameter health = new MySqlParameter();
            health.ParameterName = "@health";
            health.Value = _health;
            cmd.Parameters.Add(health);

            MySqlParameter armor = new MySqlParameter();
            armor.ParameterName = "@armor";
            armor.Value = _armor;
            cmd.Parameters.Add(armor);

            MySqlParameter attackDamage = new MySqlParameter();
            attackDamage.ParameterName = "@attackDamage";
            attackDamage.Value = _attackDamage;
            cmd.Parameters.Add(attackDamage);

            MySqlParameter intelligence = new MySqlParameter();
            intelligence.ParameterName = "@intelligence";
            intelligence.Value = _intelligence;
            cmd.Parameters.Add(intelligence);

            MySqlParameter dexterity = new MySqlParameter();
            dexterity.ParameterName = "@dexterity";
            dexterity.Value = _dexterity;
            cmd.Parameters.Add(dexterity);

            MySqlParameter luck = new MySqlParameter();
            luck.ParameterName = "@luck";
            luck.Value = _luck;
            cmd.Parameters.Add(luck);

            MySqlParameter charisma = new MySqlParameter();
            charisma.ParameterName = "@charisma";
            charisma.Value = _charisma;
            cmd.Parameters.Add(charisma);

            MySqlParameter userId = new MySqlParameter();
            userId.ParameterName = "@userId";
            userId.Value = _userId;
            cmd.Parameters.Add(userId);

            MySqlParameter roomNumber = new MySqlParameter("@roomNumber", _roomNumber);
            cmd.Parameters.Add(roomNumber);

            cmd.ExecuteNonQuery();

            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public void Update()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"UPDATE characters SET name = @name ,level = @level,experience = @experience,max_hp = @maxHealth,hp = @health,armor = @armor, ad = @attackDamage, iq = @intelligence, dexterity = @dexterity, luck = @luck, charisma = @charisma, user_id = @userId, room_number = @roomNumber WHERE id = @userId;";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = _name;
            cmd.Parameters.Add(name);

            MySqlParameter level = new MySqlParameter();
            level.ParameterName = "@level";
            level.Value = _level;
            cmd.Parameters.Add(level);

            MySqlParameter experience = new MySqlParameter();
            experience.ParameterName = "@experience";
            experience.Value = _experience;
            cmd.Parameters.Add(experience);

            MySqlParameter maxHealth = new MySqlParameter();
            maxHealth.ParameterName = "@maxHealth";
            maxHealth.Value = _maxHealth;
            cmd.Parameters.Add(maxHealth);

            MySqlParameter health = new MySqlParameter();
            health.ParameterName = "@health";
            health.Value = _health;
            cmd.Parameters.Add(health);

            MySqlParameter armor = new MySqlParameter();
            armor.ParameterName = "@armor";
            armor.Value = _armor;
            cmd.Parameters.Add(armor);

            MySqlParameter attackDamage = new MySqlParameter();
            attackDamage.ParameterName = "@attackDamage";
            attackDamage.Value = _attackDamage;
            cmd.Parameters.Add(attackDamage);

            MySqlParameter intelligence = new MySqlParameter();
            intelligence.ParameterName = "@intelligence";
            intelligence.Value = _intelligence;
            cmd.Parameters.Add(intelligence);

            MySqlParameter dexterity = new MySqlParameter();
            dexterity.ParameterName = "@dexterity";
            dexterity.Value = _dexterity;
            cmd.Parameters.Add(dexterity);

            MySqlParameter luck = new MySqlParameter();
            luck.ParameterName = "@luck";
            luck.Value = _luck;
            cmd.Parameters.Add(luck);

            MySqlParameter charisma = new MySqlParameter();
            charisma.ParameterName = "@charisma";
            charisma.Value = _charisma;
            cmd.Parameters.Add(charisma);

            MySqlParameter userId = new MySqlParameter();
            userId.ParameterName = "@userId";
            userId.Value = _userId;
            cmd.Parameters.Add(userId);

            MySqlParameter roomNumber = new MySqlParameter("@roomNumber", _roomNumber);
            cmd.Parameters.Add(roomNumber);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        //EXPERIENCE/LEVEL UPDATE FUNCTIONS BEGIN HERE ------------------------------------------------------------->
        public void StatUpdate()
        {
            //Level Adjustment
            _maxHealth = 500 + _level*25;
            _attackDamage = 66 + _level*25;
            _dexterity = 1 + _level;
            //Inventory Adjustment
            _inventory.UpdateInventoryStats();
        }
        public int ExperienceForLevel(int inputLevel)
        {
            double experienceRequiredForLevel = Math.Pow(2, (inputLevel+1)/2.5);
            return (int) (experienceRequiredForLevel);
        }
        public int GetExperienceForNextLevel()
        {
            return (int) (ExperienceForLevel(_level+1));
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
            int totalArmor = _inventory.GetArmor();

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
