using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniProject.Models.IMS
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}