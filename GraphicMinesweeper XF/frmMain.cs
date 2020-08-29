using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicMinesweeper_XF
{
    //A Minesweeper game
    //Copyright(C) 2020  Simeon K

    //This program is free software: you can redistribute it and/or modify
    //it under the terms of the GNU General Public License as published by
    //the Free Software Foundation, either version 3 of the License, or
    //(at your option) any later version.

    //This program is distributed in the hope that it will be useful,
    //but WITHOUT ANY WARRANTY; without even the implied warranty of
    //MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    //GNU General Public License for more details.

    //You should have received a copy of the GNU General Public License
    //along with this program.If not, see<https://www.gnu.org/licenses/>.
    public partial class frmMain : Form
    {
        public class Cell
        {
            public bool mine;
            public string state;
            public bool marked;

            public Cell()
            {
                mine = false;
                state = "";
                marked = false;
            }
        }
        const int mines = 10;
        static int x = 8;
        static int y = 8;
        private Button[,] buttons = new Button[x, y];
        static Cell[,] Board = new Cell[x, y];
        static bool[,] visible = new bool[x, y];

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(20, 20);
                    Board[i, j] = new Cell();
                    buttons[i, j].Click += new EventHandler(Button_Click);
                }
            }
            Generate();
            Display();
        }
        
        private void Button_Click(object sender, System.EventArgs e)
        {
            int guessx = 0; int guessy = 0;
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    if (buttons[i, j] == sender)
                    {
                        guessx = i;
                        guessy = j;
                    }
                }
            }
            if (lbxMode.Text == "Flag Mode")
            {
                Board[guessx, guessy].marked = true;
            }
            else
            {
                if (Board[guessx, guessy].state == "-")
                {
                    Fill(guessx, guessy);
                }
                else
                {
                    visible[guessx, guessy] = true;
                }
                
            }

            Display();
            int[] guessArray = new int[2];
            guessArray[0] = guessx; guessArray[1] = guessy;
            CheckWin(guessArray);

        }



        private void Display()
        {
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    this.buttons[i, j].Name = $"cmdButton{i}{j}";
                    this.buttons[i, j].Location = new System.Drawing.Point(100 + (20 * i), 100 + (20 * j));


                    if (visible[i, j])
                    {
                        buttons[i, j].Text = (Board[i, j].state);
                    }
                    else if (Board[i, j].marked)
                    {
                        buttons[i, j].Text = ("F");
                    }
                    else
                    {
                        buttons[i, j].Text = ("");
                    }

                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        static void Fill(int locx, int locy)
        {

            try
            {
                if (Board[locx, locy].state != "X" && !visible[locx, locy])
                {
                    visible[locx, locy] = true;
                    if (Board[locx, locy].state == "-")
                    {
                        Fill(locx + 1, locy);
                        Fill(locx - 1, locy);
                        Fill(locx, locy + 1);
                        Fill(locx, locy - 1);
                        Fill(locx + 1, locy + 1);
                        Fill(locx + 1, locy - 1);
                        Fill(locx - 1, locy + 1);
                        Fill(locx - 1, locy - 1);
                    }


                }
            }
            catch
            {
            }

            return;
        }
        static void Generate()
        {
            Random random = new Random();
            int minesToPlace = mines;
            int tempx = 0;
            int tempy = 0;
            while (minesToPlace > 0)
            {
                minesToPlace -= 1;
                tempx = random.Next(x);
                tempy = random.Next(y);
                Board[tempx, tempy].mine = true;

            }


            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    if (Board[i, j].mine)
                    {
                        Board[i, j].state = "X";
                    }
                    else
                    {
                        Board[i, j].state = CheckSurroundings(i, j, Board);
                    }
                    visible[i, j] = false;

                }

            }
        }
        static string CheckSurroundings(int locx, int locy, Cell[,] table)
        {
            int adjacencies = 0;
            // [x-1,y-1],[x-1,y],[x-1,y+1],[x,y-1],[x,y+1],[x+1,y-1],[x+1,y],[x+1,y+1]
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        if (table[locx + j, locy + i].mine)
                        {
                            adjacencies++;
                        }
                    }
                    catch { }
                }
            }
            string outcome = adjacencies.ToString();
            if (adjacencies == 0)
            {
                outcome = "-";
            }
            return outcome;
        }
        static bool CheckWin(int[] guesses)
        {
            int guessx = guesses[0];
            int guessy = guesses[1];
            int visibleCells = 0;
            foreach (bool cell in visible)
            {
                if (cell)
                {
                    visibleCells++;
                }
            }

            if (Board[guessx, guessy].mine && visible[guessx, guessy])
            {

                MessageBox.Show("YOU LOSE");
                return true;
            }
            else if (visibleCells == (x * y) - mines)
            {

                MessageBox.Show("YOU WIN!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
