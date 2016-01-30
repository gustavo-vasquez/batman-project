using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

using ProjectoLibre.Models;
using System.IO;
using Capa_Entidades;
using Capa_Servicios;
using ManipularImagen;

namespace ProjectoLibre.Controllers
{
    public class VillanoController : Controller
    {
        static VillanoServicios villanoServicio = new VillanoServicios();
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
                if (ModelState.IsValid)
                {
                    new MiImagen().SubirNueva(registro, Server);
                    villanoServicio.CrearNuevoPersonaje(registro);

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
        // GET: /Villano/Edit/5

        public ActionResult Editar(int id)
        {           
            return View(villanoServicio.BuscarPersonaje(id));
        }

        //
        // POST: /Villano/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Villano registro)
        {
            try
            {
                bool fileChanged = false;

                if (ModelState.IsValid)
                {
                    new MiImagen().SubirEditado(registro, Server, ref fileChanged);
                    Villano villanoModificado = villanoServicio.EditarPersonaje(id, registro, fileChanged);
                    ViewBag.submitSuccess = true;

                    return View(villanoModificado);
                }

                return View(registro);

            }
            catch (Exception ex)
            {
                return Content("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        //
        // GET: /Villano/Delete/5

        public ActionResult Eliminar(int id)
        {
            return View(villanoServicio.BuscarPersonaje(id));
        }

        //
        // POST: /Villano/Delete/5

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Villano villanoBorrado = villanoServicio.EliminarPersonaje(id);
                System.IO.File.Delete(Server.MapPath("~/Images/avatar/villano/") + villanoBorrado.nombre + Path.GetExtension(villanoBorrado.imagenName));

                return RedirectToAction("Portada", "Gotham");
            }
            catch (Exception ex)
            {
                return Content("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }
    }
}

