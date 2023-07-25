namespace PetFindMeShop.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Product
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 250;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 5000;

            public const int ImageNameMaxLength = 4096;

            public const int QuantityMinValue = 0;
            public const int QuantityMaxValue = 10000;

            public const string OnSiteQuantityMinValue = "1";
            public const string OnSiteQuantityMaxValue = "100";

            public const string PriceMinValue = "0.01";
            public const string PriceMaxValue = "200000";
        }

        public static class Shop
        {
            public const int ShopNameMinLength = 2;
            public const int ShopNameMaxLength = 100;

            public const int ShopImageNameMaxLength = 4096;

            public const int ShopDescriptionMinLength = 10;
            public const int ShopDescriptionMaxLength = 3000;
        }

        public static class Order
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 500;

            public const int CityMinLength = 2;
            public const int CityMaxLength = 200;

            public const int AddressMinLength = 2;
            public const int AddressMaxLength = 450;

            public const int PhoneNumberLength = 10;
        }

        public static class Shopmanager
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 100;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 100;

            public const int PhoneNumberLength = 10;
        }
    }
}
