using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// System.Threading.Thread.Sleep(delaytime in ms); Ai think time so player can percieve the game.
namespace Battleship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int db = 0;
        public int aia = 0, ax = 0, ay = 0, at = 0, hi = 0, r = 0, l = 0, d = 0, u = 0, dir = 0, oy = 0, ox = 0, px = 0, py = 0;
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
        private void ResetGrid()
        {
            
            for(int ab = 0; ab < 8; ab++)
            {
                for(int ac = 0; ac < 8; ac++)
                {
                    grid[ab, ac] = 0;
                    enemygrid[ab, ac] = 0;
                    attackgrid[ab, ac] = 0;
                }
            }
    }
        private void GetGrid(int[,] gridname)
        {
            lblGrid.Text = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gridname[i, j] == 0)
                    {
                        lblGrid.Text += "0 ";
                    }
                    else if (gridname[i, j] == 1)
                    {
                        lblGrid.Text += "1 ";
                    }
                    else if (gridname[i, j] == 2)
                    {
                        lblGrid.Text += "3 ";
                    }
                    else if (gridname[i, j] == 3)
                    {
                        lblGrid.Text += "X ";
                    }

                    if (j == 7)
                    {
                        lblGrid.Text += "\r\n";
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
                        lblAttack.Text += "0 ";
                    }
                    else if (gridname[i, j] == 1)
                    {
                        lblAttack.Text += "1 ";
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
                        lblAttack.Text += "\r\n";
                    }
                }
            }
        }
        private void AIshipsDebug()
        {
            lblDebug.Text = "";
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (enemygrid[i, j] == 0)
                    {
                        lblDebug.Text += "0 ";
                    }
                    else if (enemygrid[i, j] == 1)
                    {
                        lblDebug.Text += "1 ";
                    }
                    if (j == 7)
                    {
                        lblDebug.Text += "\r\n";
                    }
                }
            }
        }
        private void btnDebug_Click(object sender, EventArgs e)
        {
            if (db == 0)
            {
                this.Size = new Size(713, 445);
                lblDebug.Visible = true;
                txtAttack.Visible = true;
                btnAttack.Visible = true;
                db++;
            }
            else
            {
                this.Size = new Size(483, 445);
                lblDebug.Visible = false;
                db = 0;
            }
            
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
            Random rand = new Random(); // Athough ships are randomly generated
                                        // Each ship isn't randomly vertical or
                                        // horizontal. They are randomly generated
                                        // as a set that is one or the other.
                                        // But random horizontal structures are found
                                        // in random vertical generations. Likewise
                                        // for horizontal generations.
            int x = rand.Next(8), y = rand.Next(8), coinflip = rand.Next(2), x2 = 0, y2 = 0, st = 0, ev = 0, d = 0, s = 0;
            
            if (coinflip == 0) // Stay in row 
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
                    st++;
                    
                    
                }
                if (st == 1) // Destroyers
                {
                    
                    for (int k = d; k < 3; k++)
                    {
                        x = rand.Next(8);
                        y = rand.Next(8);
                        x2 = x;
                        if (y > 1)
                        {
                            y2 = y - 2;
                        }
                        else if (y <= 1)
                        {
                            y2 = y + 2;
                        }
                        if (y > y2)
                        {
                            for (int yi = y; yi >= y2; yi--)
                            {
                                if (enemygrid[x, yi] == 0)
                                {
                                    enemygrid[x, yi] = 1;
                                }
                                else
                                {
                                    enemygrid[x, yi] = 2;
                                    ev++;
                                }
                            }
                            if(ev > 0)
                            {
                                for (int yi = y; yi >= y2; yi--)
                                {
                                    if (enemygrid[x, yi] == 1)
                                    {
                                        enemygrid[x, yi] = 0;
                                    }
                                    else if(enemygrid[x,yi] == 2)
                                    {
                                        enemygrid[x, yi] = 1;
                                    }
                                }
                                ev = 0;
                                k--;
                            }
                        }
                        if (y < y2)
                        {
                            for (int yi = y; yi <= y2; yi++)
                            {
                                if (enemygrid[x, yi] == 0)
                                {
                                    enemygrid[x, yi] = 1;
                                }
                                else
                                {
                                    enemygrid[x, yi] = 2;
                                    ev++;
                                }
                            }
                            if(ev > 0)
                            {
                                for (int yi = y; yi <= y2; yi++)
                                {
                                    if (enemygrid[x, yi] == 1)
                                    {
                                        enemygrid[x, yi] = 0;
                                    }
                                    else if(enemygrid[x,yi] == 2)
                                    {
                                        enemygrid[x, yi] = 1;
                                    }
                                }
                                ev = 0;
                                k--;
                            }
                        }
                        
                        
                        
                    }
                    st++;
                    
                }
                if (st == 2) // Submarines
                {
                    for (int k = s; k < 4; k++)
                    {
                        x = rand.Next(8);
                        y = rand.Next(8);
                        x2 = x;
                        if (y > 0)
                        {
                            y2 = y - 1;
                        }
                        else if (y <= 0)
                        {
                            y2 = y + 1;
                        }
                        if (y > y2)
                        {
                            for (int yi = y; yi >= y2; yi--)
                            {
                                if (enemygrid[x, yi] == 0)
                                {
                                    enemygrid[x, yi] = 1;
                                }
                                else
                                {
                                    enemygrid[x, yi] = 2;
                                    ev++;
                                }
                            }
                            if(ev > 0)
                            {
                                for (int yi = y; yi >= y2; yi--)
                                {
                                    if (enemygrid[x, yi] == 1)
                                    {
                                        enemygrid[x, yi] = 0;
                                    }
                                    else if(enemygrid[x,yi] == 2)
                                    {
                                        enemygrid[x, yi] = 1;
                                    }
                                }
                                ev = 0;
                                k--;
                            }
                        }
                        if (y < y2)
                        {
                            for (int yi = y; yi <= y2; yi++)
                            {
                                if (enemygrid[x, yi] == 0)
                                {
                                    enemygrid[x, yi] = 1;
                                }
                                else
                                {
                                    enemygrid[x, yi] = 2;
                                    ev++;
                                }
                            }
                            if(ev > 0)
                            {
                                for (int yi = y; yi <= y2; yi++)
                                {
                                    if (enemygrid[x, yi] == 1)
                                    {
                                        enemygrid[x, yi] = 0;
                                    }
                                    else if(enemygrid[x,yi] == 2)
                                    {
                                        enemygrid[x, yi] = 1;
                                    }
                                }
                                ev = 0;
                                k--;
                            }
                        }
                        
                        
                        
                    }
                    st = 0;
                }
            }
            
            if (coinflip == 1) // Stay in column
            {
                
                if (st == 0) // Battleship
                {
                    y2 = y;
                    if (x > 2)
                    {
                        x2 = x - 3;
                    }
                    else if (x <= 2)
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
                    
                    st++;
                    
                }
                if(st == 1) //Destroyers
                {
                    for (int i = d; i < 3; i++)
                    {
                        x = rand.Next(8);
                        y = rand.Next(8);
                        y2 = y;
                        if (x > 1)
                        {
                            x2 = x - 2;
                        }
                        else if (x < 1)
                        {
                            x2 = x + 2;
                        }
                        if (x > x2)
                        {
                            for (int xi = x; xi >= x2; xi--)
                            {
                                if (enemygrid[xi, y] == 0)
                                {
                                    enemygrid[xi, y] = 1;
                                }
                                else
                                {
                                    enemygrid[xi, y] = 2;
                                    ev++;
                                }
                            }
                            if(ev > 0)
                            {
                                for (int xi = x; xi >= x2; xi--)
                                {
                                    if (enemygrid[xi, y] == 1)
                                    {
                                        enemygrid[xi, y] = 0;
                                    }
                                    else if(enemygrid[xi, y] == 2)
                                    {
                                        enemygrid[xi, y] = 1;
                                    }
                                }
                                ev = 0;
                                i--;
                            }
                        }
                        if (x < x2)
                        {
                            for (int xi = x; xi <= x2; xi++)
                            {
                                if (enemygrid[xi, y] == 0)
                                {
                                    enemygrid[xi, y] = 1;
                                }
                                else
                                {
                                    ev++;
                                    enemygrid[xi, y] = 2;
                                }
                            }
                            if(ev > 0)
                            {
                                for (int xi = x; xi <= x2; xi++)
                                {
                                    if (enemygrid[xi, y] == 1)
                                    {
                                        enemygrid[xi, y] = 0;
                                    }
                                    else if(enemygrid[xi, y] == 2)
                                    {
                                        enemygrid[xi, y] = 1;
                                    }
                                }
                                ev = 0;
                                i--;
                            }
                        }
                        
                        
                        
                    }
                    st++;
                }
                if (st == 2) //Submarines
                {
                    for (int i = s; i < 4; i++)
                    {
                        x = rand.Next(8);
                        y = rand.Next(8);
                        y2 = y;
                        if (x > 0)
                        {
                            x2 = x - 1;
                        }
                        else if (x == 0)
                        {
                            x2 = x + 1;
                        }
                        if (x > x2)
                        {
                            for (int xi = x; xi >= x2; xi--)
                            {
                                if (enemygrid[xi, y] == 0)
                                {
                                    enemygrid[xi, y] = 1;
                                }
                                else
                                {
                                    enemygrid[xi, y] = 2;
                                    ev++;
                                }
                            }
                            if (ev > 0)
                            {
                                for (int xi = x; xi >= x2; xi--)
                                {
                                    if (enemygrid[xi, y] == 1)
                                    {
                                        enemygrid[xi, y] = 0;
                                    }
                                    else if (enemygrid[xi, y] == 2)
                                    {
                                        enemygrid[xi, y] = 1;
                                    }
                                }
                                ev = 0;
                                i--;
                            }
                        }
                        if (x < x2)
                        {
                            for (int xi = x; xi <= x2; xi++)
                            {
                                if (enemygrid[xi, y] == 0)
                                {
                                    enemygrid[xi, y] = 1;
                                }
                                else
                                {
                                    ev++;
                                    enemygrid[xi, y] = 2;
                                }
                            }
                            if (ev > 0)
                            {
                                for (int xi = x; xi <= x2; xi++)
                                {
                                    if (enemygrid[xi, y] == 1)
                                    {
                                        enemygrid[xi, y] = 0;
                                    }
                                    else if (enemygrid[xi, y] == 2)
                                    {
                                        enemygrid[xi, y] = 1;
                                    }
                                }
                                ev = 0;
                                i--;
                            }
                        }
                        
                        
                        
                    }
                    st = 0;
                }
            }
            //MessageBox.Show(x.ToString() + " " + y.ToString() + " " + x2.ToString() + " " + y2.ToString());
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
            AIattack();
        }
        private void AIattack()
        {
            Random rand = new Random();
            if(aia == 0)
            {
                ax = rand.Next(8);
                ay = rand.Next(8);
                ox = ax;
                oy = ay;
                if(grid[ax,ay] == 1)
                {
                    grid[ax, ay] = 3;
                    GetGrid(grid);
                }
                else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                {
                    dir = 4;
                }
                else
                {
                    grid[ax, ay] = 2;
                    GetGrid(grid);
                }
                
                if (ax == 0 && ay == 0)
                {
                    at = 0;
                }           
                else if (ax == 7 && ay == 7)
                {
                    at = 1;
                }      
                else if (ax == 0 && ay == 7)
                {
                    at = 2;
                }      
                else if (ax == 7 && ay == 0)
                {
                    at = 3;
                }      
                else if (ax == 0 && ay > 0)
                {
                    at = 4;
                }        
                else if (ay == 0 && ax > 0)
                {
                    at = 5;
                }        
                else if(ay == 7 && ax > 0)
                {
                    at = 6;
                }         
                else if(ax == 7 && ay > 0)
                {
                    at = 7;
                }         
                else if(ax > 0 && ay > 0)
                {
                    at = 8;
                }
                dir--;                                      
            }
            if(at >= 0 && at < 4 && aia > 0) // 4 corners 2 directions
            {
                dir = 4;
            }
            if(at >= 4 && at < 8 && aia > 0) // 4 sides 3 directions
            {
                if(at == 4 || at == 7)
                {

                    if (dir == 0)
                    {
                        ay++;
                        if (grid[ax, ay] == 1)
                        {
                            grid[ax, ay] = 3;
                            GetGrid(grid);
                            r++;
                            hi++;

                        }
                        else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                        {
                            dir = 4;
                        }
                        else
                        {
                            grid[ax, ay] = 2;
                            GetGrid(grid);

                            ay--;
                        }
                        
                    }
                    if (dir == 1)
                    {
                        ay--;
                        if (grid[ax, ay] == 1)
                        {
                            grid[ax, ay] = 3;
                            GetGrid(grid);
                            l++;
                            hi++;

                        }
                        else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                        {
                            dir = 4;
                        }
                        else
                        {
                            grid[ax, ay] = 2;
                            GetGrid(grid);

                            ay++;
                        }
                    }
                    if(at == 7)
                    {
                        if (dir == 2)
                        {
                            ax++;
                            if (grid[ax, ay] == 1)
                            {
                                grid[ax, ay] = 3;
                                GetGrid(grid);
                                u++;
                                hi++;

                            }
                            else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                            {
                                dir = 4;
                            }
                            else
                            {
                                grid[ax, ay] = 2;
                                GetGrid(grid);

                                ax--;
                            }
                        }
                    }
                    else if(at == 4)
                    {
                        if (dir == 2)
                        {
                            ax++;
                            if (grid[ax, ay] == 1)
                            {
                                grid[ax, ay] = 3;
                                GetGrid(grid);
                                u++;
                                hi++;

                            }
                            else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                            {
                                dir = 4;
                            }
                            else
                            {
                                grid[ax, ay] = 2;
                                GetGrid(grid);

                                ax--;
                            }
                        }
                    }
                }
                else if(at == 5 || at == 6)
                {
                    if (dir == 0)
                    {
                        ax++;
                        if (grid[ax, ay] == 1)
                        {
                            grid[ax, ay] = 3;
                            GetGrid(grid);
                            u++;
                            hi++;

                        }
                        else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                        {
                            dir = 4;
                        }
                        else
                        {
                            grid[ax, ay] = 2;
                            GetGrid(grid);

                            ax--;
                        }
                    }
                    if (dir == 1)
                    {
                        ax--;
                        if (grid[ax, ay] == 1)
                        {
                            grid[ax, ay] = 3;
                            GetGrid(grid);
                            d++;
                            hi++;

                        }
                        else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                        {
                            dir = 4;
                        }
                        else
                        {
                            grid[ax, ay] = 2;
                            GetGrid(grid);

                            ax++;
                        }
                    }
                    if(at == 5)
                    {
                        if (dir == 2)
                        {
                            ay++;
                            if (grid[ax, ay] == 1)
                            {
                                grid[ax, ay] = 3;
                                GetGrid(grid);
                                r++;
                                hi++;

                            }
                            else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                            {
                                dir = 4;
                            }
                            else
                            {
                                grid[ax, ay] = 2;
                                GetGrid(grid);

                                ay--;
                            }

                        }
                    }
                    else if(at == 6)
                    {
                        if (dir == 2)
                        {
                            ay--;
                            if (grid[ax, ay] == 1)
                            {
                                grid[ax, ay] = 3;
                                GetGrid(grid);
                                l++;
                                hi++;

                            }
                            else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                            {
                                dir = 4;
                            }
                            else
                            {
                                grid[ax, ay] = 2;
                                GetGrid(grid);

                                ay++;
                            }
                        }
                    }
                }
            }
            if(at == 8 && aia > 0) // inner area 4 directions
            {
                if(dir == 0)
                {
                    ay++;
                    if(grid[ax,ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        r++;
                        hi++;
                        
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        
                        ay--;
                    }
                }
                if (dir == 1)
                {
                    ay--;
                    if (grid[ax, ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        l++;
                        hi++;
                        
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        
                        ay++;
                    }
                }
                if (dir == 2)
                {
                    ax++;
                    if (grid[ax, ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        u++;
                        hi++;
                        
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        
                        ax--;
                    }
                }
                if (dir == 3)
                {
                    ax--;
                    if (grid[ax, ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        d++;
                        hi++;
                        
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        
                        ax++;
                    }
                }
            }

            if(hi > 0)
            {
                if (r > 0)
                {
                    ay++;
                    if(grid[ax,ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        dir--;
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        r = 0;
                        hi = 0;
                        dir--;
                        ay = oy;
                        ax = ox;
                    }
                }
                if (l > 0)
                {
                    ay--;
                    if (grid[ax, ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        dir--;
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        l = 0;
                        hi = 0;
                        dir--;
                        ay = oy;
                        ax = ox;
                    }
                }
                if (u > 0)
                {
                    ax++;
                    if (grid[ax, ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        dir--;
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        u = 0;
                        hi = 0;
                        dir--;
                        ay = oy;
                        ax = ox;
                    }
                }
                if (d > 0)
                {
                    ax--;
                    if (grid[ax, ay] == 1)
                    {
                        grid[ax, ay] = 3;
                        GetGrid(grid);
                        dir--;
                    }
                    else if (grid[ax, ay] == 3 || grid[ax, ay] == 2)
                    {
                        dir = 4;
                    }
                    else
                    {
                        grid[ax, ay] = 2;
                        GetGrid(grid);
                        d = 0;
                        hi = 0;
                        dir--;
                        ay = oy;
                        ax = ox;
                    }
                }
            }

            if(dir >= 3)
            {
                aia = 0;
                dir = 0;
            }
            else
            {
                aia++;
                dir++;
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShipGen();
            GetAttackGrid(attackgrid);
            GetGrid(grid);
            AIshipsDebug();
            btnAttack.Visible = false;
            txtAttack.Visible = false;
            label2.Visible = false;
            lblDebug.Visible = false;
            this.Size = new Size(483, 445);
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
                    btnAttack.Visible = true;
                    txtAttack.Visible = true;
                    label2.Visible = true;
                    txtXY.Visible = false;
                    btnSet.Visible = false;
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
            btnAttack.Visible = false;
            txtAttack.Visible = false;
            label2.Visible = false;
            txtXY.Visible = true;
            btnSet.Visible = true;
            ResetGrid();
            GetGrid(grid);
            ShipGen();
            GetAttackGrid(attackgrid);
            AIshipsDebug();
            txtXY.Text = "";
        }
    }
}

