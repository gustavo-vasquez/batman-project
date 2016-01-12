using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

using ProjectoLibre.Models;
using System.IO;

namespace ProjectoLibre.Controllers
{
    public class HeroeController : Controller
    {
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

                        // Save to database
                        registro.imagenName = fileName;
                        registro.imagenData = data;

                    }

                    BibliotecaDBEntities context = new BibliotecaDBEntities();
                    context.Heroes.Add(registro);

                    context.SaveChanges();
                    context.Dispose();

                    return PartialView("_Resultado");
                }

                return PartialView(registro);
            }
            catch
            {
                return PartialView(registro);
            }

        }

        //
        // GET: /Heroe/Edit/5

        public ActionResult Editar(int id)
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            var busqueda = context.Heroes.FirstOrDefault(h => h.id == id);
            context.Dispose();

            return View(busqueda);
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

                    }
                    
                    BibliotecaDBEntities context = new BibliotecaDBEntities();
                    var heroeModificado = context.Heroes.FirstOrDefault(h => h.id == id);
                    heroeModificado.nombre = registro.nombre;
                    heroeModificado.habilidad = registro.habilidad;

                    if (fileChanged)
                    {
                        heroeModificado.imagenName = registro.imagenName;
                        heroeModificado.imagenData = registro.imagenData;
                    }

                    heroeModificado.fechaNacimiento = registro.fechaNacimiento;
                    
                    context.SaveChanges();
                    context.Dispose();

                    ViewBag.submitSuccess = true;

                    return View(heroeModificado);                    
                }

                return View(registro);

            }
            catch
            {
                return View(registro);
            }
        }

        //
        // GET: /Heroe/Delete/5

        public ActionResult Eliminar(int id)
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            var busqueda = context.Heroes.FirstOrDefault(h => h.id == id);
            context.Dispose();

            return View(busqueda);
        }

        //
        // POST: /Heroe/Delete/5

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BibliotecaDBEntities context = new BibliotecaDBEntities();
                var heroeBorrado = context.Heroes.Find(id);
                context.Heroes.Remove(heroeBorrado);
                context.SaveChanges();
                context.Dispose();

                return RedirectToAction("Portada", "Gotham");
            }
            catch
            {
                return View();
            }
        }
    }
}

