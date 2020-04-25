using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniProject.Models.IMS;

namespace UniProject.Models.ViewModels
{
    public class CustServiceViewModel
    {
        public Customer Customer { get; set; }
        public Service Service { get; set; }
    }
}