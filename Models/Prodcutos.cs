namespace InventPro.Models;

public class Prodcutos
{
    public Guid Id { get; set; }
    public string NombreProducto { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaRegistro { get; set; }
}