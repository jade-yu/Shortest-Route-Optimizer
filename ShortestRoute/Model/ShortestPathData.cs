namespace ShortestRoute.Model
{
  public class ShortestPathData
  {
    private readonly List<string> _nodeNames;
    private readonly int _distance;
    private string _shortestPath;

    public ShortestPathData(List<string> nodeNames, int totalDistance)
    {
      _nodeNames = nodeNames;
      _distance = totalDistance;
      _shortestPath = string.Join(", ", _nodeNames);
    }

    public List<string> NodeNames
    {
      get { return _nodeNames; }
    }

    public int Distance
    {
      get { return _distance; }
    }

    public string ShortestPath
    {
      get { return _shortestPath; }
    }

    public override string ToString()
    {
      return $"Shortest path: {_shortestPath} (Distance = {_distance})";
    }
  }
}