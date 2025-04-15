using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02RelationsRepository.Models
{
    internal class BlogHeader
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int BlogId { get; set; } // foreign key property (nullable ou non, comme pour Post -> Blog)
        public Blog Blog { get; set; } = null!; // navigation to principal
    }
}
