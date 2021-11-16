using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cuidador> Cuidadores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Familiar> Familiares { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<DesafioSaude> DesafiosSaude { get; set; }
        public DbSet<ContratosCuidador> ContratosCuidador { get; set; }
    }
}
