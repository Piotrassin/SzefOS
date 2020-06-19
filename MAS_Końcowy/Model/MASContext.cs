using Microsoft.EntityFrameworkCore;
using System;

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
        //TPT
        public DbSet<Person> People { get; set; }
        public DbSet<IngredientsSupplier> IngredientSuppliers { get; set; }
        //TPH
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishContent> DishContents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=localhost;Database=MAS_db;Username=postgres;Password=admin");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TPT
            //modelBuilder.Entity<Person>().ToTable("People");
            //modelBuilder.Entity<IngredientsSupplier>().ToTable("IngredientsSuppliers");
            //TPT & TPH
            //modelBuilder.Entity<Employee>().ToTable("Employees")
            //    .HasDiscriminator<String>("RoleName")
            //    .HasValue<Cook>("Cook")
            //    .HasValue<Waiter>("Waiter")
            //    .HasValue<Deliverer>("Deliverer")
            //    .HasValue<Manager>("Manager");

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

            modelBuilder.Entity<OrderContent>()
                .HasKey(di => new { di.DishId, di.OrderId });
            modelBuilder.Entity<OrderContent>()
                .HasOne(a => a.Dish)
                .WithMany(b => b.OrderContents)
                .HasForeignKey(c => c.DishId);
            modelBuilder.Entity<OrderContent>()
                .HasOne(a => a.Order)
                .WithMany(b => b.OrderContents)
                .HasForeignKey(c => c.OrderId);



        }
    }
}
