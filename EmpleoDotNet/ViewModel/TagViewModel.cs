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
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } 
        public EstadoRegistro Estado { get; set; }
        public DateTime Created{get; set; }

        public IList<JobOpportunity> Opportunities { get; set; }
        #endregion

        #region Methods
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

        public TagViewModel ToViewModel(Tag tag)
        {
            var vm = new TagViewModel
            {
                Estado = tag.Estado,
                Name = tag.Name,
                Created = tag.Created
            };
            return vm;
        }
      #endregion
    }
}