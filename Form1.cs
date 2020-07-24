using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace Maze_Game
{
    public partial class Form1 : Form
    {
        Button[,] maze = new Button[20, 20];

        List<Tuple<int, int>> currentPositions = new List<Tuple<int, int>>();
        List<Tuple<int, int>> solution = new List<Tuple<int, int>>();

        bool isBfs = false;
        bool isUfs = false;
        bool isAstar = false;

        bool isMaze1 = false;
        bool isMaze2 = false;

        char[,] goalState = new char[20, 20];
        char[,] maze1Char = new char[20, 20] {
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', '-', 'X', '-', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', '-', 'X', 'X'},
                { 'E', '-', '-', '-', 'X', 'X', '-', '-', '-', '-', 'X', 'X', 'X', '-', '-', '-', 'X', '-', '-', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', '-', 'X'},
                { 'X', 'X', '-', '-', 'X', '-', '-', '-', '-', '-', 'X', '-', 'X', 'X', 'X', '-', '-', '-', '-', 'X'},
                { 'X', '-', '-', 'X', 'X', '-', 'X', 'X', 'X', 'X', 'X', '-', '-', '-', '-', 'X', 'X', '-', 'X', 'X'},
                { 'X', 'X', '-', 'X', 'X', '-', 'X', '-', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X', '-', '-', 'X'},
                { 'X', '-', '-', '-', '-', '-', 'X', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', '-', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', '-', '-', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', '-', 'X', '-', 'X', 'X', 'X', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', '-', '-', '-', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', 'X', '-', '-', 'X', 'X', 'X', 'X', 'X', 'X', '-', '-', '-', '-', 'X'},
                { 'X', '-', '-', '-', 'X', '-', '-', 'X', '-', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', '-', 'X'},
                { 'X', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', '-', 'X', '-', '-', 'X'},
                { 'X', '-', '-', '-', '-', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', '-', '-', '-', 'X'},
                { 'X', '-', '-', '-', 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', '-', 'X', '-', 'X'},
                { 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', '-', '-', '-', 'X', 'X', 'X'},
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'C', 'X', 'X', 'X'}
            };

        char[,] maze2Char = new char[20, 20] {
                { 'X', 'E', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
                { 'X', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', 'X'},
                { 'X', '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', '-', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', '-', '-', 'X', '-', '-', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { '-', '-', '-', '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', 'C', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'}
            };

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            GenerateMaze();
            solveButton.Enabled = false;
        }

        private void SolveMaze()
        {
            if(isBfs && isMaze1)
            {
                Maze m = new Maze(maze1Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.BFS(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
            else if(isUfs && isMaze1)
            {
                Maze m = new Maze(maze1Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.UFS(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
            else if(isAstar && isMaze1)
            {
                Maze m = new Maze(maze1Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.AStar(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
            else if (isBfs && isMaze2)
            {
                Maze m = new Maze(maze2Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.BFS(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
            else if (isUfs && isMaze2)
            {
                Maze m = new Maze(maze2Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.UFS(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }

            else if (isAstar && isMaze2)
            {
                Maze m = new Maze(maze2Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.AStar(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
        
        }
        private void SetGoalMaze()
        {
            if (isMaze1)
            {
                for (int i = 0; i < maze1Char.GetLength(0); i++)
                {
                    for (int j = 0; j < maze1Char.GetLength(1); j++)
                    {
                        if (maze1Char[i, j] == 'E')
                            goalState[i, j] = 'C';
                        else if (maze1Char[i, j] == 'C')
                            goalState[i, j] = '-';
                        else
                            goalState[i, j] = maze1Char[i, j];
                    }
                }
            }
            else if(isMaze2)
            {
                for(int i = 0; i < maze2Char.GetLength(0); i++)
                {
                    for (int j = 0; j < maze2Char.GetLength(1); j++)
                    {
                        if (maze2Char[i, j] == 'E')
                            goalState[i, j] = 'C';
                        else if (maze2Char[i, j] == 'C')
                            goalState[i, j] = '-';
                        else
                            goalState[i, j] = maze2Char[i, j];
                    }
                }
            }
        }

        private void SetMaze()
        {
            solveButton.Enabled = true;

            if (isMaze1)
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        if (maze1Char[i, j] == '-')
                            maze[i, j].BackColor = Color.White;
                        else if (maze1Char[i, j] == 'X')
                            maze[i, j].BackColor = Color.Black;
                        else if (maze1Char[i, j] == 'C')
                            maze[i, j].BackColor = Color.Blue;
                        else if (maze1Char[i, j] == 'E')
                            maze[i, j].BackColor = Color.Green;
                    }
                }
            }
            else if(isMaze2)
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        if (maze2Char[i, j] == '-')
                            maze[i, j].BackColor = Color.White;
                        else if (maze2Char[i, j] == 'X')
                            maze[i, j].BackColor = Color.Black;
                        else if (maze2Char[i, j] == 'C')
                            maze[i, j].BackColor = Color.Blue;
                        else if (maze2Char[i, j] == 'E')
                            maze[i, j].BackColor = Color.Green;
                    }
                }
            }
        }
        private void GenerateMaze()
        {
            int xAxis = 60;
            int yAxis = 100;

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Button button = new Button();
                    button.Location = new Point(xAxis, yAxis);
                    button.Height = 30;
                    button.Width = 30;
                    button.AutoSize = true;
                    button.BackColor = Color.White;

                    this.Controls.Add(button);
                    maze[i, j] = button;
                    xAxis += 30;
                }

                xAxis = 60;
                yAxis += 30;
            }

        }

        private async void UpdateGUI()
        {
            foreach (var tuple in currentPositions)
            {
                await Task.Delay(30);
                maze[tuple.Item1, tuple.Item2].BackColor = Color.Red;
            }

            foreach (var tuple in solution)
            {
                await Task.Delay(15);
                maze[tuple.Item1, tuple.Item2].BackColor = Color.Green;
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            currentPositions.Clear();
            solution.Clear();
            ResetBoard();
            solveButton.Enabled = false;

            isBfs = false;
            isUfs = false;
            isAstar = false;

            isMaze1 = false;
            isMaze2 = false;

        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            SolveMaze();
        }

        private void ResetBoard()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j].BackColor = Color.White;
                }
            }
        }

        private void bfsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                isBfs = true;
                isUfs = false;
                isAstar = false;
            }
        }

        private void ufsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                isBfs = false;
                isUfs = true;
                isAstar = false;
            }
        }

        private void aStarRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                isBfs = false;
                isUfs = false;
                isAstar = true;
            }
        }

        private void maze1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                isMaze1 = true;
                isMaze2 = false;
            }
        }

        private void maze2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                isMaze1 = false;
                isMaze2 = true;
            }
        }
    
        private void setMazeButton_Click(object sender, EventArgs e)
        {
            SetMaze();
        }
    }
}
