﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EDnevnikAM
{
    class Konekcija
    {
        static public SqlConnection Connect()
        {
            string CS = ConfigurationManager.ConnectionStrings["Kuca"].ConnectionString;
            SqlConnection veza = new SqlConnection(CS);
            return veza;
        }
    }
}
