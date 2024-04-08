#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Huellitas.SysVeterinaria.EN.Rol_EN;


#endregion

namespace Huellitas.SysVeterinaria.EN.User_EN
{
    public class User
    {

        #region ATRIBUTOS DE LA ENTIDAD SERVICES
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Apellido")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Dui es requerido")] //Indica que es un campo requerido
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Dui")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9-]+$", ErrorMessage = "El Dui debe contener solo números")] // Validamos el tipo de dato
        public string Dui { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre de Usuario es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre de Usuario")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contrasena de Usuario es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre de Usuario")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Password { get; set; } = string.Empty;

        [ForeignKey("Rol")] //Indica que es una llave Foranea
        [Required(ErrorMessage = "El rol es requerido")] //Indica que es un campo requerido
        [Display(Name = "Rol")] // Una tipo traduccion (esto lo vera el cliente) 
        public int IdRole { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public byte Status { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime RegistrationDate { get; set; }

        #endregion

        [NotMapped]
        public int Top_Aux { get; set; } // propiedad auxiliar

        [NotMapped]
        [Required(ErrorMessage = "La confirmación de la contraseña es requerida")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [StringLength(32, ErrorMessage = "La contraseña debe tener entre 6 y 32 caracteres",
            MinimumLength = 6)]
        [Display(Name = "Confirmar la contraseña")]
        public string ConfirmPassword_Aux { get; set; } = string.Empty; //propiedad auxiliar
        // Propiedades No Mapebles
        [NotMapped]

        public Role? Role { get; set; } // Propiedad de Navegacion

      
    }

    public enum User_Status
    {
        ACTIVO = 1, INACTIVO = 2
    }
}
