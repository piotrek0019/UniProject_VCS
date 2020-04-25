﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniProject.Models
{
    public class SubPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
    }
}