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
    [Table("MovimientoInventario")]
    public class MovimientoInventario
    {
        [Key]
        public int IdMovimiento { get; set; }
        [Required]
        public int Ingreso { get; set; }
        [Required]
        public int Articulo { get; set; }
        [Required]
        public decimal CantidadSalida { get; set; }
        [Required]
        public DateTime FechaMovimiento { get; set; }
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