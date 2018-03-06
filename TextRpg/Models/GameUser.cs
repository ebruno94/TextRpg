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
        private int _roomNumber;
        private static Character _character;

        public GameUser(string name, string username, string password, string email, int roomNumber)
        {
            _name = name;
            _username = username;
            _password = password;
            _email = email;
            _roomNumber = roomNumber;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public int GetRoomNumber()
        {
            return _roomNumber;
        }

        public void SetRoomNumber(int num)
        {
            _roomNumber = num;
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

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO users (name, username, password, email, room_number, character_id) VALUES (@name, @username, @password, @email, @roomNumber, @characterId);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@GameUserName";
            name.Value = _name;
            cmd.Parameters.Add(name);

            MySqlParameter username = new MySqlParameter();
            username.ParameterName = "@GameUserUserName";
            username.Value = _username;
            cmd.Parameters.Add(username);

            MySqlParameter userPassword = new MySqlParameter("@GameUserPassword", _password);
            cmd.Parameters.Add(userPassword);

            MySqlParameter email = new MySqlParameter("@GameUserEmail", _email);
            cmd.Parameters.Add(email);

            MySqlParameter roomNumber = new MySqlParameter("@GameUserRoomNumber", _roomNumber);
            cmd.Parameters.Add(roomNumber);

            MySqlParameter characterId = new MySqlParameter("@GameUserCharacterId", _character.GetId());
            cmd.Parameters.Add(characterId);

            cmd.ExecuteNonQuery();

            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static GameUser Find(int userId)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM users WHERE id=@userId;";

          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@userId";
          searchId.Value = userId;
          cmd.Parameters.Add(searchId);

          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

          int id = 0;
          string name = "";
          string username = "";
          string password = "";
          string email = "";
          int roomNumber = 0;
          while (rdr.Read())
          {
            id = rdr.GetInt32(0);
            username = rdr.GetString(1);
            password = rdr.GetString(2);
            name = rdr.GetString(3);
            email = rdr.GetString(4);
            roomNumber = Int32.Parse(rdr.GetString(5));
          }

          GameUser myUser = new GameUser(name, username, password, email, roomNumber);
          myUser.SetId(id);

          conn.Close();
          if (!(conn == null))
          {
            conn.Dispose();
          }
          return myUser;
        }
        public static void Update(string name,string login,string password,string email, int roomNumber, int characterId, int userId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE users SET login=@login, name = @name, password = @password, email = @email, room_number = @room, character_id = @ characterId WHERE id = @userId;";

            MySqlParameter tempName = new MySqlParameter("@name", name);
            MySqlParameter tempLogin = new MySqlParameter("@login", login);
            MySqlParameter tempPassword = new MySqlParameter("@password", password);
            MySqlParameter tempEmail = new MySqlParameter("@email", email);
            MySqlParameter tempRoom = new MySqlParameter("@room", roomNumber);
            MySqlParameter tempCharacterId = new MySqlParameter("@characterId", characterId);
            MySqlParameter tempUserId = new MySqlParameter("@userId", userId);

            cmd.Parameters.Add(tempName);
            cmd.Parameters.Add(tempLogin);
            cmd.Parameters.Add(tempPassword);
            cmd.Parameters.Add(tempEmail);
            cmd.Parameters.Add(tempRoom);
            cmd.Parameters.Add(tempCharacterId);
            cmd.Parameters.Add(tempUserId);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static void Delete(int idDelete)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM users WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = idDelete;
            cmd.Parameters.Add(searchId);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public Character GetCharacter()
        {
            MySqlConnection conn = DB.Connection();
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
            int maxHp = 0;
            int hp = 0;
            int ad = 0;
            int iq = 0;
            int dex = 0;
            int lck = 0;
            int charisma = 0;
            int armor = 0;

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
            }
            Character thisCharacter = new Character(name, level, exp, maxHp, hp, armor, ad, iq, dex, lck, charisma, id);
            thisCharacter.SetId(id);
            return thisCharacter;

        }
    }
}
