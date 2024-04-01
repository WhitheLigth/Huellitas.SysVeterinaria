#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Huellitas.SysVeterinaria.EN.Employee_EN;


#endregion

namespace Huellitas.SysVeterinaria.EN.Position_EN
{
    public class Position
    {
        #region Atributos de la Entidad
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ/ ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Name { get; set; } = string.Empty;
        #endregion

        //Elementos no Mapeables
        [NotMapped] // Indica a entity que este campo no esta definido en la base de datos
        public int Top_Aux { get; set; } //Propiedad auxiliar

        public List<Employee> Employees { get; set; } = new List<Employee>(); // Propiedad de Navegacion
    }
}
