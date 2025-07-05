using Application.Entities.Base;
using Application.Interface;
using Application.Interface.IServices;

namespace EcoGreen.Service
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GenerateJwtToken(User user, List<String> roles)
        {
            return _unitOfWork.TokenRepository.GenerateJwtToken(user, roles);
        }
    }
}
