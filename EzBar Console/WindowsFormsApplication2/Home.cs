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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void newuser_Click(object sender, EventArgs e)
        {
            Random generate = new Random();
            int key = generate.Next(9999);
            while (key < 999)
            {
                key = generate.Next(9999);
            }
            MessageBox.Show(key.ToString());
            CC swipe = new CC(key);
            var dialogresult = swipe.ShowDialog();
        }

        private void checkout_Click_1(object sender, EventArgs e)
        {
            Payment leave = new Payment();
            this.Hide();
            var dialogresult = leave.ShowDialog();
        }
    }


}
