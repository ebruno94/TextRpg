using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class User
    {
        private string _name;
        private string _username;
        private string _password;
        private string _email;
        private static Character _character;

        public User(string name, string username, string password, string email, int Id = 0)
        {
            _name = name;
            _username = username;
            _password = password;
            _email = email;
        }
    }
}
