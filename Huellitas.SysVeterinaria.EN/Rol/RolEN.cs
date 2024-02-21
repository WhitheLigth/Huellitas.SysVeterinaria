using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.EN.Rol
{
    public class RolEN
    {

        // Entity Id
        [Key] //Se refiere que es la llave principal
        public int Id { get; set; }


        // Entity Name
        [Required(ErrorMessage = "Este campo 'Nombre' es requerido")]  //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Este campo solo puede contener 50 palabras como maximo")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")] // Una tipo traduccion (esto lo vera el cliente)
        public string Name { get; set; } = string.Empty;

    }
}
