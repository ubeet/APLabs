namespace Lab2PA;

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
    
    public Node(Node parent, Cell cell)
    {
        this.parent = parent;
        this.cell = cell;
    }
        
}