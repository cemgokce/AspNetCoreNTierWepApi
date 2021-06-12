using OrnekNLayerProject.Core.Model;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

    }
}
