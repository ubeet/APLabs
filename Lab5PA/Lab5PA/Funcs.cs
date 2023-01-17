namespace Lab5PA;

public static class Funcs
{
    public static int[,] GenerateDistances(int numOfCities)
    {
        var matrix = new int[numOfCities, numOfCities];
        var rnd = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j)
                {
                    matrix[i, j] = 0;
                    continue;
                }

                matrix[i, j] = rnd.Next(5, 50);
                matrix[j, i] = rnd.Next(5, 50);
            }
        }

        return matrix;
    }
}