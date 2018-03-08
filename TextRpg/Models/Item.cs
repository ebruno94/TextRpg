using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace TextRpg.Models
{
    public class Item
    {
        public int _id;
        public string _name;
        public string _imgUrl;
        public int _health;
        public int _armor;
        public int _attackDamage;
        public int _intelligence;
        public int _luck;
        public int _charisma;
        public int _dexterity;
        public int _equippable;
        public string _action;
        public string _audio;

        public Item (string name, string imgUrl, int hp, int armor, int ad, int iq, int luck, int charisma, int dex, int equippable, string action, string audio)
        {
            _name = name;
            _imgUrl = imgUrl;
            _health = hp;
            _armor = armor;
            _attackDamage = ad;
            _intelligence = iq;
            _luck = luck;
            _charisma = charisma;
            _dexterity = dex;
            _equippable = equippable;
            _action = action;
            _audio = audio;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetArmor()
        {
            return _armor;
        }

        public string GetAction()
        {
            return _action;
        }

        public string GetName()
        {
            return _name;
        }
        public string GetImgUrl()
        {
            return _imgUrl;
        }
        public int GetHealth()
        {
            return _health;
        }
        public int GetAttackDamage()
        {
            return _attackDamage;
        }
        public int GetIntelligence()
        {
            return _intelligence;
        }
        public int GetLuck()
        {
            return _luck;
        }
        public int GetCharisma()
        {
            return _charisma;
        }
        public int GetDexterity()
        {
            return _dexterity;
        }
        public int GetEquippable()
        {
            return _equippable;
        }

        public string GetAudio()
        {
            return _audio;
        }
        public static Item Find(int myId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM items WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = myId;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string name = "";
            string imgUrl = "";
            int health = 0;
            int armor = 0;
            int attackDamage = 0;
            int intelligence = 0;
            int luck = 0;
            int charisma = 0;
            int dexterity = 0;
            int equippable = 0;
            string action = "";
            string audio = "";

            while(rdr.Read())
            {
                id = (int) rdr.GetInt32(0);
                name = rdr.GetString(1);
                imgUrl = rdr.GetString(2);
                health = (int) rdr.GetInt32(3);
                armor = (int) rdr.GetInt32(4);
                attackDamage = (int) rdr.GetInt32(5);
                intelligence = (int) rdr.GetInt32(6);
                luck = (int) rdr.GetInt32(7);
                charisma = (int) rdr.GetInt32(8);
                dexterity = (int) rdr.GetInt32(9);
                equippable = (int) rdr.GetInt32(10);
                action = rdr.GetString(11);
                audio = rdr.GetString(12);

            }
            Item newItem = new Item(name, imgUrl, health, armor, attackDamage, intelligence, luck, charisma, dexterity, equippable, action, audio);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newItem;
        }
    }
}
