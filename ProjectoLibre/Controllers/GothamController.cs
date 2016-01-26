using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

using ProjectoLibre.Models;
using Capa_Entidades;
using Capa_Servicios;

namespace ProjectoLibre.Controllers
{
    public class GothamController : Controller
    {
        static GothamServicios gothamServ = new GothamServicios();
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
            return PartialView();
        }

        [HttpPost]
        public ActionResult Buscador(string nombreABuscar)
        {
            try
            {
                dynamic personaje = gothamServ.RealizarBusqueda(nombreABuscar);
                ViewBag.EsHeroe = (personaje is Heroe) ? true : ViewBag.EsHeroe = false;

                return PartialView("_ResultadoBusqueda", new ResultadoTipoDato(personaje));
            }

            catch (Exception ex)
            {
                return Content("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

    }
}
