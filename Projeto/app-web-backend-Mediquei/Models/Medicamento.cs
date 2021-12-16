using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public string Nome { get; set; }
        
        [StringLength(10, MinimumLength = 0)]
        [Display(Name = "Registro ANS")]
        public string RegistroANS { get; set; }
        [StringLength(40, MinimumLength = 0)]
        [Display(Name = "Fármaco")]
        public string Farmaco { get; set; }
        [StringLength(40, MinimumLength = 0)]
        public string Detentor { get; set; }

        [Display(Name = "Concentração")]
        [StringLength(20, MinimumLength = 0)]
        public string Concentracao { get; set; }

        [Display(Name = "Forma Farmacêutica")]        
        public FormaFarm FormaFarma { get; set; }
    }

    public enum FormaFarm
    {   
        Informar,
        Comprimidos,
        Cápsulas,
        Drágeas,
        Granulados,
        Pomadas,
        Cremes,
        Géis,
        Pasta,
        Soluções,
        Gotas,
        Xarope,
        Suspensões,
        Elixires
    }
}
