namespace EzBar_Conversion
{
    partial class HomeScreen
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
            this.alldrinks = new System.Windows.Forms.Button();
            this.liquorsearch = new System.Windows.Forms.Button();
            this.mixersearch = new System.Windows.Forms.Button();
            this.returnlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // alldrinks
            // 
            this.alldrinks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.alldrinks.Location = new System.Drawing.Point(10, 23);
            this.alldrinks.Name = "alldrinks";
            this.alldrinks.Size = new System.Drawing.Size(218, 147);
            this.alldrinks.TabIndex = 0;
            this.alldrinks.Text = "Drinks";
            this.alldrinks.UseVisualStyleBackColor = true;
            this.alldrinks.Click += new System.EventHandler(this.alldrinks_Click);
            // 
            // liquorsearch
            // 
            this.liquorsearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.liquorsearch.Location = new System.Drawing.Point(234, 23);
            this.liquorsearch.Name = "liquorsearch";
            this.liquorsearch.Size = new System.Drawing.Size(218, 147);
            this.liquorsearch.TabIndex = 1;
            this.liquorsearch.Text = "Search by Liquor";
            this.liquorsearch.UseVisualStyleBackColor = true;
            this.liquorsearch.Click += new System.EventHandler(this.liquorsearch_Click);
            // 
            // mixersearch
            // 
            this.mixersearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mixersearch.Location = new System.Drawing.Point(458, 23);
            this.mixersearch.Name = "mixersearch";
            this.mixersearch.Size = new System.Drawing.Size(218, 147);
            this.mixersearch.TabIndex = 2;
            this.mixersearch.Text = "Search by Mixer";
            this.mixersearch.UseVisualStyleBackColor = true;
            this.mixersearch.Click += new System.EventHandler(this.mixersearch_Click);
            // 
            // returnlock
            // 
            this.returnlock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.returnlock.Location = new System.Drawing.Point(10, 256);
            this.returnlock.Name = "returnlock";
            this.returnlock.Size = new System.Drawing.Size(666, 60);
            this.returnlock.TabIndex = 3;
            this.returnlock.Text = "Back";
            this.returnlock.UseVisualStyleBackColor = true;
            this.returnlock.Click += new System.EventHandler(this.returnlock_Click_1);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.returnlock);
            this.Controls.Add(this.mixersearch);
            this.Controls.Add(this.liquorsearch);
            this.Controls.Add(this.alldrinks);
            this.Name = "HomeScreen";
            this.Text = "EzBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button alldrinks;
        private System.Windows.Forms.Button liquorsearch;
        private System.Windows.Forms.Button mixersearch;
        private System.Windows.Forms.Button returnlock;
    }
}