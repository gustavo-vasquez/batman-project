using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Servicios
{
    public class GothamServicios
    {
        public object RealizarBusqueda(string nombre)
        {            
            GothamDBEntities context = new GothamDBEntities();
            var personaje = (dynamic)null;
            personaje = context.Heroes.FirstOrDefault(h => h.nombre == nombre);

            if (personaje == null)
            {
                personaje = context.Villanoes.FirstOrDefault(h => h.nombre == nombre);
                return personaje;
            }
            else
                return personaje;
        }
    }
}
