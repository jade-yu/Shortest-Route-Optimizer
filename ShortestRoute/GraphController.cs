using ShortestRoute.Model;

namespace ShortestRoute
{
  public class GraphController
  {
    private Graph _graph;
    private GraphView _graphView;

    public GraphController()
    {
      _graphView = new GraphView();
      _graphView.DisplayMessage(Messages.EnterNodeNames);
      _graph = new Graph(_graphView.GetNextInput().ToList());
      GetPathData();
      GetShortestPath();
    }

    private void GetPathData()
    {
      do
      {
        try
        {
          _graphView.DisplayMessage(Messages.EnterNewPath);
          var path = _graphView.GetNextInput();
          int.TryParse(path[2], out int distance);
          _graph.AddPath(path[0], path[1], distance, path[3].ToUpper().Equals("Y"));
          _graphView.DisplayMessage(Messages.ShouldAddNewPath);
        }
        catch (Exception)
        {
          _graphView.DisplayMessage(Messages.InvalidInput);
        }
      } while (_graphView.ShouldRepeatAction);
    }

    private void GetShortestPath()
    {
      do
      {
        try
        {
          _graphView.DisplayMessage(Messages.EnterRoute);
          var route = _graphView.GetNextInput();
          ShortestPathData data = _graph.ShortestPath(route[0], route[1]);
          _graphView.DisplayMessage(data.ToString());
          _graphView.DisplayMessage(Messages.ShouldAddNewRoute);
        }
        catch (Exception)
        {
          _graphView.DisplayMessage(Messages.InvalidInput);
        }
      } while (_graphView.ShouldRepeatAction);
    }
  }
}