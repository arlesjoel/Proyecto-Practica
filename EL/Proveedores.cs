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
    [Table ("Proveedores")]
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        [MaxLength(100)]
        public string Proveedor { get; set; }
        [Required]
        [MaxLength(10)]
        public string RUC { get; set; }
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
