using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniProject.Models.IMS
{
    public class PropertyIMS
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [MaxLength(80, ErrorMessage = "Max length is 80 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Adress { get; set; }
        [Display(Name="Post Code")]
        [MaxLength(10, ErrorMessage = "Max length is 10 characters")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string City { get; set; }
        public IList<Transaction> Purchase { get; set; }
       
    }
}