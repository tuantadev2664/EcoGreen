using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Base;

namespace Application.Interface.IRepositories
{
    public interface ITokenRepository
    {
        string GenerateJwtToken(User user, List<String> roles);
    }
}
