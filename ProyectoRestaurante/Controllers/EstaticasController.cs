using Microsoft.AspNetCore.Mvc;

namespace ProyectoRestaurante.Controllers
{
    public class EstaticasController : Controller
    {
        public IActionResult Colaboradores()
        {
            return View();
        }

        public IActionResult Historia()
        {
            return View();
        }
    }
}
