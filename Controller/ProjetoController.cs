using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi.Models;

namespace ProjetoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjetoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProjetoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Projeto>> Get() => await _context.Projetos.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Projeto>> Get(int id)
    {
        var projeto = await _context.Projetos.FindAsync(id);
        if (projeto == null) return NotFound();
        return projeto;
    }

    [HttpPost]
    public async Task<ActionResult<Projeto>> Post([FromBody] Projeto projeto)
    {
        _context.Projetos.Add(projeto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = projeto.Id }, projeto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Projeto projeto)
    {
        if (id != projeto.Id) return BadRequest();

        _context.Entry(projeto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var projeto = await _context.Projetos.FindAsync(id);
        if (projeto == null) return NotFound();

        _context.Projetos.Remove(projeto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}