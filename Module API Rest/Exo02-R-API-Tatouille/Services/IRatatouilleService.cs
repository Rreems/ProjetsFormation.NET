using Exo02_R_API_Tatouille.DTOs;
using Exo02_R_API_Tatouille.Models;

namespace Exo02_R_API_Tatouille.Services
{
    public interface IRatatouilleService
    {
        Task<IEnumerable<Ratatouille>> GetAll(string? Name, string? Description, decimal? Price, bool? IsVeggie, bool? IsSpicy, List<Ingredient>? Ingredients);
        Task<IEnumerable<Ratatouille>> GetAll();
        Task<Ratatouille?> GetById(string id);
        Task<RatatouilleDTO> Create(RatatouilleDTO RatatouilleDto);
        Task<RatatouilleDTO> AddTopping(RatatouilleDTO RatatouilleDto, Ingredient ingredient);
        Task<RatatouilleDTO> RemoveTopping(RatatouilleDTO RatatouilleDto, int ingredientId);
        Task<RatatouilleDTO> Update(string id, RatatouilleDTO RatatouilleDto);
        Task Delete(string id);
    }
}
