﻿// <auto-generated />
using System;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanCode.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("CleanCode.Domain.Entities.Coupon", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("expire_date");

                    b.Property<int>("Percentage")
                        .HasColumnType("INTEGER")
                        .HasColumnName("percentage");

                    b.HasKey("Code")
                        .HasName("code");

                    b.ToTable("coupons", (string)null);
                });

            modelBuilder.Entity("CleanCode.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("CleanCode.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CouponCode")
                        .HasColumnType("TEXT")
                        .HasColumnName("coupon_code");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("issue_date");

                    b.Property<double>("Freight")
                        .HasColumnType("REAL")
                        .HasColumnName("freight");

                    b.Property<int>("Sequence")
                        .HasColumnType("INTEGER")
                        .HasColumnName("sequence");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("CouponCode");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("CleanCode.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("item_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("order_id");

                    b.Property<double>("Price")
                        .HasColumnType("REAL")
                        .HasColumnName("price");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("OrderId");

                    b.ToTable("orderItems", (string)null);
                });

            modelBuilder.Entity("CleanCode.Domain.Entities.Order", b =>
                {
                    b.HasOne("CleanCode.Domain.Entities.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponCode");

                    b.OwnsOne("CleanCode.Domain.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("cpf");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("CleanCode.Domain.ValueObjects.OrderCode", "OrderCode", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("code");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Coupon");

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("OrderCode");
                });

            modelBuilder.Entity("CleanCode.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("CleanCode.Domain.Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanCode.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
