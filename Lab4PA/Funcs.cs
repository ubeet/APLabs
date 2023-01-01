namespace Lab4PA;

public static class Funcs
{

    public static double Pow(double x, double pow)
    {
        double c = 1;
        for (int i = 0; i < pow; i++)
            c *= x;

        return c;
    }

    public static City[] Gen(int numOfCities, int maxDistance, int minDistance)
    {

        var ss = new List<City>();
        Random rnd = new Random();
        while (ss.Count < numOfCities)
        {
            var c = new City(rnd.NextDouble() * maxDistance * 2, rnd.NextDouble() * maxDistance * 2);
            var f = true;
            foreach (var p in ss)
            {
                if (c - p < minDistance )
                {
                    f = false;
                    break;
                }
            }
            if (f) ss.Add(c);
        }

        return ss.ToArray();
    }
    
}