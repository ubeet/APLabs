using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab4PA;

public class Ant
{
    public List<KeyValuePair<City, int>> tabooList { get; set; }
    private int currentCity;
    private int startCity;
    private double[,] pheromones;
    private City[] cities;
    private double a, b;

    public Ant(int startCity, City[] cities, double a, double b, double[,] pheromones)
    {
        this.startCity = startCity;
        this.currentCity = startCity;
        this.cities = cities;
        this.a = a;
        this.b = b;
        tabooList = new List<KeyValuePair<City, int>>();
        this.pheromones = pheromones;
    }

    public void StartTheJourney()
    {
        for (int i = 0; i < cities.Length-1; i++)
        {
            var chances = GetChances();
            var indexOfCity = GetRandomIndex(chances);
            tabooList.Add(new KeyValuePair<City, int>(cities[currentCity], currentCity));
            currentCity = indexOfCity;
        }
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

            
            desires[i] = (Math.Pow(pheromones[currentCity, i], a) 
                          * Math.Pow(4.0 / (cities[currentCity] - cities[i]), b));
            
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

        var sumOfDesires = 0.0;
        //Console.WriteLine();
        //Console.WriteLine();
        foreach (var el in desires)
        {
            //Console.WriteLine(el);
            sumOfDesires += el;
        }

        //Console.WriteLine();
        //Console.WriteLine(sumOfDesires);
        
        for (var i = 0; i < desires.Length; i++)
        {
            var ss = desires[i] / sumOfDesires;
            chances[i] = ss;
        }
            

        return chances;
    }

    private int GetRandomIndex (double[] proportions)
    {
        var proportionsSorted = proportions.OrderBy(n => n).ToArray();
        var randomValue = new Random().NextDouble();
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

        var ii = -1;
        for (int i = 0; i < proportions.Length; i++)
        {

            ii = i;
            if (proportions[i] == proportionsSorted[indexOfNum])
            {
                return i;
            }
        }

        Console.WriteLine($"{proportions[ii]} == {proportionsSorted[indexOfNum]} {proportions[ii] == proportionsSorted[indexOfNum]}");
        throw new Exception("All chances == 0");
    }
}