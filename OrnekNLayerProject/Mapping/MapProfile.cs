using AutoMapper;

using OrnekNLayerProject.Core.Model;
using OrnekNLayerProject.DTOs;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();

        }
    }
}
