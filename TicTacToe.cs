using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcade
{
    public partial class TicTacToe : Form
    {
        public static int scoreX = 0;
        public static int scoreO = 0;
        public static int draws = 0;
        public static int games = 0;

        char player = 'X';
        int turn = 0;
        int count = 0;

        public TicTacToe()
        {
            choosePlayer();
            InitializeComponent();
            scoreO = 0;
            scoreX = 0;
            draws = 0;
            games = 0;
        }

        private void choosePlayer()
        {
            if(count == 0)
            {
                player = 'X';
                count++;
            }
            else if(count == 1)
            {
                player = 'O';
                count--;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosePlayer();
            turn = 0;
            b1.Enabled = true; b1.Text = ""; b1.BackColor = Color.White;
            b2.Enabled = true; b2.Text = ""; b2.BackColor = Color.White;
            b3.Enabled = true; b3.Text = ""; b3.BackColor = Color.White;
            b4.Enabled = true; b4.Text = ""; b4.BackColor = Color.White;
            b5.Enabled = true; b5.Text = ""; b5.BackColor = Color.White;
            b6.Enabled = true; b6.Text = ""; b6.BackColor = Color.White;
            b7.Enabled = true; b7.Text = ""; b7.BackColor = Color.White;
            b8.Enabled = true; b8.Text = ""; b8.BackColor = Color.White;
            b9.Enabled = true; b9.Text = ""; b9.BackColor = Color.White;
            tableLayoutPanel1.Enabled = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.Enabled = false;
            if(player == 'O')
            {
                bt.BackColor = Color.Blue;
                bt.Text = "O";
                if((b1.Text == b2.Text && b2.Text == b3.Text && b2.Text != "") ||
                    (b4.Text == b5.Text && b5.Text == b6.Text && b5.Text != "") ||
                    (b7.Text == b8.Text && b8.Text == b9.Text && b8.Text != "") ||
                    (b1.Text == b4.Text && b4.Text == b7.Text && b4.Text != "") ||
                    (b2.Text == b5.Text && b5.Text == b8.Text && b5.Text != "") ||
                    (b3.Text == b6.Text && b6.Text == b9.Text && b6.Text != "") ||
                    (b1.Text == b5.Text && b5.Text == b9.Text && b5.Text != "") ||
                    (b3.Text == b5.Text && b5.Text == b7.Text && b5.Text != ""))
                {
                    MessageBox.Show("The winner is " + player.ToString() + " !!!");
                    tableLayoutPanel1.Enabled = false;
                    scoreO++;
                    games++;
                    
                }
                else if(turn == 8)
                {
                    MessageBox.Show("It's a Draw !");
                    draws++;
                    games++;

                }
                player = 'X';
            }
            else if(player == 'X')
            {
                bt.BackColor = Color.Red;
                bt.Text = "X";
                if ((b1.Text == b2.Text && b2.Text == b3.Text && b2.Text != "") ||
                    (b4.Text == b5.Text && b5.Text == b6.Text && b5.Text != "") ||
                    (b7.Text == b8.Text && b8.Text == b9.Text && b8.Text != "") ||
                    (b1.Text == b4.Text && b4.Text == b7.Text && b4.Text != "") ||
                    (b2.Text == b5.Text && b5.Text == b8.Text && b5.Text != "") ||
                    (b3.Text == b6.Text && b6.Text == b9.Text && b6.Text != "") ||
                    (b1.Text == b5.Text && b5.Text == b9.Text && b5.Text != "") ||
                    (b3.Text == b5.Text && b5.Text == b7.Text && b5.Text != ""))
                {
                    MessageBox.Show("The winner is " + player.ToString() + " !!!");
                    tableLayoutPanel1.Enabled = false;
                    scoreX++;
                    games++;
                }
                else if (turn == 8)
                {
                    MessageBox.Show("It's a Draw !");
                    draws++;
                    games++;
                }
                player = 'O';
            }
            turn++;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number of Games: " + games + "\n\nDraws: " + draws.ToString() + "\n\nScore O: " + scoreO.ToString() + "\n\nScore X: " + scoreX.ToString());
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
