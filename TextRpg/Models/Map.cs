using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TextRpg;
using System;

namespace TextRpg.Models
{
    public class Map
    {
        private int currentLocation;

        public Map()
        {
            currentLocation = null;
        }
    }

}
