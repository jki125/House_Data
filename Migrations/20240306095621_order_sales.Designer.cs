﻿// <auto-generated />
using System;
using House_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace House_Data.Migrations
{
    [DbContext(typeof(House_DataContext))]
    [Migration("20240306095621_order_sales")]
    partial class order_sales
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("House_Data.Models.House", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal?>("area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("cDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("houseAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("houseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("salesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("uDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("House");
                });

            modelBuilder.Entity("House_Data.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("branchId")
                        .HasColumnType("int");

                    b.Property<int>("salesId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("House_Data.Models.Sales", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("branchId")
                        .HasColumnType("int");

                    b.Property<string>("salesName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}