using OrnekNLayerProject.Core.Model;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Core.Repositories
{
    public interface ICategoryRepository:IRepositories<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

    }
}
