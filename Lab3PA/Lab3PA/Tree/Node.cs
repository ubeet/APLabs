namespace Lab3PA.Tree;

public class Node
{
    public int key { get; set; }
    public int height { get; set; }
    public Node? nodeL { get; set; }
    public Node? nodeR { get; set; }

    public Node(int key, int height)
    {
        this.key = key;
        nodeL = null;
        nodeR = null;
        this.height = height; 
    }
    public Node(int key)
    {
        this.key = key;
        nodeL = null;
        nodeR = null;
        height = 1; 
    }
}