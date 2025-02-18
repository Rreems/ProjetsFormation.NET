using System.Linq.Expressions;
using System.Reflection;
using Exo01_.Data;
using Exo01_.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exo01_.Repository;


public class HamsterRepository : IRepository<Hamster, int>
{
    protected readonly AppDbContext _context;

    public HamsterRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Hamster> GetAll()
    {
        return _context.Hamsters;
    }

    public IEnumerable<Hamster> GetAll(Expression<Func<Hamster, bool>> predicate) => _context.Hamsters.Where(predicate);

    public Hamster? GetById(int id)
    {
        return _context.Hamsters.FirstOrDefault(x => x.Id == id);
    }

    public Hamster Add(Hamster entity)
    {
        _context.Hamsters.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Hamster? Update(Hamster entity)
    {
        var found = _context.Hamsters.FirstOrDefault(x => x.Id == entity.Id);

        if (found == null) return null;


        if (entity.FirstName != found.FirstName)
        {
            found.FirstName = entity.FirstName;
        }
        if (entity.LastName != found.LastName)
        {
            found.LastName = entity.LastName ;
        }
        if (entity.Gender != found.Gender)
        {
            found.Gender = entity.Gender ;
        }
        if (entity.BirthDate != found.BirthDate)
        {
            found.BirthDate = entity.BirthDate ;
        }
        if (entity.Number != found.Number)
        {
            found.Number = entity.Number ;
        }
        if (entity.Email != found.Email)
        {
            found.Email = entity.Email ;
        }

        _context.SaveChanges();
        return found;
    }

    public bool Delete(int id)
    {
        var found = _context.Hamsters.FirstOrDefault(x => x.Id == id);

        if (found == null) return false;

        _context.Hamsters.Remove(found);
        _context.SaveChanges();
        return true;
    }


    public bool Delete(Hamster entity)
    {
        var found = _context.Hamsters.FirstOrDefault(x => x.Id == entity.Id);

        if (found == null) return false;

        _context.Hamsters.Remove(found);
        _context.SaveChanges();
        return true;
    }

    Hamster? IRepository<Hamster, int>.Get(Expression<Func<HamsterRepository, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Hamster> IRepository<Hamster, int>.GetAll(Expression<Func<HamsterRepository, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}