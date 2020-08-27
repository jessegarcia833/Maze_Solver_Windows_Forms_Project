namespace Maze_Game
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
            this.restartButton = new System.Windows.Forms.Button();
            this.mazeOneButton = new System.Windows.Forms.Button();
            this.mazeTwoButton = new System.Windows.Forms.Button();
            this.mazeThreeButton = new System.Windows.Forms.Button();
            this.bfsButton = new System.Windows.Forms.Button();
            this.ufsButton = new System.Windows.Forms.Button();
            this.aStarButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.Red;
            this.restartButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.restartButton.FlatAppearance.BorderSize = 2;
            this.restartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.Location = new System.Drawing.Point(0, 687);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(161, 42);
            this.restartButton.TabIndex = 6;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // mazeOneButton
            // 
            this.mazeOneButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mazeOneButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mazeOneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mazeOneButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mazeOneButton.ForeColor = System.Drawing.Color.White;
            this.mazeOneButton.Location = new System.Drawing.Point(631, 0);
            this.mazeOneButton.Name = "mazeOneButton";
            this.mazeOneButton.Size = new System.Drawing.Size(105, 60);
            this.mazeOneButton.TabIndex = 13;
            this.mazeOneButton.Text = "Maze 1";
            this.mazeOneButton.UseVisualStyleBackColor = true;
            this.mazeOneButton.Click += new System.EventHandler(this.mazeOneButton_Click);
            // 
            // mazeTwoButton
            // 
            this.mazeTwoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mazeTwoButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mazeTwoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mazeTwoButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mazeTwoButton.ForeColor = System.Drawing.Color.White;
            this.mazeTwoButton.Location = new System.Drawing.Point(742, 0);
            this.mazeTwoButton.Name = "mazeTwoButton";
            this.mazeTwoButton.Size = new System.Drawing.Size(105, 60);
            this.mazeTwoButton.TabIndex = 14;
            this.mazeTwoButton.Text = "Maze 2";
            this.mazeTwoButton.UseVisualStyleBackColor = true;
            this.mazeTwoButton.Click += new System.EventHandler(this.mazeTwoButton_Click);
            // 
            // mazeThreeButton
            // 
            this.mazeThreeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mazeThreeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mazeThreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mazeThreeButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mazeThreeButton.ForeColor = System.Drawing.Color.White;
            this.mazeThreeButton.Location = new System.Drawing.Point(853, 0);
            this.mazeThreeButton.Name = "mazeThreeButton";
            this.mazeThreeButton.Size = new System.Drawing.Size(105, 60);
            this.mazeThreeButton.TabIndex = 15;
            this.mazeThreeButton.Text = "Maze 3";
            this.mazeThreeButton.UseVisualStyleBackColor = true;
            this.mazeThreeButton.Click += new System.EventHandler(this.mazeThreeButton_Click);
            // 
            // bfsButton
            // 
            this.bfsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bfsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bfsButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bfsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bfsButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bfsButton.ForeColor = System.Drawing.Color.White;
            this.bfsButton.Location = new System.Drawing.Point(0, 0);
            this.bfsButton.Name = "bfsButton";
            this.bfsButton.Size = new System.Drawing.Size(161, 50);
            this.bfsButton.TabIndex = 16;
            this.bfsButton.Text = "Breadth First Search";
            this.bfsButton.UseVisualStyleBackColor = false;
            this.bfsButton.Click += new System.EventHandler(this.bfsButton_Click);
            // 
            // ufsButton
            // 
            this.ufsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ufsButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ufsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ufsButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ufsButton.ForeColor = System.Drawing.Color.White;
            this.ufsButton.Location = new System.Drawing.Point(0, 56);
            this.ufsButton.Name = "ufsButton";
            this.ufsButton.Size = new System.Drawing.Size(161, 50);
            this.ufsButton.TabIndex = 17;
            this.ufsButton.Text = "Uniform Cost Search";
            this.ufsButton.UseVisualStyleBackColor = true;
            this.ufsButton.Click += new System.EventHandler(this.ufsButton_Click);
            // 
            // aStarButton
            // 
            this.aStarButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.aStarButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aStarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aStarButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aStarButton.ForeColor = System.Drawing.Color.White;
            this.aStarButton.Location = new System.Drawing.Point(0, 112);
            this.aStarButton.Name = "aStarButton";
            this.aStarButton.Size = new System.Drawing.Size(161, 50);
            this.aStarButton.TabIndex = 18;
            this.aStarButton.Text = "A Star Search";
            this.aStarButton.UseVisualStyleBackColor = true;
            this.aStarButton.Click += new System.EventHandler(this.aStarButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mazeTwoButton);
            this.panel1.Controls.Add(this.mazeThreeButton);
            this.panel1.Controls.Add(this.mazeOneButton);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 60);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.bfsButton);
            this.panel2.Controls.Add(this.ufsButton);
            this.panel2.Controls.Add(this.restartButton);
            this.panel2.Controls.Add(this.aStarButton);
            this.panel2.Location = new System.Drawing.Point(1, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 729);
            this.panel2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 31);
            this.label1.TabIndex = 21;
            this.label1.Text = "M A Z E  S O L V E R";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(161, 747);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(801, 42);
            this.panel3.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(328, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "© Copyright 2020 Jesse Garcia";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(962, 792);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button mazeOneButton;
        private System.Windows.Forms.Button mazeTwoButton;
        private System.Windows.Forms.Button mazeThreeButton;
        private System.Windows.Forms.Button bfsButton;
        private System.Windows.Forms.Button ufsButton;
        private System.Windows.Forms.Button aStarButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
    }
}

