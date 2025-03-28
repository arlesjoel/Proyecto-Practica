using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EL
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        [Required]
        public int Empleado { get; set; }
        [Required]
        public int Cliente { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal IVA { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
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
