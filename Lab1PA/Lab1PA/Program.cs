using static System.Int32;
using static Lab1PA.Funcs;

class MergeSort {

    
    public static void Main(String[] args)
    {
        
        var sss = DateTime.Now;
        OptimizedSort(Directory
            .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                    .ToString())
                .ToString()) + @"\ss.txt");
        Console.WriteLine((DateTime.Now - sss));
        
        Console.ReadLine();
        
        var arr = Array.ConvertAll(File.ReadAllLines(Directory
            .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                    .ToString())
                .ToString()) + @"\sss.txt"), Parse);
        
        var ss = DateTime.Now;
        Sort(arr, 0, arr.Length - 1);
        Console.WriteLine((DateTime.Now - ss));
    }
}
