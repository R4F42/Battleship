using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        public int[,] grid = { {0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0}};
        public int[,] attackgrid = { {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0}};
        public int[,] enemygrid = { {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0},
                                     {0, 0, 0, 0, 0, 0, 0, 0}};
        public int[] shippos = new int[4];
        public int[] attackpos = new int[2];
        public int accu = 1;
        public int ns = 3, ns2 = 4;
        public Form1()
        {
            InitializeComponent();
        }
        private void GetGrid(int[,] gridname)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gridname[i, j] == 0)
                    {
                        lblGrid.Text += "▒ ";
                    }
                    else if (gridname[i, j] == 1)
                    {
                        lblGrid.Text += "0 ";
                    }
                    if (j == 7)
                    {
                        lblGrid.Text += "\r\n\r\n";
                    }
                }
            }
        }
        private void GetAttackGrid(int[,] gridname)
        {
            lblAttack.Text = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gridname[i, j] == 0)
                    {
                        lblAttack.Text += "▒ ";
                    }
                    else if (gridname[i, j] == 1)
                    {
                        lblAttack.Text += "0 ";
                    }
                    else if (gridname[i, j] == 2)
                    {
                        lblAttack.Text += "X ";
                    }
                    else if (gridname[i, j] == 3)
                    {
                        lblAttack.Text += "3 ";
                    }
                    if (j == 7)
                    {
                        lblAttack.Text += "\r\n\r\n";
                    }
                }
            }
        }
        private void AIshipsDebug()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (enemygrid[i, j] == 0)
                    {
                        lblDebug.Text += "▒ ";
                    }
                    else if (enemygrid[i, j] == 1)
                    {
                        lblDebug.Text += "0 ";
                    }
                    if (j == 7)
                    {
                        lblDebug.Text += "\r\n\r\n";
                    }
                }
            }
        }
        private void ResetGrid()
        {
            int[,] grid =     {{ 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0}, };

        }
        private void SetShip()
        {
            int x1 = shippos[0], y1 = shippos[1], x2 = shippos[2], y2 = shippos[3];
            int xdif = 0, ydif = 0;

            if (x1 - x2 < 0) // Find diff between x's
            {
                xdif = (x1 - x2) * -1;
            }
            else
            {
                xdif = x1 - x2;
            }

            if (y1 - y2 < 0) // Find diff between y's
            {
                ydif = (y1 - y2) * -1;
            }
            else
            {
                ydif = y1 - y2;
            }
            int n1 = 0;
            if (y1 == y2) // If you are staying in the column
            {
                if (xdif == 3 && accu == 1)
                {
                    if (x1 <= x2)
                    {
                        for (int i = x1; i <= x2; i++)
                        {
                            grid[i, y1] = 1;
                        }
                    }
                    else if (x1 >= x2)
                    {
                        for (int i = x1; i >= x2; i--)
                        {
                            grid[i, y1] = 1;
                        }
                    }
                    lblGrid.Text = "";
                    GetGrid(grid);
                    accu++;
                }
                if ((xdif == 2 && accu == 2) || (xdif == 2 && accu == 3) || (xdif == 2 && accu == 4))
                {
                    if (x1 <= x2)
                    {
                        for (int i = x1; i <= x2; i++)
                        {
                            if (grid[i, y1] == 0)
                            {
                                grid[i, y1] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    else if (x1 >= x2)
                    {
                        for (int i = x1; i >= x2; i--)
                        {
                            if (grid[i, y1] == 0)
                            {
                                grid[i, y1] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    if (n1 == 0)
                    {
                        lblGrid.Text = "";
                        GetGrid(grid);
                        accu++;
                        ns--;
                    }
                    else
                    {
                        ResetGrid();
                    }
                }
                if ((xdif == 1 && accu == 5) || (xdif == 1 && accu == 6) || (xdif == 1 && accu == 7) || (xdif == 1 && accu == 8))
                {
                    if (x1 <= x2)
                    {
                        for (int i = x1; i <= x2; i++)
                        {
                            if (grid[i, y1] == 0)
                            {
                                grid[i, y1] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    else if (x1 >= x2)
                    {
                        for (int i = x1; i >= x2; i--)
                        {
                            if (grid[i, y1] == 0)
                            {
                                grid[i, y1] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    if (n1 == 0)
                    {

                        lblGrid.Text = "";
                        GetGrid(grid);
                        accu++;
                        ns2--;
                    }
                    else
                    {
                        ResetGrid();
                    }
                }
            }
            if (x1 == x2) // If you are staying in the row
            {
                if (ydif == 3 && accu == 1)
                {
                    if (y1 <= y2)
                    {
                        for (int i = y1; i <= y2; i++)
                        {
                            grid[x1, i] = 1;
                        }
                    }
                    else if (y1 >= y2)
                    {
                        for (int i = y1; i >= y2; i--)
                        {
                            grid[x1, i] = 1;
                        }
                    }
                    lblGrid.Text = "";
                    GetGrid(grid);
                    accu++;
                }
                if ((ydif == 2 && accu == 2) || (ydif == 2 && accu == 3) || (ydif == 2 && accu == 4))
                {
                    if (y1 <= y2)
                    {
                        for (int i = y1; i <= y2; i++)
                        {
                            if (grid[x1, i] == 0)
                            {
                                grid[x1, i] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    else if (y1 >= y2)
                    {
                        for (int i = y1; i >= y2; i--)
                        {
                            if (grid[x1, i] == 0)
                            {
                                grid[x1, i] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    if (n1 == 0)
                    {

                        lblGrid.Text = "";
                        GetGrid(grid);
                        accu++;
                        ns--;
                    }
                    else
                    {
                        ResetGrid();
                    }
                }
                if ((ydif == 1 && accu == 5) || (ydif == 1 && accu == 6) || (ydif == 1 && accu == 7) || (ydif == 1 && accu == 8))
                {
                    if (y1 <= y2)
                    {
                        for (int i = y1; i <= y2; i++)
                        {
                            if (grid[x1, i] == 0)
                            {
                                grid[x1, i] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    else if (y1 >= y2)
                    {
                        for (int i = y1; i >= y2; i--)
                        {
                            if (grid[x1, i] == 0)
                            {
                                grid[x1, i] = 1;
                            }
                            else
                            {
                                n1--;
                            }
                        }
                    }
                    if (n1 == 0)
                    {

                        lblGrid.Text = "";
                        GetGrid(grid);
                        accu++;
                        ns2--;
                    }
                    else
                    {
                        ResetGrid();
                    }
                }
            }

            if (x1 != x2 && y1 != y2) //If they try to go diagonally 
            {
                MessageBox.Show("Ships can't go diagonally.");
            }
            txtXY.Text = "";
        }
        private void ShipGen()
        {
            Random rand = new Random();
            int x = rand.Next(8), y = rand.Next(8), coinflip = rand.Next(2), x2 = 0, y2 = 0, st = 0;
            if(coinflip == 0) // Stay in row 
            {
                x2 = x;
                if(st == 0) // Battleship
                {
                    if(y > 2)
                    {
                        y2 = y - 3;
                    }
                    else if(y <= 2)
                    {
                        y2 = y + 3;
                    }
                    if(y > y2)
                    {
                        for(int yi = y; yi >= y2; yi--)
                        {
                            enemygrid[x, yi] = 1;
                        }
                    }
                    if(y < y2)
                    {
                        for (int yi = y; yi <= y2; yi++)
                        {
                            enemygrid[x, yi] = 1;
                        }
                    }
                }
            }

            if (coinflip == 1) // Stay in column
            {
                y2 = y;
                if (st == 0) // Battleship
                {
                    if (x > 2)
                    {
                        x2 = x - 3;
                    }
                    else if (x < 2)
                    {
                        x2 = x + 3;
                    }
                    if (x > x2)
                    {
                        for (int xi = x; xi >= x2; xi--)
                        {
                            enemygrid[xi, y] = 1;
                        }
                    }
                    if (x < x2)
                    {
                        for (int xi = x; xi <= x2; xi++)
                        {
                            enemygrid[xi, y] = 1;
                        }
                    }
                }
            }
            MessageBox.Show(x.ToString() + " " + y.ToString() + " " + x2.ToString() + " " + y2.ToString());
        }
        private void Attack()
        {
            int x, y;
            x = attackpos[0];
            y = attackpos[1];
            if(enemygrid[x,y] == 1)
            {
                attackgrid[x, y] = 2;
                GetAttackGrid(attackgrid);
            }
            else if(enemygrid[x,y] == 0)
            {
                attackgrid[x, y] = 3;
                GetAttackGrid(attackgrid);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShipGen();
            GetAttackGrid(attackgrid);
            GetGrid(grid);
            AIshipsDebug();
        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                char[] input;
                input = txtXY.Text.ToArray();
                int a2 = 0;
                for (int i = 0; i < txtXY.Text.Length; i++)
                {

                    if (input[i] == '0' || input[i] == '1' || input[i] == '2' || input[i] == '3' ||
                        input[i] == '4' || input[i] == '5' || input[i] == '6' || input[i] == '7')
                    {
                        shippos[a2] = (int)char.GetNumericValue(input[i]);
                        a2++;
                    }
                }
                SetShip();
                if (accu == 2)
                {
                    lblShips.Text = "Destroyer - " + ns.ToString() + " Left";
                }
                else if (accu == 3 || accu == 4)
                {
                    lblShips.Text = "Destroyer - " + ns.ToString() + " Left";
                }
                else if (accu == 5)
                {
                    lblShips.Text = "Submarine - " + ns2.ToString() + " Left";
                }
                else if (accu == 6 || accu == 7 || accu == 8)
                {
                    lblShips.Text = "Submarine - " + ns2.ToString() + " Left";
                }
                else
                {
                    lblShips.Text = "You are out of ships.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAttack_Click(object sender, EventArgs e)
        {
            char[] input;
            input = txtAttack.Text.ToArray();
            int a2 = 0, stupid = 0;
            for (int i = 0; i < txtAttack.Text.Length; i++)
            {
                if (input[i] == '0' || input[i] == '1' || input[i] == '2' || input[i] == '3' ||
                    input[i] == '4' || input[i] == '5' || input[i] == '6' || input[i] == '7')
                {
                    attackpos[a2] = (int)char.GetNumericValue(input[i]);
                    a2++;
                }
                else
                {
                    stupid++;
                }
            }
            if (stupid > 0)
            {
                MessageBox.Show("Stupid Idea!");
            }
            else
            {
                Attack();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ns = 3;
            ns2 = 4;
            accu = 1;
            lblShips.Text = "Battleship - 1 left";
            lblGrid.Text = "";
            int[,] grid =     {{ 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0, 0, 0, 0}, };
            GetGrid(grid);
            txtXY.Text = "";
        }
    }
}

