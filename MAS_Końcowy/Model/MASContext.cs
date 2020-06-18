using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class MASContext : DbContext
    {
        //public MASContext()
        //    : base(nameOrConnectionString: ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString)
        //{ }

        public MASContext()
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishContent> DishContents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=localhost;Database=MAS_db;Username=postgres;Password=admin");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Menu>()
                .HasMany(b => b.Dishes)
                .WithOne(c => c.Menu)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dish>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Ingredient>()
                .HasKey(a => a.Id);

            //many to many
            modelBuilder.Entity<DishContent>()
                .HasKey(di => new { di.DishId, di.IngredientId });
            modelBuilder.Entity<DishContent>()
                .HasOne(a => a.Dish)
                .WithMany(b => b.DishIngredients)
                .HasForeignKey(c => c.DishId);
            modelBuilder.Entity<DishContent>()
                .HasOne(a => a.Ingredient)
                .WithMany(b => b.DishContents)
                .HasForeignKey(c => c.IngredientId);
        }
    }
}
