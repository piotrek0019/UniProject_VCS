using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniProject.Models.IMS;

namespace UniProject.Models
{
    public class UniDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<SubPage> SubPages { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PropertyIMS> PropertyIMSs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransType> TransTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
 

        public UniDbContext()
            : base("name=UniProjDbt")
        {

        }
    }
}