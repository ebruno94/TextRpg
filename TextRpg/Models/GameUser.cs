using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;
using BCrypt.Net;

namespace TextRpg.Models
{
    public class GameUser
    {
        public int _id;
        public string _name;
        public string _username;
        public string _password;
        public string _email;
        public int _roomNumber;
        public static Character _character;

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

        public void SetCharacter(Character myCharacter)
        {
            _character = myCharacter;
        }

        public Character GetCharacter()
        {
            return _character;
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
            username = rdr.GetString(2);
            password = rdr.GetString(3);
            name = rdr.GetString(1);
            email = rdr.GetString(4);
            roomNumber = (int) rdr.GetInt32(5);
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

        public bool Save()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT username FROM users WHERE username=@userLogin;";
          MySqlParameter userLogin = new MySqlParameter("@userLogin", _username);
          cmd.Parameters.Add(userLogin);

          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

          string tempLogin = "";

          while(rdr.Read())
          {
            tempLogin = rdr.GetString(0);

          }

          conn.Close();
          if (!(conn == null))
          {
            conn.Dispose();
          }

          if (tempLogin == "")
          {
            conn = DB.Connection();
            conn.Open();
            cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO users (name, username, password, email) VALUES (@userName, @userUsername, @userPassword, @userEmail);";

            MySqlParameter name = new MySqlParameter("@userName", _name);
            MySqlParameter username = new MySqlParameter("@userUsername", _username);
            MySqlParameter password = new MySqlParameter("@userPassword", BCrypt.Net.BCrypt.HashPassword(_password));
            MySqlParameter email = new MySqlParameter ("@userEmail", _email);
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(username);
            cmd.Parameters.Add(password);
            cmd.Parameters.Add(email);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (!(conn == null))
            {
              conn.Dispose();
            }
            return true;
          }
          return false;
        }

        public static int Login(string login, string password)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM users WHERE username=@userLogin;";

          MySqlParameter userLogin = new MySqlParameter("@userLogin", login);
          cmd.Parameters.Add(userLogin);

          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

          bool flag = false;
          int myUserId = 0;
          string databasePassword = "";

          while (rdr.Read())
          {
            flag = true;
            myUserId = rdr.GetInt32(0);
            databasePassword = rdr.GetString(3);
          }

          rdr.Dispose();
          if (!(flag && BCrypt.Net.BCrypt.Verify(password, databasePassword) || password == databasePassword))
          {
            myUserId = 0;
          }

          conn.Close();
          if (!(conn == null))
          {
            conn.Dispose();
          }

          return myUserId;
        }
    }
}
