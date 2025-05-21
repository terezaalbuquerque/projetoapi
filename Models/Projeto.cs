namespace ProjetoApi.Models;

public class Projeto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public List<Tarefa> Tarefas { get; set; } = new();
}