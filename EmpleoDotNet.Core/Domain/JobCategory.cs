using System;
using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.Core.Domain
{
    /// <summary>
    /// Categoria de empleo
    /// </summary>
    [Flags]
    public enum JobCategory
    {
        /// <summary>
        /// Todas
        /// </summary>
        [Display(Name = "Invalid")]
        Invalid = -2,
        /// <summary>
        /// Todas
        /// </summary>
        [Display(Name = "Todas")]
        All = -1,

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
        [Display(Name = "Desarrollo Web")]
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
        ItSales = 64,

        /// <summary>
        /// DBA
        /// </summary>
        [Display(Name = "Administrador de base de datos")]
        DataBaseAdministrator = 128
    }
}