﻿// <auto-generated />
using DataBaseCore.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MySql.Migrations
{
    [DbContext(typeof(EmployeeDBContext))]
    [Migration("20221007211944_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Core.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BasicPay")
                        .HasColumnType("int");

                    b.Property<int>("Bonus")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int>("EmpType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("HRA")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Employees");

                    b.HasDiscriminator<int>("EmpType");
                });

            modelBuilder.Entity("Core.Models.FullTimeEmployee", b =>
                {
                    b.HasBaseType("Core.Models.Employee");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Core.Models.PartTimeEmployee", b =>
                {
                    b.HasBaseType("Core.Models.Employee");

                    b.HasDiscriminator().HasValue(2);
                });
#pragma warning restore 612, 618
        }
    }
}