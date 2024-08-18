using CleanCode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.CleanCodeContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Item>().ToTable("items");
        builder.Entity<Item>().HasKey(i => i.Id).HasName("id");
        builder.Entity<Item>().Property(i => i.Category).HasColumnName("category");
        builder.Entity<Item>().Property(i => i.Description).HasColumnName("description");
        builder.Entity<Item>().Property(i => i.Price).HasColumnName("price");
        builder.Entity<Item>().Property(i => i.Width).HasColumnName("width");
        builder.Entity<Item>().Property(i => i.Height).HasColumnName("height");
        builder.Entity<Item>().Property(i => i.Length).HasColumnName("length");
        builder.Entity<Item>().Property(i => i.Weight).HasColumnName("weight");

        builder.Entity<Coupon>().ToTable("coupons");
        builder.Entity<Coupon>().HasKey(i => i.Code).HasName("code");
        builder.Entity<Coupon>().Property(i => i.Percentage).HasColumnName("percentage");
        builder.Entity<Coupon>().Property(i => i.ExpireDate).HasColumnName("expire_date");

        builder.Entity<Order>().ToTable("orders");
        builder.Entity<Order>().HasKey(x => x.Id).HasName("id");
        builder.Entity<Order>().Property(o => o.CouponCode).HasColumnName("coupon_code");
        builder.Entity<Order>().OwnsOne(o => o.OrderCode, orderCode =>
        {
            orderCode.Property(c => c.Value).HasColumnName("code");
        });
        builder.Entity<Order>().OwnsOne(o => o.Cpf, cpf =>
        {
            cpf.Property(c => c.Value).HasColumnName("cpf");
        });
        builder.Entity<Order>().Property(o => o.Date).HasColumnName("issue_date");
        builder.Entity<Order>().Property(o => o.Freight).HasColumnName("freight");
        builder.Entity<Order>().Property(o => o.Sequence).HasColumnName("sequence");
        builder.Entity<Order>().Ignore(o => o.FreightCalculator);

        builder.Entity<OrderItem>().ToTable("orderItems");
        builder.Entity<OrderItem>().HasKey(i => i.Id).HasName("id");
        builder.Entity<OrderItem>().Property(i => i.ItemId).HasColumnName("item_id");
        builder.Entity<OrderItem>().Property(i => i.OrderId).HasColumnName("order_id");
        builder.Entity<OrderItem>().Property(i => i.Price).HasColumnName("price");
        builder.Entity<OrderItem>().Property(i => i.Quantity).HasColumnName("quantity");
    }
}
