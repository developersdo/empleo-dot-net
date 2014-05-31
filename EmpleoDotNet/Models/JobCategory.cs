using System;
using System.ComponentModel;

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
        None = 0,

        /// <summary>
        /// Diseño Grafico
        /// </summary>
        GraphicDesign = 1,
        
        /// <summary>
        /// Desarrollo Web
        /// </summary>
        WebDevelopment = 2,
        
        /// <summary>
        /// Desarrollo Movil
        /// </summary>
        MobileDevelopment = 4,
        
        /// <summary>
        /// Dessarrollo de Software
        /// </summary>
        SoftwareDevelopment = 8,
        
        /// <summary>
        /// Administrador de Sistemas
        /// </summary>
        SystemAdministrator = 16,
        
        /// <summary>
        /// Redes
        /// </summary>
        Networking = 32,
        
        /// <summary>
        /// IT Ventas
        /// </summary>
        ItSales = 64
    }
}