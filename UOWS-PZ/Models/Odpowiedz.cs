using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UOWS.Models
{
    public class Odpowiedz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Tresc { get; set; }

        public int Glosy { get; set; }

        public int AnkietaId { get; set; }
        public Ankieta Ankieta { get; set; }
    }
}