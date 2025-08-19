using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints.Games
{
    public static class PlatformValidationConstraints
    {
        public static class Limits
        {
            public const int Type = 50;
        }

        public static class Patterns
        {
            public const string Type = @"^[a-zA-Z][a-zA-Z0-9 ]*$";
        }

        public static class Messages
        {
            public const string PlatformIdRequired = "Platform ID is required.";
            public const string TypeRequired = "Platform type is required.";
            public static readonly string TypeLength = $"Platform type cannot exceed {Limits.Type} characters.";
            public const string TypeFormat = "Platform type must start with a letter and can only contain alphanumeric characters and spaces.";
        }
    }
}
