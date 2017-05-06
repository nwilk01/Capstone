namespace WindowsFormsApplication2
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.newuser = new System.Windows.Forms.Button();
            this.checkout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newuser
            // 
            this.newuser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.newuser.Location = new System.Drawing.Point(12, 282);
            this.newuser.Name = "newuser";
            this.newuser.Size = new System.Drawing.Size(407, 216);
            this.newuser.TabIndex = 0;
            this.newuser.Text = "New User";
            this.newuser.UseVisualStyleBackColor = true;
            this.newuser.Click += new System.EventHandler(this.newuser_Click);
            // 
            // checkout
            // 
            this.checkout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkout.BackColor = System.Drawing.SystemColors.Control;
            this.checkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.checkout.Location = new System.Drawing.Point(12, 41);
            this.checkout.Name = "checkout";
            this.checkout.Size = new System.Drawing.Size(407, 216);
            this.checkout.TabIndex = 2;
            this.checkout.Text = "Check Out";
            this.checkout.UseVisualStyleBackColor = false;
            this.checkout.Click += new System.EventHandler(this.checkout_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication2.Properties.Resources.Capture;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1165, 620);
            this.Controls.Add(this.checkout);
            this.Controls.Add(this.newuser);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "EzBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newuser;
        private System.Windows.Forms.Button checkout;
    }
}

