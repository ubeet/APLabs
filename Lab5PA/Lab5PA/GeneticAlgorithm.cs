using static Lab5PA.Funcs;

namespace Lab5PA;

public class GeneticAlgorithm
{
    private int numOfCities;
    private int[,] distanceMatrix;
    private double chanceOfMutation;
    private int numOfPopulation;

    public GeneticAlgorithm(int numOfCities, double chanceOfMutation, int numOfPopulation)
    {
        this.numOfCities = numOfCities;
        this.chanceOfMutation = chanceOfMutation;
        this.numOfPopulation = numOfPopulation;
    }
    public void StartAlgorithm(int iterations)
    {
        distanceMatrix = GenerateDistances(numOfCities);
        var population = new List<Individual>();
        var first = new Individual(numOfCities, distanceMatrix);
        first.cities.Sort();
        population.Add(new Individual(numOfCities, distanceMatrix));
        for (var i = 1; i < numOfPopulation; i++)
        {
            population.Add(new Individual(numOfCities, distanceMatrix));
        }
        for (int j = 0; j < iterations; j++)
        {
            population = Reproduction(population);
            population = RemoveTheWeak(population);

            Console.WriteLine($"Итерация: {j+1}\n Лучшая дистанция: {population[1].Distance()}");
            Console.WriteLine();
        }
        
    }

    private List<Individual> RemoveTheWeak(List<Individual> population)
    {
        population.Sort(Individual.CompareById);
        population.RemoveAt(population.Count - 1);
        population.RemoveAt(population.Count - 1);
        return population;
    }

    private List<Individual> Reproduction(List<Individual> population)
    {
        var rnd = new Random();
        
        var rnd1 = rnd.Next(population.Count);
        int rnd2;
        do
            rnd2 = rnd.Next(population.Count);
        while (rnd2 == rnd1);
        
        var parent1 = population[rnd1];
        var parent2 = population[rnd2];

        var (child1, child2) = GetChildren(parent1, parent2);

        child1 = Mutation(child1);
        child2 = Mutation(child2);
        
        population.Add(child1);
        population.Add(child2);
        return population;
    }

    private Individual Mutation(Individual child)
    {
        var rnd = new Random();
        if (rnd.NextDouble() <= chanceOfMutation)
        {
            var el1 = rnd.Next(child.cities.Count);
            var el2 = rnd.Next(child.cities.Count);
            (child.cities[el1], child.cities[el2]) = (child.cities[el2], child.cities[el1]);
        }

        return child;
    }
    private (Individual, Individual) GetChildren(Individual parent1, Individual parent2)
    {
        var rnd = new Random();
        var childBreak = rnd.Next(numOfCities);

        var child1 = FillChild(parent1, parent2, childBreak);
        var child2 = FillChild(parent2, parent1, childBreak);

        return (child1, child2);
    }

    private Individual FillChild(Individual parent1, Individual parent2, int childBreak)
    {
        var childCities = parent1.cities.GetRange(0, childBreak);
        
        for (int i = childBreak; i < parent2.cities.Count; i++)
            if (!childCities.Contains(parent2.cities[i]))
                childCities.Add(parent2.cities[i]);

        if (childCities.Count < parent1.cities.Count)
            for (int i = childBreak; i < parent1.cities.Count; i++)
                if (!childCities.Contains(parent1.cities[i]))
                    childCities.Add(parent1.cities[i]);

        return new Individual(childCities, distanceMatrix);
    }
    

    
}