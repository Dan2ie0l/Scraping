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
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork unitOfWork;

        public ImageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Image image)
        {
            await unitOfWork.images.InsertAsync(image);
            await unitOfWork.CommitAsync();

        }

        public async Task DeleteAsync(Image image)
        {
            unitOfWork.images.Delete(image);
            await unitOfWork.CommitAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {

            return await unitOfWork.images.GetByIdAsync(id);
        }



        public async Task UpdateAsync(Image image)
        {
            if (!(image is null))
            {
                unitOfWork.images.Update(image);
                await unitOfWork.CommitAsync();
            }
        }

    }
}
