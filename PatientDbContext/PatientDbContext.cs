using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientEntity;
using Microsoft.EntityFrameworkCore.Design;

namespace PatientDbContext
{

    /*
     * Design-time DbContext Creation
     
     * This is Factory patteren
     */
    public class PatientDbFactory : IDesignTimeDbContextFactory<PatientDb>
    {
        public PatientDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PatientDb>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-48G00GJ;Initial Catalog=HMS;Integrated Security=True");

            return new PatientDb(optionsBuilder.Options);
        }
    }
    // 	it is interact with database
    public class PatientDb : DbContext
    {
        public PatientDb(DbContextOptions<PatientDb> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                 .ToTable("tblPatient");
            modelBuilder.Entity<Problem>()
                .ToTable("tblProblem");
            modelBuilder.Entity<Medication>()
                .ToTable("tblMedication");
        }
        // table create with DbSet
        public DbSet<Patient> patients { get; set; }
    }
}
