namespace PetFindMeShop.ViewModels.Product
{
    public class LikedProductViewModel : ProductViewModel
    {
        public string Status { get; set; } = null!;

        public bool IsAvailable { get; set; }

        public bool IsLiked { get; set; }

        public bool IsDeleted { get; set; }
    }
}
