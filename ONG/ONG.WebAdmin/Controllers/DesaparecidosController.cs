using ONG.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.WebAdmin.Controllers
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
            var listadeDesaparecidos = _desaparecidosBL.ObtenerDesaparecidos();

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
        public ActionResult Crear(Desaparecido desaparecido)
        {
            if (ModelState.IsValid)
            {
                if(desaparecido.CategoriaId ==0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(desaparecido);
                }

                _desaparecidosBL.GuardarDesaparecido(desaparecido);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(desaparecido);

        }

        public ActionResult Editar(int id)
        {
            var desaparecido = _desaparecidosBL.ObtenerDesaparecido(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion", desaparecido.CategoriaId);

            return View(desaparecido);
        }

        [HttpPost]
        public ActionResult Editar(Desaparecido desaparecido)
        {
            if (ModelState.IsValid)
            {
                if (desaparecido.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(desaparecido);
                }

                _desaparecidosBL.GuardarDesaparecido(desaparecido);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(desaparecido);
        }

        public ActionResult Detalle(int id)
        {
            var desaparecido = _desaparecidosBL.ObtenerDesaparecido(id);

            return View(desaparecido);
        }

        public ActionResult Eliminar(int id)
        {
            var desaparecido = _desaparecidosBL.ObtenerDesaparecido(id);

            return View(desaparecido);
        }
        
        [HttpPost]
        public ActionResult Eliminar(Desaparecido desaparecido)
        {
            _desaparecidosBL.EliminarDesaparecido(desaparecido.Id);

            return RedirectToAction("Index");
        }
    }
}