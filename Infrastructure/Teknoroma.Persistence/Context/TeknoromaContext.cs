using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Configuration;

namespace Teknoroma.Persistence.Context
{
    public class TeknoromaContext:IdentityDbContext<AppUser,AppUserRole,Guid>
    {

        public TeknoromaContext()
        {
            
        }

        public TeknoromaContext(DbContextOptions options):base(options)
        {
           
        }

        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockInput> StockInputs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppUserProfileConfiguration());
            builder.ApplyConfiguration(new BranchConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new StockConfiguration());
            builder.ApplyConfiguration(new StockInputConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-S8RDFAU;database=TeknoromaDB;Trusted_Connection=True;TrustServerCertificate=True;");
                
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
