using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class ToDoRepository : IRepository<ToDo>
    {
        private readonly ApplicationDbContext _db;

        public ToDoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(ToDo entity)
        {
            _db.ToDos.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var a = _db.ToDos.Find(id);
            _db.ToDos.Remove(a);
            _db.SaveChanges();
            return true;    
        }

        public List<ToDo> GetAll()
        {
            return _db.ToDos.ToList();  
        }

        public ToDo GetById(int id)
        {
            return _db.ToDos.Find(id);            
        }

        public bool Update(ToDo toDo)
        {
            //_db.Update(toDo); // version moins optimisée du update => mets à jour tout l'objet
            //_db.SaveChanges();
            //return true;        

            var todoFromDb = GetById(toDo.Id);

            if (todoFromDb == null)
                return false;

            if (todoFromDb.Title != toDo.Title)
                todoFromDb.Title = toDo.Title;
            if (todoFromDb.Description != toDo.Description)
                todoFromDb.Description = toDo.Description;
            if (todoFromDb.Finished != toDo.Finished)
                todoFromDb.Finished = toDo.Finished;

            return _db.SaveChanges() > 0;
        }
    }
}
