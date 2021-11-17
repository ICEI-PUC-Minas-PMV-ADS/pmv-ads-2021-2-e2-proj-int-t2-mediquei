using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("ContratosCuidador")]
    public class ContratosCuidador
    {
        [Key]
        public int Id { get; set; }               

        /* Criando a chave estrangeira para cuidador */
        [Display(Name = "Cuidador")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int CuidadorId { get; set; }
        [ForeignKey("CuidadorId")]
        public Cuidador Cuidador { get; set; }

        /* Criando a chave estrangeira para paciente */
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraEntrada1 { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraSaida1 { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraEntrada2 { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraSaida2 { get; set; }

    }
}
