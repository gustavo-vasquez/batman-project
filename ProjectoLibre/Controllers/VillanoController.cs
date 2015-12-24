using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

using ProjectoLibre.Models;

namespace ProjectoLibre.Controllers
{
    public class VillanoController : Controller
    {
        //
        // GET: /Villano/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Villano/Create

        public ActionResult Crear()
        {
            return PartialView();
        }

        //
        // POST: /Villano/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Villano registro)
        {
            try
            {
                // TODO: Add insert logic here
                BibliotecaDBEntities context = new BibliotecaDBEntities();
                context.Villanoes.Add(registro);
                context.SaveChanges();
                context.Dispose();

                return RedirectToAction("Personajes", "Gotham");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Villano/Edit/5

        public ActionResult Editar(int id)
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            var busqueda = context.Villanoes.FirstOrDefault(h => h.id == id);
            context.Dispose();

            return View(busqueda);
        }

        //
        // POST: /Villano/Edit/5

        [HttpPost]
        public ActionResult Editar(int id, Villano registro)
        {
            try
            {
                // TODO: Add update logic here
                BibliotecaDBEntities context = new BibliotecaDBEntities();
                var villanoModificado = context.Villanoes.FirstOrDefault(h => h.id == id);
                villanoModificado.nombre = registro.nombre;
                villanoModificado.amenaza = registro.amenaza;
                context.SaveChanges();
                context.Dispose();

                return RedirectToAction("Personajes", "Gotham");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Villano/Delete/5

        public ActionResult Eliminar(int id)
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            var busqueda = context.Villanoes.FirstOrDefault(h => h.id == id);
            context.Dispose();

            return View(busqueda);
        }

        //
        // POST: /Villano/Delete/5

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BibliotecaDBEntities context = new BibliotecaDBEntities();
                var villanoBorrado = context.Villanoes.Find(id);
                context.Villanoes.Remove(villanoBorrado);
                context.SaveChanges();
                context.Dispose();

                return RedirectToAction("Personajes", "Gotham");
            }
            catch
            {
                return View();
            }
        }
    }
}

