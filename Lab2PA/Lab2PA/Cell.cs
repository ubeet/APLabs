namespace Lab2PA;

public class Cell
{
    public int x, y;
    public bool IsWall{get; set;}
    public bool IsWay = false;


    public Cell(int x, int y, bool isWall)
    {
        this.x = x;
        this.y = y;
        IsWall = isWall;
    }
    
    


    public override string ToString()
    {
        if (IsWay) return "##";
        if (!IsWall) return "  ";
        return "██";
    }
}