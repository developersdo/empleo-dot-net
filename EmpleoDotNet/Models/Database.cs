using System;
using System.Collections.Generic;
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
    }
}