using System.Collections.ObjectModel;

namespace ShortestRoute.Model
{
  public class Node
  {
    private readonly string _name;
    private List<Path> _paths;

    public Node(string name)
    {
      _name = name.ToUpper();
      _paths = new List<Path>();
    }

    public string Name
    {
      get { return _name; }
    }

    public ReadOnlyCollection<Path> Paths
    {
      get { return _paths.AsReadOnly(); }
    }

    public void AddPath(Node source, Node destination, int distance)
    {
      _paths.Add(new Path(source, destination, distance));
    }
  }
}