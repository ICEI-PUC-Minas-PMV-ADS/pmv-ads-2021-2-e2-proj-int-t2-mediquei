using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("TratamentosSaudeDet")]
    public class TratamentoSaudeDet
    {
        [Key]
        public int Id { get; set; }

        /* Criando a chave estrangeira para Tratamento Saúde */
        [Display(Name = "Tratamento")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int TratamentoId { get; set; }
        [ForeignKey("TratamentoId")]
        public TratamentoSaude TratamentoSaude { get; set; }

        /* Criando a chave estrangeira para Medicamento */
        [Display(Name = "Medicamento")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int MedicamentoId { get; set; }
        [ForeignKey("MedicamentoId")]
        public Medicamento Medicamento { get; set; }

        public string Posologia { get; set; }
        public string Observacao { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraInicial { get; set; }

        [DataType(DataType.Time)]
        public DateTime intervalo { get; set; }

        /* Criando a chave estrangeira 1 para efeito adverso */
        [Display(Name = "Efeito adverso 1")]
        public int EfeitoId1 { get; set; }
        [ForeignKey("EfeitoId1")]
        public EfeitoAdverso EfeitoAdverso1 { get; set; }

        /* Criando a chave estrangeira 2 para efeito adverso */
        [Display(Name = "Efeito adverso 2")]
        public int EfeitoId2 { get; set; }
        [ForeignKey("EfeitoId2")]
        public EfeitoAdverso EfeitoAdverso2 { get; set; }

        /* Criando a chave estrangeira 3 para efeito adverso */
        [Display(Name = "Efeito adverso 3")]
        public int EfeitoId3 { get; set; }
        [ForeignKey("EfeitoId3")]
        public EfeitoAdverso EfeitoAdverso3 { get; set; }

    }
}
