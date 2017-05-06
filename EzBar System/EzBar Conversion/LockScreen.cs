/****************************************************************************
/ Evan Mladinov                                                             /
/ 4/26/2017                                                                 /
/ The following code is a pin pad used in the Ezbar software. It takes      /
/ a 4 digit pin and check its against a pins held in a MySql database.      /
/ the pin is gather through click events and uses the ConnectionFactory     /
/ code to connect to the database.                                          /
****************************************************************************/

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

namespace EzBar_Conversion
{    
    public partial class LockScreen : Form
    {
        //declaring pin and count as global to be able to accessed by all functions
        static string[] pincode = new string[4];
        int count = 0;
        public static string pin;
        static bool flag = true;

        //Initalizes the pin locations to active
        public LockScreen()
        {
            InitializeComponent();
            pinenter.Text = "";
            pin = string.Empty;
            if (flag == true)
            {
                PinFunctionality.initalizepins();
                flag = false;
            }
        }

        //Checks when the 4th digit is entered if the pin was valid, is so opens home screen otherwise nothing. 
        private void usercheck()
        {            
            var connection = ConnectionFactory.Create();
            string pinquery = "SELECT Pin From ActiveUsers;";
            DataTable pinDT = new DataTable();            
            MySqlDataAdapter test = new MySqlDataAdapter(pinquery, connection);
            test.Fill(pinDT);

            connection.Close();

            string pincodestring = pincode[0] + pincode[1] + pincode[2] + pincode[3];            
            
            for (int i=0;i<pinDT.Rows.Count;i++)
            {
                DataRow DR = pinDT.Rows[i];
                if (DR["Pin"].ToString() == pincodestring)
                {
                    pin = pincodestring;
                    HomeScreen enter = new HomeScreen();                    
                    this.Hide();
                    var display = enter.ShowDialog();
                                        
                }
            }
            
            for (int x = 0; x < 4; x++)
            {
                pincode[x] = "";                
            }            
        }        

        private void check(string num)
        {
            pincode[count] = num;
            count++;            
            if (count == 4)
            {
                pinenter.Text = "";
                count = 0;                
                usercheck();                
            }
            else
            {
                pinenter.Text = pinenter.Text + "*";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = "1";
            check(num);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string num = "2";
            check(num);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string num = "3";
            check(num);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string num = "4";
            check(num);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string num = "5";
            check(num);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string num = "6";
            check(num);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string num = "7";
            check(num);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string num = "8";
            check(num);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string num = "9";
            check(num);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string num = "0";            
            check(num);
        }
    }
}
