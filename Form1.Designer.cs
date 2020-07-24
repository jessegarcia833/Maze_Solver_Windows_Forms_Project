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
            this.bfsRadioButton = new System.Windows.Forms.RadioButton();
            this.ufsRadioButton = new System.Windows.Forms.RadioButton();
            this.aStarRadioButton = new System.Windows.Forms.RadioButton();
            this.restartButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.maze2RadioButton = new System.Windows.Forms.RadioButton();
            this.maze1RadioButton = new System.Windows.Forms.RadioButton();
            this.setMazeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bfsRadioButton
            // 
            this.bfsRadioButton.AutoSize = true;
            this.bfsRadioButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bfsRadioButton.Location = new System.Drawing.Point(746, 93);
            this.bfsRadioButton.Name = "bfsRadioButton";
            this.bfsRadioButton.Size = new System.Drawing.Size(184, 27);
            this.bfsRadioButton.TabIndex = 3;
            this.bfsRadioButton.TabStop = true;
            this.bfsRadioButton.Text = "Breadth First Search";
            this.bfsRadioButton.UseVisualStyleBackColor = true;
            this.bfsRadioButton.CheckedChanged += new System.EventHandler(this.bfsRadioButton_CheckedChanged);
            // 
            // ufsRadioButton
            // 
            this.ufsRadioButton.AutoSize = true;
            this.ufsRadioButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ufsRadioButton.Location = new System.Drawing.Point(746, 132);
            this.ufsRadioButton.Name = "ufsRadioButton";
            this.ufsRadioButton.Size = new System.Drawing.Size(181, 27);
            this.ufsRadioButton.TabIndex = 4;
            this.ufsRadioButton.TabStop = true;
            this.ufsRadioButton.Text = "Uniform Cost Search";
            this.ufsRadioButton.UseVisualStyleBackColor = true;
            this.ufsRadioButton.CheckedChanged += new System.EventHandler(this.ufsRadioButton_CheckedChanged);
            // 
            // aStarRadioButton
            // 
            this.aStarRadioButton.AutoSize = true;
            this.aStarRadioButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aStarRadioButton.Location = new System.Drawing.Point(746, 170);
            this.aStarRadioButton.Name = "aStarRadioButton";
            this.aStarRadioButton.Size = new System.Drawing.Size(135, 27);
            this.aStarRadioButton.TabIndex = 5;
            this.aStarRadioButton.TabStop = true;
            this.aStarRadioButton.Text = "A Star Search";
            this.aStarRadioButton.UseVisualStyleBackColor = true;
            this.aStarRadioButton.CheckedChanged += new System.EventHandler(this.aStarRadioButton_CheckedChanged);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.Red;
            this.restartButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.restartButton.FlatAppearance.BorderSize = 2;
            this.restartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.Location = new System.Drawing.Point(746, 670);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(181, 32);
            this.restartButton.TabIndex = 6;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.Color.LimeGreen;
            this.solveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.solveButton.FlatAppearance.BorderSize = 2;
            this.solveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.solveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solveButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solveButton.Location = new System.Drawing.Point(746, 236);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(181, 34);
            this.solveButton.TabIndex = 7;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // maze2RadioButton
            // 
            this.maze2RadioButton.AutoSize = true;
            this.maze2RadioButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maze2RadioButton.Location = new System.Drawing.Point(309, 62);
            this.maze2RadioButton.Name = "maze2RadioButton";
            this.maze2RadioButton.Size = new System.Drawing.Size(83, 27);
            this.maze2RadioButton.TabIndex = 9;
            this.maze2RadioButton.TabStop = true;
            this.maze2RadioButton.Text = "Maze 2";
            this.maze2RadioButton.UseVisualStyleBackColor = true;
            this.maze2RadioButton.CheckedChanged += new System.EventHandler(this.maze2RadioButton_CheckedChanged);
            // 
            // maze1RadioButton
            // 
            this.maze1RadioButton.AutoSize = true;
            this.maze1RadioButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maze1RadioButton.Location = new System.Drawing.Point(100, 62);
            this.maze1RadioButton.Name = "maze1RadioButton";
            this.maze1RadioButton.Size = new System.Drawing.Size(80, 27);
            this.maze1RadioButton.TabIndex = 8;
            this.maze1RadioButton.TabStop = true;
            this.maze1RadioButton.Text = "Maze 1";
            this.maze1RadioButton.UseVisualStyleBackColor = true;
            this.maze1RadioButton.CheckedChanged += new System.EventHandler(this.maze1RadioButton_CheckedChanged);
            // 
            // setMazeButton
            // 
            this.setMazeButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.setMazeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.setMazeButton.FlatAppearance.BorderSize = 2;
            this.setMazeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setMazeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMazeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setMazeButton.Location = new System.Drawing.Point(538, 59);
            this.setMazeButton.Name = "setMazeButton";
            this.setMazeButton.Size = new System.Drawing.Size(123, 34);
            this.setMazeButton.TabIndex = 11;
            this.setMazeButton.Text = "Set Maze";
            this.setMazeButton.UseVisualStyleBackColor = false;
            this.setMazeButton.Click += new System.EventHandler(this.setMazeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1088, 751);
            this.Controls.Add(this.setMazeButton);
            this.Controls.Add(this.maze2RadioButton);
            this.Controls.Add(this.maze1RadioButton);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.aStarRadioButton);
            this.Controls.Add(this.ufsRadioButton);
            this.Controls.Add(this.bfsRadioButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton bfsRadioButton;
        private System.Windows.Forms.RadioButton ufsRadioButton;
        private System.Windows.Forms.RadioButton aStarRadioButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.RadioButton maze2RadioButton;
        private System.Windows.Forms.RadioButton maze1RadioButton;
        private System.Windows.Forms.Button setMazeButton;
    }
}

