using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("EfeitosAdversos")]
    public class EfeitoAdverso
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public string Descricao { get; set; }
    }
}
