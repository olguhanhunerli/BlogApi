using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Assets
    {
        public int AssetId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedDate { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
