using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Auth
{
    public interface IAccessService
    {
        Task<bool> CheckAccessAsync(string userEmail, string targetPage, string? targetId = null);
    }
}
