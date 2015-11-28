using System.Collections.Generic;
using System.Data.Entity;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EmpleadoContext>
    {
        public Configuration()                   
        {
             AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmpleadoContext context)
        {
            #region Locations
            var locationsList = new List<Location>
            {
                new Location { Name = "Santo Domingo" },
                new Location { Name = "Santiago" },
                new Location { Name = "Puerto Plata" }
            };
            foreach(var location in locationsList)
            {
                context.Locations.AddOrUpdate(d => d.Name,
                                              location);
            }
            #endregion
            //This triggers the save to the database making entity framework assign the correct Id's to the locationsList
            context.SaveChanges();

            #region JobOpportunities

            var opportunitiesList = new List<JobOpportunity>
            {
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Pega Blo Senior",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Debe saber programar Java",
                    CompanyName = "Developer DO",
                    Created = DateTime.Now.AddDays(-2),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Pega Blo Junior",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Debe saber programar C#",
                    CompanyName = "Developer DO",
                    Created = DateTime.Now.AddDays(-3),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.Networking,
                    Title = "Gerente de IT",
                    LocationId = locationsList[1].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Se necesita gerente de IT para multinacional",
                    CompanyName = "Developers DO Santiago",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.GraphicDesign,
                    Title = "Diseñador Gráfico Web",
                    LocationId = locationsList[2].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Se necesita diseñador que sepa HTML, CSS, Javascript y maneje Bootstrap",
                    CompanyName = "Developers DO PP",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "4 Vacantes, Desarrolladores",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Por este medio les informamos que el Sistema Único de Beneficiarios (SIUBEN) tiene disponible 4 vacantes para el área de Software para trabajar como Desarrolladores, debajo todas las informaciones necesarias para que apliquen:",
                    CompanyName = "Sistema Único de Beneficiarios (SIUBEN)",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Programador IOS",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Buscamos un programador con experiencia demostrable en aplicaciones para móviles (IOS, Android), para desarrollo de un nuevo y ambicioso proyecto.",
                    CompanyName = "Verynice",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Programador Android",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Buscamos un programador con experiencia demostrable en aplicaciones para móviles (IOS, Android), para desarrollo de un nuevo y ambicioso proyecto.",
                    CompanyName = "Verynice",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador/Desarrollador",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Tecnologo de Software.",
                    CompanyName = "Union Telecard Dominicana",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Por este medio les informamos que la empresa DATALINK NETWORKS tiene disponible una vacante para el área de Software para trabajar como Programador, debajo colocamos todas las informaciones necesarias para que apliquen:",
                    CompanyName = "DATALINK NETWORKS",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programadores y disenadores Junior y Senior",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Estamos buscando programadores y diseñadores. Si manejas una o varias de las siguientes cosas envianos tu cv a empleo@ti.com.do",
                    CompanyName = "TECNOLOGIA INTEGRAL DEL CARIBE",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Mobile Developer Intern",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "We are currently expanding, and are looking to bring on another aspiring compadre (or comadre) to [Megsoft Consulting Inc](http://www.megsoftconsulting.com). We're a company that has been profitable since day 0; we had an amazing year and continue to grow on a steady pace.",
                    CompanyName = "Megsoft Consulting Inc",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Backend python developer",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Here at meSuma we are looking to fill an in-house position for a backend developer. We are looking for someone who can learn quickly, is very skilled and passionate about coding in general. You’d be working with a wide stack of technologies, including but not limited to: python, flask, pyramid, go, grunt, mongodb, postgresql.",
                    CompanyName = "meSuma",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Diseñador web Comunimas",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Debe residir en Santo Domingo, R.D. Buena orientación de diseño Capacidad de crear propuestas de diseño para webs nuevas CSS3 HTML5 PHOTOSHOP ILUSTRATOR Responsive web design Manejo de Joomla (creacion de plantillas) Es un plus manejar herramientas de la suite de Adobe CC Y demás cosas como responsable, etc.",
                    CompanyName = "Comunimas",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador PHP/C#.NET",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Se buscan developers para puesto fijo que dominen bien PHP y MySQL, y algo de C#.NET.",
                    CompanyName = "Informatika01",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Senior PHP Developer",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Senior developer needed to work in a very agile environment. Requirements: - 3+ years of experience - PHP5 - MySQL - Must be fluent with linux Benefits: - Benefits act - Insurance - Mon-Fri: 9:00AM to 6:00PM, weekend rotation - Salary to be discussed",
                    CompanyName = "Media Revolution",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.DataBaseAdministrator,
                    Title = "Programador Base de Datos",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Necesito los servicios de alguien que tenga experiencia trabajando con base de datos. Somos una empresa de servicios con una creciente base de cleintes y necesitamos mejor organizar los mismos.",
                    CompanyName = "Gestora Quisqueya",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Mobile y Web Developers",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Se requieren VARIOS programadores en desarrollo de aplicaciones móviles para (Android, iOS y Windows Phone), para ser contratados Fijos y Freenlance por proyectos.",
                    CompanyName = "Anónima",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador web/Python",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Necesito un desarrollador Web que me complete los codigos de una pagina que tengo casi lista. Es muy poco lo que le falta y es algo urgente.",
                    CompanyName = "dilibox SRL",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "programador C++ y programador C#",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Conocimeinto en C++, c#, v isual studio. Sera para un trabajo temporal de 3 meses.",
                    CompanyName = "Dekolor",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador SENIOR .NET Indra",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Ingenieros de Sistemas o Tecnologías de la Información (egresados) 5 años o más de experiencia en desarrollo .NET Conocimientos avanzados Java y SQL. Se ofrece contrato indefinido con jornada completa, seguro médico y bonificación. El salario será a convenir según la valía del candidato.",
                    CompanyName = "Indra",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador C ++ y c#",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Buscamos un programador temporero (3 meses). Conocimiento de C++, C# Salario 25 mil Mensual.",
                    CompanyName = "Brailer",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador Java",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "Se necesitan 10 programadores Java para una empresa cliente. El salario ronda de RD$45,000 a RD$55,000",
                    CompanyName = "FL Betances & Asociados",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador web Tamontao",
                    LocationId = locationsList[2].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description = "Programador web en lenguaje asp.net con mucho tiempo libre para trabajar.",
                    CompanyName = "Tamontao",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador VB .net",
                    LocationId = locationsList[0].Id,
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Description =
                        "• Egresado o Estudiante de una carrera universitaria en el área de Ingeniería de Sistemas o carrera afín.",
                    CompanyName = "iPlus Technology",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                }
            };

            foreach (var jobOpportunity in opportunitiesList)
            {
                context.JobOpportunities.AddOrUpdate(d => d.Title,
                    jobOpportunity);
            }
            #endregion

            #region Tags

            var tagList = new List<Tag>
            {
                new Tag
                {
                    Name = "Web",
                    Created = DateTime.Now
                },
                new Tag
                {

                    Name = "Design",
                    Created = DateTime.Now
                },
                new Tag
                {

                    Name = "Programming",
                    Created = DateTime.Now
                },
            }; 
              
            tagList.ForEach(tags => context.Tags.AddOrUpdate(a=>a.Name, tags));
            #endregion
        }
    }
}
