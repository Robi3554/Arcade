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
    public partial class Sudoku : Form
    {
        public static int n = 3;
        public static int sizeButton = 50;
        public int[,] map = new int[n * n, n * n];
        public Button[,] buttons = new Button[n * n,n * n];
        public Sudoku()
        {
            InitializeComponent();
            generateMap();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    flowLayoutPanel1.Controls.Remove(buttons[i, j]);
                }
            }
            generateMap();
        }

        public void generateMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    map[i, j] = (i * n + i / n + j) % (n * n) + 1;
                    buttons[i, j] = new Button();
                }
            }
            //MatrixShuffle();
            //SwapRowsBlocks();
            //SwapColsBlocks();
            //SwapBlocksRows();
            //SwapBlocksCols();
            Random random = new Random();
            for(int i = 0; i < 40; i++)
            {
                ShuffleMap(random.Next(0, 5));
            }
            createMap();
            hideNums();
        }

        public void ShuffleMap(int i)
        {
            switch (i)
            {
                case 0:
                    MatrixShuffle();
                    break;
                case 1:
                    SwapRowsBlocks();
                    break;
                case 2:
                    SwapColsBlocks();
                    break;
                case 3:
                    SwapBlocksRows();
                    break;
                case 4:
                    SwapBlocksCols();
                    break;
                default:
                    MatrixShuffle();
                    break;
            }
        }

        public void hideNums()
        {
            int N = 40;
            Random random = new Random();
            while(N > 0)
            {
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (!string.IsNullOrEmpty(buttons[i, j].Text))
                        {
                            int a = random.Next(0, 3);
                            buttons[i, j].Text = a == 0 ? "" : buttons[i, j].Text;
                            buttons[i, j].Enabled = a == 0 ? true : false;
                            if (a == 0)
                                N--;
                            if (N < 0)
                                break;
                        }
                    }
                    if (N < 0)
                        break;
                }
            }    
        }

        public void createMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = button;
                    button.Size = new Size(sizeButton, sizeButton);
                    button.Text = map[i, j].ToString();
                    button.MouseDown += myControl_MouseDown;
                    button.MouseDown += myControl_MouseDown2;
                    button.Location =new Point(j*sizeButton, i*sizeButton);
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
        }

        private void myControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button pressButton = sender as Button;
            string buttonText = pressButton.Text;
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (string.IsNullOrEmpty(buttonText))
                {
                    pressButton.Text = "9";
                }
                else
                {
                    int num = int.Parse(buttonText);
                    num--;
                    if (num == 0)
                        num = 9;
                    pressButton.Text = num.ToString();
                }
            }
        }

        private void myControl_MouseDown2(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button pressButton = sender as Button;
            string buttonText = pressButton.Text;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (string.IsNullOrEmpty(buttonText))
                {
                    pressButton.Text = "1";
                }
                else
                {
                    int num = int.Parse(buttonText);
                    num++;
                    if (num == 10)
                        num = 1;
                    pressButton.Text = num.ToString();
                }
            }
        }

        public void MatrixShuffle()
        {
            int[,] tMap = new int[n * n, n * n];

            for(int i = 0; i< n * n; i++)
            {
                for(int j = 0; j < n*n; j++)
                {
                    tMap[i, j] = map[j, i];
                }
            }
            map = tMap;
        }

        public void SwapBlocksRows()
        {
            Random random = new Random();
            var block1 = random.Next(0, n);
            var block2 = random.Next(0, n);
            while (block1 == block2)
            {
                block2 = random.Next(0, n);
            }
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for(int j= block1; j < block1 + n; j++)
                {
                    var temp = map[j, i];
                    map[j, i] = map[k, i];
                    map[k, i] = temp;
                    k++;
                }
            }
        }

        public void SwapBlocksCols()
        {
            Random random = new Random();
            var block1 = random.Next(0, n);
            var block2 = random.Next(0, n);
            while (block1 == block2)
            {
                block2 = random.Next(0, n);
            }
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = map[i, j];
                    map[i, j] = map[i, k];
                    map[i, k] = temp;
                    k++;
                }
            }
        }

        public void SwapRowsBlocks()
        {
            Random random = new Random();
            var block = random.Next(0, n);
            var row1 = random.Next(0, n);
            var line1 = block * n + row1;
            var row2 = random.Next(0, n);

            while(row1 == row2)
            {
                row2 =random.Next(0, n);
            }
            var line2 = block * n + row2;
            for(int i = 0; i < n * n; i++)
            {
                var temp = map[line1, i];
                map[line1, i] = map[line2, i];
                map[line2, i] = temp;
            }
        }

        public void SwapColsBlocks()
        {
            Random random = new Random();
            var block = random.Next(0, n);
            var row1 = random.Next(0, n);
            var line1 = block * n + row1;
            var row2 = random.Next(0, n);

            while (row1 == row2)
            {
                row2 = random.Next(0, n);
            }
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = map[i, line1];
                map[i, line1] = map[i, line2];
                map[i, line2] = temp;
            }
        }

        private void Sudoku_Load(object sender, EventArgs e)
        {

        }

        private void Check_Click(object sender, EventArgs e)
        {

            for(int i= 0; i < n * n; i++)
            {
                for(int j = 0; j < n * n; j++)
                {
                    var btnText = buttons[i, j].Text;
                    if(btnText != map[i, j].ToString())
                    {
                        MessageBox.Show("Try Again !");
                        return;
                    }
                }
            }

            MessageBox.Show("You Win !");
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
