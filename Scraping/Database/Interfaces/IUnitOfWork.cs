using Scraping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Interfaces
{
    public interface IUnitOfWork
    {
        IAsyncRepository<Image> images { get; }
        IAsyncRepository<PornstarModel> models { get; }

        void Commit();
        Task CommitAsync();
    }
}
