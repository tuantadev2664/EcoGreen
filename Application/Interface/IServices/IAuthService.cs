using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.DTOs.User;
using Application.Response;

namespace Application.Interface.IServices
{
    public interface IAuthService
    {
        Task<APIResponse> RegisterAsync(UserRegisterDTO model);
        Task<APIResponse> LoginAsync(UserLoginDTO model);
    }
}
