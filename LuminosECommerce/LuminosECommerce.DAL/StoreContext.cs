using Microsoft.EntityFrameworkCore;
using LuminosECommerce.Models;
using System.Diagnostics;

namespace LuminosECommerce.DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<ItemCategory> ItemCategories{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderedItem> OrderedItems{ get; set; }
        public DbSet<UserReview> UserReviews{ get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = localhost\\SQLEXPRESS; Initial Catalog = eCommerce; Integrated Security = true; TrustServerCertificate=True");
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserReview>().HasIndex(x => new { x.UserId, x.ItemId}).IsUnique();
            modelBuilder.Entity<OrderedItem>().HasIndex(x => new { x.OrderId, x.ItemId }).IsUnique();
            modelBuilder.Entity<ItemCategory>().HasIndex(x => new { x.ItemId, x.CategoryId}).IsUnique();
            modelBuilder.Entity<Cart>().HasIndex(x => new { x.ItemId, x.UserId}).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
