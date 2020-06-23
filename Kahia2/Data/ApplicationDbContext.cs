using System;
using System.Collections.Generic;
using System.Text;
using Kahia2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kahia2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Patho> Pathis { get; set; }
        public DbSet<Patient> Patients { get; set; }


    }
}
