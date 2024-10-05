using Microsoft.AspNetCore.Mvc;
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
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _service;

        public BlogPostController(IBlogPostService service)
        {
            _service = service;
        }
        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
           var entity = await _service.GetAllPostsAsync();
            if (entity == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            return Ok(entity);
        }
    }
}
