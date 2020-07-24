using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO.Ports;

namespace Maze_Game
{
    public class Artificial_Intelligence
    {
        char[,] goalState = new char[20, 20];
        List<Tuple<int,int>> positions = new List<Tuple<int, int>>();
        List<Tuple<int, int>> solutionGUI = new List<Tuple<int, int>>();

        public Artificial_Intelligence()
        {
        }

        /* This function takes in the current state of the maze and the list of visited nodes
         * It compares the maze state to the states that have been stored into the visited list
         * We don't want to explore a node that has already been explored. The function returns
         * true if the current state matches a state within the visited list
         */
        private bool CompareVisited(Maze maze, List<Maze> v)
        {
            if (v.Count == 0)
                return false;

            // Instead of comparing the entire maze, we check the position of the 'C' to
            // previous maze state positions. 
            for (int i = 0; i < v.Count; i++)
            {
                int[] mazeCurrentPosition = new int[2];
                mazeCurrentPosition = maze.GetCurrentPosition();

                int[] visitedCurrentPosition = new int[2];
                visitedCurrentPosition = v[i].GetCurrentPosition();

                if (mazeCurrentPosition[0] == visitedCurrentPosition[0] && mazeCurrentPosition[1] == visitedCurrentPosition[1])
                {
                    return true;
                }
            }
            return false;
        }

        /* We take in the current state of the maze and update the solution list 
         * with the nodes that led to the 'E' 
         */
        private void TraceBackSolution(List<Maze> solution, Maze m)
        {
            // Use a tuple to store the location of every 'C' that led to the solution
            
            Maze maze = m;
            solution.Add(m);

            // iterate through every child node
            while (maze.parent != null)
            {
                maze = maze.parent;
                int[] currentPosition = new int[2];         // creating a new array in to store the current positions
                currentPosition = maze.GetCurrentPosition();
                solutionGUI.Add(Tuple.Create(currentPosition[0], currentPosition[1]));
                solution.Add(maze);
            }

            char[,] solutionMaze = new char[20, 20];         // creating a new maze with the solution
            solutionMaze = m.GetMaze();                     // setting the maze to the current maze

            // iterating through the tuple and changing the 'C' in every maze state to '#'
            // to visually show the solution in the new solution maze
            foreach (var tuple in solutionGUI)
            {
                solutionMaze[tuple.Item1, tuple.Item2] = '#';
            }
        }

        // Quick sort algorithm from geekforgeeks.org
        static int Partition(List<Maze> list, int low, int high)
        {
            Maze pivot = new Maze();
            pivot = list[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (list[j].Cost < pivot.Cost)
                {
                    i++;
                    // swap arr[i] and arr[j] 
                    Maze temp = new Maze();
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            Maze temp1 = new Maze();
            temp1 = list[i + 1];
            list[i + 1] = list[high];
            list[high] = temp1;

            return i + 1;
        }

        static void QuickSort(List<Maze> list, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(list, low, high);

                QuickSort(list, low, pi - 1);
                QuickSort(list, pi + 1, high);
            }
        }

        // Taking in the current maze and calculating the H of n
        private int CalculateH(Maze maze)
        {
            int[] temp1 = new int[2];
            temp1 = maze.GetCurrentPosition();

            int[] temp2 = new int[2];
            temp2 = maze.GetEndPosition();

            /* To calculate h of n, we take the distance of how far the 'E' exit is from
             * the current position 'C'. We are going to use the manhattan distance.
             * Since its a 2D array, we take the amount of spaces in the x direction plus
             * the amount of spaces in the y direction and add them together to get the h of n.
             * So just take the 'E' position and subtract the 'C' position in both x and y direction.
             */
            int x = Math.Abs(temp2[0] - temp1[0]);
            int y = Math.Abs(temp2[1] - temp1[1]);

            return x + y;
        }

        // setting the goal state from the main
        public void SetGoalState(char[,] goal)
        {
            for (int i = 0; i < goal.GetLength(0); i++)
            {
                for (int j = 0; j < goal.GetLength(1); j++)
                {
                    this.goalState[i, j] = goal[i, j];
                }
            }
        }

        // Breadth first Search algorithm
        public void BFS(Maze initialState)
        {
            Queue queue = new Queue();                      // creating queue for nodes
            List<Maze> visited = new List<Maze>();          // creating list for visited nodes
            List<Maze> solution = new List<Maze>();         // creating list to trace back solution
            bool goal = false;

            queue.Enqueue(initialState);                    // insert the initial state into the queue first

            // loop until there no more nodes to visit
            // of the goal has been found
            while (queue.Count != 0 && !goal)
            {
                Maze node = (Maze)queue.Dequeue();          // popping the first element off the queue                        // explore that node and then add it to  
                node.Explore();                             // the visited list
                visited.Add(node);

                int[] currentPosition = new int[2];         
                currentPosition = node.GetCurrentPosition();
                positions.Add(Tuple.Create(currentPosition[0], currentPosition[1]));
                // loop through all the nodes that were created when exploring 
                for (int i = 0; i < node.children.Count; i++)
                {
                    if (node.children[i].CheckGoalState(goalState))       // checking if the current child is the goal
                    {
                        goal = true;                                      // if true, it breaks the loop
                        TraceBackSolution(solution, node.children[i]);    // calling the function to trace solution
                    }
                    else if (!CompareVisited(node.children[i], visited))  // Checking to see if the node we want to put 
                    {                                                     // into the queue hasn't already been 
                        queue.Enqueue(node.children[i]);                  // explored
                    }
                }
            }
        }

        // Uniform Cost Search Algorithm
        public void UFS(Maze initialState)
        {
            List<Maze> pq = new List<Maze>();           // using a list because its easier to sort than a queue
            List<Maze> visited = new List<Maze>();      // creating list for visited nodes
            List<Maze> solution = new List<Maze>();     // creating list to trace back solution
            bool goal = false;

            pq.Insert(0, initialState);                 // insert initial state to the front of the list

            // loop until there are no more nodes or until the goal is found
            while (pq.Count > 0 && !goal)
            {
                Maze node = pq[0];          // setting the node to the first spot in the list
                node.Explore();             // explore the node and then add it to the visited list.
                visited.Add(node);          // since we are using a list, we have to remove from the list
                pq.RemoveAt(0);

                int[] currentPosition = new int[2];
                currentPosition = node.GetCurrentPosition();
                positions.Add(Tuple.Create(currentPosition[0], currentPosition[1]));

                // Same as before with the looping through the children after exploring
                for (int i = 0; i < node.children.Count; i++)
                {
                    if (node.children[i].CheckGoalState(goalState))
                    {
                        goal = true;
                        TraceBackSolution(solution, node.children[i]);
                    }
                    else if (!CompareVisited(node.children[i], visited))
                    {
                        node.children[i].Gof = (node.children[i].parent.Gof + 1);   // g of n is calculated by the the parent's g of n and + 1
                        node.children[i].Cost = (node.children[i].Gof);             // There is no h for UFS so g of n is the total cost of each node
                        pq.Add(node.children[i]);
                    }
                }
                // the algorithm is sorted by the total cost of each node.
                // the only cost element is the g of n for UFS
                // smaller cost nodes are in the front
                QuickSort(pq, 0, (pq.Count - 1));
            }
        }

        // A star search algorithm
        public void AStar(Maze initialState)
        {
            List<Maze> pq = new List<Maze>();               // ---------------
            List<Maze> visited = new List<Maze>();          // Same as UFS
            List<Maze> solution = new List<Maze>();         // ---------------
            bool goal = false;                              // Keeping track of h of n as well
            int hof;

            pq.Insert(0, initialState);

            while (pq.Count > 0 && !goal)
            {
                Maze node = pq[0];
                node.Explore();
                visited.Add(node);
                pq.RemoveAt(0);

                int[] currentPosition = new int[2];
                currentPosition = node.GetCurrentPosition();
                positions.Add(Tuple.Create(currentPosition[0], currentPosition[1]));


                for (int i = 0; i < node.children.Count; i++)
                {
                    if (node.children[i].CheckGoalState(goalState))
                    {
                        goal = true;
                        TraceBackSolution(solution, node.children[i]);
                    }
                    else if (!CompareVisited(node.children[i], visited))
                    {
                        hof = CalculateH(node.children[i]);
                        node.children[i].Gof = (node.children[i].parent.Gof + 1); // g of n is calculated by the the parent's g of n and + 1
                        node.children[i].Hof = hof;
                        node.children[i].Cost = (hof + node.children[i].Gof);    // the total cost is h of n + g of n
                        pq.Add(node.children[i]);
                    }
                }
                // sorting by the total cost so the smaller cost nodes are in the front.
                QuickSort(pq, 0, (pq.Count - 1));
            }
        }

        public List<Tuple<int, int>> GetPositions()
        {
            return positions;
        }

        public List<Tuple<int, int>> GetSolution()
        {
            return solutionGUI;
        }
    }
}
