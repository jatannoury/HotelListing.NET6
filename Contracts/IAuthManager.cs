using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserModel userModel);
        Task<AuthResponseModel> Login(LoginModel loginModel);
        Task<AuthResponseModel> VerifyRefreshToken(AuthResponseModel request);
        Task<string> CreateRefreshToken();
    }
}
