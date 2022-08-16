using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraping.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Scraping
{
    public class AppContext : DbContext
    {

        public DbSet<PornstarModel> stars => Set<PornstarModel>();




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PornstarModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Avatar).IsRequired();
                entity.Property(e => e.Bio).IsRequired();
                entity.Property(e => e.Description).IsRequired();


            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.Urls)
    .HasConversion(
    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
    new ValueComparer<ICollection<string>>(
        (c1, c2) => c1.SequenceEqual(c2),
        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        c => c.ToList()));
            });

        }
    }
}
