using Scraping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Interfaces
{
    public interface IImageService
    {
        Task<Image> GetByIdAsync(int id);

        Task CreateAsync(Image image);

        Task DeleteAsync(Image image);


        Task UpdateAsync(Image image);
    }
}
