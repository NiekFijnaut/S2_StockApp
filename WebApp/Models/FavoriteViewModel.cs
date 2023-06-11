using Business.Class;

namespace WebApp.Models
{
    public class FavoriteViewModel
    {
        public List<Favorite> Favorites { get; set; }

        public FavoriteViewModel() { }

        public FavoriteViewModel(List<Favorite> favorites)
        {
            Favorites = favorites;
        }
    }
}
