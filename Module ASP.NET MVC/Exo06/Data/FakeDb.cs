using Exo06.Entities;
using Exo06.Models;

namespace Exo06.Data;

public class FakeDb
{
    public HashSet<Picture> Pictures { get; set; } = [
        new Picture{
            Title="Image1",
            PictureUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pemnet.com%2Feu%2Fwp-content%2Fuploads%2Fsites%2F10%2F2023%2F02%2FFEA-Stress-Analysis-1-scaled.jpg&f=1&nofb=1&ipt=62bad395903ff75d978511e33b685011f9e3ab6e55426c4338a5f3b90fca74e7&ipo=images"
        }

        ];


}
