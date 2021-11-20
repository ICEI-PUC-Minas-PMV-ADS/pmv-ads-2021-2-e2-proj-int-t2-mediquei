using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("TratamentosSaude")]
    public class TratamentoSaude
    {
        [Key]
        public int Id { get; set; }

        /* Criando a chave estrangeira para paciente */
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        /* Criando a chave estrangeira para desafio saúde */
        [Display(Name = "Desafio")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int DesafioId { get; set; }
        [ForeignKey("DesafioId")]
        public DesafioSaude DesafioSaude { get; set; }

        public string Observacao { get; set; }

        public ICollection<TratamentoSaudeDet> TratamentoSaudeDet { get; set; }

    }
}
