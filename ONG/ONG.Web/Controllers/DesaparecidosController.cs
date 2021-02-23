using ONG.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.Web.Controllers
{
    public class DesaparecidosController : Controller
    {
        // GET: Desaparecidos
        public ActionResult Index()
        {
            var desaparecido1 = new DesaparecidoModel();
            desaparecido1.Id = 1;
            desaparecido1.Descripcion = "Juan Lopez";

            var desaparecido2 = new DesaparecidoModel();
            desaparecido2.Id = 2;
            desaparecido2.Descripcion = "Juan Lopez";

            var desaparecido3 = new DesaparecidoModel();
            desaparecido3.Id = 3;
            desaparecido3.Descripcion = "Juan Lopez";

            var listadedesaparecidos = new List<DesaparecidoModel>();
            listadedesaparecidos.Add(desaparecido1);
            listadedesaparecidos.Add(desaparecido2);
            listadedesaparecidos.Add(desaparecido3);


            return View(listadedesaparecidos);
        }
    }
}