using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Base;

namespace Application.Interface.IServices
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user, List<String> roles);
    }
}
