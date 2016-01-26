using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectoLibre.Models
{
    public class Buscador
    {
        private string _nombreABuscar;
        public string nombreABuscar
        {
            get { return _nombreABuscar; }
            set { _nombreABuscar = value; }
        }
    }
}