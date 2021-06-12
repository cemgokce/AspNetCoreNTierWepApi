using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OrnekNLayerProject.Core.Model;
using OrnekNLayerProject.Core.Services;
using OrnekNLayerProject.DTOs;
using OrnekNLayerProject.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await  _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAysnc(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newproduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            return Created(String.Empty, _mapper.Map<ProductDto>(newproduct));



        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {

            if (string.IsNullOrEmpty(productDto.Id.ToString()) || productDto.Id <= 0)
            {
                throw new Exception("Id alanı gereklidir.");
            }

            var updateproduct = _productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();

        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAysnc(id).Result;

            _productService.Remove(product);
            return NoContent();
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetwithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }
    }
}
