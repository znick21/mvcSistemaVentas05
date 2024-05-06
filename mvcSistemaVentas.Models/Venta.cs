using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcSistemaVentas.Models
{
    /*relacion con id usuario
    
    IdCliente
    */

    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public int ClientelaId { get; set; }
        [Required(ErrorMessage = "Ingrese el tipo de documento")]
        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }

        //[Required(ErrorMessage = "Ingrese el número de documento")]
        //[Display(Name = "Número de Documento")]
        //public string NroDocumento { get; set; }

        [Required(ErrorMessage = "Ingrese el documento del cliente")]
        [Display(Name = "Documento del Cliente")]
        public string DocumentoCliente { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del cliente")]
        [Display(Name = "Nombre del Cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Ingrese el monto de pago")]
        [Display(Name = "Monto de Pago")]
        public decimal MontoPago { get; set; }

        [Required(ErrorMessage = "Ingrese el monto de cambio")]
        [Display(Name = "Monto de Cambio")]
        public decimal MontoCambio { get; set; }

        [Required(ErrorMessage = "Ingrese el monto total")]
        [Display(Name = "Monto Total")]
        public decimal MontoTotal { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateOnly FechaRegistro { get; set; }
        public Clientela Clientela { get; set; }

    }
}
