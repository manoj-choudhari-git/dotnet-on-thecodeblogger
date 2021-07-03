using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Blog.Api.Models;
using Blog.Business;
using Blog.Business.Contracts;
using Blog.Data.EF.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesBusiness _categoriesBusiness;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoriesBusiness categoriesBusiness, IMapper mapper, ILogger<CategoriesController> logger)
        {
            _categoriesBusiness = categoriesBusiness;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoriesBusiness.GetAllAsync();
            return Ok(_mapper.Map<IList<CategoryModel>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoriesBusiness.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryModel>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryModel newCategory)
        {
            if (newCategory == null)
            {
                return BadRequest();
            }

            var category = _mapper.Map<Category>(newCategory);
            await _categoriesBusiness.CreateAsync(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryModel categoryModel)
        {
            if (categoryModel == null || id <= 0)
            {
                return BadRequest();
            }

            categoryModel.Id = id;
            var category = _mapper.Map<Category>(categoryModel);
            await _categoriesBusiness.UpdateAsync(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var isDeleted = await _categoriesBusiness.DeleteAsync(id);
            return Ok(isDeleted);
        }
    }
}
