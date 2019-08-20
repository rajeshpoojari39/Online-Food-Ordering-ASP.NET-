using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Code
{
    public static class ConnectionClass
    {
        private static SqlConnection conn;
        private static SqlCommand command;
        

        static ConnectionClass()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MenuConnection"].ToString();
            conn = new SqlConnection(connectionString);
            command = new SqlCommand("", conn);
        }

        public static ArrayList GetMenuByType(string menuType)
        {
            ArrayList list = new ArrayList();
            string query = string.Format("SELECT * FROM menu WHERE type LIKE '{0}'", menuType);

            try
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    double price = reader.GetDouble(3);
                    string image = reader.GetString(4);

                    Menu menu = new Menu(id, name, type, price, image);
                    list.Add(menu);
                }
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}