using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("Familiares")]
    public class Familiar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public string Nome { get; set; }

        /* Criando a chave estrangeira para usuário */
        /*[Display(Name = "Usuário")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }*/
    }
}

