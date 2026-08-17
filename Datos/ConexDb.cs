namespace InventPro.Datos;
using Microsoft.Data.SqlClient;
public class ConexDb
{
    private readonly string _cadenaConexion;

    // La cadena de conexión se recibe por inyección de dependencias (IConfiguration)
    public ConexDb(IConfiguration configuration)
    {
        _cadenaConexion = configuration.GetConnectionString("TiendaRopaConnection")
            ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'TiendaRopaConnection' en appsettings.json");
    }
    
    /// <summary>
    /// 
    /// Crea y devuelve una nueva conexión a la base de datos.
    /// Úsala dentro de un "using" para que se cierre automáticamente.
    /// </summary>
    public SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_cadenaConexion);
    }

    /// <summary>
    /// Prueba la conexión a la base de datos.
    /// </summary>
    public bool ProbarConexion()
    {
        try
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                return conexion.State == System.Data.ConnectionState.Open;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al conectar: " + ex.Message);
            return false;
        }
    }
}