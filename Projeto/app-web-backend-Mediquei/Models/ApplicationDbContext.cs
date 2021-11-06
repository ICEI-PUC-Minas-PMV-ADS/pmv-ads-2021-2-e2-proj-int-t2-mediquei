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
        public DbSet<CadastroRemedio> Remedios  { get; set; }
        public DbSet<CadastroEfeitosAdversos> Efeitos Adversos {get; set;}

    }
}
