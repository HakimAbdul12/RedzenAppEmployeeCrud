using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Employess.Models.Blazor;

namespace Employess.Data
{
    public partial class BlazorContext : DbContext
    {
        public BlazorContext()
        {
        }

        public BlazorContext(DbContextOptions<BlazorContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employess.Models.Blazor.Contact>()
              .Property(p => p.Email)
              .HasDefaultValueSql(@"(N'')");     
            this.OnModelBuilding(builder);
        }

        public DbSet<Employess.Models.Blazor.Contact> Contacts { get; set; }

        public DbSet<Employess.Models.Blazor.Employee> Employees { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}