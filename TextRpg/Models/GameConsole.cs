using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class GameConsole
    {
        private static string _gameLog;

        public GameConsole()
        {
            _gameLog = "";
        }

        public static void Append(string inputString)
        {
            _gameLog += inputString;
        }

        public static void SetGameLog(string inputString)
        {
            _gameLog = inputString;
        }
        public static String GetGameLog()
        {
            return _gameLog;
        }

    }

}
