using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoRestaurante.Controllers
{
    public class Administracion : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
