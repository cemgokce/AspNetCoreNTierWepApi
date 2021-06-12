using OrnekNLayerProject.Core.Model;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Core.Repositories
{
    public interface IProductRepository:IRepositories<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
        
    }
}
