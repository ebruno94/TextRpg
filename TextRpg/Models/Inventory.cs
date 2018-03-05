using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace TextRpg.Models
{
    public class Inventory
    {
        private int _characterId;
        private int _health;
        private int _attackDamage;
        private int _intelligence;
        private int _luck;
        private int _charisma;
        private int _dexterity;
        private List<Item> _equippables = new List<Item>{};
        private List<Item> _disposables = new List<Item>{};

        public Inventory(int charId)
        {
            _characterId = charId;
            _health = 0;
            _attackDamage = 0;
            _intelligence = 0;
            _luck = 0;
            _charisma = 0;
            _dexterity = 0;
            MySqlConnector conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT items.* FROM
                  characters JOIN inventories ON (characters.id = inventories.character_id)
                  JOIN items ON (inventories.item_id = items.id)
                  WHERE characters.character_id = @character_id;";
            MySqlParameter charIdParameter = new MySqlParameter("@character_id", charId);
            cmd.Parameters.Add(charIdParameter);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string imgUrl = rdr.GetString(2);
                int hp = rdr.GetInt32(3);
                int ad = rdr.GetInt32(4);
                int iq = rdr.GetInt32(5);
                int luck = rdr.GetInt32(6);
                int charisma = rdr.GetInt32(7);
                int dex = rdr.GetInt32(8);
                int equippable = rdr.GetInt32(9);
                Item thisItem = new Item(name, imgUrl, hp, ad, iq, luck, charisma, dex, equippable);
                thisItem.SetId(id);

                if (equippable != -1)
                {
                    _equippables.Add(thisItem);
                }
                else
                {
                    _disposables.Add(thisItem);
                }
            }
            conn.Dispose();
        }

        public void UpdateInventoryStats()
        {
            foreach (Item equippable in _equippables)
            {
                _health += equippable.GetHealth();
                _attackDamage += equippable.GetAttackDamage();
                _intelligence += equippable.GetIntelligence();
                _luck += equippable.GetLuck();
                _charisma += equippable.GetCharisma();
                _dexterity += equippable.GetDexterity();
            }
        }

        public int GetHP()
        {
            return _health;
        }

        public int GetAD()
        {
            return _attackDamage;
        }

        public int GetIQ()
        {
            return _intelligence;
        }

        public int GetLCK()
        {
            return _luck;
        }

        public int GetCHR()
        {
            return _charisma;
        }

        public int GetDexterity()
        {
            return _dexterity;
        }

        public List<Item> GetEquippables()
        {
            return _equippables;
        }

        public List<Item> GetDisposables()
        {
            return _disposables;
        }

        public void AddItem(int itemId)
        {
            MySqlConnector conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO inventories (character_id, item_id) VALUES (@character_id, @item_id);";
            MySqlParameter charIdPara = new MySqlParameter("@character_id", _charId);
            MySqlParameter itemIdPara = new MySqlParameter("@item_id", itemId);
            cmd.Parameters.Add(charIdPara);
            cmd.Parameters.Add(itemIdPara);
            cmd.ExecuteNonQuery();
            conn.Dispose();
            this.UpdateInventoryStats();
        }

        public void RemoveItem(int itemId)
        {
            MySqlConnector conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"REMOVE FROM inventories WHERE character_id = @character_id AND item_id = @item_id;";
            MySqlParameter charIdPara = new MySqlParameter("@character_id", _charId);
            MySqlParameter itemIdPara = new MySqlParameter("@item_id", itemId);
            cmd.Parameters.Add(charIdPara);
            cmd.Parameters.Add(itemIdPara);
            cmd.ExecuteNonQuery();
            conn.Dispose();
            this.UpdateInventoryStats();
        }
    }
}
