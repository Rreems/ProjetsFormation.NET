using System.ComponentModel.DataAnnotations;

namespace M2i.Demo.Upload.Models
{
    public class PictureViewModel
    {
        public long Id { get; init; }

        public required string Title { get; init; }

        public required string PictureUrl { get; init; }
    }

    // Si l'on veut créer des éléments non modifiables (immutables), on peut les créer sous forme de records depuis C# 6.0
    // TODO : (version à vérifier)
    public record PictureViewModelRecord (
            long Id,
            string Title,
            string PictureUrl
        )
    { }
}
