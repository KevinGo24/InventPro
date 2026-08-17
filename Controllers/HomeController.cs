using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InventPro.Models;

namespace InventPro.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Dash()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    // Probar conexion a Tienda_ropa
    public IActionResult ProbarConexion([FromServices] Datos.ConexDb conexion)
    {
        bool conectado = conexion.ProbarConexion();
        
        Console.WriteLine(conectado ? "✅ Conexión exitosa" : "❌ Falló la conexión");
        
        return Content(conectado ? "✅ Conexión exitosa" : "❌ Falló la conexión");
    }
}