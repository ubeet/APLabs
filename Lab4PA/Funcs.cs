using System;

namespace Lab4PA;

public class Funcs
{
    public static City[] CitiesGen(int numOfCities, int maxDistance)
    {
        var cities = new City[numOfCities];
        var rnd = new Random();
        
        for (int i = 0; i < numOfCities; i++)
            cities[i] = new City(rnd.Next(0, numOfCities + 1), rnd.Next(0, numOfCities + 1));

        return cities;
    }
    
}