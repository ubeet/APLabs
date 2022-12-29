namespace MazeTest;

using Lab2PA;

public class Tests
{
    private static readonly string path1 = Directory.GetParent(Directory
                                               .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                                                       .ToString())
                                                   .ToString()).ToString())
                                           + @"\Lab2PA\mazes\maze1.txt";

    private static readonly string path2 = Directory.GetParent(Directory
                                               .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                                                       .ToString())
                                                   .ToString()).ToString())
                                           + @"\Lab2PA\mazes\maze2.txt";

    [Test]
    public void FailedAStarTest()
    {
        var maze = MazeGen.MatrixGen(path1);
        maze = (new AStar()).AStarAlg(maze, 1, 1, 39, 39);
        
        Assert.AreEqual(null, maze);
    }
    
    [Test]
    public void FailedIdsStarTest()
    {
        var maze = MazeGen.MatrixGen(path1);
        maze = (new IDS()).IdsAlg(maze, 1, 1, 39, 39);
        
        Assert.AreEqual(null, maze);
    }
    
    [Test]
    public void PassedAStarTest()
    {
        var maze = MazeGen.MatrixGen(path2);
        maze = new AStar().AStarAlg(maze, 1, 1, 39, 39);
        
        if (maze != null)
            Assert.Pass();
    }
    
    [Test]
    public void PassedIdsStarTest()
    {
        var maze = MazeGen.MatrixGen(path2);
        maze = (new IDS()).IdsAlg(maze, 1, 1, 39, 39);
        
        if (maze != null)
            Assert.Pass();
    }
}