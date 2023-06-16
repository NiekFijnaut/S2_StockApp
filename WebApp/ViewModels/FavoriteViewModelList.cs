namespace WebApp.ViewModels
{
    public class FavoriteViewModelList
    {
        public List<FavoriteViewModel> FavoriteModels { get; }

        public FavoriteViewModelList()
        {

        }

        public FavoriteViewModelList(List<FavoriteViewModel> favoriteModels)
        {
            FavoriteModels = favoriteModels;
        }
    }
}
