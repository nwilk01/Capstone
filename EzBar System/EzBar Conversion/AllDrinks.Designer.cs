namespace EzBar_Conversion
{
    partial class AllDrinks
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
            this.drinklist = new System.Windows.Forms.ListView();
            this.Drink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ingredients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.returnback = new System.Windows.Forms.Button();
            this.buydrink = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drinklist
            // 
            this.drinklist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drinklist.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.drinklist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Drink,
            this.ingredients});
            this.drinklist.Location = new System.Drawing.Point(12, 51);
            this.drinklist.Name = "drinklist";
            this.drinklist.Size = new System.Drawing.Size(660, 260);
            this.drinklist.TabIndex = 0;
            this.drinklist.UseCompatibleStateImageBehavior = false;
            // 
            // Drink
            // 
            this.Drink.Text = "Drink";
            this.Drink.Width = 150;
            // 
            // ingredients
            // 
            this.ingredients.Text = "Ingredients";
            this.ingredients.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ingredients.Width = 510;
            // 
            // returnback
            // 
            this.returnback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.returnback.Location = new System.Drawing.Point(12, 3);
            this.returnback.Name = "returnback";
            this.returnback.Size = new System.Drawing.Size(104, 42);
            this.returnback.TabIndex = 1;
            this.returnback.Text = "Back";
            this.returnback.UseVisualStyleBackColor = true;
            this.returnback.Click += new System.EventHandler(this.returnback_Click);
            // 
            // buydrink
            // 
            this.buydrink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buydrink.Location = new System.Drawing.Point(532, 317);
            this.buydrink.Name = "buydrink";
            this.buydrink.Size = new System.Drawing.Size(140, 42);
            this.buydrink.TabIndex = 2;
            this.buydrink.Text = "Buy Drink";
            this.buydrink.UseVisualStyleBackColor = true;
            this.buydrink.Click += new System.EventHandler(this.buydrink_Click);
            // 
            // AllDrinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.buydrink);
            this.Controls.Add(this.returnback);
            this.Controls.Add(this.drinklist);
            this.Name = "AllDrinks";
            this.Text = "EzBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView drinklist;
        private System.Windows.Forms.Button returnback;
        private System.Windows.Forms.ColumnHeader Drink;
        private System.Windows.Forms.ColumnHeader ingredients;
        private System.Windows.Forms.Button buydrink;
    }
}