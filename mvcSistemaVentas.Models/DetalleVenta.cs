using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcSistemaVentas.Models
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el precio de venta")]
        [Display(Name = "Precio de Venta")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese el subtotal")]
        [Display(Name = "Subtotal")]
        public decimal Subtotal { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateOnly FechaRegistro { get; set; }
    }
}
