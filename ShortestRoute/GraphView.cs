namespace ShortestRoute
{
  public class GraphView
  {
    public GraphView()
    {
    }

    public void DisplayMessage(string message)
    {
      Console.WriteLine(message);
    }

    public string[] GetNextInput()
    {
      return Console.ReadLine().Split(' ');
    }

    public bool ShouldRepeatAction { get { return Console.ReadLine().ToLower() == "y"; } }
  }
}