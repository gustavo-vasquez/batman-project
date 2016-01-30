using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Entidades;

namespace Capa_Servicios
{
    public class PracticaServicios
    {
        public Array DevolverNombresPersonajes(string term)
        {
            GothamDBEntities context = new GothamDBEntities();

            var result = (from r in context.Heroes
                          where r.nombre.ToLower().Contains(term.ToLower())
                          select new { r.nombre }
                          ).Union(
                          from s in context.Villanoes
                          where s.nombre.ToLower().Contains(term.ToLower())
                          select new { s.nombre }).ToArray();

            return result;
        }

        public List<string> MostrarDatosHeroe(int id)
        {
            GothamDBEntities db = new GothamDBEntities();
            var result = from r in db.Heroes
                         where r.id == id
                         select new { r.nombre, r.habilidad };

            return (List<string>)result;
        }
    }
}
