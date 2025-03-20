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
    [Table ("Empleado")]
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(14)]
        public string DNI { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public byte[] Password{ get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
