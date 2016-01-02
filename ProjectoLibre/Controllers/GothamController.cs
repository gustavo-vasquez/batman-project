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


    }
}
