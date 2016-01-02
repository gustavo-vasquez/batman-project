using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectoLibre.Models
{
    public class Busqueda
    {
        private List<String> _nombres;
        public List<String> nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }
    }
}