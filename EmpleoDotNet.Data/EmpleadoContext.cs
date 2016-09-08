using System.Data.Entity;
using System.Reflection;
using EmpleoDotNet.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmpleoDotNet.Data
{
    /// <summary>
    /// Representa a la base de datos. 
    /// Define los mappings a las tablas
    /// </summary>
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext()
            : base("EmpleoDotNetConn")
        {
            Configuration.LazyLoadingEnabled = true;
#if DEBUG
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
        }

        //Tablas
        public DbSet<JobOpportunity> JobOpportunities { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<JoelTest> JoelTest { get; set; }
        public DbSet<JobOpportunityLocation> JobOpportunityLocation { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            ConfigureIdentityTables(modelBuilder);
        }

        private static void ConfigureIdentityTables(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRolesJoin").HasKey(m => new { m.UserId, m.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Logins").HasKey(m => m.UserId);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims").HasKey(m => m.Id);
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").HasKey(m => m.Id);
            modelBuilder.Entity<IdentityUser>().ToTable("Users").HasKey(m => m.Id);
        }
    }
}