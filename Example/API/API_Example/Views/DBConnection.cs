﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace API_Example.Views
{
    public static class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            string ConnString = @"Server =swin.database.windows.net;
                                  Database=DAD;User Id=DAD; Password=R@ndom!1";
            return new SqlConnection(ConnString);
        }
    }
}