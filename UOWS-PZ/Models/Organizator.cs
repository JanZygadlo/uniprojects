using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UOWS.Models
{
    public class Organizator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public string Email { get; set; }

        public string Adres { get; set; }

        public string URL_Zdjecia { get; set; }
    }
}