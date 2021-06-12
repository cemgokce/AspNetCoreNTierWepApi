using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using OrnekNLayerProject.Core.Model;
using OrnekNLayerProject.Core.Services;
using OrnekNLayerProject.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAysnc(id);

            return Ok(_mapper.Map<CategoryDto>(category));

        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            return Created(String.Empty, _mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public  IActionResult Update(CategoryDto categoryDto)
        {
            var updatecategory = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAysnc(id).Result;
            _categoryService.Remove(category);
            return NoContent();
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        }
    }
}
