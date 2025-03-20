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
    [Table ("Articulos")]
    public class Articulos
    {
        [Key]
        public int IdArticulo { get; set; }
        [Required]
        [MaxLength(100)]
        public string Articulo { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [MaxLength(20)]
        public string CodigoArticulo { get; set; }
        [Required]
        public int Categoria { get; set; }
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
