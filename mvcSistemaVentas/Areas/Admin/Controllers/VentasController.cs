using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;

namespace mvcSistemaVentas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VentasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public VentasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Venta.Add(venta);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            return View(venta);


            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Venta venta = _contenedorTrabajo.Venta.Get(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            return View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venta venta)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Venta.Update(venta);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            return View(venta);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Venta.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Venta.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando almacen" });
            }
            _contenedorTrabajo.Venta.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la almacen" });
        }
        #endregion
    }
}
