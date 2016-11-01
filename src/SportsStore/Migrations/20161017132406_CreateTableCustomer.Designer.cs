using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportsStore.Data;

namespace SportsStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161017132406_CreateTableCustomer")]
    partial class CreateTableCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsStore.Models.City", b =>
                {
                    b.Property<string>("Postalcode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Postalcode");

                    b.ToTable("City");
                });

            modelBuilder.Entity("SportsStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityPostalcode")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("CustomerId");

                    b.HasIndex("CityPostalcode");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SportsStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<decimal>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SportsStore.Models.Customer", b =>
                {
                    b.HasOne("SportsStore.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityPostalcode");
                });
        }
    }
}
