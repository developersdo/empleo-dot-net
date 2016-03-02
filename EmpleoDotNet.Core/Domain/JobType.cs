using System;
using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.Core.Domain
{
    public enum JobType
    {
        [Display(Name = "N/A")]
        NotApplicable,

        [Display(Name = "Independiente")]
        Freelance,

        [Display(Name = "Medio Tiempo")]
        PartTime,

        [Display(Name = "Tiempo Completo")]
        FullTime,

        [Display(Name = "Pasante / Internado")]
        Internship,

        [Display(Name = "Voluntario")]
        Volunteer
    }
}