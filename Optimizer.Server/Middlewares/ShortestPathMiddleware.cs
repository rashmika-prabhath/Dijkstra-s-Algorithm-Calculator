using Microsoft.AspNetCore.Http;
using Optimizer.Server.Models;
using System.Threading.Tasks;

public class ShortestPathMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Graph _graph;
    private readonly ShortestPathCalculator _calculator;

    public ShortestPathMiddleware(RequestDelegate next)
    {
        _next = next;
        _graph = new Graph();
        InitializeGraph(_graph);
        _calculator = new ShortestPathCalculator();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Make the graph and calculator available in the HttpContext.Items
        context.Items["Graph"] = _graph;
        context.Items["ShortestPathCalculator"] = _calculator;

        // Call the next delegate/middleware in the pipeline
        await _next(context);
    }

    private void InitializeGraph(Graph graph)
    {
        // Add nodes and edges as per the diagram
        graph.AddEdge("A", "B", 4);
        graph.AddEdge("B", "A", 4);

        graph.AddEdge("A", "C", 6);
        graph.AddEdge("C", "A", 6);

        graph.AddEdge("B", "F", 2);
        graph.AddEdge("F", "B", 2);

        graph.AddEdge("C", "D", 8);
        graph.AddEdge("D", "C", 8);

        graph.AddEdge("D", "G", 1);
        graph.AddEdge("G", "D", 1);

        graph.AddEdge("E", "B", 2);

        graph.AddEdge("D", "E", 4);
        graph.AddEdge("E", "D", 4);

        graph.AddEdge("F", "E", 3);
        graph.AddEdge("E", "F", 3);

        graph.AddEdge("F", "H", 6);
        graph.AddEdge("H", "F", 6);

        graph.AddEdge("G", "H", 5);
        graph.AddEdge("H", "G", 5);

        graph.AddEdge("G", "F", 4);
        graph.AddEdge("F", "G", 4);

        graph.AddEdge("G", "I", 5);
        graph.AddEdge("I", "G", 5);

        graph.AddEdge("E", "I", 8);
        graph.AddEdge("I", "E", 8);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ShortestPathMiddlewareExtensions
{
    public static IApplicationBuilder UseShortestPathMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ShortestPathMiddleware>();
    }
}