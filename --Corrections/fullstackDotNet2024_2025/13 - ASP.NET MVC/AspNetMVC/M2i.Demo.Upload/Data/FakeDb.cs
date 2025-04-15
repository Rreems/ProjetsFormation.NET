using M2i.Demo.Upload.Entities;

namespace M2i.Demo.Upload.Data
{
    public class FakeDb
    {
        // On créé un HashSet qui va servir à contenir les informations des images
        public HashSet<Picture> Pictures { get; set; } = [
                new Picture {
                    Title = "Marmoset",
                    PictureUrl = "https://cdn.wcs.org/2022/05/25/3a8u9ew5cg_8dq15rk14x_FB_RODRIGO_COSTA_ARAU_JO_02304217_1_.jpg"
                }
            ];
    }
}
