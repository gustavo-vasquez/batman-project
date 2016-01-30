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
        //private bool _existeHeroes = false;
        //private bool _existeVillanos = false;

        public List<Heroe> MostrarHeroes()
        {
            return this._heroesLista;
        }

        public List<Villano> MostrarVillanos()
        {
            return this._villanosLista;
        }

        public void CargarHeroes(List<Heroe> heroes)
        {
            this._heroesLista = heroes;
        }

        public void CargarVillanos(List<Villano> villanos)
        {
            this._villanosLista = villanos;
        }

        //public bool ExistenHeroes(List<Heroe> lista)
        //{            
        //    this._heroesLista = lista;         

        //    if (this._heroesLista.Any())
        //        this._existeHeroes = true;
        //    else
        //        this._existeHeroes = false;

        //    return this._existeHeroes;
        //}

        //public bool ExistenVillanos(List<Villano> lista)
        //{
        //    this._villanosLista = lista;            

        //    if (this._villanosLista.Any())
        //        this._existeVillanos = true;
        //    else
        //        this._existeVillanos = false;

        //    return this._existeVillanos;
        //}

    }
}