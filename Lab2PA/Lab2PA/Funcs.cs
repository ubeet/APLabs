namespace Lab2PA;

public static class Funcs
{
    public static void PrintInfo(int iterations, int states, int deadEnds, int inMemoryStates)
    {
        Console.WriteLine($"Итераций: {iterations}");
        Console.WriteLine($"Состояний: {states}");
        Console.WriteLine($"Глухих углов: {deadEnds}");
        Console.WriteLine($"Состояний в памяти: {inMemoryStates}");
        Console.WriteLine("Лабиринт невозможно пройти!");
    }
}