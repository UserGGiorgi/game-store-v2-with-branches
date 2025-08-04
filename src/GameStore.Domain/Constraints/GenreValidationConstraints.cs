using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints
{
    public static class GenreValidationConstraints
    {
        public static class Limits
        {
            public const int Name = 50;
        }

        public static class Patterns
        {
            public const string Name = "^[a-zA-Z0-9 ]+$";
        }

        public static class Messages
        {
            public const string GenreIdRequired = "Genre ID is required.";
            public const string NameRequired = "Genre name is required.";
            public static readonly string NameLength = $"Genre name cannot exceed {Limits.Name} characters.";
            public const string NameFormat = "Genre name can only contain alphanumeric characters and spaces.";
            public const string ParentIdFormat = "ParentGenreId must be a valid GUID or empty";
        }
    }
}
