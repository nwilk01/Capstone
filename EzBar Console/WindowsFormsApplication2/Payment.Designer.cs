namespace WindowsFormsApplication2
{
    partial class Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            this.activeUsers = new System.Windows.Forms.ListView();
            this.Last = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.First = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Exp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fullname = new System.Windows.Forms.TextBox();
            this.CreditCard = new System.Windows.Forms.TextBox();
            this.Expired = new System.Windows.Forms.TextBox();
            this.Bill = new System.Windows.Forms.TextBox();
            this.checkout = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Pin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pinbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // activeUsers
            // 
            this.activeUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.activeUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Last,
            this.First,
            this.Total,
            this.CC,
            this.Exp,
            this.Pin});
            this.activeUsers.Location = new System.Drawing.Point(12, 12);
            this.activeUsers.Name = "activeUsers";
            this.activeUsers.Scrollable = false;
            this.activeUsers.Size = new System.Drawing.Size(491, 596);
            this.activeUsers.TabIndex = 0;
            this.activeUsers.UseCompatibleStateImageBehavior = false;
            // 
            // Last
            // 
            this.Last.Text = "Last Name";
            this.Last.Width = 163;
            // 
            // First
            // 
            this.First.Text = "First Name";
            this.First.Width = 163;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Total.Width = 168;
            // 
            // CC
            // 
            this.CC.Text = "Hidden";
            // 
            // Exp
            // 
            this.Exp.Text = "Hidden";
            // 
            // Fullname
            // 
            this.Fullname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fullname.BackColor = System.Drawing.SystemColors.Control;
            this.Fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Fullname.Location = new System.Drawing.Point(845, 97);
            this.Fullname.Multiline = true;
            this.Fullname.Name = "Fullname";
            this.Fullname.ReadOnly = true;
            this.Fullname.Size = new System.Drawing.Size(308, 51);
            this.Fullname.TabIndex = 1;
            // 
            // CreditCard
            // 
            this.CreditCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.CreditCard.Location = new System.Drawing.Point(845, 154);
            this.CreditCard.Multiline = true;
            this.CreditCard.Name = "CreditCard";
            this.CreditCard.ReadOnly = true;
            this.CreditCard.Size = new System.Drawing.Size(308, 51);
            this.CreditCard.TabIndex = 2;
            // 
            // Expired
            // 
            this.Expired.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Expired.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Expired.Location = new System.Drawing.Point(845, 211);
            this.Expired.Multiline = true;
            this.Expired.Name = "Expired";
            this.Expired.ReadOnly = true;
            this.Expired.Size = new System.Drawing.Size(308, 51);
            this.Expired.TabIndex = 3;
            // 
            // Bill
            // 
            this.Bill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Bill.Location = new System.Drawing.Point(845, 268);
            this.Bill.Multiline = true;
            this.Bill.Name = "Bill";
            this.Bill.ReadOnly = true;
            this.Bill.Size = new System.Drawing.Size(308, 51);
            this.Bill.TabIndex = 4;
            // 
            // checkout
            // 
            this.checkout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkout.Location = new System.Drawing.Point(845, 325);
            this.checkout.Name = "checkout";
            this.checkout.Size = new System.Drawing.Size(308, 72);
            this.checkout.TabIndex = 5;
            this.checkout.Text = "Check Out";
            this.checkout.UseVisualStyleBackColor = true;
            this.checkout.Click += new System.EventHandler(this.checkout_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(845, 537);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(308, 71);
            this.button2.TabIndex = 6;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(722, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(509, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 39);
            this.label2.TabIndex = 8;
            this.label2.Text = "Credit Card Number:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.Location = new System.Drawing.Point(580, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Expiration Date:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label4.Location = new System.Drawing.Point(681, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 39);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total Bill:";
            // 
            // Pin
            // 
            this.Pin.Text = "hidden";
            // 
            // pinbox
            // 
            this.pinbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pinbox.BackColor = System.Drawing.SystemColors.Control;
            this.pinbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.pinbox.Location = new System.Drawing.Point(845, 40);
            this.pinbox.Multiline = true;
            this.pinbox.Name = "pinbox";
            this.pinbox.ReadOnly = true;
            this.pinbox.Size = new System.Drawing.Size(308, 51);
            this.pinbox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label5.Location = new System.Drawing.Point(735, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 39);
            this.label5.TabIndex = 12;
            this.label5.Text = "Pin #:";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1165, 620);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pinbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkout);
            this.Controls.Add(this.Bill);
            this.Controls.Add(this.Expired);
            this.Controls.Add(this.CreditCard);
            this.Controls.Add(this.Fullname);
            this.Controls.Add(this.activeUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Payment";
            this.Text = "EzBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView activeUsers;
        private System.Windows.Forms.ColumnHeader Last;
        private System.Windows.Forms.ColumnHeader First;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader CC;
        private System.Windows.Forms.ColumnHeader Exp;
        private System.Windows.Forms.TextBox Fullname;
        private System.Windows.Forms.TextBox CreditCard;
        private System.Windows.Forms.TextBox Expired;
        private System.Windows.Forms.TextBox Bill;
        private System.Windows.Forms.Button checkout;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Pin;
        private System.Windows.Forms.TextBox pinbox;
        private System.Windows.Forms.Label label5;
    }
}