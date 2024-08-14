using CleanCode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.CleanCodeContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Item>().ToTable("items");
        builder.Entity<Item>().HasKey(i => i.IdItem).HasName("id_item");
        builder.Entity<Item>().Property(i => i.Category).HasColumnName("category");
        builder.Entity<Item>().Property(i => i.Description).HasColumnName("description");
        builder.Entity<Item>().Property(i => i.Price).HasColumnName("price");
        builder.Entity<Item>().Property(i => i.Width).HasColumnName("width");
        builder.Entity<Item>().Property(i => i.Height).HasColumnName("height");
        builder.Entity<Item>().Property(i => i.Length).HasColumnName("length");
        builder.Entity<Item>().Property(i => i.Weight).HasColumnName("weight");

        //builder.Entity<Order>().ToTable("order");
        //builder.Entity<Order>().Property(o => o.Coupon.Code).HasColumnName("coupon_code");
        //builder.Entity<Order>().Property(o => o.Cpf.Value).HasColumnName("cpf");
        //builder.Entity<Order>().Property(o => o.Date).HasColumnName("date");
        //builder.Entity<Order>().Property(o => o.GetFreight()).HasColumnName("freight");

        //builder.Entity<OrderItem>().ToTable("orderItem");
        //builder.Entity<OrderItem>().Property(i => i.IdItem).HasColumnName("id_item");
        //builder.Entity<OrderItem>().Property(i => i.Price).HasColumnName("price");
        //builder.Entity<OrderItem>().Property(i => i.Quantity).HasColumnName("quantity");

        //builder.Entity<Coupon>().ToTable("coupon");
        //builder.Entity<Coupon>().Property(i => i.Code).HasColumnName("code");
        //builder.Entity<Coupon>().Property(i => i.Percentage).HasColumnName("percentage");
        //builder.Entity<Coupon>().Property(i => i.ExpireDate).HasColumnName("expire_date");
    }
}
