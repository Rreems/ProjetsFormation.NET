using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02RelationsRepository.Models
{
    internal class Tag
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Blog> Blogs { get; } = []; // utilisation des property-skip du Many to Many
        public List<BlogTag> BlogTags { get; } = [];
    }
}
