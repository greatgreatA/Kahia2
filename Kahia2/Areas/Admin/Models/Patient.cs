using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Kahia2.Models
{
    public class Patient
    {

        [Key]
        public int IdPatient { get; set; }
        [Required]
        public int Poids { get; set; }
        [Required]
        [DisplayName("Marié")]
        public bool SituationMatrimoniale { get; set; }
        [Required]
        [DisplayName("Groupe Sanguin")]
        public string GroupeSanguin { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Taille { get; set; }
        [Required]
        public string Sexe { get; set; }

        public Patho Patho1 { get; set; }
        public Patho Patho2 { get; set; }
        public Patho Patho3 { get; set; }
        public Patho Patho4 { get; set; }
        public Patho Patho5 { get; set; }




    }
}
