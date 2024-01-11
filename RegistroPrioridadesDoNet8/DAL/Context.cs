using Microsoft.EntityFrameworkCore;
using RegistroPrioridadesDoNet8.Models;
using System.Collections.Generic;

namespace RegistroPrioridadesDoNet8.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }
        public DbSet<Prioridades> Prioridades { get; set; }
    }
}
