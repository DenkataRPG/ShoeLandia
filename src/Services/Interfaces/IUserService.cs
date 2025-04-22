using Microsoft.AspNetCore.Identity;

namespace ShoeLandia.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(string email, string password);
    }
}
