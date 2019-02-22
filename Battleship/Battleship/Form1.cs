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
                               {0, 0, 0, 0, 0, 0, 0, 0}, };
        

        public int[] shippos = new int[4];
        public int accu = 1;
        public int ns = 3,ns2 = 4;
        public Form1()
        {
            InitializeComponent();
        }
        private void GetGrid(int[,] gridname)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    lblGrid.Text += gridname[i, j].ToString() + "      ";
                    if (j == 7)
                    {
                        lblGrid.Text += "\r\n\r\n";
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

            if(x1 - x2 < 0) //Find diff between x's
            {
                xdif = (x1 - x2) * -1;
            }
            else
            {
                xdif = x1 - x2;
            }

            if (y1 - y2 < 0) //Find diff between y's
            {
                ydif = (y1 - y2) * -1;
            }
            else
            {
                ydif = y1 - y2;
            }
            int n1 = 0;
            if (y1 == y2) //If you are staying in the column
            {
                if (xdif == 3 && accu == 1)
                {
                    for(int i = x1; i <= x2; i++)
                    {
                        
                            grid[i, y1] = 1;
                      

                    }
                    

                        lblGrid.Text = "";
                        GetGrid(grid);
                        accu++;

                    
                }
                if(xdif == 2 && accu == 2 || accu == 3 || accu == 4)
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
                if (xdif == 1 && accu == 5 || accu == 6 || accu == 7 || accu == 8)
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

            if(x1 == x2) //If you are staying in the row
            {

            }
            
            if(x1 != x2 && y1 != y2)//If they try to go diagonally 
            {
                MessageBox.Show("Ships can't go diagonally.");
            }
            txtXY.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            GetGrid(grid);
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
                
                
                if(accu == 2)
                {
                    lblShips.Text = "Destroyer - " + ns.ToString() + " Left";
                }
                else if (accu == 3 || accu == 4)
                {
                    lblShips.Text = "Destroyer - " + ns.ToString() + " Left";
                    
                }
                else if(accu == 5)
                {
                    
                    lblShips.Text = "Submarine - " + ns2.ToString() + " Left";
                    
                }
                else if(accu == 6 || accu == 7 || accu == 8)
                {
                    lblShips.Text = "Submarine - " + ns2.ToString() + " Left";
                    
                }
                else
                {
                    lblShips.Text = "You are out of ships.";
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

        }

        private void btnAttack_Click(object sender, EventArgs e)
        {

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
