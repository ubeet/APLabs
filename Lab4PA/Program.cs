using static Lab4PA.Funcs;

namespace Lab4PA;

class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Генерация городов...");
        var cities = Gen(150, 50, 5);
        Console.WriteLine("Города сгенерировались");
        var antColony = new AntColony(35, 200, 2, 3, 0.4, 1000, cities);
        antColony.StartAntColony();
    }
}

