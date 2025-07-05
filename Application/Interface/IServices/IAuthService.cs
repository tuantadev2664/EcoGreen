using Application.Entities.DTOs.User;
using Application.Response;

namespace Application.Interface.IServices
{
    public interface IAuthService
    {
        Task<APIResponse> RegisterAsync(UserRegisterDTO model, string PhotoUrl);
        Task<APIResponse> LoginAsync(UserLoginDTO model);
    }
}
