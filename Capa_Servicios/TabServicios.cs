using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Entidades;

namespace Capa_Servicios
{
    public class TabServicios
    {
        public List<Heroe> ObtenerListaHeroes()
        {
            GothamDBEntities context = new GothamDBEntities();
            List<Heroe> heroes = context.Heroes.ToList();

            return heroes;
        }

        public List<Villano> ObtenerListaVillanos()
        {
            GothamDBEntities context = new GothamDBEntities();
            List<Villano> villanos = context.Villanoes.ToList();

            return villanos;
        }
    }
}
