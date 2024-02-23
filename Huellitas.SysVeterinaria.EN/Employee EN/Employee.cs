using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.EN.Employee_EN
{
    public class Employee
    {
        #region Atribuos de la entiddad Employee
        [Key]
        public int Id { get; set; }

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

        [Required(ErrorMessage = "El Dui es requerido")] //Indica que es un campo requerido
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Dui")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Dui debe contener solo números")] // Validamos el tipo de dato
        public string Dui { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")] //Indica que es un campo requerido
        [Display(Name = "Fecha de Nacimiento")] // Una tipo traduccion (esto lo vera el cliente) 
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime BirthDate { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "El Genero es requerido")] //Indica que es un campo requerido
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Genero")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El Genero debe contener solo Letras")] // Validamos el tipo de dato
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Estado Civil es requerido")] //Indica que es un campo requerido
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Estado Civil")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El Estado Civil debe contener solo Letras")] // Validamos el tipo de dato
        public string CivilStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Direccion es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Direccion")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Telefono es requerido")] //Indica que es un campo requerido
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Telefono")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Telefono debe contener solo números")] // Validamos el tipo de dato
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Correo Electronico es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Correo Electronico")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El Correo Electronico debe contener solo Letras")] // Validamos el tipo de dato
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Numero de Emergencia es requerido")] //Indica que es un campo requerido
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Numero de Emergencia")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Numero de Emergencia debe contener solo números")] // Validamos el tipo de dato
        public string EmergencyNumber { get; set; } = string.Empty;

        #endregion
    }
}
