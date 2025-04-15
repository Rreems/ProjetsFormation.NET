using System.Text.Json;
using Exercice.Movies.Data.Entities;
using Exercice.Movies.Data.Interfaces;
using Exercice.Movies.WebApp.Models;
using Exercice.Movies.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercice.Movies.WebApp.Controllers;

public class MovieController : Controller
{
    public const string COOKIE_NAME = "favorite_movies";

    private readonly IMovieService _service;

    private HashSet<Guid> _favorites = [];
    
    public MovieController(IMovieService service)
    {
        _service = service;
    }
    
    public IActionResult Index()
    {
        if (Request.Cookies.TryGetValue(COOKIE_NAME, out var json) && !String.IsNullOrEmpty(json))
        {
            _favorites = JsonSerializer.Deserialize<HashSet<Guid>>(json) ?? [];
        }
        var movies = _service.GetAll();
        var favMovies = movies.Where(m => _favorites.Any(mF => mF.Equals(m.Id)));
        foreach (var m in favMovies) m.IsFavorite = true;
        return View(movies);
    }
    
    public IActionResult Details(Guid id)
    {
        var movie = _service.GetEditableFormViewModelById(id);
        if (movie == null)
        {
            return View("Error", new ErrorViewModel() { StatusCode = 404, Text = "It seems the movie you're looking for is missing :/" });
        }
        
        ViewBag.FormMode = "Details";
        return View("Form", movie);
    }
    
    public IActionResult Create()
    {
        ViewBag.FormMode = "Create";
        return View("Form");
    }
    
    [HttpPost]
    public IActionResult Create(MovieCreateViewModel movie)
    {
        if (ModelState.IsValid)
        {
            _service.Add(movie);
            return RedirectToAction("Index");
        }
        
        ViewBag.FormMode = "Create";
        return View("Form", movie);
    }

    public IActionResult SwitchStatus(Guid id)
    {
        _service.SwitchStatus(id);
        return RedirectToAction("Index");
    }

    public IActionResult AddToFavorites(Guid id)
    {
        if (Request.Cookies.TryGetValue(COOKIE_NAME, out var json) && !String.IsNullOrEmpty(json))
        {
            _favorites = JsonSerializer.Deserialize<HashSet<Guid>>(json) ?? [];
        }
        _favorites.Add(id);
        var returnJson = JsonSerializer.Serialize<HashSet<Guid>>(_favorites);
        Response.Cookies.Append(COOKIE_NAME, returnJson);

        return RedirectToAction("Index");

    }

    public IActionResult RemoveFromFavorites(Guid id)
    {
        if (Request.Cookies.TryGetValue(COOKIE_NAME, out var json) && !String.IsNullOrEmpty(json))
        {
            _favorites = JsonSerializer.Deserialize<HashSet<Guid>>(json) ?? [];
        }
        _favorites.Remove(id);
        var returnJson = JsonSerializer.Serialize<HashSet<Guid>>(_favorites);
        Response.Cookies.Append(COOKIE_NAME, returnJson);

        return RedirectToAction("Index");

    }


    public IActionResult Edit(Guid id)
    {
        var movie = _service.GetEditableFormViewModelById(id);
        if (movie == null)
        {
            return View("Error", new ErrorViewModel() { StatusCode = 404, Text = "It seems the movie you're looking for is missing :/" });
        }
        
        ViewBag.FormMode = "Edit";
        return View("Form", movie);
    }
    
    [HttpPost]
    public IActionResult Edit(MovieEditDeleteViewModel movie)
    {
        if (ModelState.IsValid)
        {
            _service.Update(movie);
            return RedirectToAction("Index");
        }
        
        ViewBag.FormMode = "Edit";
        return View("Form", movie);
    }
    
    public IActionResult Delete(Guid id)
    {
        var movie = _service.GetEditableFormViewModelById(id);
        if (movie == null)
        {
            return View("Error", new ErrorViewModel() { StatusCode = 404, Text = "It seems the movie you're looking for is missing :/" });
        }
        
        ViewBag.FormMode = "Delete";
        return View("Form", movie);
    }
    
    [HttpPost]
    public IActionResult Delete(MovieEditDeleteViewModel movie)
    {
        _service.Delete(movie);
        return RedirectToAction("Index");
    }
}