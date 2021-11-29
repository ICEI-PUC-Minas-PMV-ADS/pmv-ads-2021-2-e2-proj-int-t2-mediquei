using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        public Paciente()
        {
            this.DesafiosSaude = new HashSet<DesafioSaude>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*Campo obrigatório!")]
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
        
        [Display(Name = "Grau de Parentesco")]
        public GrauParentesco grauParentesco { get; set; }

        public virtual ICollection<DesafioSaude> DesafiosSaude { get; set; }
    }

    public enum GrauParentesco
    {
        Pai,
        Mae,
        Filho,
        Filha,
        Sobrinho,
        Sobrinha,
        Enteado,
        Enteada,
        Sogro,
        Sogra,
        Irmão,
        Irmã
    }
}
