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

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredients> DishContents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=localhost;Database=MAS_db;Username=postgres;Password=admin");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Ingredient>()
                .HasKey(a => a.Id);

            //many to many
            modelBuilder.Entity<DishIngredients>()
                .HasKey(di => new { di.DishId, di.IngredientId });
            modelBuilder.Entity<DishIngredients>()
                .HasOne(a => a.Dish)
                .WithMany(b => b.DishIngredients)
                .HasForeignKey(c => c.DishId);
            modelBuilder.Entity<DishIngredients>()
                .HasOne(a => a.Ingredient)
                .WithMany(b => b.DishContents)
                .HasForeignKey(c => c.IngredientId);
        }
    }
}
