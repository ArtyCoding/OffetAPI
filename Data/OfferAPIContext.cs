using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfferAPI.EntityTypeConfig;
using OfferAPI.Interfaces;
using OfferAPI.Models;

namespace OfferAPI.Data
{
    public class OfferAPIContext : DbContext
    {
        public DbSet<OfferModel> Offers { get; set; }
        public DbSet<ProviderModel> Providers { get; set; } 

        public OfferAPIContext (DbContextOptions<OfferAPIContext> options)
            : base(options) 
        {
           //Database.EnsureDeleted();
           Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfferConfiguration())
                .ApplyConfiguration(new ProviderConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }

    }
}
