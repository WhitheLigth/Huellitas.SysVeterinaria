#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#endregion

namespace Huellitas.SysVeterinaria.EN.Services_EN
{
    public class Services
    {
        #region ATRIBUTOS DE LA ENTIDAD SERVICES
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Display(Name = "Precio")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un número positivo")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Tiempo de Duracion")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string DurationTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estatus es requerido")] //Indica que es un campo requerido
        [StringLength(11, ErrorMessage = "Maximo 11 Caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Estatus")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de datox
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Descripcion es Requerida")] //Indica que es un campo requerido
        [StringLength(200, ErrorMessage = "Maximo 200 Caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Descripcion")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Description { get; set; } = string.Empty;
        #endregion

        // Elementos no mapeables
        [NotMapped]
        public int Top_Aux { get; set; } //Propiedad auxiliar
    }
}
