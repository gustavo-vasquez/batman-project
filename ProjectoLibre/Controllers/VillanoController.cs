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

namespace ProjectoLibre.Controllers
{
    public class VillanoController : Controller
    {
        static VillanoServicios villanoServ = new VillanoServicios();
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
                    HttpPostedFileBase archivo = registro.file;


                    // Verify that the user selected a file
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        // Get file info
                        var fileName = Path.GetFileName(archivo.FileName);
                        //var contentLength = registro.File.ContentLength;
                        //var contentType = registro.File.ContentType;

                        // Get file data
                        byte[] data = new byte[] { };
                        using (var binaryReader = new BinaryReader(archivo.InputStream))
                        {
                            data = binaryReader.ReadBytes(archivo.ContentLength);
                        }

                        // Guardar imagen en la base de datos
                        registro.imagenName = fileName;
                        registro.imagenData = data;

                        // Guardar imagen en el servidor
                        using (FileStream image = System.IO.File.Create(Server.MapPath("~/Images/avatar/villano/") + registro.nombre + Path.GetExtension(fileName), data.Length))
                        {
                            image.Write(data, 0, data.Length);
                        }

                    }

                    villanoServ.CrearNuevoPersonaje(registro);

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
            return View(villanoServ.BuscarPersonaje(id));
        }

        //
        // POST: /Villano/Edit/5

        [HttpPost]
        public ActionResult Editar(int id, Villano registro)
        {
            try
            {
                bool fileChanged = false;

                if (ModelState.IsValid)
                {
                    HttpPostedFileBase archivo = registro.file;

                    // Verify that the user selected a file
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        // Get file info
                        var fileName = Path.GetFileName(archivo.FileName);
                        //var contentLength = registro.File.ContentLength;
                        //var contentType = registro.File.ContentType;

                        // Get file data
                        byte[] data = new byte[] { };
                        using (var binaryReader = new BinaryReader(archivo.InputStream))
                        {
                            data = binaryReader.ReadBytes(archivo.ContentLength);
                        }

                        // Save to database
                        registro.imagenName = fileName;
                        registro.imagenData = data;
                        fileChanged = true;

                        string extension = Path.GetExtension(fileName);

                        // Guardar imagen en el servidor
                        using (FileStream image = System.IO.File.Create(Server.MapPath("~/Images/avatar/villano/") + registro.nombre + extension, data.Length))
                        {
                            image.Write(data, 0, data.Length);
                        }

                    }

                    Villano villanoModificado = villanoServ.EditarPersonaje(id, registro, fileChanged);
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
            return View(villanoServ.BuscarPersonaje(id));
        }

        //
        // POST: /Villano/Delete/5

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Villano villanoBorrado = villanoServ.EliminarPersonaje(id);
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

