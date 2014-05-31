using EmpleoDotNet.Models;

namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmpleoDotNet.Models.Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmpleoDotNet.Models.Database context)
        {
            var oportunidad1 = new Models.JobOpportunity
            {
                Category = JobCategory.SoftwareDevelopment,
                Title = "Pega Blo Senior",
                Location = "Santo Domingo",
                CompanyEmail = "prueba@developers.do",
                CompanyUrl = "http://www.developers.do",
                RequirementsToApply = "Debe saber programar Java",
                CompanyName = "Developer DO",
                Created = DateTime.Now.AddDays(-2),
                PublishedDate = DateTime.Now
            };
            context.JobOpportunities.AddOrUpdate(d => d.Title, 
                oportunidad1);

            var oportunidad2 = new Models.JobOpportunity
            {
                Category = JobCategory.SoftwareDevelopment,
                Title = "Pega Blo Junior",
                Location = "Santo Domingo",
                CompanyEmail = "prueba@developers.do",
                CompanyUrl = "http://www.developers.do",
                RequirementsToApply = "Debe saber programar Java",
                CompanyName = "Developer DO",
                Created = DateTime.Now.AddDays(-2),
                PublishedDate = DateTime.Now
            };
            context.JobOpportunities.AddOrUpdate(d => d.Title,
                oportunidad2);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
