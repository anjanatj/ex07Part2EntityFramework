using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportsStore.Data;

namespace SportsStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161017125436_CreateTableCity")]
    partial class CreateTableCity
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
        }
    }
}
