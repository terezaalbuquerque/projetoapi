namespace ProjetoApi.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public int ProjetoId { get; set; }
    public Projeto? Projeto { get; set; }
}