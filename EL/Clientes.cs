using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("Clientes")]
     public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(14)]
        public string DNI { get; set; }
        [Required]
        [MaxLength(8)]
        public string Telefono { get; set; }
        [MaxLength(100)]
        public string? Correo { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public int UsuarioRegistra { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public int? UsuarioActualiza { get; set; }
        public DateTime? FechaActualiza { get; set; }
    }
}
