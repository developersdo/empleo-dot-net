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
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext()
            : base("EmpleoDotNetConn")
        { this.Configuration.LazyLoadingEnabled = true; }

        //Tablas
        public DbSet<JobOpportunity> JobOpportunities { get; set; }
        public DbSet<Location> Locations { get; set; } 
        public DbSet<Tag> Tags { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Segun el diseño inicial, se deseaba que los PK todos se llamaran Id,
            //Para mantener esta comodidad pero generar una DB apta para el mundo real,
            //Cambiar Nombre de la columna.
            modelBuilder.Entity<JobOpportunity>()
                        .Property(p => p.Id)
                        .HasColumnName(string.Format("{0}Id", typeof(JobOpportunity).Name));

            modelBuilder.Entity<Location>()
                        .Property(p => p.Id)
                        .HasColumnName(string.Format("{0}Id", typeof(Location).Name));

            base.OnModelCreating(modelBuilder);
        }

    }
}