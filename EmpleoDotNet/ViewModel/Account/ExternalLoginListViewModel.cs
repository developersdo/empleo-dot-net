using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpleoDotNet.ViewModel.Account
{
    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
        public string Action { get; set; }
    }
}