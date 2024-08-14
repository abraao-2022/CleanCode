﻿// <auto-generated />
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanCode.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240813234031_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("CleanCode.Domain.Entities.Item", b =>
                {
                    b.Property<int>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<double>("Height")
                        .HasColumnType("REAL")
                        .HasColumnName("height");

                    b.Property<double>("Length")
                        .HasColumnType("REAL")
                        .HasColumnName("length");

                    b.Property<double>("Price")
                        .HasColumnType("REAL")
                        .HasColumnName("price");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL")
                        .HasColumnName("weight");

                    b.Property<double>("Width")
                        .HasColumnType("REAL")
                        .HasColumnName("width");

                    b.HasKey("IdItem")
                        .HasName("id_item");

                    b.ToTable("items", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
