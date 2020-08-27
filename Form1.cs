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

        bool isMaze1 = false;
        bool isMaze2 = false;
        bool isMaze3 = false;

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

        char[,] maze3Char = new char[20, 20];
               

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            GenerateMaze();
        }

        private void GenerateMaze3()
        {
            Random rnd = new Random();
           
            for (int i = 0; i < maze3Char.GetLength(0); i++)
            {
                for (int j = 0; j < maze3Char.GetLength(1); j++)
                {
                    int number = rnd.Next(4);
                    if (number == 0)
                    {
                        maze3Char[i, j] = 'X';
                    }
                    else
                    {
                        maze3Char[i, j] = '-';
                    }
                }
            }

           int start = rnd.Next(20);
           int goal = rnd.Next(20);

           maze3Char[start, 0] = 'C';
           maze3Char[goal, 19] = 'E';

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
            else if (isMaze3)
            {
                for (int i = 0; i < maze3Char.GetLength(0); i++)
                {
                    for (int j = 0; j < maze3Char.GetLength(1); j++)
                    {
                        if (maze3Char[i, j] == 'E')
                            goalState[i, j] = 'C';
                        else if (maze3Char[i, j] == 'C')
                            goalState[i, j] = '-';
                        else
                            goalState[i, j] = maze3Char[i, j];
                    }
                }
            }
        }
        private void GenerateMaze()
        {
            int xAxis = 250;
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

                xAxis = 250;
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
                await Task.Delay(20);
                maze[tuple.Item1, tuple.Item2].BackColor = Color.Green;
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            currentPositions.Clear();
            solution.Clear();
            ResetBoard();

            isMaze1 = false;
            isMaze2 = false;
            isMaze3 = false;

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


        private void mazeOneButton_Click(object sender, EventArgs e)
        {
            isMaze1 = true;
            isMaze2 = false;
            isMaze3 = false;

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

        private void mazeTwoButton_Click(object sender, EventArgs e)
        {
            isMaze1 = false;
            isMaze2 = true;
            isMaze3 = false;

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

        private void mazeThreeButton_Click(object sender, EventArgs e)
        {
            isMaze1 = false;
            isMaze2 = false;
            isMaze3 = true;
            GenerateMaze3();

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze3Char[i, j] == '-')
                        maze[i, j].BackColor = Color.White;
                    else if (maze3Char[i, j] == 'X')
                        maze[i, j].BackColor = Color.Black;
                    else if (maze3Char[i, j] == 'C')
                        maze[i, j].BackColor = Color.Blue;
                    else if (maze3Char[i, j] == 'E')
                        maze[i, j].BackColor = Color.Green;
                }
            }
        }

        private void bfsButton_Click(object sender, EventArgs e)
        {
            if (isMaze1)
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
            else if (isMaze2)
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
            else if (isMaze3)
            {
                Maze m = new Maze(maze3Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.BFS(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
        }

        private void ufsButton_Click(object sender, EventArgs e)
        {
            if (isMaze1)
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
            else if (isMaze2)
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
            else if (isMaze3)
            {
                Maze m = new Maze(maze3Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.UFS(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
        }

        private void aStarButton_Click(object sender, EventArgs e)
        {
            if (isMaze1)
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
            else if (isMaze2)
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
            else if (isMaze3)
            {
                Maze m = new Maze(maze3Char);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                SetGoalMaze();
                ai.SetGoalState(goalState);
                ai.AStar(m);
                currentPositions = ai.GetPositions();
                solution = ai.GetSolution();
                UpdateGUI();
            }
        }
    }
}
