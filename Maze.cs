using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    public class Maze
    {
        private char[,] maze = new char[20, 20];
        private int[] currentPosition = new int[2];
        private int[] endPosition = new int[2];
        public Maze parent;                                 // keeping track of the parent node to trace back the solution
        public List<Maze> children = new List<Maze>();      // this list holds the nodes that are created when exploring a node   

        private char currentPoint;
        private char endPoint;
        private char blocked;
        public Maze()
        {

        }

        public Maze(char[,] maze)
        {
            this.maze = maze;
            currentPoint = 'C';
            endPoint = 'E';
            blocked = 'X';
        }

        /* Takes in the current state of the maze and the direction of which 
        * move is wanting to be made. This function checks the bounds of the 
        * maze to make sure that the current position isn't at the edge of the
        * maze trying to make a move that is out of the 2D array bounds
        * Returns true or false if the move is valid.
        */
        private bool CheckBounds(string direction, char[,] currentMaze)
        {
            FindCurrentPosition(currentMaze);

            if (direction == "Up")
            {
                if (currentPosition[0] == 0)
                {
                    return false;
                }
            }
            else if (direction == "Down")
            {
                if (currentPosition[0] == 19)
                {
                    return false;
                }
            }
            else if (direction == "Left")
            {
                if (currentPosition[1] == 0)
                {
                    return false;
                }
            }
            else if (direction == "Right")
            {
                if (currentPosition[1] == 19)
                {
                    return false;
                }
            }

            return true;
        }

        /* Takes in the current state of the maze and find the location 
         * of the current position 'C'. The function stores the location
         * of the current position in the currentPosition[] array.
         */
        private void FindCurrentPosition(char[,] currentMaze)
        {
            for (int i = 0; i < currentMaze.GetLength(0); i++)
            {
                for (int j = 0; j < currentMaze.GetLength(1); j++)
                {
                    if (currentMaze[i, j] == currentPoint)
                    {
                        currentPosition[0] = i;
                        currentPosition[1] = j;
                    }
                }
            }
        }

        /* Takes in the current state of the maze and stores the end point 'E' 
         * position in the endPosition[] array.
         */
        private void FindEndPosition(char[,] currentMaze)
        {
            for (int i = 0; i < currentMaze.GetLength(0); i++)
            {
                for (int j = 0; j < currentMaze.GetLength(1); j++)
                {
                    if (currentMaze[i, j] == endPoint)
                    {
                        endPosition[0] = i;
                        endPosition[1] = j;
                    }
                }
            }
        }

        /* This function takes in the current state of the maze and the direction of 
         * which move is going to be made. The function Swaps the two locations in the direction given.
         */
        private void Swap(string direction, char[,] currentMaze)
        {
            if (direction == "Up")
            {
                char temp = currentMaze[(currentPosition[0] - 1), currentPosition[1]];
                currentMaze[(currentPosition[0] - 1), currentPosition[1]] = currentMaze[currentPosition[0], currentPosition[1]];
                currentMaze[currentPosition[0], currentPosition[1]] = temp;
            }
            else if (direction == "Down")
            {
                char temp = currentMaze[(currentPosition[0] + 1), currentPosition[1]];
                currentMaze[(currentPosition[0] + 1), currentPosition[1]] = currentMaze[currentPosition[0], currentPosition[1]];
                currentMaze[currentPosition[0], currentPosition[1]] = temp;
            }
            else if (direction == "Left")
            {
                char temp = currentMaze[currentPosition[0], (currentPosition[1] - 1)];
                currentMaze[currentPosition[0], (currentPosition[1] - 1)] = currentMaze[currentPosition[0], currentPosition[1]];
                currentMaze[currentPosition[0], currentPosition[1]] = temp;
            }
            else if (direction == "Right")
            {
                char temp = currentMaze[currentPosition[0], (currentPosition[1] + 1)];
                currentMaze[currentPosition[0], (currentPosition[1] + 1)] = currentMaze[currentPosition[0], currentPosition[1]];
                currentMaze[currentPosition[0], currentPosition[1]] = temp;
            }
        }

        /* This function takes in the current maze and creates a copy to
         * the a new maze that the program can modify
         */
        private void CopyMaze(char[,] currentMaze, char[,] mazeCopy)
        {
            for (int i = 0; i < currentMaze.GetLength(0); i++)
            {
                for (int j = 0; j < currentMaze.GetLength(1); j++)
                {
                    mazeCopy[i, j] = currentMaze[i, j];
                }
            }
        }

        // Takes in the current state of the maze to move up in the maze
        public void MoveUp(char[,] currentMaze)
        {
            char[,] mazeCopy = new char[20, 20];      // creating new maze
            CopyMaze(currentMaze, mazeCopy);         // copy the maze sent in through the parameter
            FindCurrentPosition(mazeCopy);           // getting the current position of the maze copy

            if (CheckBounds("Up", mazeCopy))         // checking if the move is valid
            {
                // creating a different action if the next move is 'E'. We don't want to
                // Swap we want to just replace the 'E' with 'C' to idicate we have reached the end
                if (mazeCopy[(currentPosition[0] - 1), currentPosition[1]] != blocked)
                {
                    if (mazeCopy[(currentPosition[0] - 1), currentPosition[1]] == endPoint)
                    {
                        mazeCopy[(currentPosition[0] - 1), currentPosition[1]] = currentPoint;
                        mazeCopy[(currentPosition[0]), currentPosition[1]] = '-';

                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);

                    }
                    else
                    {
                        // if the 'E' is not next, Swap, create child and store in children list.
                        Swap("Up", mazeCopy);
                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);
                    }
                }
            }
        }

        // Takes in the current state of the maze to move down in the maze
        public void MoveDown(char[,] currentMaze)
        {
            char[,] mazeCopy = new char[20, 20];         // creating new maze
            CopyMaze(currentMaze, mazeCopy);             // copy the maze sent in through the parameter
            FindCurrentPosition(mazeCopy);               // getting the current position of the maze copy

            if (CheckBounds("Down", mazeCopy))           // checking if the move is valid
            {
                // creating a different action if the next move is 'E'. We don't want to
                // Swap we want to just replace the 'E' with 'C' to idicate we have reached the end
                if (mazeCopy[(currentPosition[0] + 1), currentPosition[1]] != blocked)
                {
                    if (mazeCopy[(currentPosition[0] + 1), currentPosition[1]] == endPoint)
                    {
                        mazeCopy[(currentPosition[0] + 1), currentPosition[1]] = currentPoint;
                        mazeCopy[(currentPosition[0]), currentPosition[1]] = '-';

                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);
                    }
                    else
                    {
                        // if the 'E' is not next, Swap, create child and store in children list.
                        Swap("Down", mazeCopy);
                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);
                    }
                }
            }
        }

        // Takes in the current state of the maze to move left in the maze
        public void MoveLeft(char[,] currentMaze)
        {
            char[,] mazeCopy = new char[20, 20];        // creating new maze
            CopyMaze(currentMaze, mazeCopy);            // copy the maze sent in through the parameter
            FindCurrentPosition(mazeCopy);              // getting the current position of the maze copy

            if (CheckBounds("Left", mazeCopy))          // checking if the move is valid
            {
                // creating a different action if the next move is 'E'. We don't want to
                // Swap we want to just replace the 'E' with 'C' to idicate we have reached the end
                if (mazeCopy[currentPosition[0], (currentPosition[1] - 1)] != blocked)
                {
                    if (mazeCopy[currentPosition[0], (currentPosition[1] - 1)] == endPoint)
                    {
                        mazeCopy[currentPosition[0], (currentPosition[1] - 1)] = currentPoint;
                        mazeCopy[(currentPosition[0]), currentPosition[1]] = '-';

                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);
                    }
                    else
                    {
                        // if the 'E' is not next, Swap, create child and store in children list.
                        Swap("Left", mazeCopy);
                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);
                    }
                }
            }
        }

        // Takes in the current state of the maze to move right in the maze
        public void MoveRight(char[,] currentMaze)
        {
            char[,] mazeCopy = new char[20, 20];        // creating new maze
            CopyMaze(currentMaze, mazeCopy);            // copy the maze sent in through the parameter
            FindCurrentPosition(mazeCopy);              // getting the current position of the maze copy

            if (CheckBounds("Right", mazeCopy))         // checking if the move is valid
            {
                // creating a different action if the next move is 'E'. We don't want to
                // Swap we want to just replace the 'E' with 'C' to idicate we have reached the end
                if (mazeCopy[currentPosition[0], currentPosition[1] + 1] != blocked)
                {
                    if (mazeCopy[currentPosition[0], (currentPosition[1] + 1)] == endPoint)
                    {
                        mazeCopy[currentPosition[0], (currentPosition[1] + 1)] = currentPoint;
                        mazeCopy[(currentPosition[0]), currentPosition[1]] = '-';

                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);
                    }
                    else
                    {
                        // if the 'E' is not next, Swap, create child and store in children list.
                        Swap("Right", mazeCopy);
                        Maze child = new Maze(mazeCopy);
                        child.parent = this;
                        children.Add(child);
                    }
                }
            }
        }

        /* The goal state is being passed in the the AI class and comparing the
         * current state with the goal to see if it matches. Function
         * will return true or false.
         */
        public bool CheckGoalState(char[,] goalState)
        {
            for (int i = 0; i < this.maze.GetLength(0); i++)
            {
                for (int j = 0; j < this.maze.GetLength(1); j++)
                {
                    if (this.maze[i, j] != goalState[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // The function will be called by the AI to explore all the options
        public void Explore()
        {
            MoveUp(maze);
            MoveDown(maze);
            MoveLeft(maze);
            MoveRight(maze);
        }

        public int[] GetCurrentPosition()
        {
            FindCurrentPosition(this.maze);
            return currentPosition;
        }

        public int[] GetEndPosition()
        {
            FindEndPosition(this.maze);
            return endPosition;
        }

        public char[,] GetMaze()
        {
            return maze;
        }

        // Getters and setters of g of n, h of n and total cost
        public int Gof { get; set; }

        public int Hof { get; set; }

        public int Cost { get; set; }

    }
}

