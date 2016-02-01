using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

using ProjectoLibre.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Capa_Entidades;
using Capa_Servicios;
using ManipularImagen;

namespace ProjectoLibre.Controllers
{
    public class HeroeController : Controller
    {
        static HeroeServicios heroeServicio = new HeroeServicios();

        //
        // GET: /Heroe/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Heroe/Create

        public ActionResult Crear()
        {
            return PartialView();
        }

        //
        // POST: /Heroe/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Heroe registro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new MiImagen().SubirNueva(registro, Server);
                    heroeServicio.CrearNuevoPersonaje(registro);

                    return PartialView("_Resultado");
                }

                return PartialView(registro);
            }
            catch (Exception ex)
            {
                return Content("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }

        }

        //
        // GET: /Heroe/Edit/5

        public ActionResult Editar(int id)
        {            
            return View(heroeServicio.BuscarPersonaje(id));
        }

        //
        // POST: /Heroe/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Heroe registro)
        {
            try
            {
                bool fileChanged = false;

                if (ModelState.IsValid)
                {
                    new MiImagen().SubirEditado(registro, Server, ref fileChanged);
                    Heroe heroeModificado = heroeServicio.EditarPersonaje(id, registro, fileChanged);
                    ViewBag.submitSuccess = true;

                    return View(heroeModificado);                
                }

                return View(registro);

            }
            catch (Exception ex)
            {
                return Content("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        //
        // GET: /Heroe/Delete/5

        public ActionResult Eliminar(int id)
        {            
            return View(heroeServicio.BuscarPersonaje(id));
        }

        //
        // POST: /Heroe/Delete/5

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {            
            try
            {
                // TODO: Add delete logic here
                int numero = (dynamic)5 / 0; // Forzar excepcion para probar manejo de excepciones
                var heroeBorrado = heroeServicio.EliminarPersonaje(id);
                System.IO.File.Delete(Server.MapPath("~/Images/avatar/heroe/") + heroeBorrado.nombre + Path.GetExtension(heroeBorrado.imagenName));

                return RedirectToAction("Portada", "Gotham");                
            }
            catch (Exception ex)
            {
                return Content("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }            
        }
    }
}

