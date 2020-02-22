
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _1001Rezepti.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace _1001Rezepti.Models
{
    public class RecepieContext : IdentityDbContext<IdentityUser>
    {
        public RecepieContext(DbContextOptions<RecepieContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recepie> Recepies { get; set; }
        public DbSet<RecProd> RecProds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recepie>().ToTable("Recepie");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<RecProd>().ToTable("RecProd");
            modelBuilder.Entity<Recepie>().HasKey(r => r.RecepieID);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductID);

            modelBuilder.Entity<RecProd>().HasKey(r => new { r.RecepieId, r.ProductId });
            base.OnModelCreating(modelBuilder);
        }
    }
}