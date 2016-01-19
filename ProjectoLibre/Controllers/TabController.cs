using ProjectoLibre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoLibre.Controllers
{
    public class TabController : Controller
    {
        //
        // GET: /Tab/

        static Listados listaditos = new Listados();

        public ActionResult Heroe()
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            List<Heroe> heroes = context.Heroes.ToList();

            return PartialView("_Heroe", heroes);
        }

        public ActionResult Villano()
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            List<Villano> villanos = context.Villanoes.ToList();

            return PartialView("_Villano", villanos);
        }

        public ActionResult Galeria()
        {                    
            return PartialView("_GaleriaDB", listaditos);
        }

        public ActionResult Contacto()
        {
            return PartialView("_Contacto");
        }

        public ActionResult Trailer()
        {
            return PartialView("_Trailer");
        }

    }
}
