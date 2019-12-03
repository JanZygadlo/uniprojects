using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UOWS.Models
{
    public class Ankieta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Pytanie { get; set; }

        public DateTime Data_dodania { get; set; }

        public int WydarzenieId { get; set; }
        public Wydarzenie Wydarzenie { get; set; }
    }
}