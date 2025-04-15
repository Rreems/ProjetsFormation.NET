using M2i.Demo.Upload.Models;

namespace M2i.Demo.Upload.Services
{
    public interface IPictureService
    {
        public IEnumerable<PictureViewModel> GetAll();
        public PictureViewModel? Create(PictureCreateViewModel vm);
    }
}
