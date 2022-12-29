﻿using static Lab2PA.MazeGen;

namespace Lab2PA
{
    class Program
    {
        public static void Main(string[] args)
        {
            var path = Directory
                           .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                                   .ToString())
                               .ToString())
                       + @"\mazes\maze1.txt";

            
            var maze = MatrixGen(path);

            Console.WriteLine();
            Console.WriteLine("Лабиринт без просчитангого пути:");
            PrintMaze(maze);

            var sX = 1; //Convert.ToInt32(Console.ReadLine());
            var sY = 1; //Convert.ToInt32(Console.ReadLine());
            var eX = 39; //Convert.ToInt32(Console.ReadLine());
            var eY = 39; //Convert.ToInt32(Console.ReadLine());
            
            var aStar = new AStar();
            var ids = new IDS();
            
            var maze1 = aStar.AStarAlg(maze, sX, sY, eX, eY);
            Console.WriteLine();
            
            if (maze1 != null)
            {
                Console.WriteLine("Лабиринт после нахождения пути IDS алгоритмом:");
                PrintMaze(maze1);
            }
            var maze2 = ids.IdsAlg(maze, sX, sY, eX, eY);
            if (maze2 != null)
            {
                Console.WriteLine("Лабиринт после нахождения пути A* алгоритмом:");
                PrintMaze(maze2);
            }
            
        }
    }
}