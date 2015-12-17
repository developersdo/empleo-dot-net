using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.ViewModel
{
    /// <summary>
    /// ViewModel para crear una vacante nueva
    /// </summary>
    public class NewJobOpportunityViewModel
    {
        [Required(ErrorMessage = "El campo titulo es requerido."), StringLength(int.MaxValue)]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La localidad es requerida")]
        public int SelectedLocationId { get; set; }

        public SelectList Locations { get; set; }

        [Required(ErrorMessage = "Debe elegir una categoria.")]
        [Display(Name = "Categoria")]
        public JobCategory Category { get; set; }

        [Required(ErrorMessage = "Debe especificar al menos un requisito."), StringLength(int.MaxValue)]
        [Display(Name = "Requisitos para aplicar")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido."), StringLength(50)]
        [Display(Name = "Nombre")]
        public string CompanyName { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "La dirección Web de la compañia debe ser un Url valido.")]
        [Display(Name = "Dirección Web")]
        public string CompanyUrl { get; set; }

        [Required(ErrorMessage = "El campo email es requerido"), StringLength(int.MaxValue), EmailAddress(ErrorMessage = "Email invalido.")]
        [Display(Name = "Email"), ]
        public string CompanyEmail { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El Logo de la compañia debe ser un Url valido.")]
        [Display(Name = "Logo")]
        public string CompanyLogoUrl { get; set; }

        public JobOpportunity ToEntity()
        {
            var entity = new JobOpportunity
            {
                Title = Title,
                LocationId = SelectedLocationId,
                Category = Category,
                Description = Description,
                CompanyName = CompanyName,
                CompanyUrl = CompanyUrl,
                CompanyLogoUrl = CompanyLogoUrl,
                CompanyEmail = CompanyEmail,
                PublishedDate = DateTime.Now
            };

            return entity;
        }
    }
}