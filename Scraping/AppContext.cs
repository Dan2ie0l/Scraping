using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraping.Models;
using Microsoft.EntityFrameworkCore;

namespace Scraping
{
    public class AppContext : DbContext
    {

        public DbSet<PornstarModel> stars => Set<PornstarModel>();




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=visualstudio;user=root;password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PornstarModel>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Avatar).IsRequired();
                entity.Property(e => e.Nationality).IsRequired();
                entity.Property(e => e.Description).IsRequired();


            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Urls).IsRequired();

            });

        }
    }
}
