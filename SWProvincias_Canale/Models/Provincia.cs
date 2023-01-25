using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWProvincias_Canale.Models
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }

        public List<Ciudad> Ciudades { get; set; }
    }
}
