using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class GameConsole
    {
        private string _gameLog;

        public GameConsole()
        {
            _gameLog = "";
        }

        public void Append(string inputString)
        {
            _gameLog += inputString;
            Console.WriteLine(inputString);
        }

        public void SetGameLog(string inputString)
        {
            _gameLog = inputString;
        }
        public String GetGameLog()
        {
            return _gameLog;
        }

    }

}
