using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.ViewModel
{
    [MetadataType(typeof(Tag))]
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public EstadoRegistro Estado { get; set; }
        public DateTime Created {
            get { return DateTime.Now; }
        }
        public IList<JobOpportunity> Opportunities { get; set; } 
        public Tag ToEntity()
        {
            var tag = new Tag
            {
                Estado = this.Estado,
                Created = this.Created,
                Name = this.Name
            };

            return tag;
        }

    }
}