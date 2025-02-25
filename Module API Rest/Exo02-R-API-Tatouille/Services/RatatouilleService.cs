using System.Linq;
using AutoMapper;
using Exo02_R_API_Tatouille.DTOs;
using Exo02_R_API_Tatouille.Helpers;
using Exo02_R_API_Tatouille.Models;
using Exo02_R_API_Tatouille.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Exo02_R_API_Tatouille.Services;

public class RatatouilleService : IRatatouilleService
{
    private readonly IRepository<Ratatouille, string> _ratatouilleRepository;
    private readonly IRepository<Ingredient, string> _ingredientRepository;
    private readonly IMapper _mapper;


    public RatatouilleService(IRepository<Ratatouille, string> ratatouilleRepository,
                          IRepository<Ingredient, string> ingredientRepository,
                          IMapper mapper,
                          IOptions<AppSettings> optionsAppSettings)
    {
        _ratatouilleRepository = ratatouilleRepository;
        _ingredientRepository = ingredientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Ratatouille>> GetAll(string? name, string? description, decimal? price, bool? isVeggie, bool? isSpicy, List<Ingredient>? ingredients)
    {
        try
        {

            //return _mapper.Map<IEnumerable<Ratatouille>>(
            return
            await _ratatouilleRepository.GetAll(c =>
                    (name.IsNullOrEmpty() || c.Name.Contains(name!)) &&
                    (description.IsNullOrEmpty() || c.Description.Contains(description!)) &&
                    (isVeggie == false || c.IsVeggie == (isVeggie!)) &&
                    (isSpicy == false || c.IsSpicy == (isSpicy!)) //&&
                                                                  //(ingredients.IsNullOrEmpty() || c.Ingredients!.Contains(ingredients!))

                )/*)*/ ;
        }
        catch (Exception e)
        {
            throw;
        }
    }
    public async Task<IEnumerable<Ratatouille>> GetAll()
    {
        try
        {
            //return _mapper.Map<IEnumerable <RatatouilleDTO>>(_ratatouilleRepository.GetAll());
            return await _ratatouilleRepository.GetAll();
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<Ratatouille?> GetById(string id)
    {
        return await _ratatouilleRepository.GetById(id);
    }


    public async Task<RatatouilleDTO> Create(RatatouilleDTO ratatouilleDto)
    {
        var ratatouille = _mapper.Map<Ratatouille>(ratatouilleDto);
        try
        {
            return _mapper.Map<RatatouilleDTO>(await _ratatouilleRepository.Add(ratatouille));
        }
        catch (Exception e)
        {
            // Ajout du Logging de l'erreur rencontrée
            Console.WriteLine($"Erreur d'ajout pour le contact nommé {ratatouilleDto.Name}: {e.Message}");
            Console.WriteLine(e.StackTrace);
            throw;
        }
    }

    public async Task<RatatouilleDTO> Update(string id, RatatouilleDTO RatatouilleDto)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<RatatouilleDTO> AddTopping(RatatouilleDTO RatatouilleDto, Ingredient ingredient)
    {
        throw new NotImplementedException();
    }

    public async Task<RatatouilleDTO> RemoveTopping(RatatouilleDTO RatatouilleDto, int ingredientId)
    {
        throw new NotImplementedException();
    }
}
