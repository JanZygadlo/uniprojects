using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UOWS.Models
{
    public class Komentarz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Tresc { get; set; }

        public DateTime Data_dodania { get; set; }

        public int SubskrypcjaId { get; set; }
        public Subskrypcja Subskrypcja { get; set; }

    }
}