
namespace Lab4PA;

public class AntColony
{
    private int ants;
    private int iterations;
    private double p, Q, a, b;
    private City[] cities;

    public AntColony(int ants, int iterations, double a, double b, double p, double q, City[] cities)
    {
        this.ants = ants;
        this.iterations = iterations;
        this.p = 1 - p;
        Q = q;
        this.a = a;
        this.b = b;
        this.cities = cities;
    }

    public double StartAntColony()
    {
        
        var rnd = new Random();
        var pheromones = CreatePheromoneMatrix(cities.Length);
        
        double distance = 0;
        var minDistance = Double.MaxValue;
        List<KeyValuePair<City, int>> minJourney = null;
        for (int i = 0; i < iterations; i++)
        {
            var pheromonesCopy = MatrixCopy(pheromones);
            pheromones = EvaporationOfPheromones(pheromones);
            var minAntDistance = double.MaxValue;
            for (int j = 0; j < ants; j++)
            {
                
                var ant = new Ant(rnd.Next(0, cities.Length), cities, a, b, pheromonesCopy);
                ant.StartTheJourney();
                var antJourney = ant.tabooList;
                distance = DistanceOfTheJourney(antJourney);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minJourney = antJourney;
                }
                if (distance < minAntDistance)
                    minAntDistance = distance;
                    
                pheromones = SetNewPheromones(antJourney, distance, pheromones);
            }
            
            Console.WriteLine($"Дистанция после {i+1} итерации: {minAntDistance}");

        }

        if (minJourney != null)
            Console.WriteLine($"Лучший путь:\n{JourneyToString(minJourney)}\nДистанция: {minDistance}");
        return minDistance;
    }

    private string JourneyToString(List<KeyValuePair<City, int>> antJourney)
    {
        var citiesIndex = antJourney.Select(el => el.Value).ToList();
        return string.Join('-', citiesIndex);
    }
    private double[,] SetNewPheromones(List<KeyValuePair<City, int>> antJourney, double distance, double[,] pheromones)
    {
        for (int i = 0; i < antJourney.Count - 1; i++)
            pheromones = ChangeValueOfPheromones(pheromones, antJourney[i].Value, antJourney[i + 1].Value, Q / distance);
        
        return pheromones;
    }

    private double DistanceOfTheJourney(List<KeyValuePair<City, int>> antJourney)
    {
        var distance = 0.0;
        for (var i = 0; i < antJourney.Count-1; i++)
            distance += antJourney[i].Key - antJourney[i + 1].Key;
        
        return distance;
    }
    
    private double[,] EvaporationOfPheromones(double[,] pheromones)
    {
        for (int i = 0; i < pheromones.GetLength(0); i++)
        {
            for (int j = 0; j < pheromones.GetLength(1); j++)
            {
                pheromones[i, j] *= p;
            }
        }

        return pheromones;
    }

    private double[,] MatrixCopy(double[,] matrix)
    {
        var copy = new double[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < copy.GetLength(0); i++)
        {
            for (int j = 0; j < copy.GetLength(1); j++)
            {
                copy[i, j] = matrix[i, j];
            }
        }
        return copy;
    }
    
    private double[,] ChangeValueOfPheromones(double[,] pheromones, int i, int j, double value)
    {
        pheromones[i, j] = value;
        pheromones[j, i] = value;
        return pheromones;
    }
    
    private double[,] CreatePheromoneMatrix(int numOfCities)
    {
        var pheromone = new double[numOfCities, numOfCities];
        for (int i = 0; i < pheromone.GetLength(0); i++)
        {
            for (int j = 0; j < pheromone.GetLength(1); j++)
            {
                pheromone[i, j] = 2;
            }
        }

        return pheromone;
    }
}