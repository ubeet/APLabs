namespace Lab2PA;

public class IDS
{
    public class Node
    {
        public Node? parent { get; }
        public Cell cell { get; }

        public Node(Node parent, Cell cell)
        {
            this.parent = parent;
            this.cell = cell;
        }
        
    }
    private static bool IsCellHere(List<Node> l, Cell c)
    {
        return l.Any(n => n.cell.x == c.x && n.cell.y == c.y);
    }

    private static Node? FindWay(Cell[,] maze, int sX, int sY, int eX, int eY)
    {
        var open = new List<Node>();
        var closed = new List<Node>();
        var node = new Node(null, maze[sX, sY]);
        open.Add(node);
        var deadEnds = 0;
        var states = 0;
        var iterations = 0;
        var inMemoryStates = 0;
        do
        {
            iterations++;
            var c = false;
            
            var temp = new List<Node>();
            var num = open.Count;
            foreach (var t in open)
            {
                var cc = false;
                var x = t.cell.x;
                var y = t.cell.y;
                var xp = t.cell.x + 1;
                var xm = t.cell.x - 1;
                var yp = t.cell.y + 1;
                var ym = t.cell.y - 1;
                
                if (!maze[xp, y].IsWall && !IsCellHere(temp, maze[xp, y]) && !IsCellHere(closed, maze[xp, y]))
                {
                    c = true;
                    cc = true;
                    if (xp == eX && y == eY)
                    {
                        Console.WriteLine($"Итераций: {iterations}");
                        Console.WriteLine($"Состояний: {states}");
                        Console.WriteLine($"Глухих углов: {deadEnds}");
                        Console.WriteLine($"Состояний в памяти: {inMemoryStates}");
                        return new Node(t, maze[xp, y]);
                    }
                    temp.Add(new Node(t, maze[xp, y]));
                }
                if (!maze[xm, y].IsWall && !IsCellHere(temp, maze[xm, y]) && !IsCellHere(closed, maze[xm, y]))
                {
                    c = true;
                    cc = true;
                    if (xm == eX && y == eY)
                    {
                        Console.WriteLine($"Итераций: {iterations}");
                        Console.WriteLine($"Состояний: {states}");
                        Console.WriteLine($"Глухих углов: {deadEnds}");
                        Console.WriteLine($"Состояний в памяти: {inMemoryStates}");
                        return new Node(t, maze[xm, y]);
                    }
                    temp.Add(new Node(t, maze[xm, y]));
                }
                if (!maze[x, yp].IsWall && !IsCellHere(temp, maze[x, yp]) && !IsCellHere(closed, maze[x, yp]))
                {
                    c = true;
                    cc = true;
                    if (x == eX && yp == eY)
                    {
                        Console.WriteLine($"Итераций: {iterations}");
                        Console.WriteLine($"Состояний: {states}");
                        Console.WriteLine($"Глухих углов: {deadEnds}");
                        Console.WriteLine($"Состояний в памяти: {inMemoryStates}");
                        return new Node(t, maze[x, yp]);
                    }
                    temp.Add(new Node(t, maze[x, yp]));
                }
                if (!maze[x, ym].IsWall && !IsCellHere(temp, maze[x, ym]) && !IsCellHere(closed, maze[x, ym]))
                {
                    c = true;
                    cc = true;
                    if (x == eX && ym == eY)
                    {
                        Console.WriteLine($"Итераций: {iterations}");
                        Console.WriteLine($"Состояний: {states}");
                        Console.WriteLine($"Глухих углов: {deadEnds}");
                        Console.WriteLine($"Состояний в памяти: {inMemoryStates}");
                        return new Node(t, maze[x, ym]);
                    }
                    temp.Add(new Node(t, maze[x, ym]));
                }

                closed.AddRange(open);
                open = new List<Node>(temp);
                if (!cc) deadEnds++;
            }

            inMemoryStates += temp.Count;
            if (c) states++;
            iterations++;

        } while (open.Count != 0);
        Console.WriteLine($"Итераций: {iterations}");
        Console.WriteLine($"Состояний: {states}");
        Console.WriteLine($"Глухих углов: {deadEnds}");
        Console.WriteLine($"Состояний в памяти: {inMemoryStates}");
        Console.WriteLine("Лабиринт невозможно пройти!");
        return null;
    }
    
    public static Cell[,]? IdsAlg(Cell[,] maze, int sX, int sY, int eX, int eY)
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