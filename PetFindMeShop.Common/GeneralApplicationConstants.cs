namespace PetFindMeShop.Common
{
    public static class GeneralApplicationConstants
    {
        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 3;

        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Administrator";
        public const string DevelopmentAdminEmail = "admin@petfindmeshop.bg";

        public const string UsersCacheKey = "UsersCache";
        public const int UsersCacheDurationMinutes = 15;

        public const string CategoriesCacheKey = "CategoriesCache";
        public const int CategoriesCacheDurationMinutes = 60;
    }
}
