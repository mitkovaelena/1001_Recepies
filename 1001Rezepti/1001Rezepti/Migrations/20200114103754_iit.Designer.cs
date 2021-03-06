﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1001Rezepti.Models;

namespace _1001Rezepti.Migrations
{
    [DbContext(typeof(RecepieContext))]
    [Migration("20200114103754_iit")]
    partial class iit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_1001Rezepti.Models.Product", b =>
                {
                    b.Property<int>("ProductID");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ProductID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("_1001Rezepti.Models.RecProd", b =>
                {
                    b.Property<int>("RecepieId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("RecepieId", "ProductId");

                    b.HasAlternateKey("ProductId", "RecepieId");

                    b.ToTable("RecProd");
                });

            modelBuilder.Entity("_1001Rezepti.Models.Recepie", b =>
                {
                    b.Property<int>("RecepieID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000);

                    b.Property<string>("ImagePath");

                    b.Property<string>("RecepieName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("TimeToCook");

                    b.HasKey("RecepieID");

                    b.ToTable("Recepie");
                });

            modelBuilder.Entity("_1001Rezepti.Models.RecProd", b =>
                {
                    b.HasOne("_1001Rezepti.Models.Product", "Product")
                        .WithMany("Recepies")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_1001Rezepti.Models.Recepie", "Recepie")
                        .WithMany("Products")
                        .HasForeignKey("RecepieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
