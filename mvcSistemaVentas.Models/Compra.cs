using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mvcSistemaVentas.Models
{

    /*
     * IdUsuario
     * IdProveedor
     */
    
        public class Compra
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Ingrese el tipo de documento")]
            [Display(Name = "Tipo de Documento")]
            public string TipoDocumento { get; set; }

            [Required(ErrorMessage = "Ingrese el número de documento")]
            [Display(Name = "Número de Documento")]
            public string NumeroDocumento { get; set; }

            [Required(ErrorMessage = "Ingrese el monto total")]
            [Display(Name = "Monto Total")]
            public decimal MontoTotal { get; set; }

            [Display(Name = "Fecha de Registro")]
            [DataType(DataType.DateTime)]
            public DateOnly FechaRegistro { get; set; }

       
        }
}


