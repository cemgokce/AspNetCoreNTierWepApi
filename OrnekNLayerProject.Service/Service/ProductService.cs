using OrnekNLayerProject.Core.Model;
using OrnekNLayerProject.Core.Repositories;
using OrnekNLayerProject.Core.Services;
using OrnekNLayerProject.Core.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Service.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepositories<Product> repositories) : base(unitOfWork, repositories)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {

            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);

        }
    }
}
