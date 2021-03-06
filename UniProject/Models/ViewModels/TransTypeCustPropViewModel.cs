﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.Models.IMS;

namespace UniProject.Models.ViewModels
{
    public class TransTypeCustPropViewModel
    {
        public Transaction Transaction { get; set; }
       
        public IList<Customer> Customer { get; set; }
        public IList<PropertyIMS> PropertyIMS { get; set; }
        public IList<TransType> TransType { get; set; }
    }
}