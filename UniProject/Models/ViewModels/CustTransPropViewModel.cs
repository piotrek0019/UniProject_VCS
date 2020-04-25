using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniProject.Models.IMS;

namespace UniProject.Models.ViewModels
{
    public class CustTransPropViewModel
    {
        public Customer Customer { get; set; }
        public IList<PropertyIMS> PropertyIMS { get; set; }
        public IList<Transaction> Transaction { get; set; }
        public IList<TransType> TransType { get; set; }
        public IList<Phone> Phone { get; set; }
        public IList<Email> Email { get; set; }
        public IList<Service> Service { get; set; }
    }
}