using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    /// <summary>
    /// Representa a la base de datos. 
    /// Define los mappings a las tablas
    /// </summary>
    public class Database : DbContext
    {
        public Database() : base("EmpleoDotNetConn")
        { }

        //Tablas
        public DbSet<JobOpportunity> JobOpportunities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO: Esto debe desenterrarse de aqui en el futuro y format parte de la metada de la entidad.
            modelBuilder.Entity<JobOpportunity>()
                        .HasKey(p=>p.Id)
                        .Property(p => p.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}