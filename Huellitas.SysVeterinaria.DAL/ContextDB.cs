#region REFERENCIAS
using Huellitas.SysVeterinaria.EN.Employee_EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Huellitas.SysVeterinaria.DAL
{
    public class ContextDB : DbContext
    {

        public DbSet<Employee> Employee { get; set; } //Coleccion que hace referencia a la tabla de la base de datos


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@""); //Poner str de concexion local
        }
    }
}
