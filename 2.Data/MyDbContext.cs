using _1.Core.Domain;
using _2.Data.Mapping;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace _2.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyConnectionString")
        {
            Database.CommandTimeout = 10800000;
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Log> Logs { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductCategory> ProductCategories { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        static MyDbContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }

        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new LogMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new ProductCategoryMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderDetailMapping());
        }
    }

    public class MyContextInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
        }
    }
}