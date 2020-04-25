using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniProject.Models.ViewModels
{
    public class PropertiesViewModel
    {
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Property> Property { get; set; }
    }
}