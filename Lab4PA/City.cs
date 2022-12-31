using System;

namespace Lab4PA;

public class City
{
    private int X {get;}
    private int Y {get;}

    public City(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public static float operator -(City c1, City c2)
    {
        //Console.WriteLine((float) Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2)));
        return (float) Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2));
    }
}