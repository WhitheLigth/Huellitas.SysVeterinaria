using Huellitas.SysVeterinaria.EN.Breed_EN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.EN.Pet_EN
{
    public class Pet
    {
        #region Atribuos de la entiddad PetOwner
        [Key]
        public int Id { get; set; }

        [ForeignKey("Breed")]
        [Required(ErrorMessage = "El tipo de raza es requerido")]
        [Display(Name = "Tipo de raza")]
        public int IdBreed { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Apellido es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Apellido")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El Apellido debe contener solo Letras")] // Validamos el tipo de dato
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La edad es requerida")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Edad")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9 a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Coloque la edad correctamente")] // Validamos el tipo de dato
        public string Age { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Genero es requerido")] //Indica que es un campo requerido
        [StringLength(11, ErrorMessage = "Maximo 11 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Genero")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "El color es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Color o marca distintiva")] // Una tipo traduccion (esto lo vera el cliente) 
        public string DistinctiveColorOrBrand { get; set; } = string.Empty;

        [Required(ErrorMessage = "La necesidad especial es requerida")] //Indica que es un campo requerido
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Necesidad Especial")] // Una tipo traduccion (esto lo vera el cliente) 
        public string SpecialBehaviorOrNeed { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate {  get; set; }

        #endregion

        [NotMapped]
        public int Top_Aux { get; set; } // Atributo auxiliar

        public Breed? breed { get; set; } // Atributo de navegacion
    }
}
