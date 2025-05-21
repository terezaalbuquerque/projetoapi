using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;

namespace ProjetoApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Projeto> Projetos { get; set; } = null!;
    public DbSet<Tarefa> Tarefas { get; set; } = null!;
}