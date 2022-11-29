namespace Lab2PA;

public class MazeGen
{
    public static Cell[,] MatrixGen(string path)
    {
        var ss = ConvertMaze(path);
        var maze = new Cell[ss[0].Length, ss.Length];
        Console.WriteLine($"Размер лабиринта с учетом стен: {maze.GetLength(0)}x{maze.GetLength(1)}");
        for (int i = 0; i < ss.Length; i++)
        {
            int k = 0;
            for (int j = 0; j < ss[i].Length; j++)
            {
                if (ss[i][j].Equals('#')) maze[i, j] = new Cell(i, j, true);
                if (ss[i][j].Equals('.')) maze[i, j] = new Cell(i, j, false);
            }
        }

        return maze;
    }

    private static string[] ConvertMaze(string path)
    {
        var s = File.ReadAllLines(path);
        var newStrings = new string[s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            var str = "";
            var k = 0;
            for (int j = 0; j < s[i].Length; j = j + k)
            {
                k = k == 2 ? 1 : 2;
                str += s[i][j];
            }

            newStrings[i] = str;
        }

        return newStrings;
    }
    public static void PrintMaze(Cell[,] maze)
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                Console.Write(maze[i, j]);
            }

            Console.WriteLine();
        }
    }
}