namespace Lab5PA;

class Program
{
    static void Main(String[] args)
    {
        
        new GeneticAlgorithm(300, 0.20, 100).StartAlgorithm(200000);
    }
}