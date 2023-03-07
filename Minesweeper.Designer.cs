namespace Arcade
{
    partial class Minesweeper
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pointsTxt = new System.Windows.Forms.TextBox();
            this.flagTxt = new System.Windows.Forms.TextBox();
            this.Restart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pointsTxt);
            this.panel1.Controls.Add(this.flagTxt);
            this.panel1.Controls.Add(this.Restart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(539, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 433);
            this.panel1.TabIndex = 0;
            // 
            // pointsTxt
            // 
            this.pointsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsTxt.Location = new System.Drawing.Point(12, 285);
            this.pointsTxt.Name = "pointsTxt";
            this.pointsTxt.Size = new System.Drawing.Size(85, 36);
            this.pointsTxt.TabIndex = 2;
            this.pointsTxt.Text = "0";
            // 
            // flagTxt
            // 
            this.flagTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagTxt.Location = new System.Drawing.Point(12, 385);
            this.flagTxt.Name = "flagTxt";
            this.flagTxt.Size = new System.Drawing.Size(85, 36);
            this.flagTxt.TabIndex = 1;
            this.flagTxt.Text = "30";
            this.flagTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(3, 12);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(108, 31);
            this.Restart.TabIndex = 0;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 63);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back to Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 433);
            this.Controls.Add(this.panel1);
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Minesweeper_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox flagTxt;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.TextBox pointsTxt;
        private System.Windows.Forms.Button button1;
    }
}