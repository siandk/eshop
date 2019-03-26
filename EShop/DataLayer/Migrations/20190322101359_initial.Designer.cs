﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20190322101359_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentCategoryId");

                    b.Property<string>("ParentPath");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DataLayer.Entities.ContactInfo", b =>
                {
                    b.Property<string>("ContactInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasMaxLength(50);

                    b.Property<string>("Zip")
                        .HasMaxLength(50);

                    b.HasKey("ContactInfoId");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("DataLayer.Entities.Currency", b =>
                {
                    b.Property<string>("CurrencyId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CurrencyRate")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CurrencyId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("DataLayer.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactInfoId");

                    b.Property<string>("ContactInfoId1");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("CustomerId");

                    b.HasIndex("ContactInfoId1");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataLayer.Entities.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountCurrency")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("AmountTotal")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("CurrencyId");

                    b.Property<string>("CurrencyId1");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNote")
                        .HasMaxLength(150);

                    b.HasKey("OrderId");

                    b.HasIndex("CurrencyId1");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.Entities.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("LinePrice")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("LineQuantity")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("UomId");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UomId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<int?>("ManufacturerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Published");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("UomId");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.ProductSupplierPrice", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SupplierId");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("ProductId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductSupplierPrice");
                });

            modelBuilder.Entity("DataLayer.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactInfoId");

                    b.Property<string>("ContactInfoId1");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SupplierId");

                    b.HasIndex("ContactInfoId1");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("DataLayer.Entities.UnitOfMeasure", b =>
                {
                    b.Property<int>("UomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ParentPath");

                    b.Property<int?>("ParentUomId");

                    b.Property<decimal>("UnitDiscount");

                    b.Property<decimal>("UnitMultiplier");

                    b.HasKey("UomId");

                    b.HasIndex("ParentUomId");

                    b.ToTable("UnitOfMeasure");
                });

            modelBuilder.Entity("DataLayer.Entities.Category", b =>
                {
                    b.HasOne("DataLayer.Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("DataLayer.Entities.Customer", b =>
                {
                    b.HasOne("DataLayer.Entities.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId1");
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.HasOne("DataLayer.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId1");

                    b.HasOne("DataLayer.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.OrderLine", b =>
                {
                    b.HasOne("DataLayer.Entities.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Entities.UnitOfMeasure", "Uom")
                        .WithMany()
                        .HasForeignKey("UomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.HasOne("DataLayer.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId");
                });

            modelBuilder.Entity("DataLayer.Entities.ProductSupplierPrice", b =>
                {
                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("ProductSupplierPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Entities.Supplier", "Supplier")
                        .WithMany("ProductSupplierPrices")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Supplier", b =>
                {
                    b.HasOne("DataLayer.Entities.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId1");
                });

            modelBuilder.Entity("DataLayer.Entities.UnitOfMeasure", b =>
                {
                    b.HasOne("DataLayer.Entities.UnitOfMeasure", "ParentUom")
                        .WithMany("ChildUoms")
                        .HasForeignKey("ParentUomId");
                });
#pragma warning restore 612, 618
        }
    }
}
