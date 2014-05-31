using EmpleoDotNet.Models;

namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Database context)
        {
            var oportunidad1 = new JobOpportunity
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

            var oportunidad2 = new JobOpportunity
            {
                Category = JobCategory.SoftwareDevelopment,
                Title = "Pega Blo Junior",
                Location = "Santo Domingo",
                CompanyEmail = "prueba@developers.do",
                CompanyUrl = "http://www.developers.do",
                RequirementsToApply = "Debe saber programar C#",
                CompanyName = "Developer DO",
                Created = DateTime.Now.AddDays(-3),
                PublishedDate = DateTime.Now
            };
            context.JobOpportunities.AddOrUpdate(d => d.Title,
                oportunidad2);
        }
    }
}
