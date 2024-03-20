﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huellitas.SysVeterinaria.EN.Breed_EN;

// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.Employee_EN;
using Huellitas.SysVeterinaria.EN.Pet_Owner_EN;
using Huellitas.SysVeterinaria.EN.Services_EN;
using Microsoft.EntityFrameworkCore;



#endregion

namespace Huellitas.SysVeterinaria.DAL
{
    public class ContextDB : DbContext
    {
        #region REFERENCIAS DE LAS TABLAS DE LA BD
        public DbSet<Employee> Employees { get; set; } //Coleccion que hace referencia a la tabla de la base de datos

        public DbSet<Service> Services { get; set; } // Coleccion que hacer referencia a la tabla de la base de datos

        public DbSet<PetOwner> PetOwners { get; set; } //Coleccion que hace referencia a la tabla de la base de datos

        public DbSet<Breed> Breeds { get; set; } //Coleccion que hace referencia a la tabla de la base de datos
        #endregion

        // Metodo de Conexion a la Base de Datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@""); //Poner str de concexion local
        }
    }
}
