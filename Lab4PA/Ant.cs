using static Lab4PA.Funcs;

namespace Lab4PA;

public class Ant
{
    public List<KeyValuePair<City, int>> tabooList { get; }
    private int currentCity;
    private int startCity;
    private double[,] pheromones;
    private City[] cities;
    private double a, b;

    public Ant(int startCity, City[] cities, double a, double b, double[,] pheromones)
    {
        this.startCity = startCity;
        currentCity = startCity;
        this.cities = cities;
        this.a = a;
        this.b = b;
        tabooList = new List<KeyValuePair<City, int>>();
        this.pheromones = pheromones;
    }

    public void StartTheJourney()
    {
        for (int i = 0; i < cities.Length - 1; i++)
        {
            var chances = GetChances();
            var indexOfCity = GetRandomIndex(chances, i);
            tabooList.Add(new KeyValuePair<City, int>(cities[currentCity], currentCity));
            currentCity = indexOfCity;
        }
        tabooList.Add(new KeyValuePair<City, int>(cities[currentCity], currentCity));
        tabooList.Add(new KeyValuePair<City, int>(cities[startCity], startCity));
    }

    private double[] GetDesires()
    {
        var desires = new double[cities.Length];
        for (var i = 0; i < cities.Length; i++)
        {
            if (i == currentCity || IsKeyPairListContains(tabooList, i))
            {
                desires[i] = 0;
                continue;
            }

            var desire = Pow(pheromones[currentCity, i] * 100000, a)
                         * Pow( 30.0 / (cities[currentCity] - cities[i]), b);
            
            if (desire == 0)
                desires[i] = double.Epsilon;
            else
                desires[i] = desire;

        }

        return desires;
    }

    

    private static bool IsKeyPairListContains(List<KeyValuePair<City, int>> list, int i)
    {
        return list.Any(keyValuePair => keyValuePair.Value == i);
    }
    

    private double[] GetChances()
    {
        var desires = GetDesires();
        var chances = new double[desires.Length];

        var sumOfDesires = desires.Sum();

        for (var i = 0; i < desires.Length; i++)
        {
            var ss = desires[i] * 100 / sumOfDesires;
            chances[i] = ss;
        }
            

        return chances;
    }

    
    private int GetRandomIndex (double[] proportions, int k)
    {
        var proportionsSorted = new double[proportions.Length];
        Array.Copy(proportions, proportionsSorted, proportions.Length);
        Array.Sort(proportionsSorted);
        var randomValue = new Random().NextDouble() * 100;
        int indexOfNum = -1;
        for (int i = 0; i < proportionsSorted.Length; i++)
        {
            if (randomValue > proportionsSorted[i])
                randomValue -= proportionsSorted[i];
            else
            {
                indexOfNum = i;
                break;
            }
        }

        if (indexOfNum == -1) throw new Exception("All chances == 0");

        for (int i = 0; i < proportions.Length; i++)
        {
            if (proportions[i] == proportionsSorted[indexOfNum]) return i;
        }

        throw new Exception("All chances == 0");
    }
}