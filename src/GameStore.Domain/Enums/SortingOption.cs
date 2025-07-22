using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Enums
{
    public enum SortOption
    {
        [Description("Most popular")]
        MostPopular,

        [Description("Most commented")]
        MostCommented,

        [Description("Price ASC")]
        PriceAsc,

        [Description("Price DESC")]
        PriceDesc,

        [Description("New")]
        New
    }
}
