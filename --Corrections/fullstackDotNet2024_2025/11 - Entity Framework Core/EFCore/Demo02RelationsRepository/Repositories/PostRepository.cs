using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo02RelationsRepository.Data;
using Demo02RelationsRepository.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Demo02RelationsRepository.Repositories;

internal class PostRepository : IRepository<Post, int>
{
    private readonly AppDbContext _db;

    public PostRepository(AppDbContext db)
    {
        _db = db;
    }

    public Post? Add(Post post)
    {
        EntityEntry<Post> postEntity = _db.Add(post);
        _db.SaveChanges();

        return postEntity.Entity;
    }

    public Post? GetById(int id)
    {
        return _db.Posts
                    .FirstOrDefault(b => b.Id == id);
    }

    public Post? Get(Func<Post, bool> predicate)
    {
        return _db.Posts
                    .FirstOrDefault(predicate);
    }

    public IEnumerable<Post> GetAll()
    {
        return _db.Posts;
    }

    public IEnumerable<Post> GetAll(Func<Post, bool> predicate)
    {
        return _db.Posts.Where(predicate);
    }

    public Post? Update(int id, Post post)
    {
        var postFromDb = GetById(id);

        if (postFromDb is null)
            return null;


        if (postFromDb.Titre != post.Titre)
            postFromDb.Titre = post.Titre;
        if (postFromDb.Contenu != post.Contenu)
            postFromDb.Contenu= post.Contenu;
        if (postFromDb.DatePublication != post.DatePublication)
            postFromDb.DatePublication= post.DatePublication;
        if (postFromDb.BlogId != post.BlogId)
            postFromDb.BlogId= post.BlogId;

        _db.SaveChanges();
        return postFromDb;
    }

    public bool Delete(int id)
    {
        var post = GetById(id);

        if (post is null)
            return false;

        _db.Posts.Remove(post);

        return _db.SaveChanges() == 1;
    }
}
