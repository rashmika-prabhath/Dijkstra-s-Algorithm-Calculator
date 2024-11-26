namespace Optimizer.Server.Models;

public class ShortestPathCalculator
{
    public ShortestPathData CalculateShortestPath(string fromNodeName, string toNodeName, Graph graph)
    {
        var distances = new Dictionary<Node, int>();
        var previousNodes = new Dictionary<Node, Node>();
        var nodesToVisit = new List<Node>();

        // Initialize distances and previous nodes
        foreach (var node in graph.Nodes.Values)
        {
            distances[node] = int.MaxValue;
            previousNodes[node] = null;
            nodesToVisit.Add(node);
        }

        distances[graph.Nodes[fromNodeName]] = 0;

        while (nodesToVisit.Count > 0)
        {
            // Sort nodes by distance and pick the one with the smallest distance
            nodesToVisit.Sort((x, y) => distances[x].CompareTo(distances[y]));
            var currentNode = nodesToVisit[0];
            nodesToVisit.RemoveAt(0);

            // If the destination node is reached, stop processing
            if (currentNode.Name == toNodeName)
            {
                break;
            }

            // Update distances for each neighbor
            foreach (var neighbor in currentNode.Neighbors)
            {
                var altDistance = distances[currentNode] + neighbor.Value;
                if (altDistance < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = altDistance;
                    previousNodes[neighbor.Key] = currentNode;
                }
            }
        }

        // Build the shortest path by traversing back from the destination
        var path = new List<string>();
        var current = graph.Nodes[toNodeName];
        while (current != null)
        {
            path.Add(current.Name);
            current = previousNodes[current];
        }
        path.Reverse();

        return new ShortestPathData
        {
            NodeNames = path,
            Distance = distances[graph.Nodes[toNodeName]]
        };
    }
}
