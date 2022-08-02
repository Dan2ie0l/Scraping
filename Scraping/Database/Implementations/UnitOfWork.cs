using Scraping.Interfaces;
using Scraping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext context;


        private IAsyncRepository<Image> imageRepo;
        private IAsyncRepository<PornstarModel> modelRepo;

        public IAsyncRepository<Image> images { get => imageRepo ??= new BaseRepository<Image>(context); }

        public IAsyncRepository<PornstarModel> models { get => modelRepo ??= new BaseRepository<PornstarModel>(context); }

        public UnitOfWork(AppContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

