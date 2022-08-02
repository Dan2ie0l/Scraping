using Scraping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Interfaces
{
    public interface IPornStarModelService
    {

        Task<PornstarModel> GetByIdAsync(int id);

        Task CreateAsync(PornstarModel model);

        Task DeleteAsync(PornstarModel model);


        Task UpdateAsync(PornstarModel model);
    }
}
