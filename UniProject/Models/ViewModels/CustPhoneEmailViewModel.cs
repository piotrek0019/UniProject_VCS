using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniProject.Models.IMS;

namespace UniProject.Models.ViewModels
{
    public class CustPhoneEmailViewModel
    {
        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
        public Phone Phone { get; set; }
        public Email Email { get; set; }
    }
}