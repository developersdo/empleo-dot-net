using System;
using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.Models
{
    /// <summary>
    /// Categoria de trabajo
    /// </summary>
    [Flags]
    public enum JobCategory
    {
        /// <summary>
        /// Ninguna
        /// </summary>
        [Display(Name = "N/A")]
        None = 0,

        /// <summary>
        /// Diseño Grafico
        /// </summary>
        [Display(Name = "Diseño Gráfico")]
        GraphicDesign = 1,
        
        /// <summary>
        /// Desarrollo Web
        /// </summary>
        [Display(Name = "Desarrolo Web")]
        WebDevelopment = 2,
        
        /// <summary>
        /// Desarrollo Movil
        /// </summary>
        [Display(Name = "Desarrollo para Moviles")]
        MobileDevelopment = 4,
        
        /// <summary>
        /// Dessarrollo de Software
        /// </summary>
        [Display(Name = "Desarrollo de Software")]
        SoftwareDevelopment = 8,
        
        /// <summary>
        /// Administrador de Sistemas
        /// </summary>
        [Display(Name = "Administrador de sistemas")]
        SystemAdministrator = 16,
        
        /// <summary>
        /// Redes
        /// </summary>
        [Display(Name = "Redes y telecomunicaciones")]
        Networking = 32,
        
        /// <summary>
        /// IT Ventas
        /// </summary>
        [Display(Name = "IT Ventas")]
        ItSales = 64
    }
}