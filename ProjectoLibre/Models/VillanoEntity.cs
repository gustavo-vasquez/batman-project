using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectoLibre.Models
{
    [MetadataType(typeof(VillanoMetadata))]
    public partial class Villano
    {
        //[Display(Name = "soy el campo de heroe")]
        //public string texto { get; set; }
    }

    public class VillanoMetadata
    {
        [Required(ErrorMessage = "*Debe ingresar un nombre")]
        [StringLength(16, ErrorMessage = "*Maximo 16 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "*Debe ingresar una habilidad")]
        [StringLength(10, ErrorMessage = "*Maximo 10 caracteres")]
        public string amenaza { get; set; }
    }
}