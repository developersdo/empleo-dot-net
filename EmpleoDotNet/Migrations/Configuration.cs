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
                Description = "Debe saber programar Java",
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
                Description = "Debe saber programar C#",
                CompanyName = "Developer DO",
                Created = DateTime.Now.AddDays(-3),
                PublishedDate = DateTime.Now
            };
            context.JobOpportunities.AddOrUpdate(d => d.Title,
                oportunidad2);

            var oportunidad3 = new JobOpportunity() {
                Category = JobCategory.Networking,
                Title = "Gerente de IT",
                Location = "Santiago",
                CompanyEmail = "prueba@developers.do",
                CompanyUrl = "http://www.developers.do",
                Description = "Se necesita gerente de IT para multinacional",
                CompanyName = "Developers DO Santiago",
                Created = DateTime.Now.AddDays(-1),
                PublishedDate = DateTime.Now
            };
            context.JobOpportunities.AddOrUpdate(d => d.Title,
                oportunidad3);

            var oportunidad4 = new JobOpportunity() {
                Category = JobCategory.GraphicDesign,
                Title = "Diseñador Gráfico Web",
                Location = "Puerto Plata",
                CompanyEmail = "prueba@developers.do",
                CompanyUrl = "http://www.developers.do",
                Description = "Se necesita diseñador que sepa HTML, CSS, Javascript y maneje Bootstrap",
                CompanyName = "Developers DO PP",
                Created = DateTime.Now.AddDays(-1),
                PublishedDate = DateTime.Now
            };
            context.JobOpportunities.AddOrUpdate(d => d.Title,
                oportunidad4);
        }
    }
}
