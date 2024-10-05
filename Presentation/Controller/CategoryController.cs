using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.BlogApiDbContext;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
   public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var entity = await _categoryService.GetAllCategoryAsync();
            return Ok(entity);
            
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            
            var dto = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CreatedDate = DateTime.Now,
                BlogPosts = category.BlogPosts,
                Description = category.Description,
                
            };
            await _categoryService.AddCategoryAsync(dto);
            return Ok(dto);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromForm]int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
