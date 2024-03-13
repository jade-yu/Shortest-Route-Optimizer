namespace ShortestRoute.Model
{
  public class Graph
  {
    private readonly List<Node> _nodes;

    public Graph(List<string> nodeNames)
    {
      _nodes = new List<Node>();
      foreach (var name in nodeNames)
      {
        _nodes.Add(new Node(name.ToUpper()));
      }
    }

    public void AddPath(string fromNodeName, string toNodeName, int distance, bool isBidirectional = true)
    {
      var source = GetNode(fromNodeName);
      var destination = GetNode(toNodeName);

      source.AddPath(source, destination, distance);
      if (isBidirectional)
        destination.AddPath(destination, source, distance);
    }

    public ShortestPathData ShortestPath(string fromNodeName, string toNodeName)
    {
      var source = GetNode(fromNodeName);
      var destination = GetNode(toNodeName);

      var distances = new Dictionary<Node, int>();
      var previousNodes = new Dictionary<Node, Node>();
      var unvisitedNodes = new List<Node>(_nodes);

      foreach (var node in _nodes)
      {
        distances[node] = int.MaxValue;
      }
      distances[source] = 0;

      while (unvisitedNodes.Any())
      {
        var currentNode = unvisitedNodes.OrderBy(n => distances[n]).First();

        unvisitedNodes.Remove(currentNode);

        foreach (var path in currentNode.Paths)
        {
          var newDistance = distances[currentNode] + path.Distance;
          if (newDistance < distances[path.Destination])
          {
            distances[path.Destination] = newDistance;
            previousNodes[path.Destination] = currentNode;
          }
        }
      }

      var nodeNames = new List<string>();
      var current = destination;

      while (current != null)
      {
        nodeNames.Insert(0, current.Name);
        current = previousNodes.ContainsKey(current) ? previousNodes[current] : null;
      }

      return new ShortestPathData(nodeNames, distances[destination]);
    }

    private Node GetNode(string nodeName)
    {
      nodeName = nodeName.ToUpper();
      var node = _nodes.FirstOrDefault(n => n.Name.Equals(nodeName));

      if (node == null)
        throw new ArgumentException("Source or destination node not found.");
      
      return node;
    }
  }
}