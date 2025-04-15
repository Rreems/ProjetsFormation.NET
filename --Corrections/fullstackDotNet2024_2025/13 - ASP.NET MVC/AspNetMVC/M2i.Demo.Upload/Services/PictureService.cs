using M2i.Demo.Upload.Data;
using M2i.Demo.Upload.Entities;
using M2i.Demo.Upload.Models;

namespace M2i.Demo.Upload.Services
{
    public class PictureService : IPictureService
    {
        private readonly FakeDb _db;
        private readonly IUploadPictureService _uploadService;

        public PictureService(FakeDb db, IUploadPictureService uploadService)
        {
            _db = db;
            _uploadService = uploadService;
        }

        /*
         Cette méthode à trois étapes: 
            - On transforme le type envoyé par le contrôleur en quelque chose d'exploitable par la couche donnée
            - On demande l'exécution de la sauvegarde de l'élément par la couche donnée (idéalement un appel à la méthode du repository)
            - On retourne la sauvegarde effectuée par la couche donnée en quelque chose d'exploitable par le contrôleur
         
         */
        public PictureViewModel? Create(PictureCreateViewModel vm)
        {
            var entity = ToEntity(vm); // On transforme le ViewModel en Entity
            _db.Pictures.Add(entity); // On ajoutte l'entité à notre listing d'entités 
            // ATTENTION : On devrait avoir .SaveChanges() ici si on était dans une vraie BdD
            return ToViewModel(entity); // On retourne un ViewModel basé sur l'entité sauvegardé
        }

        /*
         Cette méthode à deux étapes: 
            - On récupère les données issues du listing depuis la couche données
            - On transforme ce listing en un type utilisable par la couche contrôleur
         
         */
        public IEnumerable<PictureViewModel> GetAll()
        {
            return _db.Pictures.Select(ToViewModel).ToHashSet();
        }

        private Picture ToEntity(PictureCreateViewModel vm)
        {
            return new Picture()
            {
                Id = _db.Pictures.Max(x => x.Id) + 1, // Cette ligne n'a pas lieu d'être si on utilise une vraie BdD
                Title = vm.Title,
                PictureUrl = _uploadService.Upload(vm.Picture) // Pour peupler la propriété, on demande la sauvegarde du fichier et on récupère l'emplacement retour que l'on place en valeur ici
            };
        } 

        private PictureViewModel ToViewModel(Picture picture)
        {
            return new PictureViewModel()
            {
                Title = picture.Title,
                PictureUrl = picture.PictureUrl
            };
        }
    }
}
