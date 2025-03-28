﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EL
{
    [Table ("DetalleIngreso")]
    public class DetalleIngreso
    {
        [Key]
        public int IdDetalle { get; set; }
        [Required]
        public int Ingreso { get; set; }
        [Required]
        public int Articulo { get; set; }
        [Required]
        public decimal PrecioCosto { get; set; }
        [Required]
        public decimal Cantidad { get; set; }
        [Required]
        public decimal PrecioVenta { get; set; }
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
