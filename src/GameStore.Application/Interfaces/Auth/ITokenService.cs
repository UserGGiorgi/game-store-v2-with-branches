using GameStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Auth
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user, IEnumerable<string> roles);
    }
}
