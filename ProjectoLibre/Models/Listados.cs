using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectoLibre.Models
{
    public class Listados
    {
        private List<Heroe> _heroesLista = new List<Heroe>();
        private List<Villano> _villanosLista = new List<Villano>();
        private bool _existeHeroes = false;
        private bool _existeVillanos = false;

        public List<Heroe> MostrarHeroes()
        {
            return this._heroesLista;
        }

        public List<Villano> MostrarVillanos()
        {
            return this._villanosLista;
        }

        public bool ExistenHeroes()
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            this._heroesLista = context.Heroes.ToList();
            context.Dispose();

            if (this._heroesLista.Any())
                this._existeHeroes = true;
            else
                this._existeHeroes = false;

            return this._existeHeroes;
        }

        public bool ExistenVillanos()
        {
            BibliotecaDBEntities context = new BibliotecaDBEntities();
            this._villanosLista = context.Villanoes.ToList();
            context.Dispose();

            if (this._villanosLista.Any())
                this._existeVillanos = true;
            else
                this._existeVillanos = false;

            return this._existeVillanos;
        }

    }
}