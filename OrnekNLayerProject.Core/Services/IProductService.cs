using OrnekNLayerProject.Core.Model;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        //bool ControlInnerBarcode(Product product);

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
