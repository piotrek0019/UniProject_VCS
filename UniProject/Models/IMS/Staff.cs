using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniProject.Models.IMS
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public IList<Email> Email { get; set; }
        public IList<Phone> Phone { get; set; }
    }
}