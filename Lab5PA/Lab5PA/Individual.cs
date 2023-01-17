using System.Collections;

namespace Lab5PA;

public class Individual
{
    public List<int> cities { get; set; }

    private int[,] distanceMatrix;
    
    public Individual(List<int> cities, int[,] distanceMatrix)
    {
        this.distanceMatrix = distanceMatrix;
        this.cities = cities;
    }
    public Individual(int numOfCities, int[,] distanceMatrix)
    {
        this.distanceMatrix = distanceMatrix;
        cities = CitiesGen(numOfCities);
    }

    private List<int> CitiesGen(int numOfCities)
    {
        var citiesList = new int[numOfCities];
        var rnd = new Random();
        for (var i = 0; i < numOfCities; i++)
        {
            var j = rnd.Next(i + 1);
            if (j != i)
                citiesList[i] = citiesList[j];
            citiesList[j] = i;
        }

        

        return new List<int>(citiesList);
    }

    public int Distance()
    {
        var d = 0;
        for (int i = 1; i < cities.Count; i++)
            d += distanceMatrix[cities[i - 1], cities[i]];

        return d;
    }
    
    public static int CompareById(Individual ind1, Individual ind2)
    {
        return ind1.Distance().CompareTo(ind2.Distance());
    }

}