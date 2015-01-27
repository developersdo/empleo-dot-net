using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class Tags:EntityBase,ISearchable
    {
        [Key]
        public int Id { get; set;}

        public string TagName { get; set; }

        public int TagCount { get; set; }

    }
}