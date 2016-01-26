using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Entidades;

namespace Capa_Servicios
{
    public class HeroeServicios
    {
        public void CrearNuevoPersonaje(Heroe registro)
        {
            GothamDBEntities context = new GothamDBEntities();
            context.Heroes.Add(registro);

            context.SaveChanges();
            context.Dispose();
        }

        public Heroe BuscarPersonaje(int id)
        {
            GothamDBEntities context = new GothamDBEntities();
            var busqueda = context.Heroes.FirstOrDefault(h => h.id == id);
            context.Dispose();

            return busqueda;
        }

        public Heroe EditarPersonaje(int id, Heroe registro, bool fileChanged)
        {
            GothamDBEntities context = new GothamDBEntities();
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

            return heroeModificado;
        }

        public Heroe EliminarPersonaje(int id)
        {
            GothamDBEntities context = new GothamDBEntities();
            var heroeBorrado = context.Heroes.Find(id);
            context.Heroes.Remove(heroeBorrado);
            context.SaveChanges();
            context.Dispose();

            return heroeBorrado;
        }
    }
}
