using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    public class PacientesViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        /* Criando a chave estrangeira para usuário */
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }

        /* Criando a chave estrangeira para familiar */
        [Display(Name = "Familiar")]
        public int FamiliarId { get; set; }
        [ForeignKey("FamiliarId")]
        public Familiar Familiar { get; set; }
        public GrauParentesco grauParentesco { get; set; }

        public List<CheckBoxViewModel> CheckBoxTratSaude { get; set; }        
    }
}
