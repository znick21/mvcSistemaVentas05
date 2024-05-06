using Microsoft.AspNetCore.Mvc;
using mvcSistemaVentas.Data.Repository.IRepository;
using System.Security.Claims;

namespace mvcSistemaVentas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_contenedorTrabajo.Usuario.GetAll());
        }
        [HttpGet]
        public IActionResult Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _contenedorTrabajo.Usuario.BloquearUsuario(id);
            return View("Index", _contenedorTrabajo.Usuario.GetAll());
        }
        [HttpGet]
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
            return View("Index", _contenedorTrabajo.Usuario.GetAll());
        }
    }
}
