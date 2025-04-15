using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo02RelationsRepository.Models;
using Demo02RelationsRepository.Repositories;

namespace Demo02RelationsRepository.UI
{
    internal class MainUI
    {
        private readonly IRepository<Blog, int> blogRepository;
        private readonly IRepository<Post, int> postRepository;

        public MainUI(IRepository<Blog, int> blogRepository, // un CRUD de blogs, peut importe comment il est fait derrière
                      IRepository<Post, int> postRepository)
        {
            this.blogRepository = blogRepository;
            this.postRepository = postRepository;
        }

        void DoSomething()
        {
            blogRepository.Add(new Blog()); // on ne sais pas COMMENT sera fait le Add
            blogRepository.GetAll();
            blogRepository.GetById(12);
        }
    }
}
