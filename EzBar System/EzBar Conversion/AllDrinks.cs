/************************************************************************************************
/ Nathan Wilk                                                                                   /
/ 4/26/2017                                                                                     /
/ This code is for the form to when a user has selected to pick a drink from all available      /
/ drinks. It populates all possible drinks to be made from the contents of the machine          /
/ upon startup of the form. This cs file has many similar functions to the search by file.      /
************************************************************************************************/



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
using RaspberryPiDotNet;

namespace EzBar_Conversion
{
    public partial class AllDrinks : Form
    {
        
        // Constructor which calls the start function to populate the ListView
        public AllDrinks()
        {
            InitializeComponent();
            drinklist.View = View.Details;
            displaydrinks();
        }

        // Kinda of redunant function that I am scared to delete in case it causes the code to stop working
        private void displaydrinks()
        {
            getRPK();
        }

        // Gets all the possible recipes that can be made from the machines in the drinks
        private void getRPK()
        {
            var connection = ConnectionFactory.Create();
            DataTable recipes = new DataTable();    

            string RPKquery = "Select Distinct R_PK from Recipes;";
            MySqlDataAdapter RPKreturn = new MySqlDataAdapter(RPKquery, connection);
            RPKreturn.Fill(recipes);
            
            connection.Close();
           
            for (int i = 0; i < recipes.Rows.Count; i++)
            {
                DataRow RPKR = recipes.Rows[i];
                drinklookup(RPKR["R_PK"].ToString());
            }
        }

        // Function that finds the number of ingredients and name of the recipes and calls a
        // function that checks to see if those ingredients exist in the machine
        private void drinklookup(string RPK)
        {
            DataTable NOI = new DataTable();
            bool possible = false;
            var connection = ConnectionFactory.Create();
            string NOIquery = "Select NOI, Recipe_Name From Recipes Where R_PK = '" + RPK + "';";
            MySqlDataAdapter NOIreturn = new MySqlDataAdapter(NOIquery, connection);
            NOIreturn.Fill(NOI);

            connection.Close();

            // Dependent on the number of ingredients calls a function to check if ingredients exist
            for (int i = 0; i < NOI.Rows.Count; i++)
            {
                DataRow NOIR = NOI.Rows[i];
                switch (NOIR["NOI"].ToString())
                {
                    case "1":
                        possible = oneingredientloookup(RPK);
                        break;
                    case "2":
                        possible = twoingredientloookup(RPK);
                        break;
                    case "3":
                        possible = threeingredientloookup(RPK);
                        break;
                    case "4":
                        possible = fouringredientloookup(RPK);
                        break;
                    case "5":
                        possible = fiveingredientloookup(RPK);
                        break;
                }
                if (possible)
                {
                    displaydrinks(NOIR["Recipe_Name"].ToString(), NOIR["NOI"].ToString(), RPK);
                }
            }
        }

        // The next 5 functions are to check whether the number of ingredients are all present.
        // The functions returns true or false whether all the ingredients are in the machine       
        private bool oneingredientloookup(string RPK)
        {
            var connection = ConnectionFactory.Create();
            bool possible = true;
            DataTable GEDT = new DataTable();
            string getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 1st_Ingredient.Amount as 1stA From 1st_Ingredient  Where 1st_Ingredient.R_PK = '" + RPK + "';";
            MySqlDataAdapter ingredientReturn = new MySqlDataAdapter(getIngredientquery, connection);
            ingredientReturn.Fill(GEDT);

            connection.Close();

            for (int i = 0; i < GEDT.Rows.Count; i++)
            {
                DataRow DR = GEDT.Rows[i];
                possible = possible && inmachine(DR["1st"].ToString()) && getAmount(DR["1st"].ToString(), DR["1stA"].ToString());
            }

            return possible;
        }

        private bool twoingredientloookup(string RPK)
        {
            var connection = ConnectionFactory.Create();
            bool possible = true;
            DataTable GEDT = new DataTable();
            string getIngredientquery = "Select 1st_Ingredient.Ingredient As 1st, 2nd_Ingredient.Ingredient As 2nd, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA From 1st_Ingredient Inner Join 2nd_Ingredient Where 1st_Ingredient.R_PK = '" + RPK + "' And 2nd_Ingredient.R_PK = '" + RPK + "';";
            MySqlDataAdapter ingredientReturn = new MySqlDataAdapter(getIngredientquery, connection);
            ingredientReturn.Fill(GEDT);

            connection.Close();

            for (int i = 0; i < GEDT.Rows.Count; i++)
            {
                DataRow DR = GEDT.Rows[i];
                possible = possible && inmachine(DR["1st"].ToString()) && getAmount(DR["1st"].ToString(), DR["1stA"].ToString());
                possible = possible && inmachine(DR["2nd"].ToString()) && getAmount(DR["2nd"].ToString(), DR["2ndA"].ToString());
            }

            return possible;
        }

        private bool threeingredientloookup(string RPK)
        {
            var connection = ConnectionFactory.Create();
            bool possible = true;
            DataTable GEDT = new DataTable();
            string getIngredientquery = "Select 1st_Ingredient.Ingredient As 1st, 2nd_Ingredient.Ingredient As 2nd, 3rd_Ingredient.Ingredient As 3rd, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA, 3rd_Ingredient.Amount as 3rdA From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + RPK + "' and 2nd_Ingredient.R_PK = '" + RPK + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + RPK + "'; ";
            MySqlDataAdapter ingredientReturn = new MySqlDataAdapter(getIngredientquery, connection);
            ingredientReturn.Fill(GEDT);

            connection.Close();

            for (int i = 0; i < GEDT.Rows.Count; i++)
            {
                DataRow DR = GEDT.Rows[i];
                possible = possible && inmachine(DR["1st"].ToString()) && getAmount(DR["1st"].ToString(), DR["1stA"].ToString());
                possible = possible && inmachine(DR["2nd"].ToString()) && getAmount(DR["2nd"].ToString(), DR["2ndA"].ToString());
                possible = possible && inmachine(DR["3rd"].ToString()) && getAmount(DR["3rd"].ToString(), DR["3rdA"].ToString());
            }

            return possible;
        }

        private bool fouringredientloookup(string RPK)
        {
            var connection = ConnectionFactory.Create();
            bool possible = true;
            DataTable GEDT = new DataTable();
            string getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 2nd_Ingredient.Ingredient as 2nd, 3rd_Ingredient.Ingredient as 3rd, 4th_Ingredient.Ingredient as 4th, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA, 3rd_Ingredient.Amount as 3rdA, 4th_Ingredient.Amount as 4thA From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + RPK + "' and 2nd_Ingredient.R_PK = '" + RPK + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + RPK + "' Inner JOIN 4th_Ingredient On 4th_Ingredient.R_PK = '" + RPK + "'; ";
            MySqlDataAdapter ingredientReturn = new MySqlDataAdapter(getIngredientquery, connection);
            ingredientReturn.Fill(GEDT);

            connection.Close();

            for (int i = 0; i < GEDT.Rows.Count; i++)
            {
                DataRow DR = GEDT.Rows[i];
                possible = possible && inmachine(DR["1st"].ToString()) && getAmount(DR["1st"].ToString(), DR["1stA"].ToString());
                possible = possible && inmachine(DR["2nd"].ToString()) && getAmount(DR["2nd"].ToString(), DR["2ndA"].ToString());
                possible = possible && inmachine(DR["3rd"].ToString()) && getAmount(DR["3rd"].ToString(), DR["3rdA"].ToString());
                possible = possible && inmachine(DR["4th"].ToString()) && getAmount(DR["4th"].ToString(), DR["4thA"].ToString());
            }

            return possible;
        }

        private bool fiveingredientloookup(string RPK)
        {
            var connection = ConnectionFactory.Create();
            bool possible = true;
            DataTable GEDT = new DataTable();
            string getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 2nd_Ingredient.Ingredient as 2nd, 3rd_Ingredient.Ingredient as 3rd, 4th_Ingredient.Ingredient as 4th, 5th_Ingredient.Ingredient as 5th, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA, 3rd_Ingredient.Amount as 3rdA, 4th_Ingredient.Amount as 4thA, 5th_Ingredient.Amount as 5thA From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + RPK + "' and 2nd_Ingredient.R_PK = '" + RPK + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + RPK + "' Inner JOIN 4th_Ingredient On 4th_Ingredient.R_PK = '" + RPK + "' Inner JOIN 5th_Ingredient on 5th_Ingredient.R_PK = '" + RPK + "'; ";
            MySqlDataAdapter ingredientReturn = new MySqlDataAdapter(getIngredientquery, connection);
            ingredientReturn.Fill(GEDT);

            connection.Close();

            for (int i = 0; i < GEDT.Rows.Count; i++)
            {
                DataRow DR = GEDT.Rows[i];
                possible = possible && inmachine(DR["1st"].ToString()) && getAmount(DR["1st"].ToString(), DR["1stA"].ToString());
                possible = possible && inmachine(DR["2nd"].ToString()) && getAmount(DR["2nd"].ToString(), DR["2ndA"].ToString());
                possible = possible && inmachine(DR["3rd"].ToString()) && getAmount(DR["3rd"].ToString(), DR["3rdA"].ToString());
                possible = possible && inmachine(DR["4th"].ToString()) && getAmount(DR["4th"].ToString(), DR["4thA"].ToString());
                possible = possible && inmachine(DR["5th"].ToString()) && getAmount(DR["5th"].ToString(), DR["5thA"].ToString());
            }

            return possible;
        }

        // Given an input of an ingredient, returns a true or false dependent if the machine has it
        private bool inmachine(string ingredient)
        {
            var connection = ConnectionFactory.Create();
            DataTable ExistDT = new DataTable();
            string checkquery = "Select Exists(Select Genre from Inventory where Genre = '" + ingredient + "') As Exist;";            
            MySqlDataAdapter Existreturn = new MySqlDataAdapter(checkquery, connection);
            Existreturn.Fill(ExistDT);

            connection.Close();

            for (int i = 0; i < ExistDT.Rows.Count; i++)
            {
                DataRow DR = ExistDT.Rows[i];
                if (DR["Exist"].ToString() == "1")
                {
                    return true;
                }
            }
            return false;
        }

        // Function to see enough liquid is on hand to make drink
        private bool getAmount(string ingredient, string amount)
        {
            var connection = ConnectionFactory.Create();
            string Amountquery = "SELECT QoH FROM Inventory where Genre = '" + ingredient + "';";
            DataTable amountDT = new DataTable();
            MySqlDataAdapter Amountreturn = new MySqlDataAdapter(Amountquery, connection);
            Amountreturn.Fill(amountDT);

            connection.Close();
            for (int i=0; i<amountDT.Rows.Count; i++)
            {
                DataRow DR = amountDT.Rows[i];
                if (Convert.ToInt32(DR["QoH"].ToString()) < Convert.ToInt32(amount.ToString()))
                {
                    return false;
                }                
            }
            return true;
        }

        // Gets all the ingredients of a drink based on a case statement to search the correct amount of tables and populates a ListView
        private void displaydrinks(string drinkname, string NOI, string RPK)
        {
            var connection = ConnectionFactory.Create();
            DataTable recipeDT = new DataTable();
            string getIngredientquery="";
            switch (NOI)
            {
                case "1":
                    getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st From 1st_Ingredient  Where 1st_Ingredient.R_PK = '" + RPK + "';";
                    break;
                case "2":
                    getIngredientquery = "Select 1st_Ingredient.Ingredient As 1st, 2nd_Ingredient.Ingredient As 2nd From 1st_Ingredient Inner Join 2nd_Ingredient Where 1st_Ingredient.R_PK = '" + RPK + "' And 2nd_Ingredient.R_PK = '" + RPK + "';";
                    break;
                case "3":
                    getIngredientquery = "Select 1st_Ingredient.Ingredient As 1st, 2nd_Ingredient.Ingredient As 2nd, 3rd_Ingredient.Ingredient As 3rd From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + RPK + "' and 2nd_Ingredient.R_PK = '" + RPK + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + RPK + "'; ";
                    break;
                case "4":
                    getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 2nd_Ingredient.Ingredient as 2nd, 3rd_Ingredient.Ingredient as 3rd, 4th_Ingredient.Ingredient as 4th From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + RPK + "' and 2nd_Ingredient.R_PK = '" + RPK + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + RPK + "' Inner JOIN 4th_Ingredient On 4th_Ingredient.R_PK = '" + RPK + "'; ";
                    break;
                case "5":
                    getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 2nd_Ingredient.Ingredient as 2nd, 3rd_Ingredient.Ingredient as 3rd, 4th_Ingredient.Ingredient as 4th, 5th_Ingredient.Ingredient as 5th From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + RPK + "' and 2nd_Ingredient.R_PK = '" + RPK + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + RPK + "' Inner JOIN 4th_Ingredient On 4th_Ingredient.R_PK = '" + RPK + "' Inner JOIN 5th_Ingredient on 5th_Ingredient.R_PK = '" + RPK + "'; ";
                    break;
            }
            MySqlDataAdapter IngredientAdapter = new MySqlDataAdapter(getIngredientquery, connection);
            IngredientAdapter.Fill(recipeDT);

            connection.Close();

            for (int i = 0; i < recipeDT.Rows.Count; i++)
            {
                DataRow DR = recipeDT.Rows[i];
                string ingredient = string.Empty;
                ListViewItem item = new ListViewItem(drinkname);
                switch (NOI)
                {
                    case "1":
                        ingredient = DR["1st"].ToString();
                        item.SubItems.Add(ingredient);
                        break;
                    case "2":
                        ingredient = DR["1st"].ToString() + ", " + DR["2nd"].ToString();
                        item.SubItems.Add(ingredient);
                        
                        break;
                    case "3":
                        ingredient = DR["1st"].ToString() + ", " + DR["2nd"].ToString() + ", " + DR["3rd"].ToString();
                        item.SubItems.Add(ingredient);                        
                        break;
                    case "4":
                        ingredient = DR["1st"].ToString() + ", " + DR["2nd"].ToString() + ", " + DR["3rd"].ToString() + ", " + DR["4th"].ToString();
                        item.SubItems.Add(ingredient);                        
                        break;
                    case "5":
                        ingredient = DR["1st"].ToString() + ", " + DR["2nd"].ToString() + ", " + DR["3rd"].ToString() + ", " + DR["4th"].ToString() + ", " + DR["5th"].ToString();
                        item.SubItems.Add(ingredient);                        
                        break;
                }
                drinklist.Items.Add(item);
                item.Font = new System.Drawing.Font("Arial", 12);
            }
        }

        // Returns the user to the homescreen
        private void returnback_Click(object sender, EventArgs e)
        {
            HomeScreen enter = new HomeScreen();
            this.Hide();
            var display = enter.ShowDialog();            
        }

        // Function that is called when a user buys a drink. It takes the drinked selected and finds all the ingredients and their respective amounts 
        private void buydrink_Click(object sender, EventArgs e)
        {
            var connection = ConnectionFactory.Create();
            DataTable RPK = new DataTable();
            DataTable recipeDT = new DataTable();
            string getIngredientquery = string.Empty;            
            string localsquery = string.Empty;
            int NOI = 0;
            string costquery = "Select Cost FROM Recipes Where Recipe_Name = '" + drinklist.SelectedItems[0].Text + "';";
            string findRPKquery = "Select R_PK, NOI from Recipes Where Recipe_Name = '" + drinklist.SelectedItems[0].Text + "';";
            MySqlDataAdapter returnRPK = new MySqlDataAdapter(findRPKquery, connection);
            returnRPK.Fill(RPK);

            for (int i = 0; i < RPK.Rows.Count; i++)
            {
                DataRow DR = RPK.Rows[i];
                NOI = Convert.ToInt32(DR["NOI"].ToString());
                switch (NOI)
                {
                    case 1:
                        getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 1st_Ingredient.Amount as 1stA From 1st_Ingredient  Where 1st_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "';";
                        break;
                    case 2:
                        getIngredientquery = "Select 1st_Ingredient.Ingredient As 1st, 2nd_Ingredient.Ingredient As 2nd, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA From 1st_Ingredient Inner Join 2nd_Ingredient Where 1st_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "' And 2nd_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "';";                        
                        break;
                    case 3:
                        getIngredientquery = "Select 1st_Ingredient.Ingredient As 1st, 2nd_Ingredient.Ingredient As 2nd, 3rd_Ingredient.Ingredient As 3rd, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA, 3rd_Ingredient.Amount as 3rdA From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "' and 2nd_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "'; ";
                        break;
                    case 4:
                        getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 2nd_Ingredient.Ingredient as 2nd, 3rd_Ingredient.Ingredient as 3rd, 4th_Ingredient.Ingredient as 4th, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA, 3rd_Ingredient.Amount as 3rdA, 4th_Ingredient.Amount as 4thA From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "' and 2nd_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "' Inner JOIN 4th_Ingredient On 4th_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "'; ";
                        break;
                    case 5:
                        getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st, 2nd_Ingredient.Ingredient as 2nd, 3rd_Ingredient.Ingredient as 3rd, 4th_Ingredient.Ingredient as 4th, 5th_Ingredient.Ingredient as 5th, 1st_Ingredient.Amount as 1stA, 2nd_Ingredient.Amount as 2ndA, 3rd_Ingredient.Amount as 3rdA, 4th_Ingredient.Amount as 4thA, 5th_Ingredient.Amount as 5thA From 1st_Ingredient Inner Join 2nd_Ingredient ON 1st_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "' and 2nd_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "'Inner JOIN 3rd_Ingredient On 3rd_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "' Inner JOIN 4th_Ingredient On 4th_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "' Inner JOIN 5th_Ingredient on 5th_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "'; ";
                        break;
                }
            }         

            MySqlDataAdapter IngredientAdapter = new MySqlDataAdapter(getIngredientquery, connection);
            IngredientAdapter.Fill(recipeDT);

            connection.Close();

            // Based on the number of ingredients its calls a function to activate the pins associated with their ingredients
            for (int i = 0; i < recipeDT.Rows.Count; i++)
            {
                DataRow DR = recipeDT.Rows[i];                             
                switch (NOI)
                {
                    case 1:
                        localsquery = "SELECT LocationNumber, QOH FROM Inventory Where Genre = '" + DR["1st"].ToString() + "';";
                        int[] AmountsA = new int[1];
                        AmountsA[0] = Convert.ToInt32(DR["1stA"].ToString());
                        break;
                    case 2:
                        localsquery = "SELECT LocationNumber, QOH FROM Inventory Where Genre = '" + DR["1st"].ToString() + "' OR Genre = '" + DR["2nd"].ToString() + "';";
                        int[] AmountsB = new int[2];
                        AmountsB[0] = Convert.ToInt32(DR["1stA"].ToString());
                        AmountsB[1] = Convert.ToInt32(DR["2ndA"].ToString());
                        activatepins(localsquery, AmountsB);
                        break;
                    case 3:
                        localsquery = "SELECT LocationNumber, QOH FROM Inventory Where Genre = '" + DR["1st"].ToString() + "' OR Genre = '" + DR["2nd"].ToString() + "' OR Genre = '" + DR["3rd"].ToString() + "';";
                        int[] AmountsC = new int[3];
                        AmountsC[0] = Convert.ToInt32(DR["1stA"].ToString());
                        AmountsC[1] = Convert.ToInt32(DR["2ndA"].ToString());
                        AmountsC[2] = Convert.ToInt32(DR["3rdA"].ToString());
                        activatepins(localsquery, AmountsC);
                        break;
                    case 4:
                        localsquery = "SELECT LocationNumber, QOH FROM Inventory Where Genre = '" + DR["1st"].ToString() + "' OR Genre = '" + DR["2nd"].ToString() + "' OR Genre = '" + DR["3rd"].ToString() + "' OR Genre = '" + DR["4th"].ToString() + "';";
                        int[] AmountsD = new int[4];
                        AmountsD[0] = Convert.ToInt32(DR["1stA"].ToString());
                        AmountsD[1] = Convert.ToInt32(DR["2ndA"].ToString());
                        AmountsD[2] = Convert.ToInt32(DR["3rdA"].ToString());
                        AmountsD[3] = Convert.ToInt32(DR["4thA"].ToString());
                        activatepins(localsquery, AmountsD);
                        break;
                    case 5:
                        localsquery = "SELECT LocationNumber, QOH FROM Inventory Where Genre = '" + DR["1st"].ToString() + "' OR Genre = '" + DR["2nd"].ToString() + "' OR Genre = '" + DR["3rd"].ToString() + "'OR Genre = '" + DR["4th"].ToString() + "' OR Genre = '" + DR["5th"].ToString() + "';";
                        int[] AmountsE = new int[5];
                        AmountsE[0] = Convert.ToInt32(DR["1stA"].ToString());
                        AmountsE[1] = Convert.ToInt32(DR["2ndA"].ToString());
                        AmountsE[2] = Convert.ToInt32(DR["3rdA"].ToString());
                        AmountsE[3] = Convert.ToInt32(DR["4thA"].ToString());
                        AmountsE[3] = Convert.ToInt32(DR["5thA"].ToString());
                        activatepins(localsquery, AmountsE);
                        break;
                }                                
            }

            costLookup(costquery);
            LockScreen quit = new LockScreen();
            this.Hide();
            var display = quit.ShowDialog();
        }

        // Calls the functions from PinFuncationality to activate their pin for the time calculated by taking the Amount and dividing it by the flow rate
        private void activatepins(string query, int[] Amounts)
        {
            var connection = ConnectionFactory.Create();
            string updatequery = string.Empty;
            DataTable localinfoDT = new DataTable();
            MySqlDataAdapter infoDA = new MySqlDataAdapter(query, connection);
            infoDA.Fill(localinfoDT);

            connection.Close();

            for (int i = 0; i < localinfoDT.Rows.Count; i++)
            {
                DataRow DR = localinfoDT.Rows[i];
                switch (DR["LocationNumber"].ToString())
                {
                    case "1":
                        PinFunctionality.pos1((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "2":
                        PinFunctionality.pos2((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "3":
                        PinFunctionality.pos3((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "4":
                        PinFunctionality.pos4((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "5":
                        PinFunctionality.pos5((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "6":
                        PinFunctionality.pos6((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "7":
                        PinFunctionality.pos7((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';"; ;
                        update(updatequery);
                        break;
                    case "8":
                        PinFunctionality.pos8((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "9":
                        PinFunctionality.pos9((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                    case "10":
                        PinFunctionality.pos10((Amounts[i] / 7) * 1000);
                        updatequery = "UPDATE Inventory SET QoH = '" + (Convert.ToInt32(DR["QoH"].ToString()) - Amounts[i]).ToString() + "' WHERE LocationNumber = '" + DR["LocationNumber"].ToString() + "';";
                        update(updatequery);
                        break;
                }
            }
        }

        // Updates the inventory of the machine
        private void update(string query)
        {
            var connection = ConnectionFactory.Create();
            MySqlCommand updatecmd = new MySqlCommand(query, connection);
            updatecmd.ExecuteNonQuery();

            connection.Close();
        }

        private void costLookup(string query)
        {
            var connection = ConnectionFactory.Create();
            DataTable costDT = new DataTable();
            MySqlDataAdapter cost = new MySqlDataAdapter(query, connection);
            cost.Fill(costDT);

            for (int i = 0; i < costDT.Rows.Count; i++)
            {
                DataRow DR = costDT.Rows[i];
                findBill(DR["Cost"].ToString());
            }

            connection.Close();
        }

        // finds the current bill for the active user
        private void findBill(string cost)
        {
            var connection = ConnectionFactory.Create();
            string updatequery = string.Empty;
            DataTable totalBillDT = new DataTable();
            string currentbill = "SELECT Bill FROM ActiveUsers Where Pin = '" + LockScreen.pin + "';";
            MySqlDataAdapter bill = new MySqlDataAdapter(currentbill, connection);
            bill.Fill(totalBillDT);

            for (int i = 0; i < totalBillDT.Rows.Count; i++)
            {
                DataRow DR = totalBillDT.Rows[i];
                updatequery = "UPDATE ActiveUsers Set Bill = '" + (Convert.ToInt32(DR["Bill"].ToString()) + Convert.ToInt32(cost)).ToString() + "' WHERE Pin = '" + LockScreen.pin + "';";
                updateBill(updatequery);
            }

            connection.Close();
        }

        // Updates the current users bill
        private void updateBill(string query)
        {
            var connection = ConnectionFactory.Create();
            MySqlCommand updatecmd = new MySqlCommand(query, connection);
            updatecmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
