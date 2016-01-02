using ProjectoLibre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoLibre.Controllers
{
    public class PracticaController : Controller
    {
        //
        // GET: /Practica/

        public JsonResult Sugerencias()
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            Busqueda busq = new Busqueda();
            busq.nombres = context.Heroes.Select(h => h.nombre).ToList();

            return Json(busq.nombres, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VerJson()
        {
            return View();
        }
    }
}
