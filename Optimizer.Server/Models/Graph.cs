namespace Optimizer.Server.Models;
public class Graph
{
    public Dictionary<string, Node> Nodes { get; set; } = new Dictionary<string, Node>();

    public void AddNode(string name)
    {
        if (!Nodes.ContainsKey(name))
        {
            Nodes[name] = new Node { Name = name };
        }
    }

    public void AddEdge(string from, string to, int distance, bool bidirectional = false)
    {
        AddNode(from);
        AddNode(to);
        Nodes[from].Neighbors[Nodes[to]] = distance;
        if (bidirectional)
        {
            Nodes[to].Neighbors[Nodes[from]] = distance;
        }
    }
}