using Microsoft.AspNetCore.Mvc;
using Optimizer.Server.Models;

[ApiController]
[Route("api/[controller]")]
public class ShortestPathController : ControllerBase
{
    [HttpGet]
    public ActionResult<ShortestPathData> GetShortestPath([FromQuery] string from, [FromQuery] string to)
    {
        if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
        {
            return BadRequest("Both 'from' and 'to' parameters are required.");
        }

        var graph = HttpContext.Items["Graph"] as Graph;
        var calculator = HttpContext.Items["ShortestPathCalculator"] as ShortestPathCalculator;

        if (graph == null || calculator == null)
        {
            return StatusCode(500, "Graph or calculator not initialized.");
        }

        if (!graph.Nodes.ContainsKey(from) || !graph.Nodes.ContainsKey(to))
        {
            return NotFound("One or both of the specified nodes do not exist in the graph.");
        }

        var result = calculator.CalculateShortestPath(from, to, graph);
        return Ok(result);
    }
}