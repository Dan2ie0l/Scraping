using Microsoft.EntityFrameworkCore;
using Scraping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Implementations
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DbSet<T> Entities;
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            Entities = context.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }


        public virtual async Task InsertAsync(T item) => await Entities.AddAsync(item);
        public virtual async Task InsertRangeAsync(IEnumerable<T> items) => await Entities.AddRangeAsync(items);

        public virtual void Delete(T item) => Entities.Remove(item);

        public virtual void Update(T item)
        {
            Entities.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
