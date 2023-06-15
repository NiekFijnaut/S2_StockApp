using WebApp.Model;

namespace WebApp.Models
{
    public class FavoriteViewModel
    {
        public List<FavoriteModel> FavoriteModels { get; }

        public FavoriteViewModel()
        {

        }

        public FavoriteViewModel(List<FavoriteModel> favoriteModels)
        {
            FavoriteModels = favoriteModels;
        }
    }
}
