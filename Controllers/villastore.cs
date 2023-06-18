using MagicVilla.Models.Dtos;

namespace MagicVilla.Controllers
{
    public static class villastore
    {
        public static List<VillasDtos> villalist = new List<VillasDtos>
        {
                new VillasDtos{Id=1, Name="Sea View" },
                new VillasDtos{Id=2, Name="Pool View"}

        };
    }
}
