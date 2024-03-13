namespace ShortestRoute.Model
{
  public class Path
  {
    private readonly Node _source;
    private readonly Node _destination;
    private readonly int _distance;

    public Path(Node source, Node destination, int distance)
    {
      _source = source;
      _destination = destination;
      _distance = distance;
    }

    public Node Source
    {
      get { return _source; }
    }

    public Node Destination
    {
      get { return _destination; }
    }

    public int Distance
    {
      get { return _distance; }
    }
  }
}