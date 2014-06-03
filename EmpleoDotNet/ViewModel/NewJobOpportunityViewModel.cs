using System;
using System.ComponentModel.DataAnnotations;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.ViewModel
{
    /// <summary>
    /// ViewModel para crear una vacante nueva
    /// </summary>
    public class NewJobOpportunityViewModel
    {
        [Required(ErrorMessage = "El campo titulo es requerido."), Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo ubicación es requerido."), Display(Name = "Ubicación")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Debe elegir una categoria."), Display(Name = "Categoria")]
        public JobCategory Category { get; set; }

        [Required(ErrorMessage = "Debe especificar al menos un requisito."), Display(Name = "Requisitos para aplicar")]
        public string RequirementsToApply { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido."), Display(Name = "Ubicación")]
        public string CompanyName { get; set; }

        [Display(Name = "Dirección Web")]
        public string CompanyUrl { get; set; }

        [Required(ErrorMessage = "Debe especificar al menos una dirección de correo electrónica."), Display(Name = "Email"),
        EmailAddress(ErrorMessage = "Email invalido. Favor colocar un Email valido.")]
        public string CompanyEmail { get; set; }


        public string CompanyLogoUrl { get; set; }

        public Models.JobOpportunity ToEntity()
        {

            var entity = new JobOpportunity {
                Title = this.Title,
                Location = this.Location,
                Category = this.Category,
                RequirementsToApply = this.RequirementsToApply,
                CompanyName = this.CompanyName,
                CompanyUrl = this.CompanyUrl,
                CompanyLogoUrl = this.CompanyLogoUrl,
                CompanyEmail = this.CompanyEmail,
                Created = DateTime.Now,
                PublishedDate = DateTime.Now
            };

            return entity;
        }
    }
}