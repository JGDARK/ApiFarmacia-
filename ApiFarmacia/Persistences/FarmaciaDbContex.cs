using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistences
{
    public class FarmaciaDbContex : DbContext


    {
        public DbSet<Medicamentos> Medicamentos {get; set;}
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }


        public FarmaciaDbContex(DbContextOptions<FarmaciaDbContex> options)
            : base(options)
        {

        }
    }
}
