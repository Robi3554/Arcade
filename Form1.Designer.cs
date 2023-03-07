namespace Arcade
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.TicTacToeButton = new System.Windows.Forms.Button();
            this.SudokuButton = new System.Windows.Forms.Button();
            this.Minesweeper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a game:";
            // 
            // TicTacToeButton
            // 
            this.TicTacToeButton.Location = new System.Drawing.Point(19, 78);
            this.TicTacToeButton.Name = "TicTacToeButton";
            this.TicTacToeButton.Size = new System.Drawing.Size(148, 61);
            this.TicTacToeButton.TabIndex = 1;
            this.TicTacToeButton.Text = "Tic Tac Toe";
            this.TicTacToeButton.UseVisualStyleBackColor = true;
            this.TicTacToeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SudokuButton
            // 
            this.SudokuButton.Location = new System.Drawing.Point(19, 145);
            this.SudokuButton.Name = "SudokuButton";
            this.SudokuButton.Size = new System.Drawing.Size(148, 60);
            this.SudokuButton.TabIndex = 2;
            this.SudokuButton.Text = "Sudoku";
            this.SudokuButton.UseVisualStyleBackColor = true;
            this.SudokuButton.Click += new System.EventHandler(this.SudokuButton_Click);
            // 
            // Minesweeper
            // 
            this.Minesweeper.Location = new System.Drawing.Point(19, 211);
            this.Minesweeper.Name = "Minesweeper";
            this.Minesweeper.Size = new System.Drawing.Size(148, 60);
            this.Minesweeper.TabIndex = 3;
            this.Minesweeper.Text = "Minesweeper";
            this.Minesweeper.UseVisualStyleBackColor = true;
            this.Minesweeper.Click += new System.EventHandler(this.Minesweeper_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Minesweeper);
            this.Controls.Add(this.SudokuButton);
            this.Controls.Add(this.TicTacToeButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TicTacToeButton;
        private System.Windows.Forms.Button SudokuButton;
        private System.Windows.Forms.Button Minesweeper;
    }
}

