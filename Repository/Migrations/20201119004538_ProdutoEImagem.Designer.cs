﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualMarketPlace.Repository.Database;

namespace VirtualMarketPlace.Repository.Migrations
{
    [DbContext(typeof(VirtualMarketPlaceContext))]
    [Migration("20201119004538_ProdutoEImagem")]
    partial class ProdutoEImagem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FatherCategoryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Slug")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FatherCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Domain.Models.CollaboratorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollaboratorTypeId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorTypeId");

                    b.ToTable("Collaborator");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CollaboratorTypeId = 1,
                            Email = "Manager@MarketPlace.com",
                            Name = "ManagerMarketPlace",
                            Password = "123@123"
                        });
                });

            modelBuilder.Entity("Domain.Models.CollaboratorTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("CollaboratorType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Employee"
                        });
                });

            modelBuilder.Entity("Domain.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Domain.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<double>("Height");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("Value");

                    b.Property<double>("Weight");

                    b.Property<double>("Width");

                    b.Property<double>("length");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("VirtualMarketPlace.Domain.Models.ClientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<string>("Cellphone")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("VirtualMarketPlace.Domain.Models.NewsletterEmailModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("NewsletterEmail");
                });

            modelBuilder.Entity("Domain.Models.CategoryModel", b =>
                {
                    b.HasOne("Domain.Models.CategoryModel", "FatherCategory")
                        .WithMany()
                        .HasForeignKey("FatherCategoryId");
                });

            modelBuilder.Entity("Domain.Models.CollaboratorModel", b =>
                {
                    b.HasOne("Domain.Models.CollaboratorTypeModel", "CollaboratorType")
                        .WithMany()
                        .HasForeignKey("CollaboratorTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.ImageModel", b =>
                {
                    b.HasOne("Domain.Models.ProductModel", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.ProductModel", b =>
                {
                    b.HasOne("Domain.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}