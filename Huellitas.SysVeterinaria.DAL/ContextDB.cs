#region REFERENCIAS
using Huellitas.SysVeterinaria.EN;
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
        public DbSet<RolEN> Rol { get; set; } //Coleccion que hace referencia a la tabla de la base de datos
        public DbSet<UserEN> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@""); //Poner str de concexion local
        }
    }
}
