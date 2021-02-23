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
    public ActionResult Crear(Categorias categoria)
    {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La Descripcion no debe contener espacios al inicio o al final");
                    return View(categoria);
                }

                _CategoriasBL.GuardarCategoria(categoria);

                return RedirectToAction("Index");

            }

            return View(categoria);
       
    }


    public ActionResult Editar(int id)
    {
        var desaparecido = _CategoriasBL.ObtenerCategorias(id);

        return View(desaparecido);
    }

    [HttpPost]
    public ActionResult Editar(Categorias categoria)
    {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La Descripcion no debe contener espacios al inicio o al final");
                    return View(categoria);
                }

                _CategoriasBL.GuardarCategoria(categoria);

                return RedirectToAction("Index");

            }

            return View(categoria);
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