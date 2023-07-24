namespace PetFindMeShop.Web.Infrastructure.Extensions
{
    using System.Security.Claims;

    using static Common.GeneralApplicationConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            //return user.FindFirstValue(ClaimTypes.NameIdentifier);
            throw new NotImplementedException();
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }
    }
}
