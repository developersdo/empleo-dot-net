using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class Location:ISearchable
    {
        /// <summary>
        /// Identificador único de cada ciudad
        /// </summary>
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}