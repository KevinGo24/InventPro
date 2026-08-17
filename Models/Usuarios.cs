namespace InventPro.Models;

public class Usuarios
{
    public int IdUsuario { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime FechaRegistro { get; set; }  
}