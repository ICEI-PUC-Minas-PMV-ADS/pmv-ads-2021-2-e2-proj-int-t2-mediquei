﻿using Microsoft.EntityFrameworkCore;
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

        // Migration M00
        public DbSet<Cuidador> Cuidadores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        // Migration M01
        public DbSet<Familiar> Familiares { get; set; }        
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<DesafioSaude> DesafiosSaude { get; set; }
        // Migration M02
        public DbSet<Paciente> Pacientes { get; set; }  
        
        // Migration M03
        public DbSet<ContratosCuidador> ContratosCuidador { get; set; }

        //public DbSet<TratamentoSaude> TratamentosSaude { get; set; }
    }
}
