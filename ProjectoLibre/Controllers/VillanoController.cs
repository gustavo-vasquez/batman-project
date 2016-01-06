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

                        // Save to server

                        //registro.file.SaveAs(Path.Combine(Server.MapPath("~/Images/avatars"), Path.GetFileName(registro.file.FileName)));

                        //string destPath = Path.Combine(Server.MapPath("~/Images/avatars"), Path.GetFileName(registro.file.FileName));
                        //var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write);
                        //fileStream.CopyTo(fileStream);


                        //registro.file.SaveAs(path);

                        // Save to database
                        registro.imagenName = fileName;
                        registro.imagenData = data;

                    }

                    BibliotecaDBEntities context = new BibliotecaDBEntities();
                    context.Villanoes.Add(registro);

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
                    var villanoModificado = context.Villanoes.FirstOrDefault(h => h.id == id);
                    villanoModificado.nombre = registro.nombre;
                    villanoModificado.amenaza = registro.amenaza;

                    if (fileChanged)
                    {
                        villanoModificado.imagenName = registro.imagenName;
                        villanoModificado.imagenData = registro.imagenData;
                    }

                    context.SaveChanges();
                    context.Dispose();

                    ViewBag.submitSuccess = true;

                    return View(villanoModificado);
                }

                return View(registro);

            }
            catch
            {
                return View(registro);
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

                return RedirectToAction("Portada", "Gotham");
            }
            catch
            {
                return View();
            }
        }
    }
}

