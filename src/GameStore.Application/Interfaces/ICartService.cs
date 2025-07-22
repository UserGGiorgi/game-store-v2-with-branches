using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(string gameKey);
        Task RemoveFromCartAsync(string gameKey);
        void ClearCartCache(Guid userId);

    }
}
