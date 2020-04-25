using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniProject.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
     
    }
}