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
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishContent> DishContents { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractIngredient> ContractIngredients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderContent> OrderContents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=localhost;Database=MAS_db;Username=postgres;Password=admin");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TPT
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<IngredientsSupplier>().ToTable("IngredientsSuppliers");
            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<ContractIngredient>().HasKey(k => new { k.ContractId, k.IngredientId });

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

            //many to many DISH - INGREDIENT
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

            //many to many ORDER - DISH
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

            //many to many CONTRACT - INGREDIENT
            modelBuilder.Entity<ContractIngredient>()
                .HasKey(di => new { di.ContractId, di.IngredientId });
            modelBuilder.Entity<ContractIngredient>()
                .HasOne(a => a.Contract)
                .WithMany(b => b.ContractIngredients)
                .HasForeignKey(c => c.ContractId);
            modelBuilder.Entity<ContractIngredient>()
                .HasOne(a => a.Ingredient)
                .WithMany(b => b.ContractIngredients)
                .HasForeignKey(c => c.IngredientId);

            //Order - Address
            modelBuilder.Entity<Address>()
                .HasMany(a => a.Orders)
                .WithOne(b => b.DeliveryAddress).OnDelete(DeleteBehavior.Restrict);

            //Person - Address
            modelBuilder.Entity<Person>()
                .HasOne(a => a.Address)
                .WithOne(b => b.Person)
                .HasForeignKey(nameof(Person.Address))
                .IsRequired();
        }
    }
}
