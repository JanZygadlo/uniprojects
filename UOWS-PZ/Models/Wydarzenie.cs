using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UOWS.Models
{
    public class Wydarzenie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public DateTime Data_rozpoczecia { get; set; }

        public DateTime Data_zakonczenia { get; set; }

        public string Opis { get; set; }

        public string Adres { get; set; }
        //ForeignKey
        // public virtual RoleModels Role { get; set; }

        public int OrganizatorId { get; set; }
        public Organizator Organizator { get; set; }
    }
}