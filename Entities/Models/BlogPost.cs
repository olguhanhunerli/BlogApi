using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Users Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int  CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Assets> Assets { get; set; }
    }
}
