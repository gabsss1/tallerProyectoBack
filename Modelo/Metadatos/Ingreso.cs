using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(IngresoMetadato))]
    public partial class Ingreso
    {

    }

    public class IngresoMetadato
    {
        [Required]
        public System.DateTime fecha { get; set; }
        [Required]
        public int numerTaller { get; set; }
        [Required]
        public string observacion { get; set; }
        [Required]
        public long mecanicoId { get; set; }
        [Required]
        public long clienteId { get; set; }

    }
}
