using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace goodfood
{
    public static class ConnectionClass
    {
        private static SqlConnection conn;
        private static SqlCommand command;
        
        static ConnectionClass()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MenuDBConnectionString"].ToString();
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

                while (reader.Read())
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


        public static Menu GetMenuById(int id)
        {
            string query = String.Format("SELECT * FROM menu WHERE id =  '{0}'", id);
            Menu menu = null;

            try
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    double price = reader.GetDouble(3);
                    string image = reader.GetString(4);
                    

                    menu = new Menu(name, type, price, image);
                }
            }
            finally
            {
                conn.Close();
            }
            return menu;
        }

        public static void AddMenu(Menu menu)
        {
            string query = string.Format("INSERT INTO menu VALUES('{0}','{1}', '{2}','{3}')", menu.name, menu.type,menu.price, menu.image);
            command.CommandText = query;
            
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                command.Parameters.Clear();
            }
           
           
        }


        public static User LoginUser(string name, string password)
        {
            
            string query = string.Format("SELECT COUNT(*) FROM MenuDB.dbo.users WHERE name = '{0}'", name);
            command.CommandText = query;

            try
            {
                conn.Open();
                int amountOfUsers = (int) command.ExecuteScalar();

                if (amountOfUsers == 1)
                {
                    
                    query = string.Format("SELECT password FROM users WHERE name = '{0}'", name);
                    command.CommandText = query;
                    string dbPassword = command.ExecuteScalar().ToString();

                    if (dbPassword == password)
                    {
                        
                        query = string.Format("SELECT email, user_type FROM users WHERE name = '{0}'", name);
                        command.CommandText = query;

                        SqlDataReader reader = command.ExecuteReader();
                        User user = null;

                        while (reader.Read())
                        {
                            string email = reader.GetString(0);
                            string type = reader.GetString(1);

                            user = new User(name, password, email, type);
                        }
                        return user;
                    }
                    else
                    {
                        
                        return null;
                    }
                }
                else
                {
                    
                    return null;
                }
            }
            finally
            {

                conn.Close();
            }

        }

        public static string RegisterUser(User user)
        {

            string query = string.Format("SELECT COUNT(*) FROM users WHERE name = '{0}'", user.Name);
            command.CommandText = query;

            try
            {
                conn.Open();
                int amountOfUsers = (int)command.ExecuteScalar();

                if (amountOfUsers < 1)
                {

                    query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}')", user.Name, user.Password, user.Email, user.Type);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    return "User succesfully registered!";
                }
                else
                {
                    return "A user with this name already exists!";
                }
            }
            

            finally
            {
                conn.Close();
                
            }
        }

        public static void AddOrders(ArrayList orders)
        {
            try
            {
                
                command.CommandText = "INSERT INTO orders VALUES (@client, @product, @amount, @price, @date, @orderSent)";
                conn.Open();

                
                foreach (Order order in orders)
                {
                    command.Parameters.Add(new SqlParameter("@client", order.Client));
                    command.Parameters.Add(new SqlParameter("@product", order.Product));
                    command.Parameters.Add(new SqlParameter("@amount", order.Amount));
                    command.Parameters.Add(new SqlParameter("@price", order.Price));
                    command.Parameters.Add(new SqlParameter("@date", order.Date));
                    command.Parameters.Add(new SqlParameter("@orderSent", order.OrderDelivered));

                    
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
