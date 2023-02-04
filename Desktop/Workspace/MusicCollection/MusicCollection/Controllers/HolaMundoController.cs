using Microsoft.AspNetCore.Mvc;

namespace MusicCollection.Controllers
{
    public class HolaMundoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public string Indice()
        {
            return "Bienvenido al mundo del codigo!!!";
        }
        
        public string Bienvenido()
        {
            return "Este es el metodo de bienvenida";
        }

        public string Informacion(int id, string nombre)
        {
            return "Este es el numero ingresado: " + id.ToString() + " - " + nombre;
        }

        public string Saludos(string nombre, int edad)
        {
            string saludo = $"Bienvenido {nombre} y tiene {edad} años";
            //saludo = "Bienvenido " + nombre + "y tiene " + edad + "años";
            return saludo;
        }

        public IActionResult Tabla(int id)
        {
            ViewData["veces"] = id;

            return View();
        }
    }
}
