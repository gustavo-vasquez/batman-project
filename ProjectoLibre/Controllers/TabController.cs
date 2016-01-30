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
        static TabServicios tabsServicio = new TabServicios();
        static CommonServicios commonServicio = new CommonServicios();
        static Listados listaditos = new Listados();
        
        //
        // GET: /Tab/        

        public ActionResult Heroe()
        {
            Thread.Sleep(2000);            

            return PartialView("_Heroe", tabsServicio.ObtenerListaHeroes());
        }

        public ActionResult Villano()
        {
            Thread.Sleep(2000);            

            return PartialView("_Villano", tabsServicio.ObtenerListaVillanos());
        }

        public ActionResult Galeria()
        {
            Thread.Sleep(2000);
            listaditos.CargarHeroes(commonServicio.ListaHeroes());
            listaditos.CargarVillanos(commonServicio.ListaVillanos());

            return PartialView("_GaleriaDB", listaditos);
        }

        public ActionResult GaleriaSV()
        {
            Thread.Sleep(2000);
            listaditos.CargarHeroes(commonServicio.ListaHeroes());
            listaditos.CargarVillanos(commonServicio.ListaVillanos());

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
