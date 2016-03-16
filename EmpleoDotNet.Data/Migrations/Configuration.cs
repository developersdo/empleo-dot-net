using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EmpleadoContext>
    {
        public Configuration()                   
        {
             AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmpleadoContext context)
        {
#if DEBUG
            #region JobOpportunities

            var opportunitiesList = new List<JobOpportunity>
            {
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Pega Blo Senior",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Debe saber programar Java",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Developer DO",
                    Created = DateTime.Now.AddDays(-2),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Pega Blo Junior",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Debe saber programar C#",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Developer DO",
                    Created = DateTime.Now.AddDays(-3),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.Networking,
                    Title = "Gerente de IT",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Se necesita gerente de IT para multinacional",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Developers DO Santiago",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.GraphicDesign,
                    Title = "Diseñador Gráfico Web",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Se necesita diseñador que sepa HTML, CSS, Javascript y maneje Bootstrap",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Developers DO PP",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "4 Vacantes, Desarrolladores",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Por este medio les informamos que el Sistema Único de Beneficiarios (SIUBEN) tiene disponible 4 vacantes para el área de Software para trabajar como Desarrolladores, debajo todas las informaciones necesarias para que apliquen:",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Sistema Único de Beneficiarios (SIUBEN)",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Programador IOS",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Buscamos un programador con experiencia demostrable en aplicaciones para móviles (IOS, Android), para desarrollo de un nuevo y ambicioso proyecto.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Verynice",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Programador Android",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Buscamos un programador con experiencia demostrable en aplicaciones para móviles (IOS, Android), para desarrollo de un nuevo y ambicioso proyecto.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Verynice",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador/Desarrollador",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Tecnologo de Software.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Union Telecard Dominicana",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Por este medio les informamos que la empresa DATALINK NETWORKS tiene disponible una vacante para el área de Software para trabajar como Programador, debajo colocamos todas las informaciones necesarias para que apliquen:",
                    Benefits = "Beneficios de ley",
                    CompanyName = "DATALINK NETWORKS",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programadores y disenadores Junior y Senior",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Estamos buscando programadores y diseñadores. Si manejas una o varias de las siguientes cosas envianos tu cv a empleo@ti.com.do",
                    Benefits = "Beneficios de ley",
                    CompanyName = "TECNOLOGIA INTEGRAL DEL CARIBE",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Mobile Developer Intern",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "We are currently expanding, and are looking to bring on another aspiring compadre (or comadre) to [Megsoft Consulting Inc](http://www.megsoftconsulting.com). We're a company that has been profitable since day 0; we had an amazing year and continue to grow on a steady pace.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Megsoft Consulting Inc",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Backend python developer",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Here at meSuma we are looking to fill an in-house position for a backend developer. We are looking for someone who can learn quickly, is very skilled and passionate about coding in general. You’d be working with a wide stack of technologies, including but not limited to: python, flask, pyramid, go, grunt, mongodb, postgresql.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "meSuma",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Diseñador web Comunimas",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Debe residir en Santo Domingo, R.D. Buena orientación de diseño Capacidad de crear propuestas de diseño para webs nuevas CSS3 HTML5 PHOTOSHOP ILUSTRATOR Responsive web design Manejo de Joomla (creacion de plantillas) Es un plus manejar herramientas de la suite de Adobe CC Y demás cosas como responsable, etc.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Comunimas",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador PHP/C#.NET",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Se buscan developers para puesto fijo que dominen bien PHP y MySQL, y algo de C#.NET.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Informatika01",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Senior PHP Developer",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Senior developer needed to work in a very agile environment. Requirements: - 3+ years of experience - PHP5 - MySQL - Must be fluent with linux Benefits: - Benefits act - Insurance - Mon-Fri: 9:00AM to 6:00PM, weekend rotation - Salary to be discussed",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Media Revolution",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.DataBaseAdministrator,
                    Title = "Programador Base de Datos",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Necesito los servicios de alguien que tenga experiencia trabajando con base de datos. Somos una empresa de servicios con una creciente base de cleintes y necesitamos mejor organizar los mismos.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Gestora Quisqueya",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Mobile y Web Developers",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Se requieren VARIOS programadores en desarrollo de aplicaciones móviles para (Android, iOS y Windows Phone), para ser contratados Fijos y Freenlance por proyectos.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Anónima",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador web/Python",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Necesito un desarrollador Web que me complete los codigos de una pagina que tengo casi lista. Es muy poco lo que le falta y es algo urgente.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "dilibox SRL",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "programador C++ y programador C#",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Conocimeinto en C++, c#, v isual studio. Sera para un empleo temporal de 3 meses.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Dekolor",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador SENIOR .NET Indra",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Ingenieros de Sistemas o Tecnologías de la Información (egresados) 5 años o más de experiencia en desarrollo .NET Conocimientos avanzados Java y SQL. Se ofrece contrato indefinido con jornada completa, seguro médico y bonificación. El salario será a convenir según la valía del candidato.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Indra",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador C ++ y c#",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Buscamos un programador temporero (3 meses). Conocimiento de C++, C# Salario 25 mil Mensual.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Brailer",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador Java",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "Se necesitan 10 programadores Java para una empresa cliente. El salario ronda de RD$45,000 a RD$55,000",
                    Benefits = "Beneficios de ley",
                    CompanyName = "FL Betances & Asociados",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador web Tamontao",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements = "Programador web en lenguaje asp.net con mucho tiempo libre para trabajar.",
                    Benefits = "Beneficios de ley",
                    CompanyName = "Tamontao",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador VB .net",
                    CompanyEmail = "prueba@developers.do",
                    CompanyUrl = "http://www.developers.do",
                    Requirements =
                        "• Egresado o Estudiante de una carrera universitaria en el área de Ingeniería de Sistemas o carrera afín.",
                    Benefits = "Beneficios de ley",
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
#endif
        }
    }
}
