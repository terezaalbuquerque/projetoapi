namespace ProjetoAPI.Models;
public class Usuario
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}