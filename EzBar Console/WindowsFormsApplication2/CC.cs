using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication2
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
            string server = "XXXXXX",
                database = "XXXXXX",
                user = "XXXXXX",
                password = "XXXXXX";

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

    public partial class CC : Form
    {
        string pin;
        public CC(int key)
        {
            InitializeComponent();
            pin = key.ToString();
            textBox1.TextChanged += txtbox_TextChanged; //adds addition to event handler on form creation
        }

        private void txtbox_TextChanged(object sender, EventArgs e) //wrote to addition to base event handler
        {
            string[] data;
            if (textBox1.Text[textBox1.TextLength - 1] == ';') //only takes needed info
            {
                data = parse(textBox1.Text); // calls parser function
                dbUpload(data, textBox1.Text);
                this.Hide();
            }
        }
        public string[] parse(string Input)
        {
            string[] data;
            data = new string[4];
            //Parsing the Number
            string[] temp = Input.Split('^');
            string[] number = temp[0].Split('B');

            //Parsing the Name
            string[] namesplit = temp[1].Split('/');

            //Parsing the Date
            string[] extra = temp[2].Split('?');
            string exp = extra[0];
            string year = exp[0] + "" + exp[1];
            string month = exp[2] + "" + exp[3];

            //Parsing the Longitude Redundancy Check
            string LRC = extra[1];

            data[0] = namesplit[0];
            data[1] = namesplit[1];
            data[2] = number[1];
            data[3] = month + '/' + year;

            return data;
        }

        public void dbUpload(string[] data, string input)
        {
            var connection = ConnectionFactory.Create();
            string inputquery = "INSERT ActiveUsers(Pin, Bill, Lname, Fname, CCnum, Exp, Swiped) VALUES ('"+ pin + "', 0.00, '" + data[0] + "','" + data[1] + "','" + data[2] + "','" + data[3] + "','" + input + "');";
            MySqlCommand inputcmd = new MySqlCommand(inputquery, connection);
            inputcmd.ExecuteNonQuery();            
        }
    }
}
