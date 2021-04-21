using ONG.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.Web.Controllers
{
    public class DesaparecidosController : Controller
    {
        DesaparecidosBL _desaparecidosBL;
        CategoriasBL _categoriasBL;

        public DesaparecidosController()
        {
            _desaparecidosBL = new DesaparecidosBL();
            _categoriasBL = new CategoriasBL();

        }

        // GET: Desaparecidos
        public ActionResult Index()
        {
            var _desaparecidosBL = new DesaparecidosBL();
            var listadeDesaparecidos = _desaparecidosBL.ObtenerDesaparecidosActivos();

            ViewBag.adminWebsiteUrl = ConfigurationManager.AppSettings["adminWebsiteUrl"];
            ViewBag.WebsiteUrl = ConfigurationManager.AppSettings["WebsiteUrl"];

            return View(listadeDesaparecidos);
    
        }

        public ActionResult Crear()
        {
            var nuevoDesaparecido = new Desaparecido();
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoDesaparecido);
        }

        [HttpPost]
        public ActionResult Crear(Desaparecido desaparecido, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (desaparecido.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(desaparecido);
                }

                if (imagen != null)
                {
                    desaparecido.UrlImagen = GuardarImagen(imagen);
                }

                _desaparecidosBL.GuardarDesaparecido(desaparecido);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(desaparecido);

        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/images/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/images/" + imagen.FileName;
        }

    }
}