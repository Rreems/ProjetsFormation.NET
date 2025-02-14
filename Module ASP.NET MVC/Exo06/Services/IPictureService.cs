using Exo06.Entities;
using Exo06.Models;

namespace Exo06.Services;

public interface IPictureService
{
    public IEnumerable<PictureViewModel> GetAll();
    public PictureViewModel? Create(PictureCreateViewModel vm);
}
