using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete.EntityFramework
{   
    //context :db tabloları ile proje claslarını bağlamak
    public class NorthwindContext:DbContext
    {
        //NorthwindContext:DbContext böyle veritabanına bağlıyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // override on yazınca çıktı
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
            //senin db ismini girip bağladık
        }

        public DbSet<Product> Products { get; set; }//hangi nesnem hangisine karşılık gelecek
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
