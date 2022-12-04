namespace Lab1PA;
using static System.Int32;

public class Funcs
{
    private static void Merge(int[] arr, int l, int m, int r)
    {
        var n1 = m - l + 1;
        var n2 = r - m;

        var L = new int[n1];
        var R = new int[n2];
        int i, j;

        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];


        i = 0;
        j = 0;

        int k = l;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
            }
            else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }
        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    private static void Merge(string ll, string rr, string directory, int n)
    {
        var i = 0;
        var j = 0;

        var lpath = new StreamReader(ll);
        var rpath = new StreamReader(rr);

        int l;
        TryParse(lpath.ReadLine(), out l);
        int r;
        TryParse(rpath.ReadLine(), out r);

        var main = new StreamWriter(directory + $@"\{n}.txt");
        
        while (lpath.Peek() > -1 && rpath.Peek() > -1) {
            if (l <= r) {
                main.WriteLine(l);
                TryParse(lpath.ReadLine(), out l);
            }
            else {
                main.WriteLine(r);
                TryParse(rpath.ReadLine(), out r);
            }
        }

        while (lpath.Peek() > -1) {
            main.WriteLine(l);
            TryParse(lpath.ReadLine(), out l);
        }
        while (rpath.Peek() > -1) {
            main.WriteLine(r);
            TryParse(rpath.ReadLine(), out r);
        }
        
        main.Close();
        lpath.Close();
        rpath.Close();
        
        File.Delete(ll);
        File.Delete(rr);
    }

    private static void TempFileMerging(string splittedFiles)
    {
        var i = 0;
        var files = Directory.GetFiles(splittedFiles, "*", SearchOption.TopDirectoryOnly);
        while (files.Length > 1)
        {
            Merge(files[0], files[1], splittedFiles, i);
            i++;
            files = Directory.GetFiles(splittedFiles, "*", SearchOption.TopDirectoryOnly);
        }
    }

    public static void Sort(int[] arr, int l, int r)
    {
        if (l >= r) return;
        var m = l + (r - l) / 2;

        Sort(arr, l, m);
        Sort(arr, m + 1, r);

        Merge(arr, l, m, r);
    }

    private static void FileSplit(string path, string splitFile, int count)
    {
        var size = File.ReadLines(path).Count();
        var buf = size / count;
        var reader = new StreamReader(path);
        var k = 0;
        for (int i = 1; i <= count; i++)
        {
            var writer = new StreamWriter(string.Format(splitFile, i));
            
            for (int j = k ; j < size - buf * (count - i) - 1; j++)
            {
                writer.WriteLine(reader.ReadLine());
            }
            writer.Write(reader.ReadLine());
            writer.Close();
            k = size - buf * (count - i);
        }
        reader.Close();
        
    }

    private static void SortSplittedFiles(string splittedFiles)
    {
        var fCount = Directory.GetFiles(splittedFiles, "*", SearchOption.TopDirectoryOnly).Length;
        string path;
        int[] arr;
        for (int i = 1; i <= fCount; i++)
        {
            path = splittedFiles + $@"\file{i}.txt";
            arr = Array.ConvertAll(File.ReadAllLines(path), Parse);
            Sort(arr, 0, arr.Length - 1);
            File.WriteAllText(path, string.Join("\n", arr));
        }
    }

    public static void OptimizedSort(string genPath)
    {
        var splittedFiles = Directory
            .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                    .ToString())
                .ToString()) + @"\SplittedFiles";
        var splittedFile = Directory
            .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                    .ToString())
                .ToString()) + @"\SplittedFiles\file{0}.txt";
        FileSplit(genPath, splittedFile, 10);
        SortSplittedFiles(splittedFiles);
        TempFileMerging(splittedFiles);
    }

}