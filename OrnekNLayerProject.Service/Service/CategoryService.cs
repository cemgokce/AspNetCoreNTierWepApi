using OrnekNLayerProject.Core.Model;
using OrnekNLayerProject.Core.Repositories;
using OrnekNLayerProject.Core.Services;
using OrnekNLayerProject.Core.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Service.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepositories<Category> repositories) : base(unitOfWork, repositories)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
