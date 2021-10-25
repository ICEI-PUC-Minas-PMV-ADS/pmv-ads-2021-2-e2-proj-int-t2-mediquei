using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="*Campo obrigatório!")]
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório")]
        [Display(Name = "E-mail")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório")]
        [Display(Name = "E-mail de recuperação de usuário")]
        public string EMailRecuperar { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório")]
        [Display(Name = "Perfil de usuário")]
        public Perfil Perfil { get; set; }
    }

    public enum Perfil
    {
        Admin,
        Paciente,
        Cuidador,
        Familiar        
    }
}
