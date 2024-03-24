using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.DataAccess.Data
{
    public class SistemaTrasnporteDbContext : IdentityDbContext<IdentityUsuarioTransporte>
    {
        public SistemaTrasnporteDbContext(DbContextOptions<SistemaTrasnporteDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaTrasnporteDbContext).Assembly);
        }
    }
}
