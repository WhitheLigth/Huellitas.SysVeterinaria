#region REFERENCIAS
using Huellitas.SysVeterinaria.EN.Rol;
using Huellitas.SysVeterinaria.EN.User;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@""); //Poner str de concexion local
        }
    }
}
