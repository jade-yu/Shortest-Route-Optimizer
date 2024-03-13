using ShortestRoute.Model;

namespace ShortestRoute.UnitTests
{
  [TestFixture]
  public class ShortestDistance_FromNode_ReturnsShortestPath
  {
    private Graph _graph;

    [SetUp]
    public void SetUp()
    {
      _graph = new Graph(new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I" });
      _graph.AddPath("A", "B", 4);
      _graph.AddPath("A", "C", 6);
      _graph.AddPath("B", "F", 2);
      _graph.AddPath("C", "D", 8);
      _graph.AddPath("D", "E", 4);
      _graph.AddPath("D", "G", 1);
      _graph.AddPath("E", "B", 2, false);
      _graph.AddPath("E", "F", 3);
      _graph.AddPath("E", "I", 8);
      _graph.AddPath("F", "G", 4);
      _graph.AddPath("F", "H", 6);
      _graph.AddPath("G", "H", 5);
      _graph.AddPath("G", "I", 5);
    }

    [TestCase("A", "C", 6, "A, C")]
    [TestCase("A", "D", 11, "A, B, F, G, D")]
    [TestCase("E", "A", 6, "E, B, A")]
    [TestCase("B", "E", 5, "B, F, E")]
    public void GetShortestPath_GivenSourceAndDestination_ShouldReturnShortestPath(
      string source, string destination, int distance, string shortestPath)
    {
      ShortestPathData result = _graph.ShortestPath(source, destination);

      Assert.That(distance == result.Distance);
      Assert.That(shortestPath.SequenceEqual(result.ShortestPath));
    }
  }
}
