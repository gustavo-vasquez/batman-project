using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Servicios
{
    public class VillanoServicios
    {
        public void CrearNuevoPersonaje(Villano registro)
        {
            GothamDBEntities context = new GothamDBEntities();
            context.Villanoes.Add(registro);

            context.SaveChanges();
            context.Dispose();
        }

        public Villano BuscarPersonaje(int id)
        {
            GothamDBEntities context = new GothamDBEntities();
            var busqueda = context.Villanoes.FirstOrDefault(h => h.id == id);
            context.Dispose();

            return busqueda;
        }

        public Villano EditarPersonaje(int id, Villano registro, bool fileChanged)
        {
            GothamDBEntities context = new GothamDBEntities();
            var villanoModificado = context.Villanoes.FirstOrDefault(h => h.id == id);
            villanoModificado.nombre = registro.nombre;
            villanoModificado.amenaza = registro.amenaza;

            if (fileChanged)
            {
                villanoModificado.imagenName = registro.imagenName;
                villanoModificado.imagenData = registro.imagenData;
            }

            villanoModificado.fechaNacimiento = registro.fechaNacimiento;

            context.SaveChanges();
            context.Dispose();

            return villanoModificado;
        }

        public Villano EliminarPersonaje(int id)
        {
            GothamDBEntities context = new GothamDBEntities();
            var villanoBorrado = context.Villanoes.Find(id);
            context.Villanoes.Remove(villanoBorrado);
            context.SaveChanges();
            context.Dispose();

            return villanoBorrado;
        }
    }
}
