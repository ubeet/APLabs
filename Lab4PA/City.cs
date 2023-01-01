using static Lab4PA.Funcs;

namespace Lab4PA;

public class City
{
    private double X;
    private double Y;

    public City(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    public static double operator -(City c1, City c2)
    {
        return Math.Sqrt(Pow(c1.X - c2.X, 2) + Pow(c1.Y - c2.Y, 2));
    }

    public override string ToString()
    {
        return $"({X} ; {Y})";
    }
}