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
    [Table ("Ingreso")]
    public class Ingreso
    {
        [Key]
        public int IdIngreso { get; set; }
        [Required]
        public int Empleado { get; set; }
        [Required]
        public int Proveedor { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
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
