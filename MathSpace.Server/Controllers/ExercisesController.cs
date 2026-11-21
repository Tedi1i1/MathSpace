using Microsoft.AspNetCore.Mvc;
using MathSpace.Core.Interfaces;
using MathSpace.Core.Models;

namespace MathSpace.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly IExerciseRepository _repository;

    public ExercisesController(IExerciseRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Exercise>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetById(int id)
    {
        var exercise = await _repository.GetByIdAsync(id);

        if (exercise == null)
            return NotFound();

        return Ok(exercise);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Exercise exercise)
    {
        await _repository.AddAsync(exercise);
        return Ok(exercise);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Exercise exercise)
    {
        if (id != exercise.Id)
            return BadRequest();

        var existingExercise = await _repository.GetByIdAsync(id);

        if (existingExercise == null)
            return NotFound();

        await _repository.UpdateAsync(exercise);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exercise = await _repository.GetByIdAsync(id);

        if (exercise == null)
            return NotFound();

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
