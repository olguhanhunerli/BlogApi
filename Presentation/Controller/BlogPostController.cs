using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [Authorize]
        [HttpPost("AddBlogPost")]
        public async Task<IActionResult> AddBlogPost(BlogPostDto blogPostDto)
        {

            // Token'dan kullanıcıyı alıyoruz
            var userIdString = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var claims = HttpContext.User.Claims.ToList();
          
            if (int.TryParse(userIdString, out var userId))
            {
                var newBlogPost = new BlogPost
                {
                    Title = blogPostDto.Title,
                    Content = blogPostDto.Content,
                    CreateDate= DateTime.UtcNow,
                    CategoryId = blogPostDto.CategoryId,
                    UserId = new Users { Id = userId },  // Kullanıcı nesnesi oluşturuluyor
                    Assets = blogPostDto.Assets.Select(a => new Assets
                    {
                        FileName = a.FileName,
                        FilePath = a.FilePath,
                        FileType = a.FileType,
                        UploadedDate = DateTime.Now
                    }).ToList()
                };

                await _service.AddBlogPostAsync(newBlogPost);
                return Ok(newBlogPost);
            }
            else
            {
                return BadRequest("Geçersiz kullanıcı ID'si");
            }
        }
    }
}
