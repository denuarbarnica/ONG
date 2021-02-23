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

        DesaparecidosBL _DesaparecidosBL;
        CategoriasBL _categoriasBL;

        public DesaparecidosController()
        {
            _DesaparecidosBL = new DesaparecidosBL();
            _categoriasBL = new CategoriasBL();
        }

        // GET: Personas
        public ActionResult Index()
        {
            var listaDesaparecidos = _DesaparecidosBL.ObtenerDesaparecidos();
            return View(listaDesaparecidos);
        }

    
        public ActionResult Crear()
        {

            var nuevoDesaparecido = new Desaparecidos();
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias = 
                new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoDesaparecido);
        }


        [HttpPost]

        public ActionResult Crear(Desaparecidos Desaparecidos)
        {
            if(ModelState.IsValid)
            {
                if(Desaparecidos.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(Desaparecidos);
                }

                _DesaparecidosBL.GuardarDesaparecido(Desaparecidos);

                return RedirectToAction("Index");

            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias =
                new SelectList(categorias, "Id", "Descripcion");

            return View(Desaparecidos);

        }


        public ActionResult Editar( int id)
        {
            var Desaparecidos = _DesaparecidosBL.ObtenerDesaparecidos(id);
            var categroias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categroias, "Id", "Descripcion", Desaparecidos.CategoriaId);

            return View(Desaparecidos);
        }

        [HttpPost]
        public ActionResult Editar(Desaparecidos Desaparecidos)
        {
            if (ModelState.IsValid)
            {
                if (Desaparecidos.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(Desaparecidos);
                }

                _DesaparecidosBL.GuardarDesaparecido(Desaparecidos);

                return RedirectToAction("Index");

            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias =
                new SelectList(categorias, "Id", "Descripcion");

            return View(Desaparecidos);
        }

        public  ActionResult Detalle(int id)
        {
            var Desaparecidos = _DesaparecidosBL.ObtenerDesaparecidos(id);
            return View(Desaparecidos);
        }

        public ActionResult Eliminar(int id)
        {
            var Desaparecidos = _DesaparecidosBL.ObtenerDesaparecidos(id);

            return View(Desaparecidos);

        }

        [HttpPost]
        public ActionResult  Eliminar(Desaparecidos Desaparecidos)
        {
            _DesaparecidosBL.EliminarDesaparecido(Desaparecidos.Id);
            return RedirectToAction("Index");
        }
    }
}