using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T item);

        void Update(T item);
        void Delete(T item);
    }
}
