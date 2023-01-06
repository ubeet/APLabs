using Lab4PA;

namespace AntTest;

public class Tests
{
    
    [Test]
    public void   Test1000Iterations()
    {
        var cities = Gen(150, 50, 5);
        var antColony = new AntColony(35, 1000, 2, 3, 0.4, 1000, cities);
        var distance = antColony.StartAntColony();
        if (distance < 1700 && distance > 1400)
            Assert.Pass();
        else
            Assert.Fail();
        
    }
    
    [Test]
    public void Test500Iterations()
    {
        var cities = Gen(150, 50, 5);
        var antColony = new AntColony(35, 500, 2, 3, 0.4, 1000, cities);
        var distance = antColony.StartAntColony();
        if (distance < 1700 && distance > 1400)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void Test200Iterations()
    {
        var cities = Gen(150, 50, 5);
        var antColony = new AntColony(35, 200, 2, 3, 0.4, 1000, cities);
        var distance = antColony.StartAntColony();
        if (distance < 1800 && distance > 1500)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    
    
    [Test]
    public void Test50Iterations()
    {
        var cities = Gen(150, 50, 5);
        var antColony = new AntColony(35, 50, 2, 3, 0.4, 1000, cities);
        var distance = antColony.StartAntColony();
        if (distance < 2000 && distance > 1500)
            Assert.Pass();
        else
            Assert.Fail();
    }
}