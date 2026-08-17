using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InventPro.Models;
using InventPro.Datos;
using Microsoft.Data.SqlClient;

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

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string Email, string Password, [FromServices] ConexDb conexion)
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ViewBag.Error = "Correo y contraseña son obligatorios.";
            return View();
        }

        try
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT idusuario, username, password FROM Usuarios WHERE email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashGuardado = reader.GetString(2);

                            // Verifica la contraseña ingresada contra el hash guardado
                            bool passwordCorrecta = BCrypt.Net.BCrypt.Verify(Password, hashGuardado);

                            if (passwordCorrecta)
                            {
                                // Login correcto - guardamos datos en sesión
                                HttpContext.Session.SetInt32("IdUsuario", reader.GetInt32(0));
                                HttpContext.Session.SetString("Username", reader.GetString(1));

                                return RedirectToAction("Dashboard"); // o la vista que uses después de login
                            }
                        }
                    }
                }
            }

            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error al iniciar sesión: " + ex.Message;
            return View();
        }
    }

    public IActionResult Dash()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string Username, string Email, string Password, [FromServices] ConexDb conexion)
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ViewBag.Error = "Todos los campos son obligatorios.";
            return View();
        }

        try
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                // Verificar si el nombre o email ya existen
                string checkQuery = "SELECT COUNT(*) FROM registro WHERE Nombre = @Nombre OR Email = @Email";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Nombre", Username);
                    checkCmd.Parameters.AddWithValue("@Email", Email);

                    int existe = (int)checkCmd.ExecuteScalar();
                    if (existe > 0)
                    {
                        ViewBag.Error = "El usuario o correo ya está registrado.";
                        return View();
                    }
                }

                // Hashear la contraseña antes de guardarla
                string passwordHasheado = BCrypt.Net.BCrypt.HashPassword(Password);

                string insertQuery = @"INSERT INTO registro (Nombre, Email, pass) 
                                VALUES (@Nombre, @Email, @pass)";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@Nombre", Username);
                    insertCmd.Parameters.AddWithValue("@pass", passwordHasheado);
                    insertCmd.Parameters.AddWithValue("@Email", Email);

                    insertCmd.ExecuteNonQuery();
                }
            }

            TempData["Mensaje"] = "Registro exitoso, ahora inicia sesión.";
            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error al registrar: " + ex.Message;
            return View();
        }
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