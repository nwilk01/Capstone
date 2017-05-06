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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            activeUsers.SelectedIndexChanged += populate;
            activeUsers.View = View.Details;
            var connection = ConnectionFactory.Create();
            string dataquery = "Select Lname, Fname, Bill, CCnum, Exp, Pin From ActiveUsers";
            MySqlDataAdapter datacmd = new MySqlDataAdapter(dataquery, connection);
            DataTable users = new DataTable();
            datacmd.Fill(users);

            for(int i=0; i<users.Rows.Count;i++)
            {
                DataRow AU= users.Rows[i];
                ListViewItem item = new ListViewItem(AU["Lname"].ToString());
                item.SubItems.Add(AU["Fname"].ToString());
                item.SubItems.Add("$" + AU["Bill"].ToString());
                item.SubItems.Add(AU["CCNum"].ToString());
                item.SubItems.Add(AU["Exp"].ToString());
                item.SubItems.Add(AU["Pin"].ToString());
                item.Font = new System.Drawing.Font("Arial", 12);
                activeUsers.Items.Add(item);
            }
            connection.Close();
        }

        private void populate(object sender, EventArgs e)
        {
            if(activeUsers.SelectedItems.Count>0)
            { 
                ListViewItem item = activeUsers.SelectedItems[0];
                Fullname.Text = item.SubItems[0].Text + ", " + item.SubItems[1].Text;
                Bill.Text = item.SubItems[2].Text;
                CreditCard.Text = item.SubItems[3].Text;
                Expired.Text = item.SubItems[4].Text;
                pinbox.Text = item.SubItems[5].Text;                
            }
        }

        private void checkout_Click(object sender, EventArgs e)
        {
            var connection = ConnectionFactory.Create();
            string updatequery = "Delete From ActiveUsers Where CCNum = '" + CreditCard.Text + "';";
            MySqlCommand inputcmd = new MySqlCommand(updatequery, connection);
            inputcmd.ExecuteNonQuery();

            activeUsers.Items.Clear();

            string dataquery = "Select Lname, Fname, Bill, CCnum, Exp, Pin From ActiveUsers";
            MySqlDataAdapter datacmd = new MySqlDataAdapter(dataquery, connection);
            DataTable users = new DataTable();
            datacmd.Fill(users);

            for (int i = 0; i < users.Rows.Count; i++)
            {
                DataRow AU = users.Rows[i];
                ListViewItem item = new ListViewItem(AU["Lname"].ToString());
                item.SubItems.Add(AU["Fname"].ToString());
                item.SubItems.Add("$" + AU["Bill"].ToString());
                item.SubItems.Add(AU["CCNum"].ToString());
                item.SubItems.Add(AU["Exp"].ToString());
                item.SubItems.Add(AU["Pin"].ToString());
                item.Font = new System.Drawing.Font("Arial", 12);
                activeUsers.Items.Add(item);
            }
            connection.Close();

            Fullname.Text = string.Empty;
            Bill.Text = string.Empty;
            CreditCard.Text = string.Empty;
            Expired.Text = string.Empty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            var display = home.ShowDialog();
        }
    }
}
