using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(SalidaMetadato))]
    public partial class Salida
    {

    }

    public class SalidaMetadato
    {
        [Required]
        public System.DateTime fecha { get; set; }
        [Required]
        [Range(0,99999999999.99)]
        public decimal monto { get; set; }
        [Required]
        public bool borrado { get; set; }
        [Required]
        public long mecanicoId { get; set; }
        [Required]
        public long ingresoId { get; set; }
    }
}
