using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniProject.Models.IMS
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public double? Price { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public int PropertyIMSId { get; set; }
        public PropertyIMS PropertyIMS { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public byte TransTypeId { get; set; }
        public TransType TransType { get; set; }
    }
}