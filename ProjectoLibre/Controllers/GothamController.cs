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
        static GothamServicios gothamServicio = new GothamServicios();
        static CommonServicios commonServicio = new CommonServicios();
        static Listados listadito = new Listados();
        //
        // GET: /Gotham/

        public ActionResult Portada()
        {
            listadito.CargarHeroes(commonServicio.ListaHeroes());
            listadito.CargarVillanos(commonServicio.ListaVillanos());

            return View(listadito);
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Tabs()
        {
            listadito.CargarHeroes(commonServicio.ListaHeroes());
            listadito.CargarVillanos(commonServicio.ListaVillanos());

            return View(listadito);
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
                dynamic personaje = gothamServicio.RealizarBusqueda(nombreABuscar);
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
