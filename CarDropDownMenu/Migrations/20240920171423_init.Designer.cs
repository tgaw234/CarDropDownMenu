﻿// <auto-generated />
using CarDropDownMenu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarDropDownMenu.Migrations
{
    [DbContext(typeof(CarRentalDbContext))]
    [Migration("20240920171423_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("CarBrandCarMakeMatrix", b =>
                {
                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<int>("CarMakeId")
                        .HasColumnType("int");

                    b.HasKey("CarBrandId", "CarMakeId");

                    b.HasIndex("CarMakeId");

                    b.ToTable("CarBrandCarMakeMatrix");
                });

            modelBuilder.Entity("CarMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarMakes");
                });

            modelBuilder.Entity("CarBrandCarMakeMatrix", b =>
                {
                    b.HasOne("CarBrand", "CarBrand")
                        .WithMany("CarBrandCarMakeMatrix")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarMake", "CarMake")
                        .WithMany("CarBrandCarMakeMatrix")
                        .HasForeignKey("CarMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");

                    b.Navigation("CarMake");
                });

            modelBuilder.Entity("CarBrand", b =>
                {
                    b.Navigation("CarBrandCarMakeMatrix");
                });

            modelBuilder.Entity("CarMake", b =>
                {
                    b.Navigation("CarBrandCarMakeMatrix");
                });
#pragma warning restore 612, 618
        }
    }
}