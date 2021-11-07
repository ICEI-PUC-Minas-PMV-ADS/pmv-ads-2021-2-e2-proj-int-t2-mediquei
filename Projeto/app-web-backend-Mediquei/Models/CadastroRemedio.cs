using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table ("Cadastro de Remedio")]
    public class CadastroRemedio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="*Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public int Dosagem { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public int Intervalo { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public DateTime Datainicial { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public DateTime Datafinal { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        public DateTime Horainicial { get; set; }

           [Required(ErrorMessage = "*Campo obrigatório!")]
        public int Recomendação { get; set; }

      public Enum Recomendação
        {
            Antes das refeções
                Durante as refeições
                após as refeições
                Não há recomendação
        }

        public string idefeito { get; set; }

    }
}
