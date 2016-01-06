using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectoLibre.Models
{
    public class ResultadoTipoDato
    {
        private Heroe _heroeModel;
        private Villano _villanoModel;

        public Heroe heroeModel {
            get { return _heroeModel; }
            set { _heroeModel = value; }
        }

        public Villano villanoModel
        {
            get { return _villanoModel; }
            set { _villanoModel = value; }
        }

        public ResultadoTipoDato(object personaje)
        {
            if (personaje is Heroe)
            {
                heroeModel = (Heroe)personaje;                
            }
            else
            {
                villanoModel = (Villano)personaje;                    
            }
        }

    }
}