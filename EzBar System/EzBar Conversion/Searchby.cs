/************************************************************************************************
/ Nathan Wilk                                                                                   /
/ 4/26/2017                                                                                     /
/ This code is for the form to when a user is trying to search by a liquor or mixer. Since      /
/ both pages were to do the same search with different input paramters, it is made under        /
/ one page. The constructor initalizes the page for the which search. The code uses ListViews   /
/ and ConnectionFactory to connect to the database. The form only outputs drinks that can       /
/ be made from the inventory. When a user wants to buy the program accesses PinFunctionality    /
/ to turn on the pin. This code has many similar functions to the Alldrinks file                /
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

namespace EzBar_Conversion
{
    public partial class Searchby : Form
    {
        int searchby;                                       // variable to store the type of search we have 
        public Searchby(int x)
        {
            InitializeComponent();
            initializesearch(x);                            // initalizes the search to be a liquor or mixer search
            liquorlist.SelectedIndexChanged += populate;    // updates the selectedindexchanged handler to include methods written in this file
            liquorlist.View = View.Details;                 // Sets the ListViews to have specific columns
            searchresult.View = View.Details;     
        }
        
        // Method to initialize the type of search
        private void initializesearch(int type)
        {
            if (type == 0)                                  // Sets the liquorlist ListView to be a liquor search
            {
                searchby = 0;
                for (int i = 0; i < liquorlist.Items.Count; i++)
                {
                    liquorlist.Items[i].Remove();
                }

                DataTable Inventory = new DataTable();
                DataTable Liquid = new DataTable();
                var connection = ConnectionFactory.Create();
                string dataquery = "Select Distinct Genre from Inventory;";
                MySqlDataAdapter datacmd = new MySqlDataAdapter(dataquery, connection);
                datacmd.Fill(Inventory);

                // Selects only the types of liquids that are Alcoholic from the inventory lsit
                for (int i = 0; i < Inventory.Rows.Count; i++)
                {
                    DataRow IN = Inventory.Rows[i];
                    string recipequery = "Select Distinct Genre from Liquids Where ABV>0 AND Genre = '" + IN["Genre"].ToString() + "';";
                    MySqlDataAdapter Genrecmd = new MySqlDataAdapter(recipequery, connection);
                    Genrecmd.Fill(Liquid);
                }

                // Populates the listView
                for (int i = 0; i < Liquid.Rows.Count; i++)
                {
                    DataRow AU = Liquid.Rows[i];

                    ListViewItem item = new ListViewItem(AU["Genre"].ToString());
                    item.Font = new System.Drawing.Font("Arial", 12);
                    liquorlist.Items.Add(item);
                }
                connection.Close();
            }
            else                                        // Sets the liquorlist ListView to be a mixer search
            {
                searchby = 1;
                for (int i = 0; i < liquorlist.Items.Count; i++)
                {
                    liquorlist.Items[i].Remove();
                }

                DataTable Inventory = new DataTable();
                DataTable Liquid = new DataTable();
                var connection = ConnectionFactory.Create();
                string dataquery = "Select Distinct Genre from Inventory;";
                MySqlDataAdapter datacmd = new MySqlDataAdapter(dataquery, connection);
                datacmd.Fill(Inventory);

                // Selects only the types of liquids that are non-alcoholic from the inventory lsit
                for (int i = 0; i < Inventory.Rows.Count; i++)
                {
                    DataRow IN = Inventory.Rows[i];
                    string recipequery = "Select Distinct Genre from Liquids Where ABV=0 AND Genre = '" + IN["Genre"].ToString() + "';";
                    MySqlDataAdapter Genrecmd = new MySqlDataAdapter(recipequery, connection);
                    Genrecmd.Fill(Liquid);
                }

                // Populates the listView
                for (int i = 0; i < Liquid.Rows.Count; i++)
                {
                    DataRow AU = Liquid.Rows[i];

                    ListViewItem item = new ListViewItem(AU["Genre"].ToString());
                    item.Font = new System.Drawing.Font("Arial", 12);
                    liquorlist.Items.Add(item);
                }
                connection.Close();

            }
        }

        // Function that is meant to act as an addition to IndexChanged event handler for ListViews. It first removes any items in the listView
        // then finds if the liquor or mixer is an ingredient in any recipe it returns its R_PK from the query
        private void populate(object sender, EventArgs e)
        {
            for (int i = 0; i < searchresult.Items.Count; i++)
            {
                searchresult.Items[i].Remove();
            }

            if (liquorlist.SelectedItems.Count > 0)
            {
                var connection = ConnectionFactory.Create();
                DataTable recipes = new DataTable();
                
                string dataquery1 = "Select R_PK from 1st_Ingredient Where Ingredient = '" + liquorlist.SelectedItems[0].Text + "';";
                MySqlDataAdapter datacmd = new MySqlDataAdapter(dataquery1, connection);
                datacmd.Fill(recipes);

                string dataquery2 = "Select R_PK from 2nd_Ingredient Where Ingredient = '" + liquorlist.SelectedItems[0].Text + "';";
                MySqlDataAdapter datacmd2 = new MySqlDataAdapter(dataquery2, connection);
                datacmd2.Fill(recipes);

                string dataquery3 = "Select R_PK from 3rd_Ingredient Where Ingredient = '" + liquorlist.SelectedItems[0].Text + "';";
                MySqlDataAdapter datacmd3 = new MySqlDataAdapter(dataquery3, connection);
                datacmd3.Fill(recipes);

                string dataquery4 = "Select R_PK from 4th_Ingredient Where Ingredient = '" + liquorlist.SelectedItems[0].Text + "';";
                MySqlDataAdapter datacmd4 = new MySqlDataAdapter(dataquery4, connection);
                datacmd4.Fill(recipes);

                string dataquery5 = "Select R_PK from 5th_Ingredient Where Ingredient = '" + liquorlist.SelectedItems[0].Text + "';";
                MySqlDataAdapter datacmd5 = new MySqlDataAdapter(dataquery5, connection);
                datacmd5.Fill(recipes);

                connection.Close();

                for (int i = 0; i < recipes.Rows.Count; i++)
                {
                    DataRow RPKR = recipes.Rows[i];
                    drinklookup(RPKR["R_PK"].ToString());
                }               
            }
        }


        // When given and input of a R_PK, it finds the number of ingredients in that recipe and it checks to see if the machine has all the ingredients for that recipe
        private void drinklookup(string RPK)
        {
            DataTable NOI = new DataTable();
            bool possible = false;
            var connection = ConnectionFactory.Create();
            string NOIquery = "Select NOI, Recipe_Name From Recipes Where R_PK = '" + RPK + "';";   
            MySqlDataAdapter NOIreturn = new MySqlDataAdapter(NOIquery, connection);
            NOIreturn.Fill(NOI);

            connection.Close();

            //based on the the NOI looks to see if machine has all the ingredients
            for (int i =0; i<NOI.Rows.Count;i++)
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
                if(possible)
                {
                    displaydrinks(NOIR["Recipe_Name"].ToString(), NOIR["NOI"].ToString(), RPK);                    
                }
            }            
        }

        // Gets all the ingredients of a drink based on a case statement to search the correct amount of tables and populates a ListView
        private void displaydrinks(string drinkname, string NOI, string RPK)
        {
            var connection = ConnectionFactory.Create();
            DataTable recipeDT = new DataTable();
            string getIngredientquery = "";
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

            // Statement to add the subitems in the Listview per their number of ingredients
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
                item.Font = new System.Drawing.Font("Arial", 12);
                searchresult.Items.Add(item);
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

            for (int i=0; i<ExistDT.Rows.Count; i++)
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
            for (int i = 0; i < amountDT.Rows.Count; i++)
            {
                DataRow DR = amountDT.Rows[i];
                if (Convert.ToInt32(DR["QoH"].ToString()) < Convert.ToInt32(amount.ToString()))
                {
                    return false;
                }
            }
            return true;
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
            string costquery = "Select Cost FROM Recipes Where Recipe_Name = '" + searchresult.SelectedItems[0].Text + "';";
            string findRPKquery = "Select R_PK, NOI from Recipes Where Recipe_Name = '" + searchresult.SelectedItems[0].Text + "';";
            MySqlDataAdapter returnRPK = new MySqlDataAdapter(findRPKquery, connection);
            returnRPK.Fill(RPK);

            for (int i = 0; i < RPK.Rows.Count; i++)
            {
                DataRow DR = RPK.Rows[i];
                NOI = Convert.ToInt32(DR["NOI"].ToString());
                switch (NOI)
                {
                    case 1:
                        getIngredientquery = "Select 1st_Ingredient.Ingredient as 1st From 1st_Ingredient  Where 1st_Ingredient.R_PK = '" + DR["R_PK"].ToString() + "';";
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

            for(int i =0; i<totalBillDT.Rows.Count;i++)
            {
                DataRow DR = totalBillDT.Rows[i];
                updatequery = "UPDATE ActiveUsers Set Bill = '" + (Convert.ToInt32(DR["Bill"].ToString()) + Convert.ToInt32(cost)).ToString() + "' WHERE Pin = '" + LockScreen.pin + "';";
                updateBill(updatequery);
            }            
        }

        // Updates the current users bill
        private void updateBill(string query)
        {
            var connection = ConnectionFactory.Create();
            MySqlCommand updatecmd = new MySqlCommand(query, connection);
            updatecmd.ExecuteNonQuery();
        }

        // Returns the user to the home screen
        private void returnback_Click(object sender, EventArgs e)
        {
            HomeScreen enter = new HomeScreen();
            this.Hide();
            var display = enter.ShowDialog();
        }
    }
}
