using static System.Int32;
using static Lab1PA.Funcs;

class MergeSort {

    
    public static void Main(String[] args)
    {
        var path = Directory
            .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                    .ToString())
                .ToString());
        if (Directory.Exists(path + @"\SplittedFiles"))
        {
            Directory.Delete(path + @"\SplittedFiles", true);
        }
        var sss = DateTime.Now;
        OptimizedSort(path + @"\ss.txt");
        Console.WriteLine("Время сортировки с оптимизацией: " + (DateTime.Now - sss));

        
        var arr = Array.ConvertAll(File.ReadAllLines(path + @"\sss.txt"), Parse);
        
        var ss = DateTime.Now;
        Sort(arr, 0, arr.Length - 1);
        Console.WriteLine("\nВремя сортировки без оптимизации: " + (DateTime.Now - ss));
    }
}
