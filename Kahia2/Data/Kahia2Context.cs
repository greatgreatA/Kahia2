using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kahia2.Models;

namespace Kahia2.Data
{
    public class Kahia2Context : DbContext
    {
        public Kahia2Context (DbContextOptions<Kahia2Context> options)
            : base(options)
        {
        }

        public DbSet<Kahia2.Models.Patient> Patient { get; set; }
    }
}
