using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo02RelationsRepository.Models
{
    //[PrimaryKey(nameof(BlogId),nameof(TagId))] // primary key composite avec les 2 clés étrangères
    internal class BlogTag
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public Blog Blog { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}
