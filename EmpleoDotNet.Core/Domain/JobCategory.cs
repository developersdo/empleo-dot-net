using System;
using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.Core.Domain
{
    /// <summary>
    /// Categoria de empleo
    /// </summary>
    public enum JobCategory
    {
        /// <summary>
        /// Ninguna
        /// </summary>
        [Display(Name = "N/A")]
        None,

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
        DataBaseAdministrator = 128,

        ///<summary>
        ///Desarrollo de Videojuegos
        ///</summary>
        [Display(Name ="Desarrollo de Videojuegos")]
        GameDevelopment = 256
    }
}