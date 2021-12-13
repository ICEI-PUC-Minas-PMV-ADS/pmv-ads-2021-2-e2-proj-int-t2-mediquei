using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("TratSaude")]
    public class TratSaude
    {
        public TratSaude()
        {
            this.TratSaudeDet = new HashSet<TratSaudeDet>();
        }

        [Key]
        public int TratSaudeId { get; set; }
        public int DesafioSaudeId { get; set; }
        public int PacienteId { get; set; }

        public virtual DesafioSaude DesafioSaude { get; set; }
        public virtual Paciente Paciente { get; set; }

        public bool Checked { get; set; }

        public ICollection<TratSaudeDet> TratSaudeDet { get; set; }

    }  
}
