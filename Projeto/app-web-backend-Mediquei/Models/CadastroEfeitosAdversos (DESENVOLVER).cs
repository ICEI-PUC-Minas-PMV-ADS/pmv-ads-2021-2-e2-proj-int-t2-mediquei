using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table ("Efeitos Adversos")]
    public class CadastroEfeitosAdversos
    {
        [Key]
        public int Idefeito { get; set; }

        [Required(ErrorMessage ="*Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public int Dosagem { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public int Intervalo { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public DateTime datainicial { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public DateTime datafinal { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public Time horainicial { get; set; }

        public string Idefeito { get; set; }

    }
}
