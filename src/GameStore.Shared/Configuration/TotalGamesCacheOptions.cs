using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.Configuration
{
    public class TotalGamesCacheOptions
    {
        public const string SectionName = "TotalGamesCacheOptions";
        public int CacheExpirationMinutes { get; set; } = 1;
    }
}
