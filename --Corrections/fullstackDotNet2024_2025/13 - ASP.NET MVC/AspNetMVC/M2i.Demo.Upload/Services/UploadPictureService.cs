
namespace M2i.Demo.Upload.Services
{
    public class UploadPictureService : IUploadPictureService
    {
        private readonly IWebHostEnvironment _webHost;

        public UploadPictureService(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        public string Upload(IFormFile file)
        {
            // Si l'on a pas de fichier, ou que le fichier est vide, on se stoppe ici
            if (file == null || file.Length == 0) return null;

            // On génère un nom de fichier aléatoire de sorte à permettre les doublons (on conserve l'extension pour éviter les soucis)
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // var pathToSave = $"{_webHost.WebRootPath}\\pictures\\{fileName}"; PB car les chemins de fichiers ne sont pas les mêmes selon les OS
            var pathToSave = Path.Combine(_webHost.WebRootPath, "pictures", fileName); // On créé le chemin en utilisant les séparateurs de l'OS où tourne l'application, pour éviter les soucis d'en haut (C:\\....)

            /*
             
               Pour éviter d'oublier de fermer un flux, on peut utiliser le mot-clé 'using' de sorte à déclencher automatiquement .Dispose() / .Close() : 
             
                using (var fileStream = new FileStream(pathToSave, FileMode.Create)) 
                {
                    file.CopyTo(fileStream);
                }

             */

            // Ou sa syntaxe plus moderne, qui se base sur le principe des stacks se terminant en fin de fonction
            using var fileStream = new FileStream(pathToSave, FileMode.Create); // On va créer un flux de donnée dont l'emplacement final sera un fichier (qu'il convient donc de créer)
            file.CopyTo(fileStream); // On copie les données (le flux de bytes) du fichier reçu en paramètre vers celui en cours de création
            // fileStream.Close(); // On ferme le flux, on sauvegarde l'état actuel du fichier => Pas besoin de le spécifier, automatique car on utilise 'using'

            // On retourne un chemin possible d'être exploité par notre navigateur (il n'a pas accès aux fichiers stockés sur l'ordinateur des gens pour des raisons de sécurité telles que le lancement de scripts malveillants sur la machine des utilisateurs)
            return $"/pictures/{fileName}";
        }
    }
}
