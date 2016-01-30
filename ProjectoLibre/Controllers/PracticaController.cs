using Capa_Entidades;
using Newtonsoft.Json;
using ProjectoLibre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Servicios;

namespace ProjectoLibre.Controllers
{
    public class PracticaController : Controller
    {
        static PracticaServicios practicaServicio = new PracticaServicios();

        //
        // GET: /Practica/

        public JsonResult Sugerencias(string term)
        {
            var result = practicaServicio.DevolverNombresPersonajes(term);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string VerFecha()
        {
            return DateTime.Today.ToString();
        }

        public ActionResult VerJson()
        {
            return View();
        }

        public string WelcomeMsg(string input)
        {
            if (!String.IsNullOrEmpty(input))
                return "Please welcome " + input + ".";
            else
                return "Please enter your name.";
        }

        public JsonResult ListaHeroe(int id)
        {
            var result = practicaServicio.MostrarDatosHeroe(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
