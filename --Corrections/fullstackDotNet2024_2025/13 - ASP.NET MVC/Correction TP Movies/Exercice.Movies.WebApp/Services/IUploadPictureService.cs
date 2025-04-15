namespace Exercice.Movies.WebApp.Services;

public interface IUploadPictureService
{
    public string Upload(IFormFile file);
}