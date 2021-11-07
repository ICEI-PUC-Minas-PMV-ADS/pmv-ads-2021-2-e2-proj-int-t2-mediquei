using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend_Mediquei.Models
{
    [Table("Agenda")]
    public class Agenda
    {
        [Key]

        public int Id { get; set; }
       public string Descricao { get; set; }


    }
}
