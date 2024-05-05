using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App_Avval.Models.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<RubikaModel> RubikaModels { get; set; }
        public DbSet<RubikaPost> RubikaPosts { get; set; }
        public DbSet<RubikaLink> RubikaLinks { get; set; }
        public DbSet<RubikaKeywords> RubikaKeywords { get; set; }
        public DbSet<RubikaGroup> RubikaGroups { get; set; }
        public AppDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // call the base if you are using Identity service.
            // Important
            base.OnModelCreating(builder);

           
        }
    }
}
