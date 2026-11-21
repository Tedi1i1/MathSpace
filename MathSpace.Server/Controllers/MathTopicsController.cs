using Microsoft.AspNetCore.Mvc;
using MathSpace.Core.Interfaces;
using MathSpace.Core.Models;

namespace MathSpace.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MathTopicsController : ControllerBase
{
    private readonly IMathTopicRepository _repository;

    public MathTopicsController(IMathTopicRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<MathTopic>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MathTopic>> GetById(int id)
    {
        var topic = await _repository.GetByIdAsync(id);

        if (topic == null)
            return NotFound();

        return Ok(topic);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MathTopic topic)
    {
        await _repository.AddAsync(topic);
        return Ok(topic);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MathTopic topic)
    {
        if (id != topic.Id)
            return BadRequest();

        var existingTopic = await _repository.GetByIdAsync(id);

        if (existingTopic == null)
            return NotFound();

        await _repository.UpdateAsync(topic);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var topic = await _repository.GetByIdAsync(id);

        if (topic == null)
            return NotFound();

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}