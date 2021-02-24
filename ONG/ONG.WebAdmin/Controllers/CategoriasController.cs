using ONG.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
            CategoriasBL _categoriasBL;

            public CategoriasController()
            {
                _categoriasBL = new CategoriasBL();
            }

        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(listadeCategorias);
        }

        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria desaparecido)
        {
            _categoriasBL.GuardarCategoria(desaparecido);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var desaparecido = _categoriasBL.ObtenerCategoria(id);
            return View(desaparecido);
        }

        [HttpPost]
        public ActionResult Editar(Categoria desaparecido)
        {
            _categoriasBL.GuardarCategoria(desaparecido);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var desaparecido = _categoriasBL.ObtenerCategoria(id);

            return View(desaparecido);
        }

        public ActionResult Eliminar(int id)
        {
            var desaparecido = _categoriasBL.ObtenerCategoria(id);

            return View(desaparecido);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria desaparecido)
        {
            _categoriasBL.EliminarCategoria(desaparecido.Id);

            return RedirectToAction("Index");
        }
    }
}