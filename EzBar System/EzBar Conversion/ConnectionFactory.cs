/************************************************************************************************
/ Nathan Wilk                                                                                   /
/ 4/26/2017                                                                                     /
/ This code establishes a connection to the MySql databse. It has one function which generates  /
/ a connection that is to be used in the forms through this project                             /
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EzBar_Conversion
{
    public class ConnectionFactory
    {
        /* The ConnectionFactory class is used throughout the program to connect to the database. Instead of having to write out the credentials
         * and create a connection everytime, the line 'var connection = ConnectionFactory.Create();' is used in each function. This line makes
         * the variable 'connection' the connection string to the database.
         */
        public static MySqlConnection Create()
        {
            MySqlConnection connection;
            string server = "XXXXXXX",
                database = "XXXXXX",
                user = "XXXXXXX",
                password = "XXXXXXX";

            string connectionString = @"server=" + server + ";" + "UID=" + user + ";" + "password=" + password + ";" + "database=" + database + ";";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

            }
            // Exception Handling
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        break;

                    case 1045:
                        break;
                }
            }
            return connection;
        }
    }
}
