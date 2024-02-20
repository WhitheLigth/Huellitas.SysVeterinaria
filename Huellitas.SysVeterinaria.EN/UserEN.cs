using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.EN
{
    public class UserEN
    {
        // Entity ID
        [Key] //Se refiere que es la llave principal
        public int Id { get; set; }


        // Entity Name
        [Required(ErrorMessage = "Este campo 'Nombre' es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Este campo solo puede contener 50 palabras como maximo")]  // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")] // Una tipo traduccion (esto lo vera el cliente)
        public string Name { get; set; } = string.Empty;


        // Entity Lastname
        [Required(ErrorMessage = "Este campo 'Apellido' es requerido")]  //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Este campo solo puede contener 50 palabras como maximo")]  // Indica la longitud maxima para dicho campo
        [Display(Name = "Apellido")] // Una tipo traduccion (esto lo vera el cliente)
        public string LastName { get; set; } = string.Empty;


        // Entity Dui
        [Required(ErrorMessage = "Este campo 'Dui' es requerido")]  //Indica que es un campo requerido
        [StringLength(10, ErrorMessage = "Este campo solo puede contener 10 palabras como maximo")]  // Indica la longitud maxima para dicho campo
        [Display(Name = "Dui")] // Una tipo traduccion (esto lo vera el cliente)
        public string Dui { get; set; } = string.Empty;


        // Entity User
        [Required(ErrorMessage = "Este campo 'Usuario' es requerido")]  //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Este campo solo puede contener 50 palabras como maximo")]  // Indica la longitud maxima para dicho campo
        [Display(Name = "Usuario")] // Una tipo traduccion (esto lo vera el cliente)
        public string User { get; set; } = string.Empty;


        // Entity Password
        [Required(ErrorMessage = "Este campo 'Usuario' es requerido")]  //Indica que es un campo requerido
        [StringLength(30, ErrorMessage = "Este campo solo puede contener 30 palabras como maximo")]  // Indica la longitud maxima para dicho campo
        [Display(Name = "Contraseña")] // Una tipo traduccion (esto lo vera el cliente)
        public string Password { get; set; } = string.Empty;


        // Entity IdRol
        [ForeignKey("Rol")] //Se refiere que es la llave foranea
        [Required(ErrorMessage = "El rol es requerido")]  //Indica que es un campo requerido
        [Display(Name = "Rol")] // Una tipo traduccion (esto lo vera el cliente)
        public int IdRol { get; set; }


        [NotMapped]
        public RolEN Category { get; set; } = new RolEN(); //Propiedad de agregacion
    }
}
