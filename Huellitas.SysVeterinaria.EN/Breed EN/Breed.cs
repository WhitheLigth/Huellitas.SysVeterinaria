#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias necesarias para el correcto funcionamiento
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



#endregion

namespace Huellitas.SysVeterinaria.EN.Breed_EN
{
    public class Breed
    {
        #region ATRIBUTOS DE LA ENTIDAD
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")] // Indica la longitud maxima para dicho campo
        [Display (Name = "Nombre")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Name { get; set; } = string.Empty;

        #endregion

        // Propiedades no mapeables
        [NotMapped]
        public int Top_Aux { get; set; } //Propiedad auxiliar
    }
}
