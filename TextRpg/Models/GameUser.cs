using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class GameUser
    {
        private int _id;
        private string _name;
        private string _username;
        private string _password;
        private string _email;
        private static Character _character;

        public GameUser(string name, string username, string password, string email, int Id = 0)
        {
            _name = name;
            _username = username;
            _password = password;
            _email = email;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetUserName()
        {
            return _username;
        }

        public string GetPassword()
        {
            return _password;
        }

        public string GetEmail()
        {
            return _email;
        }

        public Character GetCharacter()
        {
            MySqlConnector = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM characters WHERE user_id = @user_id;";
            var userIdPara = new MySqlParameter("@user_id", _id);
            cmd.Parameters.Add(userIdPara);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id =  0;
            string name = "";
            int level = 0;
            int exp = 0;
            int hp = 0;
            int ad = 0;
            int iq = 0;
            int dex = 0;
            int lck = 0;
            int charisma = 0;

            while (rdr.Read())
            {
                int id =  rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int level = rdr.GetInt32(2);
                int exp = rdr.GetInt32(3);
                int hp = rdr.GetInt32(4);
                int ad = rdr.GetInt32(5);
                int iq = rdr.GetInt32(6);
                int dex = rdr.GetInt32(7);
                int lck = rdr.GetInt32(8);
                int charisma = rdr.GetInt32(9);
            }
            Character thisCharacter = new Character(name, level, exp, hp, ad, iq, dex, lck, charisma, id);
            thisCharacter.SetId(id);
            return thisCharacter;

        }
    }
}
