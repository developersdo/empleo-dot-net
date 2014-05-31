using System;
using System.ComponentModel;
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
        [Description("N/A")]
        None = 0,

        /// <summary>
        /// Diseño Grafico
        /// </summary>
        [Description("Diseño Gráfico")]
        GraphicDesign = 1,
        
        /// <summary>
        /// Desarrollo Web
        /// </summary>
        [Description("Desarrolo Web")]
        WebDevelopment = 2,
        
        /// <summary>
        /// Desarrollo Movil
        /// </summary>
        [Description("Desarrollo para Moviles")]
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