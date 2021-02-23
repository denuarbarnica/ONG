using ONG.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.WebAdmin.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriasBL _CategoriasBL;

        public CategoriaController()
        {
            _CategoriasBL = new CategoriasBL();
        }


    // GET: Categoria
    public ActionResult Index()
    {
        var listadeCategorias = _CategoriasBL.ObtenerCategorias();
        return View(listadeCategorias);
    }


    public ActionResult Crear()
    {

        var nuevaCategoria = new Categorias();

        return View(nuevaCategoria);
    }

    [HttpPost]

    public ActionResult Crear(Categorias desaparecido)
    {
        _CategoriasBL.GuardarCategoria(desaparecido);

        return RedirectToAction("Index");
    }


    public ActionResult Editar(int id)
    {
        var desaparecido = _CategoriasBL.ObtenerCategorias(id);

        return View(desaparecido);
    }

    [HttpPost]
    public ActionResult Editar(Categorias desaparecido)
    {
        _CategoriasBL.GuardarCategoria(desaparecido);

        return RedirectToAction("Index");
    }
        
    public ActionResult Detalle(int id)
    {
        var desaparecido = _CategoriasBL.ObtenerCategorias(id);
        return View(desaparecido);
    }




    public ActionResult Eliminar(int id)
    {
        var desaparecido = _CategoriasBL.ObtenerCategorias(id);

        return View(desaparecido);

    }
        
    [HttpPost]
    public ActionResult Eliminar(Categorias desaparecido)
    {
        _CategoriasBL.EliminarCategoria(desaparecido.Id);
        return RedirectToAction("Index");
    }


}
}