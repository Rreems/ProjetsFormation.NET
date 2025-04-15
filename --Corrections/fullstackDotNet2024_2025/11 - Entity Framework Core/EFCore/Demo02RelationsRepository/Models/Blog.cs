using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02RelationsRepository.Models
{
    internal class Blog
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Url { get; set; } = null!;

        // Propriétés de navigations
        // Many-to-One
        public List<Post> Posts { get; set; } = new List<Post>();

        // One-to-One
        public BlogHeader? Header { get; set; } // nullable car peut-être pas encore existant

        // Many-To-Many
        public List<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
        public List<Tag> Tags { get; set; } = new List<Tag>();  // utilisation des property-skip du Many to Many

    }
}
