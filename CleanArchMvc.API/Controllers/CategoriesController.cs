using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMemoryCache _memoryCache;
        private const string CACHE_KEY = "CACHE_CATEGORIAS";

        public CategoriesController(ICategoryService categoryService, IMemoryCache memoryCache)
        {
            _categoryService = categoryService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            if (!_memoryCache.TryGetValue(CACHE_KEY, out IEnumerable<CategoryDTO>? categories))
            {
                categories = await _categoryService.GetCategories();

                if (categories is not null && categories.Any())
                {
                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(55),
                        SlidingExpiration = TimeSpan.FromSeconds(50),
                        Priority = CacheItemPriority.High,
                        Size = 1
                    };

                    _memoryCache.Set(CACHE_KEY, categories, cacheOptions);

                }  
               
                return categories is null ? NotFound("Categories not found") : Ok(categories);
            }


            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {

            var cacheCategoryKey = $"CacheCategory_{id}";
            
                

            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid Data");

            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id },
                categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest();

            if (categoryDto == null)
                return BadRequest();

            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            await _categoryService.Remove(id);

            return Ok(category);

        }


    }
}