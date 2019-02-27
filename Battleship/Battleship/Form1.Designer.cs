namespace Battleship
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblGrid = new System.Windows.Forms.Label();
            this.txtXY = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAttack = new System.Windows.Forms.Button();
            this.txtAttack = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblShips = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblAttack = new System.Windows.Forms.Label();
            this.lblDebug = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDebug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGrid
            // 
            this.lblGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblGrid.Location = new System.Drawing.Point(16, 61);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(186, 180);
            this.lblGrid.TabIndex = 0;
            this.lblGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtXY
            // 
            this.txtXY.Location = new System.Drawing.Point(21, 321);
            this.txtXY.Name = "txtXY";
            this.txtXY.Size = new System.Drawing.Size(100, 20);
            this.txtXY.TabIndex = 1;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(127, 321);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set Ships";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Format : row1 col1 row2 col2";
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(127, 361);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 4;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // txtAttack
            // 
            this.txtAttack.Location = new System.Drawing.Point(21, 364);
            this.txtAttack.Name = "txtAttack";
            this.txtAttack.Size = new System.Drawing.Size(100, 20);
            this.txtAttack.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Format : x1 y1";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(369, 303);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 79);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblShips
            // 
            this.lblShips.AutoSize = true;
            this.lblShips.Location = new System.Drawing.Point(20, 303);
            this.lblShips.Name = "lblShips";
            this.lblShips.Size = new System.Drawing.Size(89, 13);
            this.lblShips.TabIndex = 8;
            this.lblShips.Text = "Battleship - 1 Left";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(38, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ship Logistics";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(284, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Enemy Region";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(65, 270);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 13);
            this.label29.TabIndex = 39;
            this.label29.Text = "point 1";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(117, 270);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 13);
            this.label30.TabIndex = 40;
            this.label30.Text = "point 2 ";
            // 
            // lblAttack
            // 
            this.lblAttack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAttack.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblAttack.Location = new System.Drawing.Point(258, 61);
            this.lblAttack.Name = "lblAttack";
            this.lblAttack.Size = new System.Drawing.Size(186, 180);
            this.lblAttack.TabIndex = 118;
            this.lblAttack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDebug
            // 
            this.lblDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDebug.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblDebug.Location = new System.Drawing.Point(499, 61);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(186, 180);
            this.lblDebug.TabIndex = 119;
            this.lblDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(527, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 24);
            this.label5.TabIndex = 120;
            this.label5.Text = "AI Debug";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(369, 270);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 121;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 406);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblShips);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAttack);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtXY);
            this.Controls.Add(this.lblGrid);
            this.Controls.Add(this.lblAttack);
            this.Controls.Add(this.lblDebug);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.TextBox txtXY;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.TextBox txtAttack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblShips;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblAttack;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDebug;
    }
}

