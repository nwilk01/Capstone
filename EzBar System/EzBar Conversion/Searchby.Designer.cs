namespace EzBar_Conversion
{
    partial class Searchby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.liquorlist = new System.Windows.Forms.ListView();
            this.Ingredient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.returnback = new System.Windows.Forms.Button();
            this.searchresult = new System.Windows.Forms.ListView();
            this.Recipe_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ingredients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buydrink = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // liquorlist
            // 
            this.liquorlist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.liquorlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ingredient});
            this.liquorlist.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.liquorlist.Location = new System.Drawing.Point(12, 12);
            this.liquorlist.Name = "liquorlist";
            this.liquorlist.Scrollable = false;
            this.liquorlist.Size = new System.Drawing.Size(140, 304);
            this.liquorlist.TabIndex = 0;
            this.liquorlist.UseCompatibleStateImageBehavior = false;
            // 
            // Ingredient
            // 
            this.Ingredient.Text = "Ingredient";
            this.Ingredient.Width = 130;
            // 
            // returnback
            // 
            this.returnback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.returnback.Location = new System.Drawing.Point(12, 322);
            this.returnback.Name = "returnback";
            this.returnback.Size = new System.Drawing.Size(140, 38);
            this.returnback.TabIndex = 2;
            this.returnback.Text = "Back";
            this.returnback.UseVisualStyleBackColor = true;
            this.returnback.Click += new System.EventHandler(this.returnback_Click);
            // 
            // searchresult
            // 
            this.searchresult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchresult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Recipe_Name,
            this.ingredients});
            this.searchresult.Location = new System.Drawing.Point(158, 12);
            this.searchresult.Name = "searchresult";
            this.searchresult.Scrollable = false;
            this.searchresult.Size = new System.Drawing.Size(514, 304);
            this.searchresult.TabIndex = 4;
            this.searchresult.UseCompatibleStateImageBehavior = false;
            // 
            // Recipe_Name
            // 
            this.Recipe_Name.Text = "Drink";
            this.Recipe_Name.Width = 150;
            // 
            // ingredients
            // 
            this.ingredients.Text = "Ingredients";
            this.ingredients.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ingredients.Width = 405;
            // 
            // buydrink
            // 
            this.buydrink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buydrink.Location = new System.Drawing.Point(542, 322);
            this.buydrink.Name = "buydrink";
            this.buydrink.Size = new System.Drawing.Size(130, 38);
            this.buydrink.TabIndex = 5;
            this.buydrink.Text = "Buy Drink";
            this.buydrink.UseVisualStyleBackColor = true;
            this.buydrink.Click += new System.EventHandler(this.buydrink_Click);
            // 
            // Searchby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.buydrink);
            this.Controls.Add(this.searchresult);
            this.Controls.Add(this.returnback);
            this.Controls.Add(this.liquorlist);
            this.Name = "Searchby";
            this.Text = "EzBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView liquorlist;
        private System.Windows.Forms.Button returnback;
        private System.Windows.Forms.ListView searchresult;
        private System.Windows.Forms.ColumnHeader Recipe_Name;
        private System.Windows.Forms.ColumnHeader Ingredient;
        private System.Windows.Forms.Button buydrink;
        private System.Windows.Forms.ColumnHeader ingredients;
    }
}