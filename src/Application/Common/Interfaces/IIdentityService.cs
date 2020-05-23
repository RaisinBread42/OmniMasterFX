using OmniMasterFX.Application.Common.Models;
using System.Threading.Tasks;

namespace OmniMasterFX.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string email, string phone, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
