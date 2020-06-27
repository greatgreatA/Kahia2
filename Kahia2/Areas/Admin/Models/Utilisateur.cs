using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kahia2.Admin.Models
{
    public class Utilisateur : IdentityUser
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Adresse { get; set; }
        [NotMapped]
        public string Profession  { get; set; }
        [NotMapped]
        public string Role { get; set; }

    }
}
