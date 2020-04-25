﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniProject.Models.IMS
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}