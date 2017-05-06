/****************************************************************************
/ Nathan Wilk                                                               /
/ 4/26/2017                                                                 /
/ This code is the Home Screen for Ez Bar software. It includes the buttons /
/ to access the drink pages of the GUI.                                     /
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

namespace EzBar_Conversion
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();            
        }

        //Opens the alldrink form and closes the homepage
        private void alldrinks_Click(object sender, EventArgs e)
        {
            AllDrinks enter = new AllDrinks();
            this.Hide();
            var display = enter.ShowDialog();
            
        }

        //Opens the searchby form and sends a 0 to signifiy it is a liquor search and closes the homepage
        private void liquorsearch_Click(object sender, EventArgs e)
        {
            Searchby enter = new Searchby(0);
            this.Hide();
            var display = enter.ShowDialog();
            
        }

        //Opens the searchby form and sends a 1 to signifiy it is a mixer search and closes the homepage
        private void mixersearch_Click(object sender, EventArgs e)
        {
            Searchby enter = new Searchby(1);
            this.Hide();
            var display = enter.ShowDialog();
            
        }

        //returns the user to the lock screen and closes the homepage
        private void returnlock_Click_1(object sender, EventArgs e)
        {
            LockScreen enter = new LockScreen();
            this.Hide();
            var display = enter.ShowDialog();
        }
    }
}
