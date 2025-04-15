namespace Exercice.Movies.WebApp.Services;

public class UploadPictureService : IUploadPictureService
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    
    public UploadPictureService(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    
    public string Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return null;
        }

        var directoryPath = Path.Combine(_hostingEnvironment.WebRootPath, "pictures");
        if (!Path.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        var fileName = Guid.NewGuid().ToString() + "-" + file.Name; // + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(directoryPath, fileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(fileStream);

        return "/pictures/" + fileName;
    }
}