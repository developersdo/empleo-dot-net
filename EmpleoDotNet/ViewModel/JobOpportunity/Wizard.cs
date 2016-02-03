using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.ViewModel.JobOpportunity
{
    public class Wizard
    {
        [Required(ErrorMessage = "El campo título es requerido."), StringLength(int.MaxValue)]
        [Display(Name = "Título. ¿Qué estás buscando?")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La localidad es requerida")]
        [Display(Name = "Localidad")]
        public int SelectedLocationId { get; set; }

        public SelectList Locations { get; set; }

        [Required(ErrorMessage = "Debes elegir una categoría.")]
        [Display(Name = "Categoría")]
        public JobCategory Category { get; set; }

        [Required(ErrorMessage = "Debes especificar al menos un requisito."), StringLength(int.MaxValue)]
        [Display(Name = "Requisitos para aplicar")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido."), StringLength(50)]
        [Display(Name = "Nombre")]
        public string CompanyName { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "La dirección Web de la compañia debe ser un Url válido.")]
        [Display(Name = "Sitio Web (url)")]
        public string CompanyUrl { get; set; }

        [Required(ErrorMessage = "El campo correo electrónico es requerido"), StringLength(int.MaxValue), EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        [Display(Name = "Correo electrónico"),]
        public string CompanyEmail { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El logo de la compañía debe ser un Url válido.")]
        [Display(Name = "Logo (Opcional)")]
        public string CompanyLogoUrl { get; set; }

        public bool IsRemote { get; set; }
        public Core.Domain.JobOpportunity ToEntity()
        {
            var entity = new Core.Domain.JobOpportunity
            {
                Title = Title,
                LocationId = SelectedLocationId,
                Category = Category,
                Description = Description,
                CompanyName = CompanyName,
                CompanyUrl = CompanyUrl,
                CompanyLogoUrl = CompanyLogoUrl,
                CompanyEmail = CompanyEmail,
                PublishedDate = DateTime.Now,
                IsRemote = IsRemote
            };

            return entity;
        }
    }
}