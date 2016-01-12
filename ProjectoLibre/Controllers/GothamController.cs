using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

using ProjectoLibre.Models;

namespace ProjectoLibre.Controllers
{
    public class GothamController : Controller
    {
        static Listados listas = new Listados();
        //
        // GET: /Gotham/

        public ActionResult Portada()
        {
            return View(listas);
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Tabs()
        {
            return View(listas);
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult Trailer()
        {
            return View();
        }
        
        public ActionResult Buscador()
        {
            //Buscador modelo = new Buscador();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Buscador(string nombreABuscar)
        {
            try
            {
                BibliotecaDBEntities context = new BibliotecaDBEntities();
                var personaje = (dynamic)null;
                personaje = context.Heroes.FirstOrDefault(h => h.nombre == nombreABuscar);
                ViewBag.EsHeroe = true;

                if (personaje == null)
                {
                    personaje = context.Villanoes.FirstOrDefault(h => h.nombre == nombreABuscar);
                    ViewBag.EsHeroe = false;
                }

                return PartialView("_ResultadoBusqueda", new ResultadoTipoDato(personaje));
            }

            catch
            {
                return PartialView();
            }
        }

    }
}
