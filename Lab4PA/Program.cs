using System;
using static Lab4PA.Funcs;

namespace Lab4PA;

class Program
{
    static void Main(String[] args)
    {
        var cities = CitiesGen(150, 50);
        var antColony = new AntColony(35, 1000, 2, 3, 0.4f, 4, cities);
        antColony.StartAntColony();
    }
}

