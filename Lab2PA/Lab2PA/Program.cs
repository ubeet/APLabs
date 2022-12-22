using static Lab2PA.MazeGen;
using static Lab2PA.AStar;
using static Lab2PA.IDS;

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
                       + @"\mazes\maze2.txt";
            
            var maze = MatrixGen(path);

            Console.WriteLine();
            Console.WriteLine("Лабиринт без просчитангого пути:");
            PrintMaze(maze);

            var sX = 1; //Convert.ToInt32(Console.ReadLine());
            var sY = 1; //Convert.ToInt32(Console.ReadLine());
            var eX = 39; //Convert.ToInt32(Console.ReadLine());
            var eY = 39; //Convert.ToInt32(Console.ReadLine());
            
            var maze1 = AStarAlg(maze, sX, sY, eX, eY);
            Console.WriteLine();
            
            if (maze1 != null)
            {
                Console.WriteLine("Лабиринт после нахождения пути IDS алгоритмом:");
                PrintMaze(maze1);
            }
            var maze2 = IdsAlg(maze, sX, sY, eX, eY);
            if (maze2 != null)
            {
                Console.WriteLine("Лабиринт после нахождения пути A* алгоритмом:");
                PrintMaze(maze2);
            }
            
        }
    }
}