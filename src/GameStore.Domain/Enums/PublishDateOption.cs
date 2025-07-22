using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Enums
{
    public enum PublishDateOption
    {
        [Description("last week")]
        LastWeek,

        [Description("last month")]
        LastMonth,

        [Description("last year")]
        LastYear,

        [Description("2 years")]
        TwoYears,

        [Description("3 years")]
        ThreeYears
    }
}
