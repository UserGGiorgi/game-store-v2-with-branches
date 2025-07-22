using GameStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            return value.GetType()
                       .GetMember(value.ToString())
                       .First()
                       .GetCustomAttribute<DescriptionAttribute>()?
                       .Description
                       ?? value.ToString();
        }
    }
}
