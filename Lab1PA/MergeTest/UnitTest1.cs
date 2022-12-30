namespace MergeTest;
using static Lab1PA.Funcs;


public class Tests
{
    [Test]
    public void TestVoidArray()
    {
        var array = new int[0];
        var expectedArray = new int[0];
        Sort(array, 0, array.Length - 1);
        Assert.AreEqual(expectedArray, array);
    }
    
    [Test]
    public void Test1LenghtArray()
    {
        var array = new int[] {1};
        var expectedArray = new int[] {1};
        Sort(array, 0, array.Length - 1);
        Assert.AreEqual(expectedArray, array);
    }

    [Test]
    public void TestShortNums()
    {
        var array = new int[] {6, 7, 3, 2, 5, 8, 1, 9, 10, 4};
        var expectedArray = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        Sort(array, 0, array.Length - 1);
        Assert.AreEqual(expectedArray, array);
    }
    
    [Test]
    public void TestLongNums()
    {
        var array = new int[] {23421, 543674, 32145, 123578, 3824, 23489, 5687, 12435978, 89234, 41234905, 123512, 89453, 920385, 172346};
        var expectedArray = new int[] {3824, 5687, 23421, 23489, 32145, 89234, 89453, 123512, 123578, 172346, 543674, 920385, 12435978, 41234905};
        Sort(array, 0, array.Length - 1);
        Assert.AreEqual(expectedArray, array);
    }
}