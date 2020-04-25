using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniProject.Models.IMS;

namespace UniProject.Models.ViewModels
{
    public class StaffPhoneEmailListViewModel
    {
        public Staff Staff { get; set; }
        public IEnumerable<Phone> Phone { get; set; }
        public IEnumerable<Email> Email { get; set; }
    }
}