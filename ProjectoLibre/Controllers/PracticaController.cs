﻿using Capa_Entidades;
using Newtonsoft.Json;
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

        public JsonResult Sugerencias(string term)
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            
            var result = (from r in context.Heroes
                          where r.nombre.ToLower().Contains(term.ToLower())
                          select new { r.nombre }
                          ).Union(
                          from s in context.Villanoes
                          where s.nombre.ToLower().Contains(term.ToLower())
                          select new { s.nombre });
                          //.Distinct();

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

        public JsonResult ListaHeroe(int Id)
        {
            BibliotecaDBEntities db = new BibliotecaDBEntities();
            var result = from r in db.Heroes
                         where r.id == Id
                         select new { r.nombre, r.habilidad };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
