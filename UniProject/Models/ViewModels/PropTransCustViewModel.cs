using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniProject.Models.IMS;

namespace UniProject.Models.ViewModels
{
    public class PropTransCustViewModel
    {
        public PropertyIMS PropertyIMS { get; set; }
        public IList<Transaction> Transaction { get; set; }
        public IList<Customer> Customer { get; set; }
        public IList<TransType> TransType { get; set; }
    }
}