using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi.Models;

namespace ProjetoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TarefaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TarefaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Tarefa>> Get() => await _context.Tarefas.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> Get(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return NotFound();
        return tarefa;
    }

    [HttpPost]
    public async Task<ActionResult<Tarefa>> Post([FromBody] Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Tarefa tarefa)
    {
        if (id != tarefa.Id) return BadRequest();

        _context.Entry(tarefa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return NotFound();

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}