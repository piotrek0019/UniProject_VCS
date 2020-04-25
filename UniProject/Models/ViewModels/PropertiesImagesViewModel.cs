using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniProject.Models.ViewModels
{
    public class PropertiesImagesViewModel
    {
        public IEnumerable<Image> Images { get; set; }
        public Property Property { get; set; }
    }
}