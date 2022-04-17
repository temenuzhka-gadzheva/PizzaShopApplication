using Microsoft.EntityFrameworkCore;
using PizzaShop.Models.Models;

namespace PizzaShop.Models.Data
{
    public class PizzaShopDbContext : DbContext
    {
        public PizzaShopDbContext()
        {
            this.Categories = Set<Category>();
            this.Ingredients = Set<Ingredient>();
            this.PizzaIngredients = Set<PizzaIngredient>();
            this.Pizzas = Set<Pizza>();
            this.Reviews = Set<Review>();
            this.Orders = Set<Order>();
            this.Users = Set<User>();
        }


        public PizzaShopDbContext(DbContextOptions<PizzaShopDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server=.;Database=PizzaShopDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "admin",
                Password = "admin123",
                FirstName = "Admin",
                LastName = "Admin"
            });
        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
