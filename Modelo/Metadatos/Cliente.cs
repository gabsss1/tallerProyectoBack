using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(ClienteMetadato))]
    public partial class Cliente
    {

    }

    public class ClienteMetadato
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidoPaterno { get; set; }
        [Required]
        public string apellidoMaterno { get; set; }
        [Required]
        public string celular { get; set; }
        [Required]
        public string correo { get; set; }
    }
}
