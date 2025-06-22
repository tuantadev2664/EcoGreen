using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Base;
using Application.Interface;
using Application.Interface.IServices;
using InfrasStructure.Services;
using Microsoft.IdentityModel.Tokens;

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
