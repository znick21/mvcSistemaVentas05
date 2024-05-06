using Microsoft.AspNetCore.Mvc;
using mvcSistemaVentas.Data.Repository;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using mvcSistemaVentas.Models.ViewModels;
using System.Diagnostics;

namespace mvcSistemaVentas.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        //public IContenedorTrabajo Get_contenedorTrabajo()
        //{
           // return _contenedorTrabajo;
       // }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 6)
        {

            var productos = _contenedorTrabajo.Producto.AsQueryable();

            // Paginar los resultados
            var paginatedEntries = productos.Skip((page - 1) * pageSize).Take(pageSize);


            //_contenedorTrabajo.Producto

            //Primera versi�n p�gina de inicio sin paginaci�n
            //[HttpGet]
            //public IActionResult Index()
            
                HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),
                ListProductos = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPages = (int)Math.Ceiling(productos.Count() / (double)pageSize)

            };

            //Esta l�nea es para poder saber si estamos en el home o no
            ViewBag.IsHome = true;

            return View(homeVM);
        }



            //Para buscador
            [HttpGet]
            public IActionResult ResultadoBusqueda(string searchString, int page = 1, int pageSize = 3)
            {
                var productos = _contenedorTrabajo.Producto.AsQueryable();

                // Filtrar por t�tulo si hay un t�rmino de b�squeda
                if (!string.IsNullOrEmpty(searchString))
                {
                    productos = productos.Where(e => e.Nombre.Contains(searchString));
                }

                // Paginar los resultados
                var paginatedEntries = productos.Skip((page - 1) * pageSize).Take(pageSize);

                // Crear el modelo para la vista
                var model = new ListaPaginada<Producto>(paginatedEntries.ToList(), productos.Count(), page, pageSize, searchString);
                return View(model);
            }

            [HttpGet]
            public IActionResult Detalle(int id)
            {
                var productoDesdeBd = _contenedorTrabajo.Producto.Get(id);
                return View(productoDesdeBd);
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }


//public IActionResult Privacy()
//{
// return View();
// }

//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//public IActionResult Error()
//{
// return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
// }

