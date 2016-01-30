using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Servicios
{
    public class CommonServicios
    {
        public List<Heroe> ListaHeroes()
        {
            return new GothamDBEntities().Heroes.ToList();
        }

        public List<Villano> ListaVillanos()
        {
            return new GothamDBEntities().Villanoes.ToList();
        }
    }
}
