using Capa_Entidades;
using Capa_Servicios;
using ProjectoLibre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ProjectoLibre.Controllers
{
    public class TabController : Controller
    {
        static TabServicios tabsServ = new TabServicios();
        //
        // GET: /Tab/

        static Listados listaditos = new Listados();

        public ActionResult Heroe()
        {
            Thread.Sleep(2000);            

            return PartialView("_Heroe", tabsServ.ObtenerListaHeroes());
        }

        public ActionResult Villano()
        {
            Thread.Sleep(2000);            

            return PartialView("_Villano", tabsServ.ObtenerListaVillanos());
        }

        public ActionResult Galeria()
        {
            Thread.Sleep(2000);

            return PartialView("_GaleriaDB", listaditos);
        }

        public ActionResult GaleriaSV()
        {
            Thread.Sleep(2000);

            return PartialView("_GaleriaSV", listaditos);
        }

        public ActionResult Contacto()
        {
            Thread.Sleep(2000);

            return PartialView("_Contacto");
        }

        public ActionResult Trailer()
        {
            Thread.Sleep(2000);

            return PartialView("_Trailer");
        }

    }
}
