using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UniProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Field can't be empty")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Login must be an email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }
        public string ReturnUrl { get; set; }
      
    }
}