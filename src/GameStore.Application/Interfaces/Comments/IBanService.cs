using GameStore.Application.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Comments
{
    public interface IBanService
    {
        Task<IEnumerable<string>> GetBanDurationsAsync();
        Task BanUserAsync(BanUserDto banDto);
    }
}
