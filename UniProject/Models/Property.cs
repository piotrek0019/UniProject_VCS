using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniProject.Models
{
    public class Property
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [MaxLength(80, ErrorMessage = "Max length is 80 characters")]
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime Added { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Range(0.00, 100000000.00, ErrorMessage="Choose form 0.00 to 100000000.00")]
        public double? Price { get; set; }
        [Display(Name = "Number of Beds")]
        [Range(1, 254, ErrorMessage = "Choose from 1 to 254")]
        public byte? NoOfBeds { get; set; }
        [Required(ErrorMessage = "Choose one")]
        [Display(Name = "Type")]
        public bool? RentOrBuy { get; set; }
        public IList<Image> Image { get; set; }
    }
}