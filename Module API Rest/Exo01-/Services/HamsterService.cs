using System;
using Exo01_.Entities;
using Exo01_.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.Swagger.Annotations;

namespace Exo01_.Services;

public class HamsterService : IHamsterService
{
    private readonly IRepository<Hamster, int> _repository;


    public HamsterService(IRepository<Hamster, int> repository)
    {
        _repository = repository;
    }


    public Hamster Add(Hamster hamster)
    {
        try
        {
            return _repository.Add(hamster);
        }
          catch (Exception)
        {
            // Ajout de logging ici
            throw;
        }
    }

    public bool Delete(Hamster hamster)
    {
        return _repository.Delete(hamster);
    }

    IEnumerable<Hamster> IHamsterService.GetAll()
    {
        return _repository.GetAll();
    }


    //[SwaggerOperation(Summary = "Obtenir la liste des contacts",
    //          Description = "Récupère tous les contacts avec des filtres optionnels sur le prénom, le nom, le numéro de téléphone et l'email.")]
    [ProducesResponseType(typeof(IEnumerable<Hamster>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IEnumerable<Hamster> GetAll(string? firstName, string? lastName, string? numero, string? email)
    {
        return _repository.GetAll(c =>
            (string.IsNullOrEmpty(firstName) || c.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(lastName) || c.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(numero) || c.Number.Contains(numero)) &&
            (string.IsNullOrEmpty(email) || c.Email.Contains(email, StringComparison.OrdinalIgnoreCase)));
    }

    public Hamster? GetById(int id) =>  _repository.GetById(id);

    [HttpGet("name/{lastName}")]
    //[SwaggerOperation(Summary = "Obtenir un contact par nom",
    //                  Description = "Récupère un contact en fonction de son nom de famille.")]
    [ProducesResponseType(typeof(Hamster), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Hamster? GetByLastName(string lastName)
    {
        return _repository.GetAll().FirstOrDefault(h => h.LastName == lastName);
    }

    public Hamster? Update(int id, Hamster hamster)
    {
        Hamster hamsterFound = _repository.GetById(id);

        if (hamsterFound == null)
        {
            return null;
        }
        hamster.Id = hamsterFound.Id;

        return _repository.Update(hamster);
        
    }


}
