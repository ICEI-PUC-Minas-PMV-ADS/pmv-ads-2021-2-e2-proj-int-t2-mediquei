﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app_web_backend_Mediquei.Models;

namespace app_web_backend_Mediquei.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211119032611_M05")]
    partial class M05
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("app_web_backend_Mediquei.Models.ContratosCuidador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuidadorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraEntrada1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraEntrada2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraSaida1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraSaida2")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CuidadorId");

                    b.HasIndex("PacienteId");

                    b.ToTable("ContratosCuidador");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Cuidador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cuidadores");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.DesafioSaude", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DesafiosSaude");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.EfeitoAdverso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EfeitosAdversos");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Familiar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Familiares");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FamiliarId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("grauParentesco")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamiliarId");

                    b.HasIndex("UserId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.TratamentoSaude", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DesafioId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DesafioId");

                    b.HasIndex("PacienteId");

                    b.ToTable("TratamentosSaude");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.TratamentoSaudeDet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("EfeitoId1")
                        .HasColumnType("int");

                    b.Property<int>("EfeitoId2")
                        .HasColumnType("int");

                    b.Property<int>("EfeitoId3")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Posologia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TratamentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("intervalo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EfeitoId1");

                    b.HasIndex("EfeitoId2");

                    b.HasIndex("EfeitoId3");

                    b.HasIndex("MedicamentoId");

                    b.HasIndex("TratamentoId");

                    b.ToTable("TratamentosSaudeDet");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMailRecuperar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.ContratosCuidador", b =>
                {
                    b.HasOne("app_web_backend_Mediquei.Models.Cuidador", "Cuidador")
                        .WithMany("ContratoCuidador")
                        .HasForeignKey("CuidadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app_web_backend_Mediquei.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuidador");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Cuidador", b =>
                {
                    b.HasOne("app_web_backend_Mediquei.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Familiar", b =>
                {
                    b.HasOne("app_web_backend_Mediquei.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Paciente", b =>
                {
                    b.HasOne("app_web_backend_Mediquei.Models.Familiar", "Familiar")
                        .WithMany()
                        .HasForeignKey("FamiliarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app_web_backend_Mediquei.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familiar");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.TratamentoSaude", b =>
                {
                    b.HasOne("app_web_backend_Mediquei.Models.DesafioSaude", "DesafioSaude")
                        .WithMany()
                        .HasForeignKey("DesafioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app_web_backend_Mediquei.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DesafioSaude");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.TratamentoSaudeDet", b =>
                {
                    b.HasOne("app_web_backend_Mediquei.Models.EfeitoAdverso", "EfeitoAdverso1")
                        .WithMany()
                        .HasForeignKey("EfeitoId1");

                    b.HasOne("app_web_backend_Mediquei.Models.EfeitoAdverso", "EfeitoAdverso2")
                        .WithMany()
                        .HasForeignKey("EfeitoId2");

                    b.HasOne("app_web_backend_Mediquei.Models.EfeitoAdverso", "EfeitoAdverso3")
                        .WithMany()
                        .HasForeignKey("EfeitoId3");

                    b.HasOne("app_web_backend_Mediquei.Models.Medicamento", "Medicamento")
                        .WithMany()
                        .HasForeignKey("MedicamentoId")                        
                        .IsRequired();

                    b.HasOne("app_web_backend_Mediquei.Models.TratamentoSaude", "TratamentoSaude")
                        .WithMany()
                        .HasForeignKey("TratamentoId")                        
                        .IsRequired();

                    b.Navigation("EfeitoAdverso1");

                    b.Navigation("EfeitoAdverso2");

                    b.Navigation("EfeitoAdverso3");

                    b.Navigation("Medicamento");

                    b.Navigation("TratamentoSaude");
                });

            modelBuilder.Entity("app_web_backend_Mediquei.Models.Cuidador", b =>
                {
                    b.Navigation("ContratoCuidador");
                });
#pragma warning restore 612, 618
        }
    }
}
