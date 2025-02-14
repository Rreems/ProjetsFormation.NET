
namespace Exo06.Services
{
    public class UploadPictureService : IUploadPictureService
    {
        private readonly IWebHostEnvironment _webHost;

        public UploadPictureService(IWebHostEnvironment webHostEnvironment)
        {
            _webHost = webHostEnvironment;
        }


        public string Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            //var pathToSave = $"{_webHost.WebRootPath}/pictures/${fileName}";  // PB -> le chemin écrit différement Linux/Windows/Mac...
            var pathToSave = Path.Combine(_webHost.WebRootPath , "pictures" ,fileName); // On crée le chemin en fonction de l'OS

            using var fileStream = new FileStream(pathToSave, FileMode.Create);
            file.CopyTo(fileStream);
            //fileStream.Close();  // On ferme un Stream ! Fait ici via le Using 

            return $"/pictures/{fileName}";
        }
    }
}
