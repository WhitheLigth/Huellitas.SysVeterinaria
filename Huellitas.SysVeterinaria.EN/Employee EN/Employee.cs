#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Huellitas.SysVeterinaria.EN.Position_EN;

#endregion

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
        [RegularExpression("^[0-9-]+$", ErrorMessage = "El Dui debe contener solo números")] // Validamos el tipo de dato
        public string Dui { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")] //Indica que es un campo requerido
        [Display(Name = "Fecha de Nacimiento")] // Una tipo traduccion (esto lo vera el cliente) 
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime BirthDate { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "La edad es requerida")] //Indica que es un campo requerido
        [StringLength(3, ErrorMessage = "Maximo 3 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Edad")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9]+$", ErrorMessage = "La edad debe contener solo números")] // Validamos el tipo de dato
        public string Age { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Genero es requerido")] //Indica que es un campo requerido
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Genero")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Estado Civil es requerido")] //Indica que es un campo requerido
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Estado Civil")] // Una tipo traduccion (esto lo vera el cliente) 
        public string CivilStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Direccion es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Direccion")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Telefono es requerido")] //Indica que es un campo requerido
        [StringLength(9, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Telefono")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9-]+$", ErrorMessage = "El Telefono debe contener solo números")] // Validamos el tipo de dato
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Correo Electronico es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Correo Electronico")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Numero de Emergencia es requerido")] //Indica que es un campo requerido
        [StringLength(9, ErrorMessage = "Maximo 10 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Numero de Emergencia")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9-]+$", ErrorMessage = "El Numero de Emergencia debe contener solo números")] // Validamos el tipo de dato
        public string EmergencyNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Titulo Academico es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Titulo Academico")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Titulo Academico debe contener solo Letras")] // Validamos el tipo de dato
        public string AcademicTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Experiencia Laboral es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Experiencia Laboral")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$", ErrorMessage = "La Experiencia debe contener solo Letras")] // Validamos el tipo de dato
        public string WorkExperience { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Area de Especializacion es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Area de Especializacion")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Area de Especializacion debe contener solo Letras")] // Validamos el tipo de dato
        public string AreaOfSpecialization { get; set; } = string.Empty;

        [ForeignKey("Position")] //Indica que es una llave Foranea
        [Required(ErrorMessage = "El Puesto o Cargo es requerido")] //Indica que es un campo requerido
        [Display(Name = "Puesto o Cargo")] // Una tipo traduccion (esto lo vera el cliente) 
        public int IdPosition { get; set; }

        [Required(ErrorMessage = "Alergias Conocidas es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Alergias Conocidas")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ, ]+$", ErrorMessage = "Las Alergias Conocidas debe contener solo Letras")] // Validamos el tipo de dato
        public string KnownAllergies { get; set; } = string.Empty;

        [Required(ErrorMessage = "Condiciones Medicas Relevantes es requerido")] //Indica que es un campo requerido
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Condiciones Medicas Relevantes")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ, ]+$", ErrorMessage = "Condiciones Medicas Relevantes debe contener solo Letras")] // Validamos el tipo de dato
        public string RelevantMedicalConditions { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Fecha de Creacion es requerida")] //Indica que es un campo requerido
        [Display(Name = "Fecha de Creacion")] // Una tipo traduccion (esto lo vera el cliente) 
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime CreationDate { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "La Fecha de Modificacion es requerida")] //Indica que es un campo requerido
        [Display(Name = "Fecha de Modificacion")] // Una tipo traduccion (esto lo vera el cliente) 
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime ModificationDate { get; set; } = DateTime.MinValue;

        #endregion

        // Propiedades No Mapebles
        [NotMapped]
        public int Top_Aux { get; set; } //Propiedad auxiliar

        public Position? Position {  get; set; } // Propiedad de Navegacion
    }
}
