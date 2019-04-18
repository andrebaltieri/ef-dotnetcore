using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace efseis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired();
        }
    }

    public class DataContext : DbContext
    {
        public DataContext() : base("CONNSTR") { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
