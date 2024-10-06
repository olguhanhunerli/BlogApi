using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class BlogPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public List<AssetsDto> Assets { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
