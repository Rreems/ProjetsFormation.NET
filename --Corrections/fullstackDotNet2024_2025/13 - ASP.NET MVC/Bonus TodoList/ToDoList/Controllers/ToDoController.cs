using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    public class ToDoController : Controller
    {
       private readonly IRepository<ToDo> _repository;

        public ToDoController(IRepository<ToDo> repositoryToDoList)
        {
            _repository = repositoryToDoList;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Change(int id)
        {
            var todo = _repository.GetById(id);
            todo.Finished = !todo.Finished; // toggle
            _repository.Update(todo);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Submit(ToDo toDoList)
        {
            _repository.Create(toDoList);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
