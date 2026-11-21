using Microsoft.AspNetCore.Mvc;
using MathSpace.Core.Interfaces;
using MathSpace.Core.Models;

namespace MathSpace.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolutionsController : ControllerBase
{
    private readonly ISolutionRepository _repository;

    public SolutionsController(ISolutionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Solution>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Solution>> GetById(int id)
    {
        var solution = await _repository.GetByIdAsync(id);

        if (solution == null)
            return NotFound();

        return Ok(solution);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Solution solution)
    {
        await _repository.AddAsync(solution);
        return Ok(solution);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var solution = await _repository.GetByIdAsync(id);

        if (solution == null)
            return NotFound();

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
