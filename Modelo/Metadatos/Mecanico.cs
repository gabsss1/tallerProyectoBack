using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(MecanicoMetadato))]
    public partial class Mecanico
    {
    }

    public class MecanicoMetadato
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidoPaterno { get; set; }
        [Required]
        public string apellidoMaterno { get; set; }
        [Required]
        public bool habilitado { get; set; }
    }
}
