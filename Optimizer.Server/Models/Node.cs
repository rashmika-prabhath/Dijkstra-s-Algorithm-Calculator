namespace Optimizer.Server.Models;

public class Node
{
    public string Name { get; set; }
    public Dictionary<Node, int> Neighbors { get; set; } = new Dictionary<Node, int>();
}