using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Entidades
{
    [MetadataType(typeof(VillanoMetadata))]
    public partial class Villano
    {
        //[Required(ErrorMessage = "*Debe seleccionar un archivo")]
        [FileSize((2 * 1024 * 1024))]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase file { get; set; }
    }

    public class VillanoMetadata
    {
        [Required(ErrorMessage = "*Debe ingresar un nombre")]
        [StringLength(16, ErrorMessage = "*Maximo 16 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "*Debe ingresar una habilidad")]
        [StringLength(10, ErrorMessage = "*Maximo 10 caracteres")]
        public string amenaza { get; set; }

        public string imagenName { get; set; }
        public byte[] imagenData { get; set; }

        [Required(ErrorMessage = "*Debe elegir una fecha de nacimiento")]
        public DateTime fechaNacimiento { get; set; }
    }

    //public class FileSizeAttribute : ValidationAttribute
    //{
    //    private readonly int _maxSize;

    //    public FileSizeAttribute(int maxSize)
    //    {
    //        _maxSize = maxSize;
    //    }

    //    public override bool IsValid(object value)
    //    {
    //        if (value == null) return true;

    //        return (value as HttpPostedFileBase).ContentLength <= _maxSize;
    //    }

    //    public override string FormatErrorMessage(string name)
    //    {
    //        return string.Format("*Tamaño máximo de imágen = 2 MB");
    //    }
    //}

    //public class FileTypesAttribute : ValidationAttribute
    //{
    //    private readonly List<string> _types;

    //    public FileTypesAttribute(string types)
    //    {
    //        _types = types.Split(',').ToList();
    //    }

    //    public override bool IsValid(object value)
    //    {
    //        if (value == null) return true;

    //        var fileExt = System.IO.Path.GetExtension((value as HttpPostedFileBase).FileName).Substring(1);
    //        return _types.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
    //    }

    //    public override string FormatErrorMessage(string name)
    //    {
    //        return string.Format("*Foto inválida. Tipos de imágen soportadas: {0}.", String.Join(", ", _types));
    //    }
    //}
}