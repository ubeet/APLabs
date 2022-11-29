namespace Lab2PA;

public class AStar
{
    public class Node
    {
        public Node? parent { get; }
        public Cell cell { get; }
        public int f { get; }
        public int h { get; }
        public int g { get; }

        public Node(Node parent, Cell cell, int h, int g)
        {
            this.parent = parent;
            this.cell = cell;
            f = h + g;
            this.h = h;
            this.g = g;
        }
        
    }

    private static bool IsCellHere(List<Node> l, Cell c)
    {
        return l.Any(n => n.cell.x == c.x && n.cell.y == c.y);
    }

    private static Node? FindWay(Cell[,] maze, int sX, int sY, int eX, int eY)
    {
        var open = new List<Node>();
        var close = new List<Node>();
        var ss = new Node(null, maze[sX, sY], 0, 0);
        var deadEnds = 0;
        var states = 0;
        var iterations = 0;
        
        do
        {
            if (open.Count > 0)
            {
                var min = Int32.MaxValue;
                var inode = 0;
                for (var i = 0; i < open.Count; i++)
                {
                    if (open[i].f < min)
                    {
                        min = open[i].f;
                        inode = i;
                    }
                }

                //Console.WriteLine($"{ss.g}  {ss.cell.x} {ss.cell.y}");
                ss = open[inode];
                open.RemoveAt(inode);
            }
            iterations++;
            var c = false;
            close.Add(ss);
            if (!maze[ss.cell.x, ss.cell.y + 1].IsWall && !IsCellHere(close, maze[ss.cell.x, ss.cell.y + 1]))
            {
                c = true;
                var node = new Node(ss, maze[ss.cell.x, ss.cell.y + 1], ss.h + 10,
                    Math.Abs(eX - ss.cell.x) + Math.Abs(eY - (ss.cell.y + 1)));
                if (node.g == 0)
                {
                    Console.WriteLine($"Итераций: {iterations}");
                    Console.WriteLine($"Состояний: {states}");
                    Console.WriteLine($"Глухих углов: {deadEnds}");
                    Console.WriteLine($"Состояний в памяти: {close.Count}");
                    return node;
                }
                
                open.Add(node);
            }
            
            if (!maze[ss.cell.x, ss.cell.y - 1].IsWall && !IsCellHere(close, maze[ss.cell.x, ss.cell.y - 1]))
            {
                c = true;
                var node = new Node(ss, maze[ss.cell.x, ss.cell.y - 1], ss.h + 10,
                    Math.Abs(eX - ss.cell.x) + Math.Abs(eY - (ss.cell.y - 1)));
                
                if (node.g == 0)
                {
                    Console.WriteLine($"Итераций: {iterations}");
                    Console.WriteLine($"Состояний: {states}");
                    Console.WriteLine($"Глухих углов: {deadEnds}");
                    Console.WriteLine($"Состояний в памяти: {close.Count}");
                    return node;
                }
                open.Add(node);
            }
            
            if (!maze[ss.cell.x + 1, ss.cell.y].IsWall && !IsCellHere(close, maze[ss.cell.x + 1, ss.cell.y]))
            {
                c = true;
                var node = new Node(ss, maze[ss.cell.x + 1, ss.cell.y], ss.h + 10,
                    Math.Abs(eX - (ss.cell.x + 1)) + Math.Abs(eY - ss.cell.y));
                
                if (node.g == 0)
                {
                    Console.WriteLine($"Итераций: {iterations}");
                    Console.WriteLine($"Состояний: {states}");
                    Console.WriteLine($"Глухих углов: {deadEnds}");
                    Console.WriteLine($"Состояний в памяти: {close.Count}");
                    return node;
                }
                open.Add(node);
            }
            
            if (!maze[ss.cell.x - 1, ss.cell.y].IsWall && !IsCellHere(close, maze[ss.cell.x - 1, ss.cell.y]))
            {
                c = true;
                var node = new Node(ss, maze[ss.cell.x - 1, ss.cell.y], ss.h + 10,
                    Math.Abs(eX - (ss.cell.x - 1)) + Math.Abs(eY - ss.cell.y));
                if (node.g == 0)
                {
                    Console.WriteLine($"Итераций: {iterations}");
                    Console.WriteLine($"Состояний: {states}");
                    Console.WriteLine($"Глухих углов: {deadEnds}");
                    Console.WriteLine($"Состояний в памяти: {close.Count}");
                    return node;
                }
                open.Add(node);
            }
            
            if (!c) deadEnds++;
            if (c) states++;
            
        } while (open.Count != 0) ;
        Console.WriteLine($"Итераций: {iterations}");
        Console.WriteLine($"Состояний: {states}");
        Console.WriteLine($"Глухих углов: {deadEnds}");
        Console.WriteLine($"Состояний в памяти: {close.Count}");
        Console.WriteLine("Лабиринт невозможно пройти!");
        return null;
    }

    public static Cell[,]? AStarAlg(Cell[,] maze, int sX, int sY, int eX, int eY)
    {
        var x = maze;
        var n = FindWay(maze, sX, sY, eX, eY);
        if (n == null) return null;
        while (n != null)
        {
            n.cell.IsWay = true;
            x[n.cell.x, n.cell.y] = n.cell;
            n = n.parent;
        }

        return x;
    }
}