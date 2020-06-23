using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kahia2.Models
{
    public class Patho
    {

        public int Id { get; set; }
        [Required]
        public string  NomPatho { get; set; }
    }
}
