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

namespace ProjectoLibre.Controllers
{
    public class HeroeController : Controller
    {
        static HeroeServicios heroeServ = new HeroeServicios();

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
                        using (FileStream image = System.IO.File.Create(Server.MapPath("~/Images/avatar/heroe/") + registro.nombre + Path.GetExtension(fileName), data.Length)) {
                            image.Write(data, 0, data.Length);
                        }

                    }

                    heroeServ.CrearNuevoPersonaje(registro);

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
            return View(heroeServ.BuscarPersonaje(id));
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

                        //Borrar foto anterior
                        //System.IO.File.Delete(Server.MapPath("~/Images/avatar/heroe/" + registro.nombre));

                        // Guardar imagen en el servidor
                        using (FileStream image = System.IO.File.Create(Server.MapPath("~/Images/avatar/heroe/") + registro.nombre + extension, data.Length))
                        {
                            image.Write(data, 0, data.Length);
                        }

                    }                                        

                    Heroe heroeModificado = heroeServ.EditarPersonaje(id, registro, fileChanged);
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
            return View(heroeServ.BuscarPersonaje(id));
        }

        //
        // POST: /Heroe/Delete/5

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //int numero = (dynamic)5 / 0; // Forzar excepcion para probar manejo de excepciones
                var heroeBorrado = heroeServ.EliminarPersonaje(id);
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

