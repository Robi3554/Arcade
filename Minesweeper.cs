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
    public partial class Minesweeper : Form
    {
        bool gameover = false;
        int[,] Position = new int[15, 15];
        Button[,] ButtonList = new Button[15, 15];
        int flag = 30;
        int points = 0;
        public Minesweeper()
        {
            InitializeComponent();
            GenerateBombs();
            GeneratePosValue();
            GenerateButtons();
            gameover = false;
        }

        Random random = new Random();

        private void GenerateBombs()
        {
            int bombs = 0;
            while(bombs < 30)
            {
                int x = random.Next(0, 14);
                int y = random.Next(0, 14);

                if(Position[x, y] == 0)
                {
                    Position[x, y] = 10;
                    bombs++;
                }
            }
        }

        private void GeneratePosValue()
        {
            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    int bombCount = 0;

                    if (Position[x, y] == 10)
                        continue;

                    for(int counterX = -1; counterX < 2; counterX++)
                    {
                        int checkerX = x + counterX;

                        for(int counterY = -1; counterY < 2; counterY++)
                        {
                            int checkerY = y + counterY;

                            if(checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
                                continue;

                            if (checkerX == x && checkerY == y)
                                continue;


                            if(Position[checkerX, checkerY] == 10)
                            {
                                bombCount++;
                            }
                        }
                    }

                    if(bombCount == 0)
                    {
                        Position[x, y] = 20;
                    }
                    else
                    {
                        Position[x, y] = bombCount;
                    }
                }
            }
        }

        private void GenerateButtons()
        {
            int xloc = 3;
            int yloc = 6;

            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    Button button = new Button();
                    //button.Parent = BodyPnl;
                    button.Location = new Point(xloc, yloc);
                    button.Size = new Size(30,30);
                    button.Tag = $"{x},{y}";
                    button.Click += ButtonClick;
                    button.MouseUp += MouseUp;
                    xloc += 25;
                    ButtonList[x, y] = button;
                    this.Controls.Add(button);
                }
                yloc += 22;
                xloc = 3;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int x = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(1));

            int value = Position[x, y];

            if(value == 10)
            {
                button.Image = Properties.Resources.Bomb;

                MessageBox.Show("GameOver!");
                gameover = true;
                //BodyPnl.Enabled = false;
            }
            else if(value == 20)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = SystemColors.ControlDark;
                button.FlatAppearance.BorderSize = 1;
                button.Enabled = false;
                OpenAdjTiles(button);
                points++;
            }
            else
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = SystemColors.ControlDark;
                button.FlatAppearance.MouseDownBackColor = button.BackColor;
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.Text = Position[x,y].ToString();
                points++;
            }

            button.Click -= ButtonClick;
            pointsTxt.Text = pointsTxt.ToString();

        }

        private void OpenAdjTiles(Button button)
        {
            int x = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(button.Tag.ToString().Split(',').GetValue(1));
            List<Button> emptyButton = new List<Button>();

            for (int counterX = -1; counterX < 2; counterX++)
            {
                int checkerX = x + counterX;

                for (int counterY = -1; counterY < 2; counterY++)
                {
                    int checkerY = y + counterY;

                    if (checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
                        continue;

                    if (checkerX == x && checkerY == y)
                        continue;

                    Button buttonAdj = ButtonList[checkerX, checkerY];

                    int xAdj = Convert.ToInt32(buttonAdj.Tag.ToString().Split(',').GetValue(0));
                    int yAdj = Convert.ToInt32(buttonAdj.Tag.ToString().Split(',').GetValue(1));

                    int value = Position[xAdj, yAdj];

                    if(value == 20)
                    {
                        if(buttonAdj.FlatStyle != FlatStyle.Flat)
                        {
                            buttonAdj.FlatStyle = FlatStyle.Flat;
                            buttonAdj.FlatAppearance.BorderSize = 0;
                            button.FlatAppearance.BorderColor = SystemColors.ControlDark;
                            buttonAdj.Enabled = false;
                            emptyButton.Add(buttonAdj);
                            points++;
                        }                       
                    }
                    else if(value != 10)
                    {
                        buttonAdj.PerformClick();
                    }
                }
            }
            foreach (var btnEmpty in emptyButton)
            {
                OpenAdjTiles(btnEmpty);
            }

            pointsTxt.Text = pointsTxt.ToString();
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Button button =(Button)sender;

                if(button.Image == null)
                {
                    button.Image = Properties.Resources.Flag;
                    flag--;
                }
                else
                {
                    button.Image = null;
                    flag++;
                }
                flagTxt.Text = flag.ToString();
            }
        }


        private void Minesweeper_Load(object sender, EventArgs e)
        {

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            points = 0;
            flag = 30;

            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    ButtonList[x, y].Dispose();
                }
            }

            //BodyPnl.Controls.Clear();
            ButtonList = new Button[15, 15];
            Position = new int[15, 15];

            GenerateBombs();
            GeneratePosValue();
            GenerateButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
