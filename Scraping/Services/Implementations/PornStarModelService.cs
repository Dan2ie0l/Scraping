using Scraping.Interfaces;
using Scraping.Models;
using Scraping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Implementations
{
    public class PornStarModelService : IPornStarModelService
    {
        private readonly IUnitOfWork unitOfWork;

        public PornStarModelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(PornstarModel model)
        {
            await unitOfWork.models.InsertAsync(model);
            await unitOfWork.CommitAsync();

        }

        public async Task DeleteAsync(PornstarModel model)
        {
            unitOfWork.models.Delete(model);
            await unitOfWork.CommitAsync();
        }

        public async Task<PornstarModel> GetByIdAsync(int id)
        {

            return await unitOfWork.models.GetByIdAsync(id);
        }



        public async Task UpdateAsync(PornstarModel model)
        {
            if (!(model is null))
            {
                unitOfWork.models.Update(model);
                await unitOfWork.CommitAsync();
            }
        }


    }
}