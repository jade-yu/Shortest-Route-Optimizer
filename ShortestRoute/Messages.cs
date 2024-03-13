namespace ShortestRoute
{
  public static class Messages
  {
    public static string EnterNodeNames => "Enter the names of the nodes in the graph, separated by spaces:";
    public static string EnterNewPath => "Enter a path in the format 'source destination distance isBidirectional' (e.g. 'A G 5 y'): ";
    public static string EnterRoute => "Enter the source and destination nodes in the format 'source destination' to get the shortest route:";
    public static string ShouldAddNewPath => "Do you want to add another path? (y/n)";
    public static string ShouldAddNewRoute => "Do you want to get the shortest route between another two nodes? (y/n)";
    public static string InvalidInput => "Invalid input. Please try again.";
  }
}